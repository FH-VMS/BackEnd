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
        DataTable GetSalesAmountByMachine(string salesDateStart, string salesDateEnd, bool needPage, int pageIndex, int pageSize);
    }
}
