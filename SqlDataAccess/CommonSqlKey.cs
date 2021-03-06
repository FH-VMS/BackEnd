﻿using System;
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
        CheckUserExist,

        //用户设置
        ChangePassword,

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
        CheckMachineId,
        GetMachineNameById,
        GetPayConfigDic,

        //机型
        GetMachineType,
        GetMachineTypeCount,
        DeleteMachineType,
        UpdateMachineType,
        GetCabinetByMachineTypeId,
        DeleteMachineTypeAndCabinet,
        //机柜
        GetMachineCabinet, 
        GetCabinetCount,
        DeleteMachineCabinet,
        UpdateMachineCabinet,

        //机器列表
        GetMachineList,
        GetMachineListCount,
        DeleteMachineList,
        UpdateMachineList,
        GetMachineTypeDic,
        GetMachineCountWithStatus,

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
        GetPriceByWaresId,
        UpdateTunnelPrice,

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
        GetClientIds,
        GetChildAndParentIds,
        GetClientParentIds,
        GetRefundDetail,

        //货道信息
        GetTunnelInfoCount,
        GetTunnelInfo,
        DeleteTunnelInfo,
        UpdateTunnelInfo,
        UpdateTunnelConfigStatus,
        GenerateFullfilBill,
        GetFullfilCount,
        UpdateTunnelCurrStock,
        ExportByTunnel,
        ExportByProduct,

        //机器对应接口
        GetProductByMachine,
        GetProductByMachineCount,
        GetCountByTradeNo,
        UpdatePayResult,
        DeleteTunnelStatusByMachine,
        FullfilGoodsOneKey,
        IsExistTunnelInfo,
        UpdateFullfilGoodsOneKey,
        DeleteTunnelStatusByMachineAndTunnel,
        GetBeepHeart,
        DeleteToMachine,
        ToMachinePrice,
        ToMachineStock,
        PostPriceAndMaxStock,
        GetMachineSetting,
        UpdateCurrStock,
        UpdateAddCurrStock,
        UpdateMaxPuts,
        UpdatePrice,
        UpdateMachineInlineTime,
        UpdateMachineInlineTimeAndIpv4,
        GetCabinetId,
        GetSalesByNo,
        //支付对应接口
        GetProductInfo,
        GetProductInfoByWaresId,
        GetRefundData,
        UpdateRefundResult,
        UpdateOrderStatusForAli,
        IsRefundSucceed,
        GetMachineByMachineId,
        GetPayConfig,

        //总额及提现记录
        GetTotalMoneyByClient,
        //统计
        GetSalesAmountByMachine,
        GetSalesAmountByMachineCount,
        GetStatisticSalesMoneyByDate,

        //支付配置
        GetPayConfigList,
        GetPayConfigListCount,
        DeletePayConfig,
        UpdatePayConfig
    }
}
