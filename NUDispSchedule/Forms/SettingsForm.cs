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

        private Dictionary<string, string> updateIntervalDictionary = new Dictionary<string, string> { 
            {"10 минут", "10"},
            {"30 минут", "30"},
            {"1 час", "60"},
            {"3 часа", "180"},
            {"6 часов", "360"}
        };

        public SettingsForm(Schedule schedule)
        {
            InitializeComponent();

            updateInterval.Items.AddRange(updateIntervalDictionary.Keys.ToArray());

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

            if (SettingsCore.Data.ContainsKey("saveDate"))
            {
                var savedDate = SettingsCore.Data["saveDate"];
                
                if (savedDate == "1")
                {
                    saveDateOnExit.Checked = true;
                }
                else
                {
                    saveDateOnExit.Checked = false;
                }
            }

            if (SettingsCore.Data.ContainsKey("saveScheduleLocally"))
            {
                if (SettingsCore.Data["saveScheduleLocally"] == "1")
                {
                    saveScheduleDataLocally.Checked = true;
                }
                else
                {
                    saveScheduleDataLocally.Checked = false;
                }
            }

            if (SettingsCore.Data.ContainsKey("updateSchedule"))
            {
                if (SettingsCore.Data["updateSchedule"] == "1")
                {
                    updateFromSite.Checked = true;
                }
                else
                {
                    updateFromSite.Checked = false;
                }

            }

            if (SettingsCore.Data.ContainsKey("updateInterval"))
            {
                updateInterval.Text = updateIntervalDictionary
                    .FirstOrDefault(kvp => kvp.Value == SettingsCore.Data["updateInterval"].ToString())
                    .Key;                    
            }
        }

        private void SettingsFormFormClosed(object sender, FormClosedEventArgs e)
        {
            if (SettingsCore.Data["updateSchedule"] == "1")
            {
                SettingsCore.AddOrUpdateSetting("updateInterval", updateIntervalDictionary[updateInterval.Text]);
            }
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

        private void saveDateOnExit_CheckedChanged(object sender, EventArgs e)
        {
            SettingsCore.Data["saveDate"] = (saveDateOnExit.Checked) ? "1" : "0";
        }

        private void saveScheduleDataLocally_CheckedChanged(object sender, EventArgs e)
        {
            SettingsCore.Data["saveScheduleLocally"] = (saveScheduleDataLocally.Checked) ? "1" : "0";
        }

        private void updateFromSite_CheckedChanged(object sender, EventArgs e)
        {
            SettingsCore.Data["updateSchedule"] = (updateFromSite.Checked) ? "1" : "0";
        }
    }
}
