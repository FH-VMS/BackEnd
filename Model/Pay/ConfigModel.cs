using Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Pay
{
    [Table("table_mobile_pay_config")]
    public class ConfigModel
    {
        [Column(Name = "id")]
        public string Id
        {
            get;
            set;
        }

        [Column(Name = "name")]
        public string Name
        {
            get;
            set;
        }

        [Column(Name = "ali_parter")]
        public string AliParter
        {
            get;
            set;
        }

        [Column(Name = "ali_key")]
        public string AliKey
        {
            get;
            set;
        }

        [Column(Name = "ali_refund_appid")]
        public string AliRefundAppId
        {
            get;
            set;
        }

        [Column(Name = "ali_refund_rsa_sign")]
        public string AliRefundRsaSign
        {
            get;
            set;
        }

        [Column(Name = "wx_appid")]
        public string WxAppId
        {
            get;
            set;
        }

        [Column(Name = "wx_mchid")]
        public string WxMchId
        {
            get;
            set;
        }

        [Column(Name = "wx_key")]
        public string WxKey
        {
            get;
            set;
        }

        [Column(Name = "wx_app_secret")]
        public string WxAppSecret
        {
            get;
            set;
        }

        [Column(Name = "wx_sslcert_path")]
        public string WxSslcertPath
        {
            get;
            set;
        }

        [Column(Name = "wx_sslcert_password")]
        public string WxSslcertPassword
        {
            get;
            set;
        }

        [Column(Name = "client_id")]
        public string ClientId
        {
            get;
            set;
        }

        public int PageIndex
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

    }
}
