using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUDispSchedule.Main.Others;

namespace NUDispSchedule.Main
{
    public class Schedule
    {
        public List<Auditorium> auditoriums { get; set; }
        public List<Calendar> calendars { get; set; }
        public List<Discipline> disciplines { get; set; }
        public List<Lesson> lessons { get; set; }
        public List<Ring> rings { get; set; }
        public List<Student> students { get; set; }
        public List<StudentGroup> studentGroups { get; set; }
        public List<StudentsInGroups> studentsInGroups { get; set; }
        public List<Teacher> teachers { get; set; }
        public List<TeacherForDiscipline> teacherForDisciplines { get; set; }
        public List<LessonLogEvent> lessonLogEvents { get; set; }
        public List<ConfigOption> configOptions { get; set; }
        
        static public Schedule FromWebSchedule(WebSchedule ws)
        {
            var result = new Schedule
                             {
                                 auditoriums = new List<Auditorium>(),
                                 calendars = new List<Calendar>(),
                                 disciplines = new List<Discipline>(),
                                 lessons = new List<Lesson>(),
                                 rings = new List<Ring>(),
                                 students = new List<Student>(),
                                 studentGroups = new List<StudentGroup>(),
                                 studentsInGroups = new List<StudentsInGroups>(),
                                 teachers = new List<Teacher>(),
                                 teacherForDisciplines = new List<TeacherForDiscipline>(),

                                 configOptions = new List<ConfigOption>(),
                                 lessonLogEvents = new List<LessonLogEvent>()
                             };

            foreach (var a in ws.auditoriums)
            {
                result.auditoriums.Add(a);
            }

            foreach (var c in ws.calendars)
            {
                result.calendars.Add(c);
            }

            foreach (var r in ws.rings)
            {
                result.rings.Add(r);
            }

            foreach (var sg in ws.studentGroups)
            {
                result.studentGroups.Add(sg);
            }

            foreach (var t in ws.teachers)
            {
                result.teachers.Add(t);
            }

            foreach (var co in ws.configOptions)
            {
                result.configOptions.Add(co);
            }

            foreach (var d in ws.disciplines)
            {
                var sg = result.studentGroups.FirstOrDefault(stgr => stgr.StudentGroupId == d.StudentGroupId);
                var newD = new Discipline(d.DisciplineId, d.Name, 
                    sg, d.Attestation, d.AuditoriumHours, d.LectureHours, d.PracticalHours);
                
                result.disciplines.Add(newD);
            }

            foreach (var s in ws.students)
            {
                result.students.Add(new Student(s.StudentId, s.F, s.I, s.O, 
                    s.Starosta == 1, s.NFactor == 1, s.Expelled == 1));
            }

            foreach (var sig in ws.studentsInGroups)
            {
                var stud = result.students.FirstOrDefault(s => s.StudentId == sig.StudentId);
                var stgr = result.studentGroups.FirstOrDefault(sg => sg.StudentGroupId == sig.StudentGroupId);
                result.studentsInGroups.Add(new StudentsInGroups
                                                {
                                                    StudentsInGroupsId = sig.StudentsInGroupsId,
                                                    Student = stud, StudentGroup = stgr
                                                });
            }

            foreach (var tfd in ws.teacherForDisciplines)
            {
                var teacher = result.teachers.FirstOrDefault(t => t.TeacherId == tfd.TeacherId);
                var discipline = result.disciplines.FirstOrDefault(d => d.DisciplineId == tfd.DisciplineId);
                result.teacherForDisciplines.Add(new TeacherForDiscipline
                                                     {
                                                         TeacherForDisciplineId = tfd.TeacherForDisciplineId,
                                                         Teacher = teacher, Discipline = discipline
                                                     });
            }

            foreach (var lesson in ws.lessons)
            {
                var tefd = result.teacherForDisciplines.FirstOrDefault(
                        tfd => tfd.TeacherForDisciplineId == lesson.TeacherForDisciplineId);
                var cal = result.calendars.FirstOrDefault(c => c.CalendarId == lesson.CalendarId);
                var ring = result.rings.FirstOrDefault(r => r.RingId == lesson.RingId);
                var aud = result.auditoriums.FirstOrDefault(a => a.AuditoriumId == lesson.AuditoriumId);
                result.lessons.Add(new Lesson(lesson.LessonId, tefd, cal, ring, aud, lesson.IsActive == 1));
            }

            foreach (var logEvent in ws.lessonLogEvents)
            {
                var oldLesson = result.lessons.FirstOrDefault(l => l.LessonId == logEvent.OldLessonId);
                var newLesson = result.lessons.FirstOrDefault(l => l.LessonId == logEvent.NewLessonId);
                result.lessonLogEvents.Add(new LessonLogEvent
                                               {
                                                   LessonLogEventId = logEvent.LessonLogEventId,
                                                   Comment = logEvent.Comment,
                                                   DateTime = logEvent.DateTime,
                                                   NewLesson = newLesson,
                                                   OldLesson = oldLesson

                                               });
            }

            return result;
        }
    }
}
