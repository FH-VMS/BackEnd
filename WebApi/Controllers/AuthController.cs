using Chuang.Back.Base;
using Interface;
using Model.Common;
using Model.Sys;
using Model.User;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chuang.Back.Controllers
{
    public class AuthController : ApiBaseController
    {
        private static IBase<AuthModel> _IBase
        {
            get
            {
                return new AuthService();
            }
        }

        public ResultObj<List<AuthModel>> GetData(int pageIndex = 1, int pageSize = 10)
        {
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();
            AuthModel authInfo = new AuthModel();
           
            authInfo.PageIndex = pageIndex;
            authInfo.PageSize = pageSize;
            var users = _IBase.GetAll(authInfo);
            int totalcount = _IBase.GetCount(authInfo);

            var pagination = new Pagination { PageSize = pageSize, PageIndex = pageIndex, StartIndex = 0, TotalRows = totalcount, TotalPage = 0 };
            return Content(users, pagination);
        }

        public ResultObj<int> PostData(string name,int rank ,List<MenuModel> lstAuthInfo)
        {
            IAuth iAuth = new AuthService();
            return Content(iAuth.PostAuthTemplate(name, rank, lstAuthInfo));
        }

        public ResultObj<int> PutData(AuthModel authInfo)
        {
            return Content(_IBase.UpdateData(authInfo));
        }

        public ResultObj<int> DeleteData(string idList)
        {
            return Content(_IBase.DeleteData(idList));
        }
    }
}
