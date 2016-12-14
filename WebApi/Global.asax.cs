using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Chuang.Back
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Request.ContentEncoding = Encoding.UTF8;
            //2015/12/11 下面的设置放到Web.config中，解决跨域问题
            //var origin = HttpContext.Current.Request.Headers["Origin"];
            //HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", string.IsNullOrEmpty(origin) ? "*" : origin);
            //var requestHeaders = HttpContext.Current.Request.Headers["Access-Control-Request-Headers"];
            //HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Headers", string.IsNullOrEmpty(requestHeaders) ? "*" : requestHeaders);
            //HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Methods", "PUT,POST,GET,OPTIONS,DELETE,*");
            if (HttpContext.Current.Request.HttpMethod.ToUpper().Equals("OPTIONS"))
            {
                HttpContext.Current.Response.End();
            }
        }

        protected void Application_End()
        {
        }
    }
}
