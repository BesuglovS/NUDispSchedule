using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NUDispSchedule.Core;
using NUDispSchedule.Forms;
using NUDispSchedule.Main;
using NUDispSchedule.Properties;
using NUDispSchedule.Views;
using NUDispSchedule.wnu;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace NUDispSchedule
{
    public partial class MainForm : Form
    {
        private Schedule _schedule;

        private TaskScheduler _uiScheduler;

        public MainForm()
        {   
            InitializeComponent();
        }

        private void LoadScheduleOnSettings()
        {
            if (SettingsCore.Data.ContainsKey("saveScheduleLocally"))
            {
                if ((SettingsCore.Data["saveScheduleLocally"] == "1") && File.Exists("schedule.txt"))
                {
                    Schedule schedule = null;
                    
                    var splashForm = new SplashScreen();
                    
                    var loadTask = Task.Factory.StartNew(() => { schedule = Schedule.LoadScheduleFromFile(); });

                    
                    loadTask.ContinueWith(
                        antecedent => splashForm.Close(),
                        TaskScheduler.FromCurrentSynchronizationContext()
                    );
                    
                    splashForm.ShowDialog();

                    loadTask.Wait();
                    

                    if (schedule != null)
                    {
                        if (_schedule != null)
                        {
                            lock (_schedule)
                            {
                                _schedule = schedule;
                            }
                        }
                        else
                        {
                            _schedule = schedule;
                        }

                        SwitchInterFace(true);
                    }
                }
            }
        }

        private void ApplySettings()
        {
            if (SettingsCore.Data.ContainsKey("saveDate"))
            {
                if (SettingsCore.Data["saveDate"] == "1")
                {
                    if (SettingsCore.Data.ContainsKey("savedDate"))
                    {
                        var date = SettingsCore.Data["savedDate"];

                        int d, m, y;
                        int.TryParse(date.Split('.')[0], out d);
                        int.TryParse(date.Split('.')[1], out m);
                        int.TryParse(date.Split('.')[2], out y);

                        datePicker.Value = new DateTime(y, m, d);
                    }
                }
            }

            if (SettingsCore.Data.ContainsKey("saveGroup"))
            {
                if ((SettingsCore.Data["saveGroup"] == "Save") || (SettingsCore.Data["saveGroup"] == "Set Exact"))
                {
                    var groups = (List<StudentGroup>)groupList.DataSource;
                    if (SettingsCore.Data.ContainsKey("savedGroup"))
                    {
                        var group = groups.FirstOrDefault(g => g.Name == SettingsCore.Data["savedGroup"]);
                        var index = groups.IndexOf(group);
                        groupList.SelectedIndex = index;
                    }
                }
            }            
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            SwitchInterFace(false);

            SettingsCore.ReadSettings();

            LoadScheduleOnSettings();

            if (_schedule != null)
            {
                SetGroupListAndDatePicker(_schedule);
                ApplySettings();
            }

            StartUploadCycle(true);
        }

        private void StartUploadCycle(bool syncNOW = false)
        {
            if (SettingsCore.Data["updateSchedule"] == "1")
            {
                if (syncNOW)
                {
                    LoadSchedule();
                }

                if (SettingsCore.Data.ContainsKey("updateInterval"))
                {
                    updateScheduleTimer.Interval = int.Parse(SettingsCore.Data["updateInterval"]) * 60 * 1000;
                }
                else
                {
                    updateScheduleTimer.Interval = 30*60*1000;
                }

                updateScheduleTimer.Enabled = true;
            }
        }

        private void LoadSchedule()
        {
            Text = Resources.MainFormScheduleLoadingTitle;

            if (!IsConnectedToInternet())
            {
                Text = Resources.MainFormNoInternetTitle;
                return;
            }

            var request = new WNURequest(new Dictionary<string, string> 
                { 
                  { "action", "bundle" }
                }
            );

            var siteLoadTask = Task.Factory.StartNew(arg =>
                {
                    var req = (WNURequest)arg;
                    return WNU.PostRequest("http://wiki.nayanova.edu/api.php", req.ToJSON());
                },
                request
            );

            var deserializeAndConvertTask = siteLoadTask.ContinueWith(antecedent =>
                {
                    var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer { MaxJsonLength = 10000000 };
                    var deserializedWebSchedule = jsonSerializer.Deserialize<WebSchedule>(antecedent.Result);
                    var schedule = Schedule.FromWebSchedule(deserializedWebSchedule);
                    return schedule;
                }
            );

            deserializeAndConvertTask.ContinueWith(antecedent =>
                {   
                    var schedule = antecedent.Result;

                    SetGroupListAndDatePicker(schedule);
                    
                    if (_schedule != null)
                    {
                        lock (_schedule)
                        {
                            _schedule = schedule;
                        }
                    }
                    else
                    {
                        _schedule = schedule;
                    }

                    SwitchInterFace(true);

                    Text = Resources.MainFormScheduleTitle;
                    
                    DatePickerValueChanged(null, null);
                },
                _uiScheduler
            );
        }

        private void SetGroupListAndDatePicker(Schedule schedule)
        {
            var filteredGroups = schedule.studentGroups
                .Where(sg => !sg.Name.Contains('I') && !sg.Name.Contains('-') && !sg.Name.Contains('+'))
                .OrderBy(sg => sg.Name)
                .ToList();

            groupList.DisplayMember = "Name";
            groupList.ValueMember = "StudentGroupId";
            groupList.DataSource = filteredGroups;
            

            datePicker.MinDate = schedule.calendars.Select(c => c.Date).Min();
            datePicker.MaxDate = schedule.calendars.Select(c => c.Date).Max();
        }

        private void SwitchInterFace(bool enable)
        {
            groupList.Enabled = enable;
            datePicker.Enabled = enable;
            today.Enabled = enable;
            tomorrow.Enabled = enable;
            settingsButton.Enabled = enable;
        }

        private void DatePickerValueChanged(object sender, EventArgs e)
        {
            UpdateDailySchedule();
        }

        private void UpdateDailySchedule()
        {
            if ((_schedule == null) || (groupList.Items.Count == 0))
            {
                return;
            }
            if (groupList.SelectedValue == null)
            {
                groupList.SelectedIndex = 0;
            }
            var lList = Utilities.GetDailySchedule(_schedule, (int) groupList.SelectedValue, datePicker.Value);
            var viewList = DailyScheduleGroupLessonView.FromLessonsList(lList, (int) groupList.SelectedValue);
            scheduleView.DataSource = viewList;
            FormatMainView.DailyScheduleView(scheduleView, this);
        }

        private void MainFormResize(object sender, EventArgs e)
        {
            FormatMainView.DailyScheduleView(scheduleView, this);
        }

        private void TodayClick(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Now.Date;
        }

        private void TomorrowClick(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Now.AddDays(1).Date;
        }

        private void GroupListSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDailySchedule();
        }

        private void SettingsClick(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(_schedule);
            settingsForm.ShowDialog();
            if (SettingsCore.Data["updateSchedule"] == "1")
            {
                StartUploadCycle();
            }
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);

        public static bool IsConnectedToInternet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        private void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            if (SettingsCore.Data["saveDate"] == "1")
            {
                SettingsCore.AddOrUpdateSetting("savedDate", datePicker.Value.ToString("dd.MM.yyyy"));
            }

            if (SettingsCore.Data["saveGroup"] == "Save")
            {
                SettingsCore.AddOrUpdateSetting("savedGroup", groupList.Text);
            }

            if ((SettingsCore.Data["saveScheduleLocally"] == "1") && (_schedule != null))
            {
                _schedule.SaveScheduleToFile();                
            }

            SettingsCore.SaveSettings();
        }

        private void AboutButtonClick(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void UpdateScheduleTimerTick(object sender, EventArgs e)
        {
            LoadSchedule();
        }
    }
}
