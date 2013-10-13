using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using NUDispSchedule.Core;
using NUDispSchedule.Main;
using System.Reflection;
using System.IO;

namespace NUDispSchedule.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly Schedule _schedule;
        readonly Form _antecedent;

        readonly string _autoStart;

        private readonly Dictionary<string, string> _updateIntervalDictionary = 
            new Dictionary<string, string> { 
                {"10 минут", "10"},
                {"30 минут", "30"},
                {"1 час", "60"},
                {"3 часа", "180"},
                {"6 часов", "360"}
        };

        public SettingsForm(Form antecedent, Schedule schedule)
        {
            InitializeComponent();

            Icon = Properties.Resources.settings1;

            updateInterval.Items.AddRange(_updateIntervalDictionary.Keys.ToArray());

            _schedule = schedule;
            _antecedent = antecedent;
            _autoStart = SettingsCore.Data["autoStart"];
        }

        private void SettingsFormLoad(object sender, EventArgs e)
        {
            if (_antecedent.WindowState == FormWindowState.Minimized)
            {
                Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2;
                Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2;
            }
            
            if (_schedule == null)
            {
                return;
            }

            FillWindowLists();

            DisplaySettings();
        }

        private void FillWindowLists()
        {
            var filteredGroups = _schedule.studentGroups
                .Where(sg => !sg.Name.Contains('I') && !sg.Name.Contains('-') && !sg.Name.Contains('+'))
                .OrderBy(sg => sg.Name)
                .ToList();

            groupList.DataSource = filteredGroups;
            groupList.DisplayMember = "Name";
            groupList.ValueMember = "StudentGroupId";

            groupList2.DataSource = filteredGroups;
            groupList2.DisplayMember = "Name";
            groupList2.ValueMember = "StudentGroupId";

            var studList = _schedule.students.Where(s => !s.Expelled).OrderBy(s => s.FIO).ToList();

            studentList.DataSource = studList;
            studentList.DisplayMember = "FIO";
            studentList.ValueMember = "StudentId";
        }

        private void DisplaySettings()
        {
            if (SettingsCore.Data == null)
            {
                SettingsCore.SetDefaultData();

                DisplaySettings();

                return;
            }

            if (SettingsCore.Data.ContainsKey("saveGroup"))
            {
                var saveGroup = SettingsCore.Data["saveGroup"];
                switch (saveGroup)
                {
                    case "Save":
                        saveGroupOnExit.Checked = true;
                        break;
                    case "Don't Save":
                        dontSave.Checked = true;
                        break;
                    case "Set Exact":
                        setThisGroupOnStartup.Checked = true;

                        var groups = (List<StudentGroup>) groupList.DataSource;
                        if (SettingsCore.Data.ContainsKey("savedGroup"))
                        {
                            var group = groups.FirstOrDefault(g => g.Name == SettingsCore.Data["savedGroup"]);
                            var index = groups.IndexOf(group);
                            groupList.SelectedIndex = index;
                        }
                        break;
                }
            }

            if (SettingsCore.Data.ContainsKey("showNotifications"))
            {
                var showNotifications = SettingsCore.Data["showNotifications"];
                switch (showNotifications)
                {
                    case "ForSavedGroup":
                        showForSavedGroup.Checked = true;
                        break;
                    case "ForChoosenGroup":
                        showForChoosenGroup.Checked = true;

                        var groups = (List<StudentGroup>) groupList.DataSource;
                        if (SettingsCore.Data.ContainsKey("notificationId"))
                        {
                            int groupId;
                            int.TryParse(SettingsCore.Data["notificationId"], out groupId);
                            var group = groups.FirstOrDefault(g => g.StudentGroupId == groupId);
                            var index = groups.IndexOf(group);
                            groupList.SelectedIndex = index;
                        }
                        break;
                    case "ForChoosenStudent":
                        showForChoosenStudent.Checked = true;

                        var students = (List<Student>)studentList.DataSource;
                        if (SettingsCore.Data.ContainsKey("notificationId"))
                        {
                            int studentId;
                            int.TryParse(SettingsCore.Data["notificationId"], out studentId);
                            var student = students.FirstOrDefault(s => s.StudentId == studentId);
                            var index = students.IndexOf(student);
                            studentList.SelectedIndex = index;
                        }
                        break;
                    case "DontShow":
                        dontShow.Checked = true;
                        break;
                }
            }

            if (SettingsCore.Data.ContainsKey("saveDate"))
            {
                var savedDate = SettingsCore.Data["saveDate"];

                saveDateOnExit.Checked = savedDate == "1";
            }

            if (SettingsCore.Data.ContainsKey("saveScheduleLocally"))
            {
                saveScheduleDataLocally.Checked = SettingsCore.Data["saveScheduleLocally"] == "1";
            }

            if (SettingsCore.Data.ContainsKey("updateSchedule"))
            {
                updateFromSite.Checked = SettingsCore.Data["updateSchedule"] == "1";

            }

            if (SettingsCore.Data.ContainsKey("updateInterval"))
            {
                updateInterval.Text = _updateIntervalDictionary
                    .FirstOrDefault(kvp => kvp.Value == SettingsCore.Data["updateInterval"].ToString(CultureInfo.InvariantCulture))
                    .Key;                    
            }

            if (SettingsCore.Data.ContainsKey("minimizeOnClose"))
            {
                MinimizeOnClose.Checked = SettingsCore.Data["minimizeOnClose"] == "1";
            }

            if (SettingsCore.Data.ContainsKey("autoStart"))
            {
                AutoStart.Checked = SettingsCore.Data["autoStart"] == "1";
            }
        }

        private void SettingsFormFormClosed(object sender, FormClosedEventArgs e)
        {
            if (SettingsCore.Data["updateSchedule"] == "1")
            {
                SettingsCore.AddOrUpdateSetting("updateInterval", _updateIntervalDictionary[updateInterval.Text]);
            }
            if (SettingsCore.Data["saveGroup"] == "Set Exact")
            {
                SettingsCore.AddOrUpdateSetting("savedGroup", groupList.Text);
            }

            if ((_autoStart == "0") && (SettingsCore.Data["autoStart"] == "1"))
            {
                var startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                var lnkName = startupFolder + "\\Расписание СГОАН.lnk";
                if (!File.Exists(lnkName))
                {
                    Utilities.CreateShortcut("Расписание СГОАН", startupFolder, Assembly.GetExecutingAssembly().Location, "");
                }
            }

            if ((_autoStart == "1") && (SettingsCore.Data["autoStart"] == "0"))
            {
                var lnkName = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\Расписание СГОАН.lnk";
                if (File.Exists(lnkName))
                {
                    File.Delete(lnkName);
                }
            }

            if ((SettingsCore.Data["showNotifications"] == "ForChoosenGroup") && (groupList2.SelectedValue != null))
            {
                SettingsCore.AddOrUpdateSetting(
                    "notificationId", 
                    ((int)groupList2.SelectedValue).ToString(CultureInfo.InvariantCulture)
                );
            }
            if ((SettingsCore.Data["showNotifications"] == "ForChoosenStudent") && (studentList.SelectedValue != null))
            {
                SettingsCore.AddOrUpdateSetting(
                    "notificationId",
                    ((int)studentList.SelectedValue).ToString(CultureInfo.InvariantCulture)
                );
            }

            SettingsCore.SaveSettings();
        }

        private void SaveGroupOnExitCheckedChanged(object sender, EventArgs e)
        {
            if (saveGroupOnExit.Checked)
            {
                SettingsCore.Data["saveGroup"] = "Save";
            }
        }

        private void SetThisGroupOnStartupCheckedChanged(object sender, EventArgs e)
        {
            if (setThisGroupOnStartup.Checked)
            {
                SettingsCore.Data["saveGroup"] = "Set Exact";                
            }
        }

        private void DontSaveCheckedChanged(object sender, EventArgs e)
        {
            if (dontSave.Checked)
            {
                SettingsCore.Data["saveGroup"] = "Don't Save";
            }
        }

        private void SaveDateOnExitCheckedChanged(object sender, EventArgs e)
        {
            SettingsCore.Data["saveDate"] = (saveDateOnExit.Checked) ? "1" : "0";
        }

        private void SaveScheduleDataLocallyCheckedChanged(object sender, EventArgs e)
        {
            SettingsCore.Data["saveScheduleLocally"] = (saveScheduleDataLocally.Checked) ? "1" : "0";
        }

        private void UpdateFromSiteCheckedChanged(object sender, EventArgs e)
        {
            SettingsCore.Data["updateSchedule"] = (updateFromSite.Checked) ? "1" : "0";
        }

        private void MinimizeOnCloseCheckedChanged(object sender, EventArgs e)
        {
            SettingsCore.Data["minimizeOnClose"] = (MinimizeOnClose.Checked) ? "1" : "0";
        }

        private void AutoStartCheckedChanged(object sender, EventArgs e)
        {
            SettingsCore.Data["autoStart"] = (AutoStart.Checked) ? "1" : "0";
        }

        private void ShowForSavedGroupCheckedChanged(object sender, EventArgs e)
        {
            if (showForSavedGroup.Checked)
            {
                SettingsCore.Data["showNotifications"] = "ForSavedGroup";
            }
        }

        private void ShowForChoosenGroupCheckedChanged(object sender, EventArgs e)
        {
            if (showForChoosenGroup.Checked)
            {
                SettingsCore.Data["showNotifications"] = "ForChoosenGroup";
            }
        }

        private void ShowForChoosenStudentCheckedChanged(object sender, EventArgs e)
        {
            if (showForChoosenStudent.Checked)
            {
                SettingsCore.Data["showNotifications"] = "ForChoosenStudent";
            }
        }

        private void DontShowCheckedChanged(object sender, EventArgs e)
        {
            if (dontShow.Checked)
            {
                SettingsCore.Data["showNotifications"] = "DontShow";
            }
        }
    }
}
