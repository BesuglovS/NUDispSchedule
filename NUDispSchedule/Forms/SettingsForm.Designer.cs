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
            this.MinimizeOnClose = new System.Windows.Forms.CheckBox();
            this.AutoStart = new System.Windows.Forms.CheckBox();
            this.notificationGroup = new System.Windows.Forms.GroupBox();
            this.studentList = new System.Windows.Forms.ComboBox();
            this.showForChoosenStudent = new System.Windows.Forms.RadioButton();
            this.groupList2 = new System.Windows.Forms.ComboBox();
            this.showForChoosenGroup = new System.Windows.Forms.RadioButton();
            this.showForSavedGroup = new System.Windows.Forms.RadioButton();
            this.dontShow = new System.Windows.Forms.RadioButton();
            this.savingGroup.SuspendLayout();
            this.notificationGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveGroupOnExit
            // 
            this.saveGroupOnExit.AutoSize = true;
            this.saveGroupOnExit.Checked = true;
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
            this.saveDateOnExit.Text = "Запоминать дату после выхода";
            this.saveDateOnExit.UseVisualStyleBackColor = true;
            this.saveDateOnExit.CheckedChanged += new System.EventHandler(this.SaveDateOnExitCheckedChanged);
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
            this.saveScheduleDataLocally.CheckedChanged += new System.EventHandler(this.SaveScheduleDataLocallyCheckedChanged);
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
            this.updateFromSite.CheckedChanged += new System.EventHandler(this.UpdateFromSiteCheckedChanged);
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
            // MinimizeOnClose
            // 
            this.MinimizeOnClose.AutoSize = true;
            this.MinimizeOnClose.Checked = true;
            this.MinimizeOnClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MinimizeOnClose.Location = new System.Drawing.Point(18, 250);
            this.MinimizeOnClose.Name = "MinimizeOnClose";
            this.MinimizeOnClose.Size = new System.Drawing.Size(200, 17);
            this.MinimizeOnClose.TabIndex = 7;
            this.MinimizeOnClose.Text = "При закрытии сворачивать в трэй";
            this.MinimizeOnClose.UseVisualStyleBackColor = true;
            this.MinimizeOnClose.CheckedChanged += new System.EventHandler(this.MinimizeOnCloseCheckedChanged);
            // 
            // AutoStart
            // 
            this.AutoStart.AutoSize = true;
            this.AutoStart.Location = new System.Drawing.Point(18, 273);
            this.AutoStart.Name = "AutoStart";
            this.AutoStart.Size = new System.Drawing.Size(190, 17);
            this.AutoStart.TabIndex = 8;
            this.AutoStart.Text = "Автостарт при запуске Windows";
            this.AutoStart.UseVisualStyleBackColor = true;
            this.AutoStart.CheckedChanged += new System.EventHandler(this.AutoStartCheckedChanged);
            // 
            // notificationGroup
            // 
            this.notificationGroup.Controls.Add(this.studentList);
            this.notificationGroup.Controls.Add(this.showForChoosenStudent);
            this.notificationGroup.Controls.Add(this.groupList2);
            this.notificationGroup.Controls.Add(this.showForChoosenGroup);
            this.notificationGroup.Controls.Add(this.showForSavedGroup);
            this.notificationGroup.Controls.Add(this.dontShow);
            this.notificationGroup.Location = new System.Drawing.Point(14, 301);
            this.notificationGroup.Name = "notificationGroup";
            this.notificationGroup.Size = new System.Drawing.Size(261, 171);
            this.notificationGroup.TabIndex = 9;
            this.notificationGroup.TabStop = false;
            this.notificationGroup.Text = "Показывать оповещения";
            // 
            // studentList
            // 
            this.studentList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.studentList.FormattingEnabled = true;
            this.studentList.Location = new System.Drawing.Point(6, 115);
            this.studentList.Name = "studentList";
            this.studentList.Size = new System.Drawing.Size(245, 21);
            this.studentList.TabIndex = 6;
            // 
            // showForChoosenStudent
            // 
            this.showForChoosenStudent.AutoSize = true;
            this.showForChoosenStudent.Location = new System.Drawing.Point(6, 92);
            this.showForChoosenStudent.Name = "showForChoosenStudent";
            this.showForChoosenStudent.Size = new System.Drawing.Size(221, 17);
            this.showForChoosenStudent.TabIndex = 5;
            this.showForChoosenStudent.TabStop = true;
            this.showForChoosenStudent.Text = "Показывать для выбранного студента";
            this.showForChoosenStudent.UseVisualStyleBackColor = true;
            this.showForChoosenStudent.CheckedChanged += new System.EventHandler(this.ShowForChoosenStudentCheckedChanged);
            // 
            // groupList2
            // 
            this.groupList2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupList2.FormattingEnabled = true;
            this.groupList2.Location = new System.Drawing.Point(6, 65);
            this.groupList2.Name = "groupList2";
            this.groupList2.Size = new System.Drawing.Size(245, 21);
            this.groupList2.TabIndex = 4;
            // 
            // showForChoosenGroup
            // 
            this.showForChoosenGroup.AutoSize = true;
            this.showForChoosenGroup.Location = new System.Drawing.Point(6, 42);
            this.showForChoosenGroup.Name = "showForChoosenGroup";
            this.showForChoosenGroup.Size = new System.Drawing.Size(207, 17);
            this.showForChoosenGroup.TabIndex = 3;
            this.showForChoosenGroup.TabStop = true;
            this.showForChoosenGroup.Text = "Показывать для выбранной группы";
            this.showForChoosenGroup.UseVisualStyleBackColor = true;
            this.showForChoosenGroup.CheckedChanged += new System.EventHandler(this.ShowForChoosenGroupCheckedChanged);
            // 
            // showForSavedGroup
            // 
            this.showForSavedGroup.AutoSize = true;
            this.showForSavedGroup.Checked = true;
            this.showForSavedGroup.Location = new System.Drawing.Point(6, 19);
            this.showForSavedGroup.Name = "showForSavedGroup";
            this.showForSavedGroup.Size = new System.Drawing.Size(219, 17);
            this.showForSavedGroup.TabIndex = 2;
            this.showForSavedGroup.TabStop = true;
            this.showForSavedGroup.Text = "Показывать для запомненной группы";
            this.showForSavedGroup.UseVisualStyleBackColor = true;
            this.showForSavedGroup.CheckedChanged += new System.EventHandler(this.ShowForSavedGroupCheckedChanged);
            // 
            // dontShow
            // 
            this.dontShow.AutoSize = true;
            this.dontShow.Location = new System.Drawing.Point(6, 142);
            this.dontShow.Name = "dontShow";
            this.dontShow.Size = new System.Drawing.Size(103, 17);
            this.dontShow.TabIndex = 1;
            this.dontShow.TabStop = true;
            this.dontShow.Text = "Не показывать";
            this.dontShow.UseVisualStyleBackColor = true;
            this.dontShow.CheckedChanged += new System.EventHandler(this.DontShowCheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 484);
            this.Controls.Add(this.notificationGroup);
            this.Controls.Add(this.AutoStart);
            this.Controls.Add(this.MinimizeOnClose);
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
            this.notificationGroup.ResumeLayout(false);
            this.notificationGroup.PerformLayout();
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
        private System.Windows.Forms.CheckBox MinimizeOnClose;
        private System.Windows.Forms.CheckBox AutoStart;
        private System.Windows.Forms.GroupBox notificationGroup;
        private System.Windows.Forms.ComboBox studentList;
        private System.Windows.Forms.RadioButton showForChoosenStudent;
        private System.Windows.Forms.ComboBox groupList2;
        private System.Windows.Forms.RadioButton showForChoosenGroup;
        private System.Windows.Forms.RadioButton dontShow;
        private System.Windows.Forms.RadioButton showForSavedGroup;
    }
}