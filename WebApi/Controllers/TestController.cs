using PaymentLib.wx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chuang.Back.Controllers
{
    public class TestController : ApiController
    {
        public string GetTestWpay()
        {
            WxPayData jsApiParam = new WxPayData();
            jsApiParam.SetValue("mch_id", "mch_id");
            jsApiParam.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
            jsApiParam.SetValue("sign", jsApiParam.MakeSign());

            return HttpService.Post(jsApiParam.ToXml(), "https://apitest.mch.weixin.qq.com/sandboxnew/pay/getsignkey", true, 5000);
        
        }
    }
}