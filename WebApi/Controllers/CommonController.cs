using Chuang.Back.Base;
using Interface;
using Model.Common;
using Model.Sys;
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
            ServiceInfoHelper.WriteWebAPI();
            ServiceInfoHelper.WriteWebModels();
            return Content(1);
        }
    }
}
