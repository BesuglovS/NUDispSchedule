﻿using System.Threading.Tasks;
using NUDispSchedule.Main;
using NUDispSchedule.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NUDispSchedule.Properties;

namespace NUDispSchedule.Forms
{
    public partial class Changes : Form
    {
        private readonly Schedule _schedule;
        private int _groupId;
        private readonly int _initialGroupId;
        private int _calendarId = -1;
        private readonly Form _antecedent;

        private readonly TaskScheduler _uiScheduler;

        public Changes(Form antecedent, Schedule schedule, int groupId)
        {
            InitializeComponent();

            Icon = Resources.diffIcon;

            _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            _schedule = schedule;
            _initialGroupId = groupId;
            _groupId = groupId;
            _antecedent = antecedent;
        }

        private void ChangesLoad(object sender, EventArgs e)
        {
            if (_antecedent.WindowState == FormWindowState.Minimized)
            {
                Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2;
                Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2;
            }

            var getChangesTask = Task.Factory
                .StartNew(() =>
                              {
                                  var calendar = _schedule.calendars.FirstOrDefault(c => c.Date.Date == DateTime.Now.Date);
                                  if (calendar != null)
                                  {
                                      _calendarId = calendar.CalendarId;
                                  }
                                  else
                                  {
                                      _calendarId = -1;
                                  }
                                  return GetGroupChanges(_groupId, _calendarId);
                              }
                );

            getChangesTask
                .ContinueWith(
                    antecedent =>
                        {
                            SetGroupListFromSchedule();
                            SetGroupChangesView(antecedent.Result);
                            
                            if (_schedule != null)
                            {
                                datePicker.MinDate = _schedule.calendars.Select(c => c.Date).Min();
                                datePicker.MaxDate = _schedule.calendars.Select(c => c.Date).Max();
                            }
                            datePicker.Value = DateTime.Now.Date;
                        },
                    TaskScheduler.FromCurrentSynchronizationContext()
                );
        }

        private void SetGroupChangesView(List<lleView> evtsView)
        {
            changesView.Columns.Clear();
            changesView.DataSource = evtsView;
            SetChangesView();
        }

        private List<lleView> GetGroupChanges(int groupId, int calendarId)
        {
            var studentIds = _schedule.studentsInGroups
                .Where(sig => sig.StudentGroup.StudentGroupId == groupId)
                .Select(stig => stig.Student.StudentId)
                .ToList();

            var groupIds = _schedule.studentsInGroups
                .Where(sig => studentIds.Contains(sig.Student.StudentId))
                .Select(stig => stig.StudentGroup.StudentGroupId)
                .Distinct()
                .ToList();

            List<LessonLogEvent> evts;

            if (calendarId == -1)
            {
                evts = _schedule.lessonLogEvents
                    .Where(
                        et =>
                        ((et.OldLesson != null) &&
                         groupIds.Contains(et.OldLesson.TeacherForDiscipline.Discipline.StudentGroup.StudentGroupId)) ||
                        ((et.NewLesson != null) &&
                         groupIds.Contains(et.NewLesson.TeacherForDiscipline.Discipline.StudentGroup.StudentGroupId)))
                    .OrderByDescending(et => et.DateTime)
                    .ToList();
            }
            else
            {
                evts = _schedule.lessonLogEvents
                    .Where(et => ((et.OldLesson != null) && et.OldLesson.Calendar.CalendarId == calendarId &&
                                  groupIds.Contains(et.OldLesson.TeacherForDiscipline.Discipline.StudentGroup.StudentGroupId)) ||
                                 ((et.NewLesson != null) && et.NewLesson.Calendar.CalendarId == calendarId &&
                                  groupIds.Contains(et.NewLesson.TeacherForDiscipline.Discipline.StudentGroup.StudentGroupId)))
                    .OrderByDescending(et => et.DateTime)
                    .ToList();
            }

            var evtsView = lleView.ListFromLessonLogEvents(evts);
            return evtsView;
        }

        private void SetChangesView()
        {
            changesView.ColumnHeadersVisible = false;
            changesView.RowHeadersVisible = false;
            changesView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            changesView.AutoResizeColumns();
            changesView.AutoResizeRows();
            changesView.AllowUserToResizeColumns = false;
            changesView.AllowUserToResizeRows = false;

            // EventId
            changesView.Columns["EventId"].Visible = false;
            changesView.Columns["EventId"].Width = 0;

            //changesView.Columns[1].DefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.FontFamily, 14);
            //changesView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // EventDate
            changesView.Columns["EventDate"].Width = Percent(20, changesView.Width - 20);
            
            // EventType
            changesView.Columns["EventType"].Visible = false;
            changesView.Columns["EventType"].Width = 0;

            // Message
            changesView.Columns["Message"].Width = Percent(60, changesView.Width - 20);

            var img = new DataGridViewImageColumn {Name = "img"};

            changesView.Columns.Insert(2, img);

            int numberOfRows = changesView.RowCount;
            Image lessonAddedImage = Resources.LessonAdded;
            Image lessonRemovedImage = Resources.LessonRemoved;
            Image auditoriumChangedImage = Resources.AuditoriumChanged;

            for (int i = 0; i < numberOfRows; i++)
            {
                switch (changesView.Rows[i].Cells["EventType"].Value.ToString())
                {
                    case "1":
                        changesView.Rows[i].Cells["img"].Value = lessonAddedImage;
                        break;
                    case "2":
                        changesView.Rows[i].Cells["img"].Value = lessonRemovedImage;
                        break;
                    case "3":
                        changesView.Rows[i].Cells["img"].Value = auditoriumChangedImage;
                        break;
                }

            }

            // img
            changesView.Columns["img"].Width = Percent(20, changesView.Width - 20);
        }

        private int Percent(int percent, int whole)
        {
            return (int)Math.Round((double)whole * percent / 100);
        }

        private void SetGroupListFromSchedule()
        {
            var filteredGroups = _schedule.studentGroups
                .Where(sg => !sg.Name.Contains('I') && !sg.Name.Contains('-') && !sg.Name.Contains('+'))
                .OrderBy(sg => sg.Name)
                .ToList();

            groupList.DisplayMember = "Name";
            groupList.ValueMember = "StudentGroupId";
            groupList.DataSource = filteredGroups;

            groupList.SelectedValue = _initialGroupId;

            var studentGroup = _schedule.studentGroups
                .FirstOrDefault(sg => sg.StudentGroupId == _initialGroupId);
            if (studentGroup != null)
            {
                groupList.SelectedText = studentGroup.Name;
            }
        }

        private void GroupListSelectedValueChanged(object sender, EventArgs e)
        {
            if (groupList.SelectedValue != null)
            {
                _groupId = (int) groupList.SelectedValue;

                var evtsView = GetGroupChanges(_groupId, _calendarId);

                SetGroupChangesView(evtsView);
            }
        }

        private void TomorrowsChangesClick(object sender, EventArgs e)
        {
            if (datePicker.Value == DateTime.Now.AddDays(1).Date)
            {
                DatePickerValueChanged(this, e);
            }
            else
            {
                datePicker.Value = DateTime.Now.AddDays(1).Date;
            }
        }

        private void TodaysChangesClick(object sender, EventArgs e)
        {
            if (datePicker.Value == DateTime.Now.Date)
            {
                DatePickerValueChanged(this, e);
            }
            else
            {
                datePicker.Value = DateTime.Now.Date;
            }
        }

        private void ChangesViewCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (changesView.Columns["img"] == null)
            {
                return;
            }

            if ((e.ColumnIndex == changesView.Columns["img"].Index) && (e.Value != null))
            {
                DataGridViewCell cell =
                    changesView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataGridViewCell valueCell =
                    changesView.Rows[e.RowIndex].Cells["EventType"];
                var eventType = (int) valueCell.Value;

                switch (eventType)
                {
                    case 1:
                        cell.ToolTipText = "Добавлена пара";
                        break;
                    case 2:
                        cell.ToolTipText = "Отменена пара";
                        break;
                    case 3:
                        cell.ToolTipText = "Изменена аудитория";
                        break;
                    default:
                        cell.ToolTipText = "Страх и ужас";
                        break;

                }
            }
        }

        private void AllChangesClick(object sender, EventArgs e)
        {
            var loadingEvents = Task.Factory.StartNew(() => GetGroupChanges(_groupId, -1));

            loadingEvents.ContinueWith(
                antecedent => SetGroupChangesView(antecedent.Result),
                _uiScheduler
            );
        }

        private void DatePickerValueChanged(object sender, EventArgs e)
        {
            var loadingEvents = Task.Factory.StartNew(() =>
            {
                var calendar =
                    _schedule.calendars.FirstOrDefault(
                        c => c.Date.Date == datePicker.Value.Date);
                if (calendar != null)
                {
                    _calendarId = calendar.CalendarId;
                }
                else
                {
                    _calendarId = -1;
                }
                return GetGroupChanges(_groupId, _calendarId);
            }
            );

            loadingEvents.ContinueWith(
                antecedent => SetGroupChangesView(antecedent.Result),
                _uiScheduler
            );
        }

        private void ChangesViewSelectionChanged(object sender, EventArgs e)
        {
            changesView.ClearSelection();
        }

    }
}
