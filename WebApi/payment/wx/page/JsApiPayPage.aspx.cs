using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Threading;
using LitJson;
using System.Web.Security;

namespace WxPayAPI
{
    public partial class JsApiPayPage : System.Web.UI.Page
    {
        public static string wxJsApiParam {get;set;} //H5调起JS API参数
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Info(this.GetType().ToString(), "page load");
            if (!IsPostBack)
            {
                 JsApiPay jsApiPay = new JsApiPay(this);
               
                 jsApiPay.GetOpenidAndAccessToken();
                //string openid = Request.QueryString["openid"];
                //string total_fee = Request.QueryString["total_fee"];
                string total_fee = "1";
                //检测是否给当前页面传递了相关参数
                

                //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数
               
                // jsApiPay.openid = openid;
                jsApiPay.total_fee = int.Parse(total_fee);
                if (string.IsNullOrEmpty(jsApiPay.openid) || string.IsNullOrEmpty(total_fee))
                {
                    Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面传参出错,请返回重试" + jsApiPay.openid + "</span>");
                    Log.Error(this.GetType().ToString(), "This page have not get params, cannot be inited, exit...");
                    submit.Visible = false;
                    return;
                }
                //JSAPI支付预处理
                try
                {
                    WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult();
                   
                    wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数       
                  
                    Log.Write(this.GetType().ToString(), "wxJsApiParam : " + wxJsApiParam);
                    //在页面上显示订单信息
                    Response.Write("<span style='color:#00CD00;font-size:20px'>订单详情：</span><br/>");
                    Response.Write("<span style='color:#00CD00;font-size:20px'>" + unifiedOrderResult.ToPrintStr() + "</span>");

                }
                catch(Exception ex)
                {
                    Response.Write("<span style='color:#FF0000;font-size:20px'>" + "下单失败，请返回重试" + "</span>");
                    submit.Visible = false;
                }
            }
        }
    }
}