using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace QGJSoft.SettingsFile
{
    public static class SettingsFileValidator<T>
    {
        public static bool FileExists(string settingsFileFullPath)
        {
            return File.Exists(settingsFileFullPath);
        }

        public static bool IsValid(string settingsFileFullPath)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(settingsFileFullPath))
                {
                    var json = streamReader.ReadToEnd();
                    JObject obj = JObject.Parse(json);
                    var properties = typeof(T).GetProperties();
                    foreach (var property in properties)
                    {
                        if (obj[property.Name] == null)
                        {
                            throw new Exception($"{property.Name} is missing in the json");
                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
