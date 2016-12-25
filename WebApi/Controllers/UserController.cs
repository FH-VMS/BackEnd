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
    public class UserController : ApiBaseController
    {
        private static IBase<UserModel> _IBase
        {
            get
            {
                return new UserServicee();
            }
        }

        public ResultObj<List<UserModel>> GetData(string userAccount="", string userName="", int pageIndex =1, int pageSize=10)
        {
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();

            UserModel userInfo = new UserModel();
            userInfo.UserName = userName;
            userInfo.UserAccount = userAccount;
            userInfo.PageIndex = pageIndex;
            userInfo.PageSize = pageSize;
            var users = _IBase.GetAll(userInfo);
            int totalcount = _IBase.GetCount(userInfo);

            var pagination = new Pagination { PageSize = pageSize, PageIndex = pageIndex, StartIndex = 0, TotalRows = totalcount, TotalPage = 0 };
            return Content(users, pagination);
        }

        public ResultObj<int> PostData(UserModel userInfo)
        {
            userInfo.CreateDate = DateTime.Now;
            return Content(_IBase.PostData(userInfo));
        }

        public ResultObj<int> PutData(UserModel userInfo)
        {
            userInfo.CreateDate = DateTime.Now;
            return Content(_IBase.UpdateData(userInfo));
        }

        public ResultObj<int> DeleteData(string idList)
        {
            return Content(_IBase.DeleteData(idList));
        }

        public ResultObj<List<CommonDic>> GetClientDic()
        {
            ICommon iCommon = new CommonService();
            return Content(iCommon.GetClientDic());
        }

        public ResultObj<List<CommonDic>> GetAuthDic()
        {
            ICommon iCommon = new CommonService();
            return Content(iCommon.GetAuthDic());
        }

    }
}
