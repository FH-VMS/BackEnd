using Chuang.Back.Base;
using Interface;
using Model.Sys;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Utility;

namespace Chuang.Back.Controllers
{
    public class HomeController : ApiBaseController
    {
        public IEnumerable<RemoteServiceEntity> GetAllProducts()
        {
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();

            var servicelist = ServiceInfoHelper.RemoteServiceList;
            return servicelist;
        }

        //机器 状态数
        public ResultObj<string> GetTotalMachineCount()
        {
            ICommon icommon = new CommonService();
            string retutStr = JsonHandler.DataTable2Json(icommon.GetTotalMachineCount());
            return Content(retutStr);
        }


        //机器 销售额
        public ResultObj<string> GetSalesAmountByMachine(string salesDateStart="", string salesDateEnd="", bool needPage=false,  int pageIndex = 1, int pageSize = 10)
        {
            IStatistic istatistic = new StatisticService();
            string retutStr = JsonHandler.DataTable2Json(istatistic.GetSalesAmountByMachine(salesDateStart,salesDateEnd,needPage,pageSize,pageIndex));
            return Content(retutStr);
        }
    }
}
