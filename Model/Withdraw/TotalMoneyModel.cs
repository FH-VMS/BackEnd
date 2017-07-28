using Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Withdraw
{
    [Table("table_total_money")]
    public class TotalMoneyModel
    {
        [Column(Name = "id")]
        public string Id
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

        [Column(Name = "ali_account")]
        public string AliAccount
        {
            get;
            set;
        }

        [Column(Name = "wx_account")]
        public string WxAccount
        {
            get;
            set;
        }

        [Column(Name = "total_money")]
        public float TotalMoney
        {
            get;
            set;
        }
    }
}
