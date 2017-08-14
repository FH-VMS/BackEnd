using Chuang.Back.Base;
using Interface;
using Model.Sys;
using Model.Withdraw;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chuang.Back.Controllers
{
    public class TotalMoneyController : ApiBaseController
    {
        private static IBase<TotalMoneyModel> _IBase
        {
            get
            {
                return new TotalMoneyService();
            }
        }
        public ResultObj<List<TotalMoneyModel>> GetData()
        {
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();
            TotalMoneyModel totalMoneyInfo = new TotalMoneyModel();

            var data = _IBase.GetAll(totalMoneyInfo);
            return Content(data);
        }
    }
}