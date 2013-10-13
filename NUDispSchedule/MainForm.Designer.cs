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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.teacherSchedule = new System.Windows.Forms.Button();
            this.updateSchedule = new System.Windows.Forms.Button();
            this.changes = new System.Windows.Forms.Button();
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
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.измененияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расписаниеПреподавателяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьРасписниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьОкноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshButtonTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.controlsPanel.SuspendLayout();
            this.viewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleView)).BeginInit();
            this.trayIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.teacherSchedule);
            this.controlsPanel.Controls.Add(this.updateSchedule);
            this.controlsPanel.Controls.Add(this.changes);
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
            this.controlsPanel.Size = new System.Drawing.Size(462, 81);
            this.controlsPanel.TabIndex = 1;
            this.refreshButtonTooltip.SetToolTip(this.controlsPanel, "Обновить расписание");
            // 
            // teacherSchedule
            // 
            this.teacherSchedule.Image = global::NUDispSchedule.Properties.Resources.teacher1;
            this.teacherSchedule.Location = new System.Drawing.Point(192, 8);
            this.teacherSchedule.Name = "teacherSchedule";
            this.teacherSchedule.Size = new System.Drawing.Size(32, 32);
            this.teacherSchedule.TabIndex = 10;
            this.refreshButtonTooltip.SetToolTip(this.teacherSchedule, "Расписание преподавателя");
            this.teacherSchedule.UseVisualStyleBackColor = true;
            this.teacherSchedule.Click += new System.EventHandler(this.TeacherScheduleClick);
            // 
            // updateSchedule
            // 
            this.updateSchedule.Image = global::NUDispSchedule.Properties.Resources.update24;
            this.updateSchedule.Location = new System.Drawing.Point(154, 8);
            this.updateSchedule.Name = "updateSchedule";
            this.updateSchedule.Size = new System.Drawing.Size(32, 32);
            this.updateSchedule.TabIndex = 9;
            this.refreshButtonTooltip.SetToolTip(this.updateSchedule, "Обновить расписание");
            this.updateSchedule.UseVisualStyleBackColor = true;
            this.updateSchedule.Click += new System.EventHandler(this.UpdateScheduleClick);
            // 
            // changes
            // 
            this.changes.Image = global::NUDispSchedule.Properties.Resources.diff;
            this.changes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changes.Location = new System.Drawing.Point(154, 43);
            this.changes.Name = "changes";
            this.changes.Size = new System.Drawing.Size(109, 29);
            this.changes.TabIndex = 8;
            this.changes.Text = "        Изменения";
            this.changes.UseVisualStyleBackColor = true;
            this.changes.Click += new System.EventHandler(this.ChangesClick);
            // 
            // aboutButton
            // 
            this.aboutButton.Image = global::NUDispSchedule.Properties.Resources.information;
            this.aboutButton.Location = new System.Drawing.Point(15, 42);
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
            this.settingsButton.Location = new System.Drawing.Point(60, 43);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(88, 29);
            this.settingsButton.TabIndex = 6;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.SettingsClick);
            // 
            // tomorrow
            // 
            this.tomorrow.Location = new System.Drawing.Point(363, 43);
            this.tomorrow.Name = "tomorrow";
            this.tomorrow.Size = new System.Drawing.Size(87, 29);
            this.tomorrow.TabIndex = 5;
            this.tomorrow.Text = "Завтра";
            this.tomorrow.UseVisualStyleBackColor = true;
            this.tomorrow.Click += new System.EventHandler(this.TomorrowClick);
            // 
            // today
            // 
            this.today.Location = new System.Drawing.Point(269, 43);
            this.today.Name = "today";
            this.today.Size = new System.Drawing.Size(87, 29);
            this.today.TabIndex = 4;
            this.today.Text = "Сегодня";
            this.today.UseVisualStyleBackColor = true;
            this.today.Click += new System.EventHandler(this.TodayClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Группа";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(269, 14);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(181, 20);
            this.datePicker.TabIndex = 1;
            this.datePicker.Value = new System.DateTime(2013, 9, 2, 0, 0, 0, 0);
            this.datePicker.ValueChanged += new System.EventHandler(this.DatePickerValueChanged);
            // 
            // groupList
            // 
            this.groupList.FormattingEnabled = true;
            this.groupList.Location = new System.Drawing.Point(60, 14);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(88, 21);
            this.groupList.TabIndex = 0;
            this.groupList.SelectedIndexChanged += new System.EventHandler(this.GroupListSelectedIndexChanged);
            // 
            // viewPanel
            // 
            this.viewPanel.Controls.Add(this.scheduleView);
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 81);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(462, 330);
            this.viewPanel.TabIndex = 2;
            // 
            // scheduleView
            // 
            this.scheduleView.AllowUserToAddRows = false;
            this.scheduleView.AllowUserToDeleteRows = false;
            this.scheduleView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.scheduleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scheduleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleView.Location = new System.Drawing.Point(0, 0);
            this.scheduleView.Name = "scheduleView";
            this.scheduleView.ReadOnly = true;
            this.scheduleView.Size = new System.Drawing.Size(462, 330);
            this.scheduleView.TabIndex = 0;
            this.scheduleView.SelectionChanged += new System.EventHandler(this.ScheduleViewSelectionChanged);
            // 
            // updateScheduleTimer
            // 
            this.updateScheduleTimer.Tick += new System.EventHandler(this.UpdateScheduleTimerTick);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Расписание СГОАН";
            this.trayIcon.BalloonTipClicked += new System.EventHandler(this.TrayIconBalloonTipClicked);
            this.trayIcon.DoubleClick += new System.EventHandler(this.TrayIconDoubleClick);
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.измененияToolStripMenuItem,
            this.расписаниеПреподавателяToolStripMenuItem,
            this.обновитьРасписниеToolStripMenuItem,
            this.показатьОкноToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.trayIconMenu.Name = "trayIconMenu";
            this.trayIconMenu.Size = new System.Drawing.Size(225, 164);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Image = global::NUDispSchedule.Properties.Resources.information;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.AboutButtonClick);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Image = global::NUDispSchedule.Properties.Resources.settings;
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.SettingsClick);
            // 
            // измененияToolStripMenuItem
            // 
            this.измененияToolStripMenuItem.Image = global::NUDispSchedule.Properties.Resources.diff;
            this.измененияToolStripMenuItem.Name = "измененияToolStripMenuItem";
            this.измененияToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.измененияToolStripMenuItem.Text = "Изменения";
            this.измененияToolStripMenuItem.Click += new System.EventHandler(this.ИзмененияToolStripMenuItemClick);
            // 
            // расписаниеПреподавателяToolStripMenuItem
            // 
            this.расписаниеПреподавателяToolStripMenuItem.Image = global::NUDispSchedule.Properties.Resources.teacher1;
            this.расписаниеПреподавателяToolStripMenuItem.Name = "расписаниеПреподавателяToolStripMenuItem";
            this.расписаниеПреподавателяToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.расписаниеПреподавателяToolStripMenuItem.Text = "Расписание преподавателя";
            this.расписаниеПреподавателяToolStripMenuItem.Click += new System.EventHandler(this.РасписаниеПреподавателяToolStripMenuItemClick);
            // 
            // обновитьРасписниеToolStripMenuItem
            // 
            this.обновитьРасписниеToolStripMenuItem.Image = global::NUDispSchedule.Properties.Resources.update24;
            this.обновитьРасписниеToolStripMenuItem.Name = "обновитьРасписниеToolStripMenuItem";
            this.обновитьРасписниеToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.обновитьРасписниеToolStripMenuItem.Text = "Обновить расписание";
            this.обновитьРасписниеToolStripMenuItem.Click += new System.EventHandler(this.ОбновитьРасписниеToolStripMenuItemClick);
            // 
            // показатьОкноToolStripMenuItem
            // 
            this.показатьОкноToolStripMenuItem.Image = global::NUDispSchedule.Properties.Resources.window_new;
            this.показатьОкноToolStripMenuItem.Name = "показатьОкноToolStripMenuItem";
            this.показатьОкноToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.показатьОкноToolStripMenuItem.Text = "Показать окно";
            this.показатьОкноToolStripMenuItem.Click += new System.EventHandler(this.TrayIconDoubleClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = global::NUDispSchedule.Properties.Resources.exit;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ВыходToolStripMenuItemClick);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "СГОАН - расписание занятий";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.Resize += new System.EventHandler(this.MainFormResize);
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            this.viewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleView)).EndInit();
            this.trayIconMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Button changes;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem показатьОкноToolStripMenuItem;
        private System.Windows.Forms.Button updateSchedule;
        private System.Windows.Forms.ToolStripMenuItem обновитьРасписниеToolStripMenuItem;
        private System.Windows.Forms.ToolTip refreshButtonTooltip;
        private System.Windows.Forms.Button teacherSchedule;
        private System.Windows.Forms.ToolStripMenuItem измененияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расписаниеПреподавателяToolStripMenuItem;
    }
}

