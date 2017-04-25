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
        GetCabinetDic,
        GetProductDicAll,

        //机型
        GetMachineType,
        GetMachineTypeCount,
        DeleteMachineType,
        UpdateMachineType,
        GetCabinetByMachineTypeId,
        DeleteMachineTypeAndCabinet,

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
        GetProductAllList,
        GetProductListAllCount,

        //商品配置
        GetProductConfigAll,
        GetProductConfig,
        GetProductConfigAllCount,
        GetProductConfigCount,
        DeleteProductConfig,
        UpdateProductConfig,

        //图片资源
        GetPictureList,
        GetPictureListCount,
        UpdatePictureList,
        DeletePictureList,

        //销售
        UpdateSale,
        GetPayResultById,
        DeleteSaleList,
        GetSaleAllList,
        GetSaleList,
        GetSaleListAllCount,
        GetSaleListCount,

        //货道信息
        GetTunnelInfoCount,
        GetTunnelInfo,
        DeleteTunnelInfo,
        UpdateTunnelInfo,

        //机器对应接口
        GetProductByMachine,
        GetProductByMachineCount,
        //支付对应接口
        GetProductInfo
    }
}
