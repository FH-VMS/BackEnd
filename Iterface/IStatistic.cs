using Model.Sale;
using Model.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Interface
{
    public interface IStatistic
    {
        //取机器的销售额
         [Remark("取机器的销售额", ParmsNote = "", ReturnNote = "DataTable")]
        DataTable GetSalesAmountByMachine(string salesDateStart, string salesDateEnd, bool needPage, int pageIndex, int pageSize);

        [Remark("统计销售额根据销售日期", ParmsNote = "", ReturnNote = "DataTable")]
        DataTable GetStatisticSalesMoneyByDate(SaleModel saleInfo);
    }
}
