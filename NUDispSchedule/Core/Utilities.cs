using System;
using System.Collections.Generic;
using System.Linq;
using NUDispSchedule.Main;

namespace NUDispSchedule.Core
{
    public static class Utilities
    {
        public static List<Lesson> GetDailySchedule(Schedule s, int groupId, DateTime date, bool limitToExactGroup = false)
        {
            List<Lesson> result;
            if (limitToExactGroup)
            {
                result = s.lessons
                    .Where(l =>
                        (l.TeacherForDiscipline.Discipline.StudentGroup.StudentGroupId == groupId) &&
                        (l.Calendar.Date == date))
                    .OrderBy(l => l.Ring.Time.TimeOfDay)
                    .ToList();
            }
            else
            {
                var studentIds = s.studentsInGroups
                    .Where(sig => sig.StudentGroup.StudentGroupId == groupId)
                    .Select(stig => stig.Student.StudentId)
                    .ToList();

                var groupIds = s.studentsInGroups
                    .Where(sig => studentIds.Contains(sig.Student.StudentId))
                    .Select(stig => stig.StudentGroup.StudentGroupId)
                    .Distinct()
                    .ToList();
               
                result = s.lessons
                    .Where(l =>
                        (groupIds.Contains(l.TeacherForDiscipline.Discipline.StudentGroup.StudentGroupId)) &&
                        (l.Calendar.Date.Date == date.Date) &&
                        (l.IsActive))
                    .OrderBy(l => l.Ring.Time.TimeOfDay)
                    .ToList();
               
            }

            return result;
        }
    }
}
