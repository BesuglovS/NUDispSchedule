using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace NUDispSchedule
{
    public partial class MainForm : Form
    {
        private Schedule _schedule;

        public MainForm()
        {
            InitializeComponent();

            SettingsCore.ReadSettings();
        }

        private void ApplySettings()
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

        private void MainFormLoad(object sender, EventArgs e)
        {
            SwitchInterFace(false);
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

                    var filteredGroups = schedule.studentGroups
                        .Where(sg => !sg.Name.Contains('I') && !sg.Name.Contains('-') && !sg.Name.Contains('+'))
                        .OrderBy(sg => sg.Name)
                        .ToList();

                    groupList.DataSource = filteredGroups;
                    groupList.DisplayMember = "Name";
                    groupList.ValueMember = "StudentGroupId";

                    datePicker.MinDate = schedule.calendars.Select(c => c.Date).Min();
                    datePicker.MaxDate = schedule.calendars.Select(c => c.Date).Max();

                    DatePickerValueChanged(null, null);

                    _schedule = schedule;
                    SwitchInterFace(true);
                    Text = Resources.MainFormScheduleTitle;

                    ApplySettings();

                },
                TaskScheduler.FromCurrentSynchronizationContext()
            );
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
            if (_schedule == null)
            {
                return;
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

            SettingsCore.SaveSettings();
        }

        private void AboutButtonClick(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }
}
