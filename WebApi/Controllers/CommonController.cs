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
using Utility;

namespace Chuang.Back.Controllers
{
    public class CommonController : ApiBaseController
    {
        public ResultObj<List<MenuModel>> GetMenus()
        {
            ICommon menusService = new CommonService();
            var menuList = menusService.GetMenus("");
            return Content(menuList);
        }

        public ResultObj<int> GetWebAPIAndModel()
        {
            // ServiceInfoHelper.WriteWebAPI();
            ServiceInfoHelper.WriteWebModels();
            return Content(1);
        }

        public ResultObj<UserModel> PostLogin(UserModel userInfo)
        {
            ICommon common = new CommonService();
            var user = common.PostUser(userInfo);
            if (user == null)
            {
                return Content(new UserModel(), ResultCode.NoAccess, "用户名密码不正确！");
            }
            else
            {
                return Content(user);
            }
            
        }

        public ResultObj<List<DicModel>> GetDic(string id)
        {
            ICommon menusService = new CommonService();
            return Content(menusService.GetDic(id));
        }

        public ResultObj<List<DicModel>> GetRank(string id)
        {
            ICommon menusService = new CommonService();
            return Content(menusService.GetRank(id));
        }


    }
}
