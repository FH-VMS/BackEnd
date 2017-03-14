using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WxPayAPI;

namespace Chuang.Back.Controllers
{
    public class PaymentController : ApiController
    {
        public string PostPayNow()
        {
            NativePay nativePay = new NativePay();


            //生成扫码支付模式二url
            string url2 = nativePay.GetPayUrl("123456789");

            return url2;
        }
    }
}