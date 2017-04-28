using Interface;
using Model.Machine;
using Model.Pay;
using Model.Sale;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class MachineService : AbstractService, IMachine
    {
        public List<ProductForMachineModel> GetProductByMachine(ProductForMachineModel machineInfo)
        {
            var conditions = new List<Condition>();

            if (!string.IsNullOrEmpty(machineInfo.MachineId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "MachineId",
                    DbColumnName = "a.machine_id",
                    ParamValue = machineInfo.MachineId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }

            conditions.AddRange(CreatePaginConditions(machineInfo.PageIndex, machineInfo.PageSize));
            return GenerateDal.LoadByConditions<ProductForMachineModel>(CommonSqlKey.GetProductByMachine, conditions);


        }



        public int GetCount(ProductForMachineModel machineInfo)
        {
            var result = 0;

         
            var conditions = new List<Condition>();
            if (!string.IsNullOrEmpty(machineInfo.MachineId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "MachineId",
                    DbColumnName = "a.machine_id",
                    ParamValue = machineInfo.MachineId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }


            result = GenerateDal.CountByConditions(CommonSqlKey.GetProductByMachineCount, conditions);

            return result;
        }


        //微信支付结果插入数据库
        public void PostPayResultW(KeyJsonModel keyJsonModel, string tradeNo)
        {
            try
            {
                GenerateDal.BeginTransaction();

                foreach (KeyTunnelModel keyTunnelInfo in keyJsonModel.t)
                {
                    SaleModel saleInfo = new SaleModel();
                    saleInfo.SalesIcId = Guid.NewGuid().ToString();
                    saleInfo.MachineId = keyJsonModel.m;
                    saleInfo.SalesDate = DateTime.Now;
                    saleInfo.SalesNumber = string.IsNullOrEmpty(keyTunnelInfo.n) ? 1 : Convert.ToInt32(keyTunnelInfo.n);
                    saleInfo.PayDate = DateTime.Now;
                    saleInfo.PayInterface = "微信";
                    saleInfo.TradeNo = tradeNo;
                    saleInfo.GoodsId = keyTunnelInfo.tid;
                    saleInfo.TradeStatus = 1;
                    saleInfo.TradeAmount = Convert.ToDouble(keyTunnelInfo.p);
                    GenerateDal.Create(saleInfo);
                }
                
                GenerateDal.CommitTransaction();

            }
            catch (Exception e)
            {
                GenerateDal.RollBack();
            }


        }

        //支付宝支付结果插入数据库
        public void PostPayResultA(List<ProductModel> listProductInfo)
        {
            try
            {
                GenerateDal.BeginTransaction();

                foreach (ProductModel keyTunnelInfo in listProductInfo)
                {
                    SaleModel saleInfo = new SaleModel();
                    saleInfo.SalesIcId = Guid.NewGuid().ToString();
                    saleInfo.MachineId = keyTunnelInfo.MachineId;
                    saleInfo.SalesDate = DateTime.Now;
                    saleInfo.SalesNumber = string.IsNullOrEmpty(keyTunnelInfo.Num) ? 1 : Convert.ToInt32(keyTunnelInfo.Num);
                    saleInfo.PayDate = DateTime.Now;
                    saleInfo.PayInterface = "支付宝";
                    saleInfo.TradeNo = keyTunnelInfo.TradeNo;
                    saleInfo.GoodsId = keyTunnelInfo.TunnelId;
                    saleInfo.TradeStatus = 1;
                    saleInfo.TradeAmount = Convert.ToDouble(keyTunnelInfo.UnitA);
                    GenerateDal.Create(saleInfo);
                }

                GenerateDal.CommitTransaction();

            }
            catch (Exception e)
            {
                GenerateDal.RollBack();
            }


        }

        //是否已存在此单
        public int GetCountByTradeNo(string tradeNo)
        {
            var result = 0;


            var conditions = new List<Condition>();
            conditions.Add(new Condition
            {
                LeftBrace = " AND ",
                ParamName = "TradeNo",
                DbColumnName = "trade_no",
                ParamValue = tradeNo,
                Operation = ConditionOperate.Equal,
                RightBrace = "",
                Logic = ""
            });

            result = GenerateDal.CountByConditions(CommonSqlKey.GetCountByTradeNo, conditions);

            return result;
        }



       
    }
}
