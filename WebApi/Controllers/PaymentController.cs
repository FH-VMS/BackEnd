using Chuang.Back.Base;
using Model.Pay;
using Model.Product;
using Model.Sys;
using Payment.wx;
using PaymentLib.wx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Chuang.Back.Controllers
{
    public class PaymentController : ApiBaseController
    {
        public string PostPayNow()
        {
            //NativePay nativePay = new NativePay();


            //生成扫码支付模式二url
            //string url2 = nativePay.GetPayUrl("123456789");

            return null;
        }

        public ResultObj<PayStateModel> GetData(string k, string code)
        {
            //解码机器传过来的key值
            AnalizeKey(k);

            JsApi.payInfo = new PayModel();
            JsApi.payInfo.k = k;
            Log.Debug(this.GetType().ToString(), "Get k : " + k + "get code:" + code);
            //生成code 根据code取微信支付的openid和access_token
            JsApi.GetOpenidAndAccessToken(code);
            string total_fee = "1";
            //检测是否给当前页面传递了相关参数


            //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数

            // jsApiPay.openid = openid;
            JsApi.payInfo.total_fee = int.Parse(total_fee);
            PayStateModel payState = new PayStateModel();
            if (string.IsNullOrEmpty(JsApi.payInfo.openid) || string.IsNullOrEmpty(total_fee))
            {
                payState.RequestState = "0";
                payState.ProductJson = "";
                payState.RequestData = JsApi.payInfo.redirect_url;
                return Content(payState);
            }

            //JSAPI支付预处理
            try
            {
                WxPayData unifiedOrderResult = JsApi.GetUnifiedOrderResult();

                string wxJsApiParam = JsApi.GetJsApiParameters();//获取H5调起JS API参数       
                payState.RequestState = "1";
                payState.ProductJson = "";
                payState.RequestData = wxJsApiParam;
                
                return Content(payState);

            }
            catch (Exception ex)
            {
                
            }
            return Content(new PayStateModel());
        }

        //对k进行解码
        private void AnalizeKey(string key)
        {

        }
    }
}