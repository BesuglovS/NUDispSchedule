﻿using System.Globalization;
using NUDispSchedule.Core;
using NUDispSchedule.Main;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NUDispSchedule.Properties;
using NUDispSchedule.Views;

namespace NUDispSchedule.Forms
{
    public partial class TeacherSchedule : Form
    {
        private readonly Form _antecedent;
        private readonly Schedule _schedule;

        public TeacherSchedule(Form antecedent, Schedule schedule)
        {
            InitializeComponent();

            _antecedent = antecedent;
            _schedule = schedule;
        }

        private void TeacherScheduleLoad(object sender, EventArgs e)
        {
            if (_antecedent.WindowState == FormWindowState.Minimized)
            {
                Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2;
                Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2;
            }

            SetTeacherList();
        }

        private void SetTeacherList()
        {
            var tList = _schedule.teachers.OrderBy(t => t.FIO).ToList();

            teacherList.DisplayMember = "FIO";
            teacherList.ValueMember = "TeacherId";
            teacherList.DataSource = tList;
            
        }

        private void TeacherListSelectedIndexChanged(object sender, EventArgs e)
        {
            var result = new List<TeacherScheduleTimeView>();

            var teacherId = (int) (teacherList.SelectedValue);
            var lessonList = _schedule.lessons.Where(l => l.TeacherForDiscipline.Teacher.TeacherId == teacherId &&
                                                          l.IsActive).ToList();

            var lessonsGrouped = lessonList
                .GroupBy(l => l.Ring.Time)
                .ToDictionary(l => l.Key,
                              l2 => l2.GroupBy(l3 => Utilities.DOWEnToRu[(int) l3.Calendar.Date.DayOfWeek])
                                        .ToDictionary(ll => ll.Key, ll => ll.GroupBy(l4 => l4.TeacherForDiscipline.TeacherForDisciplineId)
                                                                            .ToDictionary(l5 => l5.Key, l5 => l5.ToList())))
                .ToList();

            var semesterStartsOption =
                            _schedule.configOptions.FirstOrDefault(co => co.Key == "Semester Starts");
            if (semesterStartsOption == null)
            {
                return;
            }

            foreach (var time in lessonsGrouped.OrderBy(lg => lg.Key))
            {
                var tstv = new TeacherScheduleTimeView {Time = time.Key.ToString("H:mm")};

                foreach (var timeDowLessons in time.Value)
                {
                    var dow = timeDowLessons.Key;
                    string message = "";
                    int i = 0;
                    foreach (var tfdBundle in timeDowLessons.Value
                        .OrderBy(tfd => tfd.Value.Select(l => l.Calendar.Date).Min()))
                    {
                        message += tfdBundle.Value[0].TeacherForDiscipline.Discipline.StudentGroup.Name;
                        message += Environment.NewLine;
                        message += tfdBundle.Value[0].TeacherForDiscipline.Discipline.Name;
                        message += Environment.NewLine;
                        var semesterStartsDate = DateTime.ParseExact(semesterStartsOption.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        var weekList = tfdBundle.Value
                            .Select(l => Utilities.WeekFromDate(l.Calendar.Date, semesterStartsDate))
                            .ToList();
                        message += "(" + Utilities.GatherWeeksToString(weekList) + ")";
                        message += Environment.NewLine;
                        var audWeeks = new Dictionary<string, List<int>>();
                        foreach (var lesson in tfdBundle.Value)
                        {
                            if (!audWeeks.ContainsKey(lesson.Auditorium.Name))
                            {
                                audWeeks.Add(lesson.Auditorium.Name, new List<int>());
                            }

                            audWeeks[lesson.Auditorium.Name].Add(Utilities.WeekFromDate(lesson.Calendar.Date, semesterStartsDate));
                        }
                        var sortedWeeks = audWeeks.OrderBy(aw => aw.Value.Min());
                        if (sortedWeeks.Count() == 1)
                        {
                            message += audWeeks.ElementAt(0).Key;
                        }
                        else
                        {
                            message = sortedWeeks
                                .Aggregate(message, (current, kvp) =>
                                                    current +
                                                    (Utilities.GatherWeeksToString(kvp.Value) + " - " + kvp.Key +
                                                     Environment.NewLine));
                        }

                        if (i != timeDowLessons.Value.Count-1)
                        {
                            message += Environment.NewLine + Environment.NewLine;
                        }

                        i++;
                    }

                    while(message.EndsWith(Environment.NewLine))
                    {
                        message = message.Substring(0, message.Length - Environment.NewLine.Length);
                    }

                    switch (dow)
                    {
                        case 1:
                            tstv.MonLessons = message;
                            break;
                        case 2:
                            tstv.TueLessons = message;
                            break;
                        case 3:
                            tstv.WedLessons = message;
                            break;
                        case 4:
                            tstv.ThuLessons = message;
                            break;
                        case 5:
                            tstv.FriLessons = message;
                            break;
                        case 6:
                            tstv.SatLessons = message;
                            break;
                        case 7:
                            tstv.SunLessons = message;
                            break;

                    }
                }

                result.Add(tstv);
            }

            scheduleView.DataSource = result;

            FormatView();
        }

        private static int Percent(double percent, double whole)
        {
            return (int)Math.Round(whole * (percent / 100));
        }

        private void FormatView()
        {
            if ((scheduleView.DataSource == null) || 
                (scheduleView.DataSource != null && 
                 ((List<TeacherScheduleTimeView>)(scheduleView.DataSource)).Count == 0))
            {
                return;
            }

            scheduleView.RowHeadersVisible = false;
            scheduleView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            scheduleView.AutoResizeColumns();
            scheduleView.AutoResizeRows();
            scheduleView.AllowUserToResizeColumns = false;
            scheduleView.AllowUserToResizeRows = false;

            // Time
            scheduleView.Columns["Time"].HeaderText = Resources.TeacherSchedule_FormatView_Time;
            scheduleView.Columns["Time"].Width = 56;
            scheduleView.Columns["Time"].DefaultCellStyle.Font = new Font(scheduleView.DefaultCellStyle.Font.FontFamily, 14);
            scheduleView.Columns["Time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var source = (List<TeacherScheduleTimeView>)scheduleView.DataSource;
            var emptyColumn = new Dictionary<int, bool>();
            for (int i = 1; i <= 7; i++)
            {
                emptyColumn.Add(i, true);
                foreach (TeacherScheduleTimeView time in source)
                {
                    switch (i)
                    {
                        case 1:
                            if (time.MonLessons != null)
                            {
                                emptyColumn[i] = false;
                            }
                            break;
                        case 2:
                            if (time.TueLessons != null)
                            {
                                emptyColumn[i] = false;
                            }
                            break;
                        case 3:
                            if (time.WedLessons != null)
                            {
                                emptyColumn[i] = false;
                            }
                            break;
                        case 4:
                            if (time.ThuLessons != null)
                            {
                                emptyColumn[i] = false;
                            }
                            break;
                        case 5:
                            if (time.FriLessons != null)
                            {
                                emptyColumn[i] = false;
                            }
                            break;
                        case 6:
                            if (time.SatLessons != null)
                            {
                                emptyColumn[i] = false;
                            }
                            break;
                        case 7:
                            if (time.SunLessons != null)
                            {
                                emptyColumn[i] = false;
                            }
                            break;
                    }
                }
            }
            var notEmptyDowColumnCount = 7 - emptyColumn.Count(e => e.Value);

            var emptyColumnIndexes = emptyColumn.Where(e => e.Value).Select(e => e.Key).ToList();
            
            for (var i = 1; i <= 7; i++)
            {
                scheduleView.Columns[i].Visible = !emptyColumnIndexes.Contains(i);
            }
            
            // Lessons
            for (int i = 1; i <= 7; i++)
            {
                scheduleView.Columns[i].Width = (scheduleView.Width - 76) / notEmptyDowColumnCount;
                scheduleView.Columns[i].HeaderText = Constants.DOWRU[i];
            }

        }

        private void TeacherScheduleResize(object sender, EventArgs e)
        {
            FormatView();
        }

        private void ScheduleViewSelectionChanged(object sender, EventArgs e)
        {
            scheduleView.ClearSelection();
        }
    }
}
