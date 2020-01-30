using System;
using System.Net;
using Newtonsoft.Json;

namespace ShowImageFromJason
{
    class APIHelper
    {
       public APIHelper() { }
      
        public  T DownloadAPIjson<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;               
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }               
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
        
    }
}
