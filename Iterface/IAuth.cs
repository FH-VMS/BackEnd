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
    public interface IAuth
    {
        [Remark("添加权限模板", ParmsNote = "模板名称，权限对应关系", ReturnNote = "0 或 1")]
        int PostAuthTemplate(string name,int rank, List<MenuModel> lstAuthModel);

    }
}
