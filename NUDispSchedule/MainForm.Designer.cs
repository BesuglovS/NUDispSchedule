namespace NUDispSchedule
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.aboutButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.tomorrow = new System.Windows.Forms.Button();
            this.today = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.groupList = new System.Windows.Forms.ComboBox();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.scheduleView = new System.Windows.Forms.DataGridView();
            this.updateScheduleTimer = new System.Windows.Forms.Timer(this.components);
            this.controlsPanel.SuspendLayout();
            this.viewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleView)).BeginInit();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.aboutButton);
            this.controlsPanel.Controls.Add(this.settingsButton);
            this.controlsPanel.Controls.Add(this.tomorrow);
            this.controlsPanel.Controls.Add(this.today);
            this.controlsPanel.Controls.Add(this.label2);
            this.controlsPanel.Controls.Add(this.label1);
            this.controlsPanel.Controls.Add(this.datePicker);
            this.controlsPanel.Controls.Add(this.groupList);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlsPanel.Location = new System.Drawing.Point(0, 0);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(462, 74);
            this.controlsPanel.TabIndex = 1;
            // 
            // aboutButton
            // 
            this.aboutButton.Image = global::NUDispSchedule.Properties.Resources.information;
            this.aboutButton.Location = new System.Drawing.Point(15, 39);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(29, 29);
            this.aboutButton.TabIndex = 7;
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.AboutButtonClick);
            // 
            // settingsButton
            // 
            this.settingsButton.Image = global::NUDispSchedule.Properties.Resources.settings;
            this.settingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.Location = new System.Drawing.Point(60, 39);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(150, 29);
            this.settingsButton.TabIndex = 6;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.SettingsClick);
            // 
            // tomorrow
            // 
            this.tomorrow.Location = new System.Drawing.Point(340, 38);
            this.tomorrow.Name = "tomorrow";
            this.tomorrow.Size = new System.Drawing.Size(115, 29);
            this.tomorrow.TabIndex = 5;
            this.tomorrow.Text = "Завтра";
            this.tomorrow.UseVisualStyleBackColor = true;
            this.tomorrow.Click += new System.EventHandler(this.TomorrowClick);
            // 
            // today
            // 
            this.today.Location = new System.Drawing.Point(219, 38);
            this.today.Name = "today";
            this.today.Size = new System.Drawing.Size(115, 29);
            this.today.TabIndex = 4;
            this.today.Text = "Сегодня";
            this.today.UseVisualStyleBackColor = true;
            this.today.Click += new System.EventHandler(this.TodayClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Группа";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(255, 12);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 1;
            this.datePicker.Value = new System.DateTime(2013, 9, 2, 0, 0, 0, 0);
            this.datePicker.ValueChanged += new System.EventHandler(this.DatePickerValueChanged);
            // 
            // groupList
            // 
            this.groupList.FormattingEnabled = true;
            this.groupList.Location = new System.Drawing.Point(60, 12);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(150, 21);
            this.groupList.TabIndex = 0;
            this.groupList.SelectedIndexChanged += new System.EventHandler(this.GroupListSelectedIndexChanged);
            // 
            // viewPanel
            // 
            this.viewPanel.Controls.Add(this.scheduleView);
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 74);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(462, 337);
            this.viewPanel.TabIndex = 2;
            // 
            // scheduleView
            // 
            this.scheduleView.AllowUserToAddRows = false;
            this.scheduleView.AllowUserToDeleteRows = false;
            this.scheduleView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.scheduleView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.scheduleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scheduleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleView.Location = new System.Drawing.Point(0, 0);
            this.scheduleView.Name = "scheduleView";
            this.scheduleView.ReadOnly = true;
            this.scheduleView.Size = new System.Drawing.Size(462, 337);
            this.scheduleView.TabIndex = 0;
            // 
            // updateScheduleTimer
            // 
            this.updateScheduleTimer.Tick += new System.EventHandler(this.UpdateScheduleTimerTick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 411);
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.controlsPanel);
            this.MinimumSize = new System.Drawing.Size(478, 177);
            this.Name = "MainForm";
            this.Text = "СГОАН - расписание занятий";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.Resize += new System.EventHandler(this.MainFormResize);
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            this.viewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.ComboBox groupList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.DataGridView scheduleView;
        private System.Windows.Forms.Button tomorrow;
        private System.Windows.Forms.Button today;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Timer updateScheduleTimer;
    }
}

