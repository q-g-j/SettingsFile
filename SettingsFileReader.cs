using Newtonsoft.Json;
using System;
using System.IO;

namespace QGJSoft.SettingsFile
{
    public static class SettingsFileReader<T>
    {
        public static T Load(string settingsFileFullPath)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(settingsFileFullPath))
                {
                    return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
