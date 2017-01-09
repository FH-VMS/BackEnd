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
        GetClientDic,
        GetAuthDic,

        UpdateCustomer,
        DeleteCustomer,
        GetCustomer,
        GetCustomerCount,
        GetCustomerForSys,
        GetCustomerCountForSys,
        UpdateChildCustomer,

        //权限
        GetAuthCount,
        DeleteAuth,
        UpdateAuth,
        GetAuth,
        GetAuthByDmsId,
        GetMenuByUser,
        DeleteAuthRelate,
        GetRankValue,

        //公用模块
        GetDic,
        GetRank,
        GetUserByClientId,
        GetMachineDic,
        GetCabinetByMachineId,
        GetPictureDic,
        GetProductDic,

        //机型
        GetMachineType,
        GetMachineTypeCount,
        DeleteMachineType,
        UpdateMachineType,

        //机器列表
        GetMachineList,
        GetMachineListCount,
        DeleteMachineList,
        UpdateMachineList,
        GetMachineTypeDic,

        //机器配置
        GetMachineConfig,
        GetMachineConfigCount,
        DeleteMachineConfig,
        UpdateMachineConfig,

        //货道配置
        GetTunnelConfigCount,
        GetTunnelConfig,
        GetCabinetConfig,
        DeleteTunnelConfig,
        UpdateTunnelConfig,

        //商品列表
        GetProductList,
        GetProductListCount,
        DeleteProductList,
        UpdateProductList,

        //图片资源
        GetPictureList,
        GetPictureListCount,
        UpdatePictureList,
        DeletePictureList
    }
}
