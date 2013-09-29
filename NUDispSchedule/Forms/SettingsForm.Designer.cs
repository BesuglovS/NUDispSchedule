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
            this.saveDate = new System.Windows.Forms.GroupBox();
            this.saveDateNo = new System.Windows.Forms.RadioButton();
            this.saveDateYes = new System.Windows.Forms.RadioButton();
            this.savingGroup.SuspendLayout();
            this.saveDate.SuspendLayout();
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
            // saveDate
            // 
            this.saveDate.Controls.Add(this.saveDateNo);
            this.saveDate.Controls.Add(this.saveDateYes);
            this.saveDate.Location = new System.Drawing.Point(12, 139);
            this.saveDate.Name = "saveDate";
            this.saveDate.Size = new System.Drawing.Size(198, 79);
            this.saveDate.TabIndex = 3;
            this.saveDate.TabStop = false;
            this.saveDate.Text = "Запоминать дату после выхода";
            // 
            // saveDateNo
            // 
            this.saveDateNo.AutoSize = true;
            this.saveDateNo.Location = new System.Drawing.Point(16, 47);
            this.saveDateNo.Name = "saveDateNo";
            this.saveDateNo.Size = new System.Drawing.Size(44, 17);
            this.saveDateNo.TabIndex = 1;
            this.saveDateNo.TabStop = true;
            this.saveDateNo.Text = "Нет";
            this.saveDateNo.UseVisualStyleBackColor = true;
            this.saveDateNo.CheckedChanged += new System.EventHandler(this.SaveDateNoCheckedChanged);
            // 
            // saveDateYes
            // 
            this.saveDateYes.AutoSize = true;
            this.saveDateYes.Location = new System.Drawing.Point(16, 24);
            this.saveDateYes.Name = "saveDateYes";
            this.saveDateYes.Size = new System.Drawing.Size(40, 17);
            this.saveDateYes.TabIndex = 0;
            this.saveDateYes.TabStop = true;
            this.saveDateYes.Text = "Да";
            this.saveDateYes.UseVisualStyleBackColor = true;
            this.saveDateYes.CheckedChanged += new System.EventHandler(this.SaveDateYesCheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 238);
            this.Controls.Add(this.saveDate);
            this.Controls.Add(this.savingGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsFormFormClosed);
            this.Load += new System.EventHandler(this.SettingsFormLoad);
            this.savingGroup.ResumeLayout(false);
            this.savingGroup.PerformLayout();
            this.saveDate.ResumeLayout(false);
            this.saveDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton saveGroupOnExit;
        private System.Windows.Forms.RadioButton setThisGroupOnStartup;
        private System.Windows.Forms.GroupBox savingGroup;
        private System.Windows.Forms.ComboBox groupList;
        private System.Windows.Forms.RadioButton dontSave;
        private System.Windows.Forms.GroupBox saveDate;
        private System.Windows.Forms.RadioButton saveDateNo;
        private System.Windows.Forms.RadioButton saveDateYes;
    }
}