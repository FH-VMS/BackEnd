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
            var auths = _IBase.GetAll(authInfo);

            IAuth iauth = new AuthService();
            foreach(var auth in auths)
            {
                auth.lstAuthRelate = iauth.GetAuthRelateByDmsId(auth.Id);
            }
           
            int totalcount = _IBase.GetCount(authInfo);

            var pagination = new Pagination { PageSize = pageSize, PageIndex = pageIndex, StartIndex = 0, TotalRows = totalcount, TotalPage = 0 };
            return Content(auths, pagination);
        }

        public ResultObj<int> PostData(string name,int rank ,List<MenuModel> lstAuthInfo)
        {
            IAuth iAuth = new AuthService();
            return Content(iAuth.PostAuthTemplate(name, rank, lstAuthInfo));
        }

        public ResultObj<int> PutData(string id,string name, int rank, List<MenuModel> lstAuthInfo)
        {
            IAuth iAuth = new AuthService();
            return Content(iAuth.UpdaetAuthTemplate(id, name, rank, lstAuthInfo));
        }

        public ResultObj<int> DeleteData(string idList)
        {
            return Content(_IBase.DeleteData(idList));
        }

        public ResultObj<List<AuthModel>> GetAuthDic()
        {
            IAuth iAuth = new AuthService();
            return Content(iAuth.GetAuthDic());
        }
    }
}
