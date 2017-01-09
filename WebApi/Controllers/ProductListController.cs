using Chuang.Back.Base;
using Interface;
using Model.Product;
using Model.Sys;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chuang.Back.Controllers
{
    public class ProductListController : ApiBaseController
    {

        private static IBase<ProductListModel> _IBase
        {
            get
            {
                return new ProductListService();
            }
        }

        public ResultObj<List<ProductListModel>> GetData(string waresName = "", string waresTypeId = "", int pageIndex = 1, int pageSize = 10)
        {
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();

            ProductListModel productListInfo = new ProductListModel();
            productListInfo.WaresName = waresName;
            productListInfo.WaresTypeId = waresTypeId;
            productListInfo.PageIndex = pageIndex;
            productListInfo.PageSize = pageSize;
            var users = _IBase.GetAll(productListInfo);
            int totalcount = _IBase.GetCount(productListInfo);

            var pagination = new Pagination { PageSize = pageSize, PageIndex = pageIndex, StartIndex = 0, TotalRows = totalcount, TotalPage = 0 };
            return Content(users, pagination);
        }

        public ResultObj<int> PostData(ProductListModel productListInfo)
        {
            return Content(_IBase.PostData(productListInfo));
        }

        public ResultObj<int> PutData(ProductListModel productListInfo)
        {
            return Content(_IBase.UpdateData(productListInfo));
        }

        public ResultObj<int> DeleteData(string idList)
        {
            return Content(_IBase.DeleteData(idList));
        }
    }
}
