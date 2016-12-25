using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Utility
{
    public class HttpContextHandler
    {

        public static string GetClientIPv4(HttpRequest request)
        {
            if (request == null) return String.Empty;
            var result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];//todo 可以隔过代理IP获得真实IP
            if (string.IsNullOrEmpty(result)) { result = request.ServerVariables["REMOTE_ADDR"]; }
            if (string.IsNullOrEmpty(result)) { result = request.UserHostAddress; }
            if (string.IsNullOrEmpty(result)) { result = "0.0.0.0"; }
            return result;
        }

        public static string GetClientHostName(HttpRequest request)
        {
            if (request == null) return String.Empty;
            var result = request.ServerVariables["REMOTE_HOST"];
            if (string.IsNullOrEmpty(result)) { result = request.UserHostName; }
            return result;
        }

        public static string GetClientBrowserType(HttpRequest request)
        {
            if (request == null) return String.Empty;
            var result = request.Browser.Type;
            return result;
        }

        public static string GetClientBrowserVersion(HttpRequest request)
        {
            if (request == null) return String.Empty;
            var result = request.Browser.Version;
            return result;
        }

        public static string GetClientBrowserResolution(HttpRequest request)
        {
            if (request == null) return String.Empty;
            var result = string.Format("{0}*{1}", request.Form["WidthPixel"], request.Form["HeightPixel"]);
            return result;
        }

        public static string GetClientPlatform(HttpRequest request)
        {
            if (request == null) return String.Empty;
            var result = request.Browser.Platform;
            return result;
        }

        public static string GetClrVersion(HttpRequest request)
        {
            if (request == null) return String.Empty;
            var version = request.Browser.ClrVersion;
            var result = version == null ? String.Empty : version.ToString();
            return result;
        }

        public static void AddCookie(string key, string value)
        {
            var httpCookie = new HttpCookie(key) { Value = value };
            if (HttpContext.Current != null)
                HttpContext.Current.Response.Cookies.Add(httpCookie);
        }

        public static string GetCookie(string key)
        {
            if (HttpContext.Current != null)
            {
                var cookie = HttpContext.Current.Request.Cookies[key];
                if (cookie != null)
                    return cookie.Value;
            }
            return String.Empty;
        }

        public static object GetHeaderObj(string key)
        {
            var wiiCookies = HttpContext.Current.Request.Headers["fh-cookies"];
            if (wiiCookies == null) return null;
            var cookies = JsonHandler.GetObjectFromJson<Dictionary<string, object>>(wiiCookies);
            return cookies.ContainsKey(key) ? cookies[key] : null;
        }


        private static string _sysOperator;

        /// <summary>
        /// 系统当前操作人，一般是登陆人
        /// </summary>
        public static string SysOperator
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return _sysOperator;
                }
                _sysOperator = GetHeaderObj("CurSysOperator") as string;
                return _sysOperator;
            }
            set
            {
                _sysOperator = value;
                if (HttpContext.Current != null)
                {
                    AddCookie("CurSysOperator", value);
                }
            }
        }
    }
}
