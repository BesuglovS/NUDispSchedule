using System.Collections.Generic;
using System.IO;

namespace NUDispSchedule.Core
{
    public static class SettingsCore
    {
        public static Dictionary<string, string> Data { get; set; }

        public static void AddOrUpdateSetting(string key, string value)
        {
            if (!Data.ContainsKey(key))
            {
                Data.Add(key, "");
            }
            Data[key] = value;
        }

        public static void ReadSettings()
        {
            if (!File.Exists("settings.txt"))
            {
                SetDefaultData();
                return;
            }

            Data = new Dictionary<string, string>();
            var sr = new StreamReader("settings.txt");
            string line;
            while((line = sr.ReadLine()) != null)
            {
                var key = line.Split('=')[0].TrimEnd(' ');
                string value = "";
                if (line.Split('=').Length > 1)
                {
                    value = line.Split('=')[1].TrimStart(' ');
                }

                Data.Add(key, value);
            }
        }

        public static void SaveSettings()
        {
            var sw = new StreamWriter("settings.txt");
            foreach (var kvp in Data)
            {
                sw.WriteLine(kvp.Key + " = " + kvp.Value);
            }
            sw.Close();
        }

        public static void SetDefaultData()
        {
            Data = new Dictionary<string, string> { { "saveGroup", "Save" }, { "saveDate", "1" } };
        }
    }
}
