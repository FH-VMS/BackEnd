using Interface;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CommonService:AbstractService,ICommon
    {
        public List<MenuModel> GetMenus(string userAccount)
        {
            var menuList = GenerateDal.Load<MenuModel>();
            var fatherList = from m in menuList
                             where m.MenuFather == null || m.MenuFather ==""
                             orderby m.MenuId
                             select m;
            foreach (MenuModel item in fatherList)
            {
                var menu = from m in menuList
                           where m.MenuFather == item.MenuId
                           select m;
                item.Menus = menu.ToList<MenuModel>();
            }
            return fatherList.ToList<MenuModel>();
        }

    }
}
