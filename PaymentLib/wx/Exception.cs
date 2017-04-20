using System;
using System.Collections.Generic;
using System.Web;

namespace PaymentLib.wx
{
    public class WxPayException : Exception 
    {
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}