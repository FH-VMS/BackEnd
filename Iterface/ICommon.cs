using Model.Common;
using Model.Sys;
using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface ICommon
    {
        [Remark("取数据列表", ParmsNote = "当前页,每页显示行数", ReturnNote = "返回返页列表")]
        List<MenuModel> GetMenus(string userAccount);

        [Remark("取数据列表", ParmsNote = "当前页,每页显示行数", ReturnNote = "返回返页列表")]
        UserModel PostUser(UserModel userInfo);
    }
}
