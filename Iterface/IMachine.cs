using Model.Machine;
using Model.Pay;
using Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface
{
    public interface IMachine
    {
        [Remark("根据机器取商品", ParmsNote = "", ReturnNote = "返回返页列表")]
        List<ProductForMachineModel> GetProductByMachine(ProductForMachineModel machineInfo);

        [Remark("根据机器取商品的总共数据", ParmsNote = "", ReturnNote = "返回返页列表")]
        int GetCount(ProductForMachineModel machineInfo);

        [Remark("微信支付结果回调", ParmsNote = "机器和货道和商品信息", ReturnNote = "void")]
        void PostPayResultW(KeyJsonModel keyJsonModel, string tradeNo);

        [Remark("支付宝支付结果回调", ParmsNote = "商品信息列表", ReturnNote = "void")]
        void PostPayResultA(List<ProductModel> listProductInfo);

        [Remark("判断是否已存在该单", ParmsNote = "商户交易号", ReturnNote = "int")]
        int GetCountByTradeNo(string tradeNo);
    }
}
