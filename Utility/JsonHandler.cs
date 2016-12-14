using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Utility
{
    public class JsonHandler
    {
        public static T GetObjectFromJson<T>(string jsonStr)
        {
            if (String.IsNullOrEmpty(jsonStr)) jsonStr = "[]";
            if (jsonStr.IndexOf("%7b") >= 0 || jsonStr.IndexOf("%7d") >= 0 || jsonStr.ToUpper().IndexOf("%E") >= 0)
            {
                jsonStr = HttpUtility.UrlDecode(jsonStr);
            }
            return JsonConvert.DeserializeObject<T>(jsonStr, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public static T GetTryObjectFromJson<T>(string jsonStr, out bool isSuccess)
        {
            try
            {
                isSuccess = true;
                return GetObjectFromJson<T>(jsonStr);
            }
            catch (Exception)
            {
                isSuccess = false;
                return Activator.CreateInstance<T>();
            }
        }


        public static string GetJsonStrFromObject(object o)
        {
            return GetJsonStrFromObject(o, true);
        }

        public static string GetJsonStrFromObject(object o, bool needEncode)
        {
            var jsonSeriaSetting = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
            };

            var str = JsonConvert.SerializeObject(o, jsonSeriaSetting);
            return needEncode ? HttpUtility.UrlEncode(str) : str;
        }
    }
}
