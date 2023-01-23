using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QGJSoft.SettingsFile
{
    public static class SettingsFileCreator<T> where T : new()
    {
        public static void Create(string settingsFolderFullPath, string settingsFileFullPath)
        {
            try
            {
                Directory.CreateDirectory(settingsFolderFullPath);
                T settingsData = new T();
                using (StreamWriter streamWriter = new StreamWriter(settingsFileFullPath, false))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(settingsData, Formatting.Indented));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
