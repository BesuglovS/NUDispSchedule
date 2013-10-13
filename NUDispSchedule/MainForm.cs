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

        private void MainFormLoad(object sender, EventArgs e)
        {
            Icon = Resources.NULogo2;

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

            string[] args = Environment.GetCommandLineArgs();
            if (args.Contains("-Startup"))
            {
                MinimizeToTray();
            }
        }

        private void LoadScheduleOnSettings()
        {
            if (SettingsCore.Data.ContainsKey("saveScheduleLocally"))
            {
                var baseExePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);

                if ((SettingsCore.Data["saveScheduleLocally"] == "1") && File.Exists(baseExePath + "\\schedule.txt"))
                {
                    Schedule schedule = null;
                    
                    var splashForm = new SplashScreen();
                    
                    var loadTask = Task.Factory.StartNew(() => { schedule = Schedule.LoadScheduleFromFile(); });

                    
                    loadTask.ContinueWith(
                        antecedent => splashForm.Close(),
                        TaskScheduler.FromCurrentSynchronizationContext()
                    );

                    string[] args = Environment.GetCommandLineArgs();
                    if (!args.Contains("-Startup"))
                    {
                        splashForm.ShowDialog();
                    }                    

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
                    int interval;
                    int.TryParse(SettingsCore.Data["updateInterval"], out interval);
                    updateScheduleTimer.Interval = interval * 60 * 1000;
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
            updateSchedule.Enabled = false;
            updateSchedule.Image = Resources.update24sepia;            
            refreshButtonTooltip.Active = false;
            обновитьРасписниеToolStripMenuItem.Enabled = false;
            обновитьРасписниеToolStripMenuItem.Text = "Идёт обновление ...";
            обновитьРасписниеToolStripMenuItem.Image = Resources.update24sepia;

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

                    ChackForAndDisplayUpdateCount();

                    updateSchedule.Enabled = true;
                    updateSchedule.Image = Resources.update24;
                    refreshButtonTooltip.Active = true;
                    refreshButtonTooltip.SetToolTip(updateSchedule, "Обновить расписание");
                    обновитьРасписниеToolStripMenuItem.Enabled = true;
                    обновитьРасписниеToolStripMenuItem.Text = "Обновить расписание";
                    обновитьРасписниеToolStripMenuItem.Image = Resources.update24;
                    
                },
                _uiScheduler
            );
        }

        private void ChackForAndDisplayUpdateCount()
        {
            if (SettingsCore.Data.ContainsKey("showNotifications") &&
                (SettingsCore.Data["showNotifications"] == "DontShow"))
            {
                return;
            }

            if (SettingsCore.Data.ContainsKey("LastDisplayedEventId"))
            {
                int lastDisplayedId;
                int.TryParse(SettingsCore.Data["LastDisplayedEventId"], out lastDisplayedId);

                var updateEvents = new List<LessonLogEvent>();

                if (SettingsCore.Data.ContainsKey("showNotifications"))
                {
                    StudentGroup group;
                    switch (SettingsCore.Data["showNotifications"])
                    {
                        case "ForSavedGroup":
                            group = _schedule.studentGroups
                                .FirstOrDefault(g => g.Name == SettingsCore.Data["savedGroup"]);
                            if (group != null)
                            {
                                updateEvents = _schedule.lessonLogEvents
                                    .Where(e => ((e.LessonLogEventId > lastDisplayedId) &&
                                                 ((e.OldLesson != null && 
                                                  e.OldLesson.TeacherForDiscipline.Discipline.StudentGroup.
                                                      StudentGroupId == group.StudentGroupId) ||
                                                  (e.NewLesson != null && 
                                                  e.NewLesson.TeacherForDiscipline.Discipline.StudentGroup.
                                                      StudentGroupId == group.StudentGroupId))))
                                    .ToList();
                            }
                            break;
                        case "ForChoosenGroup":
                            if (SettingsCore.Data.ContainsKey("notificationId"))
                            {
                                group = _schedule.studentGroups
                                    .FirstOrDefault(g =>
                                                    g.StudentGroupId.ToString(CultureInfo.InvariantCulture) ==
                                                    SettingsCore.Data["notificationId"]);
                                if (group != null)
                                {
                                    updateEvents = _schedule.lessonLogEvents
                                        .Where(e => ((e.LessonLogEventId > lastDisplayedId) &&
                                                     ((e.OldLesson != null && 
                                                      e.OldLesson.TeacherForDiscipline.Discipline.StudentGroup.
                                                          StudentGroupId == group.StudentGroupId) ||
                                                      (e.NewLesson != null &&
                                                      e.NewLesson.TeacherForDiscipline.Discipline.StudentGroup.
                                                          StudentGroupId == group.StudentGroupId))))
                                        .ToList();

                                }
                            }
                            break;
                        case "ForChoosenStudent":
                            if (SettingsCore.Data.ContainsKey("notificationId"))
                            {
                                var student = _schedule.students
                                    .FirstOrDefault(s =>
                                                    s.StudentId.ToString(CultureInfo.InvariantCulture) ==
                                                    SettingsCore.Data["notificationId"]);
                                if (student != null)
                                {
                                    var groupIdList = _schedule.studentsInGroups
                                        .Where(sig => sig.Student.StudentId.ToString(CultureInfo.InvariantCulture) ==
                                                      SettingsCore.Data["notificationId"])
                                        .Select(sig => sig.StudentGroup.StudentGroupId)
                                        .ToList();

                                    updateEvents = _schedule.lessonLogEvents
                                        .Where(e => ((e.LessonLogEventId > lastDisplayedId) &&
                                                     ((e.OldLesson != null &&
                                                        groupIdList.Contains(
                                                            e.OldLesson.TeacherForDiscipline.Discipline.
                                                                StudentGroup.StudentGroupId)) ||
                                                      (e.NewLesson != null &&
                                                        groupIdList.Contains(
                                                            e.NewLesson.TeacherForDiscipline.Discipline.
                                                                StudentGroup.StudentGroupId)))))
                                        .ToList();

                                }
                            }
                            break;
                            
                    }
                }
                
                if (updateEvents.Count != 0)
                {
                    trayIcon.Visible = true;
                    trayIcon.Tag = "ChangesCount";
                    trayIcon.ShowBalloonTip(
                        1000,
                        Resources.MainForm_MinimizeToTray_ToolTipTitle,
                        Resources.MainForm_ChackForAndDisplayUpdateCount_ChangesCount_ToolTipText + 
                        updateEvents.Count,
                        ToolTipIcon.Info
                        );
                }
            }
        }

        private void SetGroupListAndDatePicker(Schedule schedule)
        {
            var groupName = groupList.Text;

            var filteredGroups = schedule.studentGroups
                .Where(sg => !sg.Name.Contains('I') && !sg.Name.Contains('-') && !sg.Name.Contains('+'))
                .OrderBy(sg => sg.Name)
                .ToList();

            groupList.DisplayMember = "Name";
            groupList.ValueMember = "StudentGroupId";
            groupList.DataSource = filteredGroups;

            groupList.Text = groupName;            

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
            changes.Enabled = enable;
            teacherSchedule.Enabled = enable;
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
            if (WindowState == FormWindowState.Minimized)
            {
                MinimizeToTray();
            }
        }

        private void MinimizeToTray()
        {
            WindowState = FormWindowState.Minimized;
            trayIcon.Tag = "StillHere";
            trayIcon.Visible = true;
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            trayIcon.BalloonTipTitle = Resources.MainForm_MinimizeToTray_ToolTipTitle;
            trayIcon.BalloonTipText = Resources.MainForm_MinimizeToTray_ToolTipText_KeepRunning;
            trayIcon.ShowBalloonTip(100);
            ShowInTaskbar = false;            
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
            var settingsForm = new SettingsForm(this, _schedule);
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
            OnApplicationExit();
        }

        private void OnApplicationExit()
        {
            trayIcon.Visible = false;

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
                
                var maxEventId = _schedule.lessonLogEvents.Select(lle => lle.LessonLogEventId).Max();
                SettingsCore.AddOrUpdateSetting("LastDisplayedEventId", maxEventId.ToString(CultureInfo.InvariantCulture));
            }

            SettingsCore.SaveSettings();
        }

        private void AboutButtonClick(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm(this);
            aboutForm.ShowDialog(this);
        }

        private void UpdateScheduleTimerTick(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        private void ChangesClick(object sender, EventArgs e)
        {
            var changesForm = new Changes(this, _schedule, (int)groupList.SelectedValue);
            changesForm.ShowDialog();
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (SettingsCore.Data.ContainsKey("minimizeOnClose") && SettingsCore.Data["minimizeOnClose"] == "1")
            {
                e.Cancel = true;
                MinimizeToTray();
            }
        }

        private void TrayIconDoubleClick(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void ВыходToolStripMenuItemClick(object sender, EventArgs e)
        {
            OnApplicationExit();
            Application.Exit();
        }

        private void TrayIconBalloonTipClicked(object sender, EventArgs e)
        {
            if ((trayIcon.Tag.ToString() == "ChangesCount") &&
                (SettingsCore.Data.ContainsKey("showNotifications") &&
                 SettingsCore.Data["showNotifications"] == "ForChoosenGroup") &&
                SettingsCore.Data.ContainsKey("notificationId"))
            {
                int groupId;
                int.TryParse(SettingsCore.Data["notificationId"], out groupId);
                var changesForm = new Changes(this, _schedule, groupId);
                changesForm.ShowDialog();
            }
        }

        private void UpdateScheduleClick(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        private void ОбновитьРасписниеToolStripMenuItemClick(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        private void ScheduleViewSelectionChanged(object sender, EventArgs e)
        {
            scheduleView.ClearSelection();
        }

        private void TeacherScheduleClick(object sender, EventArgs e)
        {
            var teacherScheduleForm = new TeacherSchedule(this, _schedule);
            teacherScheduleForm.ShowDialog();
        }

        private void ИзмененияToolStripMenuItemClick(object sender, EventArgs e)
        {
            var changesForm = new Changes(this, _schedule, (int)groupList.SelectedValue);
            changesForm.ShowDialog();
        }

        private void РасписаниеПреподавателяToolStripMenuItemClick(object sender, EventArgs e)
        {
            var teacherScheduleForm = new TeacherSchedule(this, _schedule);
            teacherScheduleForm.ShowDialog();
        }
    }
}
