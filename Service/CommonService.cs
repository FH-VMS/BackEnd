using Interface;
using Model.Common;
using Model.User;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Service
{
    public class CommonService:AbstractService,ICommon
    {
        public List<MenuModel> GetMenus(string userAccount)
        {
            string sts = HttpContextHandler.GetHeaderObj("Sts").ToString();
            if (sts == "100")
            {
                var dic = new Dictionary<string, object>();
                var menuList = GenerateDal.Load<MenuModel>();
                var fatherList = from m in menuList
                                 where m.MenuFather == null || m.MenuFather == ""
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
            else
            {
                return null;
            }
           
        }

        public UserModel PostUser(UserModel userInfo)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("UserAccount", userInfo.UserAccount);
            dic.Add("UserPassword", userInfo.UserPassword);
            var userList = GenerateDal.Load<UserModel>(CommonSqlKey.GetLogin, dic);
            if (userList != null && userList.ToList<UserModel>().Count>0)
            {

                return userList[0];
            }
            else
            {
                return null;
            }
            
        }

    }
}
