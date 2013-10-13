using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUDispSchedule.Core
{
    public static class Constants
    {
        public static Dictionary<int, string> DOWRU = new Dictionary<int, string>
            {
                {1, "Понедельник"},
                {2, "Вторник"},
                {3, "Среда"},
                {4, "Четверг"},
                {5, "Пятница"},
                {6, "Суббота"},
                {7, "Воскресенье"},
            };
    }
}
