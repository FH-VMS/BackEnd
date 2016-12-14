using Chuang.Back.Base;
using Interface;
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
        private static IBase<UserModel> _User
        {
            get
            {
                return new UserServicee();
            }
        }

        public ResultObj<List<UserModel>> GetUser(string userAccount="", string userName="", int pageIndex =1, int pageSize=10)
        {
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();
            UserModel userInfo = new UserModel();
            userInfo.UserName = userName;
            userInfo.UserAccount = userAccount;
            userInfo.PageIndex = pageIndex;
            userInfo.PageSize = pageSize;
            var users = _User.GetAll(userInfo);
            int totalcount = _User.GetCount(userInfo);

            var pagination = new Pagination { PageSize = pageSize, PageIndex = pageIndex, StartIndex = 0, TotalRows = totalcount, TotalPage = 0 };
            return Content(users, pagination);
        }

        public ResultObj<int> PostUser(UserModel userInfo)
        {
            userInfo.CreateDate = DateTime.Now;
            return Content(_User.PostData(userInfo));
        }

        public ResultObj<int> PutUser(UserModel userInfo)
        {
            userInfo.CreateDate = DateTime.Now;
            return Content(_User.UpdateData(userInfo));
        }

        public ResultObj<int> DeleteUser(string id)
        {
            return Content(_User.DeleteData(id));
        }
    }
}
