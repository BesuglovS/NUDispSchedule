namespace NUDispSchedule.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveGroupOnExit = new System.Windows.Forms.RadioButton();
            this.setThisGroupOnStartup = new System.Windows.Forms.RadioButton();
            this.savingGroup = new System.Windows.Forms.GroupBox();
            this.groupList = new System.Windows.Forms.ComboBox();
            this.dontSave = new System.Windows.Forms.RadioButton();
            this.saveDateOnExit = new System.Windows.Forms.CheckBox();
            this.saveScheduleDataLocally = new System.Windows.Forms.CheckBox();
            this.updateFromSite = new System.Windows.Forms.CheckBox();
            this.updateInterval = new System.Windows.Forms.ComboBox();
            this.savingGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveGroupOnExit
            // 
            this.saveGroupOnExit.AutoSize = true;
            this.saveGroupOnExit.Location = new System.Drawing.Point(6, 19);
            this.saveGroupOnExit.Name = "saveGroupOnExit";
            this.saveGroupOnExit.Size = new System.Drawing.Size(196, 17);
            this.saveGroupOnExit.TabIndex = 0;
            this.saveGroupOnExit.TabStop = true;
            this.saveGroupOnExit.Text = "Запоминать группу после выходв";
            this.saveGroupOnExit.UseVisualStyleBackColor = true;
            this.saveGroupOnExit.CheckedChanged += new System.EventHandler(this.SaveGroupOnExitCheckedChanged);
            // 
            // setThisGroupOnStartup
            // 
            this.setThisGroupOnStartup.AutoSize = true;
            this.setThisGroupOnStartup.Location = new System.Drawing.Point(6, 42);
            this.setThisGroupOnStartup.Name = "setThisGroupOnStartup";
            this.setThisGroupOnStartup.Size = new System.Drawing.Size(245, 17);
            this.setThisGroupOnStartup.TabIndex = 1;
            this.setThisGroupOnStartup.TabStop = true;
            this.setThisGroupOnStartup.Text = "При запуске всегда выставлять эту группу";
            this.setThisGroupOnStartup.UseVisualStyleBackColor = true;
            this.setThisGroupOnStartup.CheckedChanged += new System.EventHandler(this.SetThisGroupOnStartupCheckedChanged);
            // 
            // savingGroup
            // 
            this.savingGroup.Controls.Add(this.groupList);
            this.savingGroup.Controls.Add(this.dontSave);
            this.savingGroup.Controls.Add(this.saveGroupOnExit);
            this.savingGroup.Controls.Add(this.setThisGroupOnStartup);
            this.savingGroup.Location = new System.Drawing.Point(12, 12);
            this.savingGroup.Name = "savingGroup";
            this.savingGroup.Size = new System.Drawing.Size(266, 121);
            this.savingGroup.TabIndex = 2;
            this.savingGroup.TabStop = false;
            this.savingGroup.Text = "Запоминать группу";
            // 
            // groupList
            // 
            this.groupList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupList.FormattingEnabled = true;
            this.groupList.Location = new System.Drawing.Point(6, 65);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(245, 21);
            this.groupList.TabIndex = 3;
            // 
            // dontSave
            // 
            this.dontSave.AutoSize = true;
            this.dontSave.Location = new System.Drawing.Point(6, 92);
            this.dontSave.Name = "dontSave";
            this.dontSave.Size = new System.Drawing.Size(94, 17);
            this.dontSave.TabIndex = 2;
            this.dontSave.TabStop = true;
            this.dontSave.Text = "Не сохранять";
            this.dontSave.UseVisualStyleBackColor = true;
            this.dontSave.CheckedChanged += new System.EventHandler(this.DontSaveCheckedChanged);
            // 
            // saveDateOnExit
            // 
            this.saveDateOnExit.AutoSize = true;
            this.saveDateOnExit.Checked = true;
            this.saveDateOnExit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveDateOnExit.Location = new System.Drawing.Point(18, 145);
            this.saveDateOnExit.Name = "saveDateOnExit";
            this.saveDateOnExit.Size = new System.Drawing.Size(186, 17);
            this.saveDateOnExit.TabIndex = 3;
            this.saveDateOnExit.Text = "Запоминать дату посде выхода";
            this.saveDateOnExit.UseVisualStyleBackColor = true;
            this.saveDateOnExit.CheckedChanged += new System.EventHandler(this.saveDateOnExit_CheckedChanged);
            // 
            // saveScheduleDataLocally
            // 
            this.saveScheduleDataLocally.AutoSize = true;
            this.saveScheduleDataLocally.Checked = true;
            this.saveScheduleDataLocally.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveScheduleDataLocally.Location = new System.Drawing.Point(18, 168);
            this.saveScheduleDataLocally.Name = "saveScheduleDataLocally";
            this.saveScheduleDataLocally.Size = new System.Drawing.Size(234, 17);
            this.saveScheduleDataLocally.TabIndex = 4;
            this.saveScheduleDataLocally.Text = "Сохранять данные расписания локально";
            this.saveScheduleDataLocally.UseVisualStyleBackColor = true;
            this.saveScheduleDataLocally.CheckedChanged += new System.EventHandler(this.saveScheduleDataLocally_CheckedChanged);
            // 
            // updateFromSite
            // 
            this.updateFromSite.AutoSize = true;
            this.updateFromSite.Checked = true;
            this.updateFromSite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.updateFromSite.Location = new System.Drawing.Point(18, 191);
            this.updateFromSite.Name = "updateFromSite";
            this.updateFromSite.Size = new System.Drawing.Size(228, 17);
            this.updateFromSite.TabIndex = 5;
            this.updateFromSite.Text = "Обновлять расписание с сайта каждые";
            this.updateFromSite.UseVisualStyleBackColor = true;
            this.updateFromSite.CheckedChanged += new System.EventHandler(this.updateFromSite_CheckedChanged);
            // 
            // updateInterval
            // 
            this.updateInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.updateInterval.FormattingEnabled = true;
            this.updateInterval.Location = new System.Drawing.Point(18, 214);
            this.updateInterval.Name = "updateInterval";
            this.updateInterval.Size = new System.Drawing.Size(245, 21);
            this.updateInterval.TabIndex = 6;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 253);
            this.Controls.Add(this.updateInterval);
            this.Controls.Add(this.updateFromSite);
            this.Controls.Add(this.saveScheduleDataLocally);
            this.Controls.Add(this.saveDateOnExit);
            this.Controls.Add(this.savingGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsFormFormClosed);
            this.Load += new System.EventHandler(this.SettingsFormLoad);
            this.savingGroup.ResumeLayout(false);
            this.savingGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton saveGroupOnExit;
        private System.Windows.Forms.RadioButton setThisGroupOnStartup;
        private System.Windows.Forms.GroupBox savingGroup;
        private System.Windows.Forms.ComboBox groupList;
        private System.Windows.Forms.RadioButton dontSave;
        private System.Windows.Forms.CheckBox saveDateOnExit;
        private System.Windows.Forms.CheckBox saveScheduleDataLocally;
        private System.Windows.Forms.CheckBox updateFromSite;
        private System.Windows.Forms.ComboBox updateInterval;
    }
}