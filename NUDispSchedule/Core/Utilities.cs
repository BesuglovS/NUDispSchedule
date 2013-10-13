using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NUDispSchedule.Main;
using IWshRuntimeLibrary;
using NUDispSchedule.Main.Others;

namespace NUDispSchedule.Core
{
    public static class Utilities
    {
        public static Dictionary<int,int> DOWEnToRu  = new Dictionary<int, int> 
            {{1,1},{2,2},{3,3},{4,4},{5,5},{6,6},{0,7}};
        public static Dictionary<int,int> DOWRuToEn  = new Dictionary<int, int> 
            {{1,1},{2,2},{3,3},{4,4},{5,5},{6,6},{7,0}};



        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation, string shortcutDescription)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = shortcutDescription;                                                             // The description of the shortcut
            shortcut.IconLocation = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase + ", 0";   // The icon of the shortcut            
            shortcut.TargetPath = targetFileLocation + " -Startup";                                                // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                                                                        // Save the shortcut
        }

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

        public static int WeekFromDate(DateTime date, DateTime semesterStarts)
        {
            return ((date - semesterStarts).Days / 7) + 1;
        }

        public static string GatherWeeksToString(List<int> weekArray)
        {
            var result = new List<string>();
            var boolWeeks = new bool[21];
        
            for(var i = 0; i <= 20; i++) {
                boolWeeks[i] = false;
            }

            foreach (var week in weekArray) {
                boolWeeks[week] = true;
            }

            bool prev = false;
            int baseNum = 20;
            for(var i = 0; i <= 19; i++)
            {
                if (!prev && boolWeeks[i])
                {
                    baseNum = i;
                }

                if (!boolWeeks[i] && ((i - baseNum) > 2))
                    {
                        result.Add(baseNum +  "-" + (i - 1));

                        for (var k = baseNum; k < i; k++)
                        {
                            boolWeeks[k] = false;
                        }
                    }

                    if (!boolWeeks[i])
                    {
                        baseNum = 20;
                    }

                    prev = boolWeeks[i];
            }

            prev = false;
            baseNum = 20;
            for(var i = 1; i <= 19; i += 2)
            {
                if (!prev && boolWeeks[i])
                {
                    baseNum = i;
                }

                if (!boolWeeks[i] && ((i - baseNum) > 4))
                {
                    result.Add(baseNum +  "-" + (i - 2) + " (нечёт.)");

                    for (var k = baseNum; k < i; k += 2)
                    {
                        boolWeeks[k] = false;
                    }
                }

                if (!boolWeeks[i])
                {
                    baseNum = 20;
                }

                prev = boolWeeks[i];
            }

            prev = false;
            baseNum = 20;
            for(var i = 2; i <= 20; i += 2)
            {
                if (!prev && boolWeeks[i])
                {
                    baseNum = i;
                }

                if (!boolWeeks[i] && ((i - baseNum) > 4))
                {
                    result.Add(baseNum +  "-" + (i - 2) + " (чёт.)");

                    for (var k = baseNum; k < i; k += 2)
                    {
                        boolWeeks[k] = false;
                    }
                }

                if (!boolWeeks[i])
                {
                    baseNum = 20;
                }

                prev = boolWeeks[i];
            }



            for (var i = 1; i <= 18; i++)
            {
                if (boolWeeks[i])
                {
                    result.Add(i.ToString(CultureInfo.InvariantCulture));
                }
            }

            result.Sort((a,b) =>
                            {
                                int aVal=-1, bVal=-1;
                                
                                if (a.Contains('-'))
                                {
                                    int.TryParse(a.Substring(0,a.IndexOf('-')), out aVal);
                                }
                                else
                                {
                                    int.TryParse(a, out aVal);
                                }

                                if (b.Contains('-'))
                                {
                                    int.TryParse(b.Substring(0, b.IndexOf('-')), out bVal);
                                }
                                else
                                {
                                    int.TryParse(b, out bVal);
                                }

                                if (aVal > bVal) return 1;
                                if (bVal > aVal) return -1;
                                return 0;
                            });

            var final = result.Aggregate((current, str) => current + ", " + str);
            return final;
        }
    }
}
