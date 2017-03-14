using Chuang.Back.Base;
using Model.Sys;
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
    }
}
