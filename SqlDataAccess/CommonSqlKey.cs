using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataAccess
{
    public enum CommonSqlKey
    {
        Null,
        Sql,
        GetUser,
        GetUserCount,
        UpdateUser,
        DeleteUser,
        GetLogin,

        UpdateCustomer,
        DeleteCustomer,
        GetCustomer,
        GetCustomerCount,

        //权限
        GetAuthCount,
        DeleteAuth,
        UpdateAuth,
        GetAuth
    }
}
