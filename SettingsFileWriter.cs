using System;
using System.IO;
using Newtonsoft.Json;

namespace QGJSoft.SettingsFile
{
    public class SettingsFileWriter<T>
    {
        public static void Write(string settingsFileFullPath, T settingsData)
        {
            string jsonString = JsonConvert.SerializeObject(settingsData, Formatting.Indented);

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(settingsFileFullPath))
                {
                    streamWriter.Write(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
