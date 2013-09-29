using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using NUDispSchedule.Core;
using NUDispSchedule.Main;

namespace NUDispSchedule.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly Schedule _schedule;

        public SettingsForm(Schedule schedule)
        {
            InitializeComponent();

            _schedule = schedule;
        }

        private void SettingsFormLoad(object sender, EventArgs e)
        {
            if (_schedule == null)
            {
                return;
            }

            var filteredGroups = _schedule.studentGroups
                        .Where(sg => !sg.Name.Contains('I') && !sg.Name.Contains('-') && !sg.Name.Contains('+'))
                        .OrderBy(sg => sg.Name)
                        .ToList();
            groupList.DataSource = filteredGroups;
            groupList.DisplayMember = "Name";
            groupList.ValueMember = "StudentGroupId";

            DisplaySettings();
        }

        private void DisplaySettings()
        {
            if (SettingsCore.Data == null)
            {
                SettingsCore.SetDefaultData();
                
                saveGroupOnExit.Checked = true;
                saveDateYes.Checked = true;

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

            if (SettingsCore.Data.ContainsKey("saveDate"))
            {
                var savedDate = SettingsCore.Data["saveDate"];
                
                if (savedDate == "1")
                {
                    saveDateYes.Checked = true;
                }
                else
                {
                    saveDateNo.Checked = true;
                }
            }
        }

        private void SettingsFormFormClosed(object sender, FormClosedEventArgs e)
        {
            if (SettingsCore.Data["saveGroup"] == "Set Exact")
            {
                SettingsCore.AddOrUpdateSetting("savedGroup", groupList.Text);
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

        private void SaveDateYesCheckedChanged(object sender, EventArgs e)
        {
            if (saveDateYes.Checked)
            {
                SettingsCore.Data["saveDate"] = "1";
            }
        }

        private void SaveDateNoCheckedChanged(object sender, EventArgs e)
        {
            if (saveDateNo.Checked)
            {
                SettingsCore.Data["saveDate"] = "0";
            }
        }
    }
}
