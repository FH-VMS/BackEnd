using Interface;
using Model.Machine;
using Model.Pay;
using Model.Sale;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utility;

namespace Service
{
    public class MachineService : AbstractService, IMachine
    {
        //取商品列表
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
            conditions.Add(new Condition
            {
                LeftBrace = "  ",
                ParamName = "TunnelId",
                DbColumnName = "tunnel_id",
                ParamValue = "asc",
                Operation = ConditionOperate.OrderBy,
                RightBrace = "",
                Logic = ""
            });
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
                    saleInfo.PayType = "微信";
                    saleInfo.TradeNo = tradeNo;
                    saleInfo.GoodsId = keyTunnelInfo.tid;
                    saleInfo.TradeStatus = 1;
                    saleInfo.TradeAmount = Convert.ToDouble(keyTunnelInfo.p);
                    GenerateDal.Create(saleInfo);
                    //更新存存
                    UpdateCurrStock(keyJsonModel.m, keyTunnelInfo.tid, saleInfo.SalesNumber);
                }
                
                GenerateDal.CommitTransaction();

            }
            catch (Exception e)
            {
                GenerateDal.RollBack();
            }


        }

        //支付宝支付结果插入数据库
        public int PostPayResultA(KeyJsonModel keyJsonModel, string tradeNo)
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
                    saleInfo.PayInterface = "支付宝";
                    saleInfo.PayType = "支付宝";
                    saleInfo.TradeNo = tradeNo;
                    saleInfo.GoodsId = keyTunnelInfo.tid;
                    saleInfo.TradeStatus = 1;
                    saleInfo.TradeAmount = Convert.ToDouble(keyTunnelInfo.p);
                    GenerateDal.Create(saleInfo);
                    //更新存存
                    UpdateCurrStock(keyJsonModel.m, keyTunnelInfo.tid, saleInfo.SalesNumber);
                }

                GenerateDal.CommitTransaction();
                return 1;

            }
            catch (Exception e)
            {
                GenerateDal.RollBack();
                return 0;
            }


        }

        private void UpdateCurrStock(string machineId, string tunnelId, int saleNumber)
        {
            TunnelInfoModel tunnelInfo = new TunnelInfoModel();
            tunnelInfo.MachineId = machineId;
            tunnelInfo.GoodsStuId = tunnelId;
            tunnelInfo.CurrStock = saleNumber;
            GenerateDal.Execute(CommonSqlKey.UpdateCurrStock, tunnelInfo);
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

        //上报出货结果  更新销售表状态
        public int PutPayResult(KeyJsonModel keyJsonInfo)
        {
            try
            {
                GenerateDal.BeginTransaction();

                foreach (KeyTunnelModel keyTunnelInfo in keyJsonInfo.t)
                {
                    SaleModel saleInfo = new SaleModel();
                    saleInfo.SalesDate = DateTime.Now;
                    saleInfo.GoodsId = keyTunnelInfo.tid;
                    saleInfo.MachineId = keyJsonInfo.m;
                    saleInfo.TradeNo = keyTunnelInfo.tn;
                    saleInfo.RealitySaleNumber = Convert.ToInt32(keyTunnelInfo.n);
                    saleInfo.TradeStatus = Convert.ToInt32(keyTunnelInfo.s);
                    GenerateDal.Update(CommonSqlKey.UpdatePayResult, saleInfo);
                }

                GenerateDal.CommitTransaction();

            }
            catch (Exception e)
            {
                GenerateDal.RollBack();
                return 0;
            }
            return 1;
        }

        //一键补货操作
        public int GetFullfilGood(string machineId)
        {
            try
            {
                TunnelInfoModel tunnelInfo = new TunnelInfoModel();
                tunnelInfo.MachineId = machineId;
                int delResult = GenerateDal.Delete<TunnelInfoModel>(CommonSqlKey.DeleteTunnelStatusByMachine, tunnelInfo);
                GenerateDal.Execute<TunnelInfoModel>(CommonSqlKey.FullfilGoodsOneKey, tunnelInfo);
                //往机器下行表里插入库存改变的数据
                PostToMachine(machineId, "s");
                /*
                GenerateDal.BeginTransaction();
                TunnelInfoModel tunnelInfo = new TunnelInfoModel();
                tunnelInfo.MachineId = machineId;
                GenerateDal.Delete<TunnelInfoModel>(CommonSqlKey.DeleteTunnelStatusByMachine, tunnelInfo);
                GenerateDal.Execute<TunnelInfoModel>(CommonSqlKey.FullfilGoodsOneKey, tunnelInfo);

                GenerateDal.CommitTransaction();
                */
            }
            catch (Exception e)
            {
                //GenerateDal.RollBack();
                return 0;
            }
            return 1;
        }

        //按货道更新
        public int GetFullfilGoodByTunnel(KeyJsonModel keyJsonModel)
        {
            try
            {
                GenerateDal.BeginTransaction();
                foreach (KeyTunnelModel keyTunnelInfo in keyJsonModel.t)
                {
                    TunnelInfoModel tunnelInfo = new TunnelInfoModel();
                    tunnelInfo.MachineId = keyJsonModel.m;
                    tunnelInfo.GoodsStuId = keyTunnelInfo.tid;
                    if (!string.IsNullOrEmpty(keyTunnelInfo.n))
                    {
                        tunnelInfo.CurrStock = Convert.ToInt32(keyTunnelInfo.n);
                    }
                    
                    if (string.IsNullOrEmpty(keyTunnelInfo.s))
                    {
                        tunnelInfo.CurrStatus = "1";
                    }
                    else
                    {
                        tunnelInfo.CurrStatus = keyTunnelInfo.s;
                    }
                   
                    tunnelInfo.UpdateDate = DateTime.Now;
                    tunnelInfo.CabinetId = keyTunnelInfo.tid.Substring(0, 1);
                    GenerateDal.Delete<TunnelInfoModel>(CommonSqlKey.DeleteTunnelStatusByMachineAndTunnel, tunnelInfo);
                    GenerateDal.Create<TunnelInfoModel>(tunnelInfo);
                }

                //往机器下行表里插入库存改变的数据
                PostToMachine(keyJsonModel.m, "s");

                GenerateDal.CommitTransaction();
                
            }
            catch (Exception e)
            {
                //GenerateDal.RollBack();
                return 0;
            }
            return 1;
        }

        //心跳包
        public DataTable GetBeepHeart(string machineId)
        {
            IDictionary<string,object> dicParam = new Dictionary<string,object>();
            dicParam.Add("P_MachineId",machineId);
            UpdateMachineInlineTime(machineId);
            return GenerateDal.LoadDataTable(CommonSqlKey.GetBeepHeart, dicParam);
        }

        private int UpdateMachineInlineTime(string machineId)
        {
            MachineListModel machineList = new MachineListModel();
            machineList.MachineId = machineId;
            machineList.LatestDate = DateTime.Now;

            return GenerateDal.Update(CommonSqlKey.UpdateMachineInlineTime, machineList);
        }

        //机器上报下行处理结果
        public int GetHandleResult(string machineId, string machineStatus)
        {
            try
            {
                ToMachineModel toMachineInfo = new ToMachineModel();
                toMachineInfo.MachineId = machineId;
                toMachineInfo.MachineStatus = machineStatus;
                GenerateDal.Delete<ToMachineModel>(CommonSqlKey.DeleteToMachine, toMachineInfo);
            }
            catch (Exception e)
            {
                //GenerateDal.RollBack();
                return 0;
            }
            return 1;
        }

        //向机器下行表插入数据
        public int PostToMachine(string machineId, string machineStatus)
        {
            try
            {
                if (!string.IsNullOrEmpty(machineId) && !string.IsNullOrEmpty(machineStatus))
                {
                    GenerateDal.BeginTransaction();
                    ToMachineModel toMachineInfo = new ToMachineModel();
                    toMachineInfo.MachineId = machineId;
                    toMachineInfo.MachineStatus = machineStatus;
                    GenerateDal.Delete<ToMachineModel>(CommonSqlKey.DeleteToMachine, toMachineInfo);
                    GenerateDal.Create<ToMachineModel>(toMachineInfo);

                    GenerateDal.CommitTransaction();
                }
                
               
            }
            catch (Exception e)
            {
                //GenerateDal.RollBack();
                return 0;
            }
            return 1;
        }


        //向机器下行价格
        public DataTable GetToMachinePrice(string machineId, int startNo, int len)
        {
            var conditions = new List<Condition>();

            if (!string.IsNullOrEmpty(machineId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "MachineId",
                    DbColumnName = "machine_id",
                    ParamValue = machineId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }

           

            conditions.Add(new Condition
            {
                LeftBrace = "  ",
                ParamName = "TunnelId",
                DbColumnName = "tunnel_id",
                ParamValue = "asc",
                Operation = ConditionOperate.OrderBy,
                RightBrace = "",
                Logic = ""
            });

            conditions.Add(new Condition
            {
                LeftBrace = "",
                ParamName = "Index",
                DbColumnName = "",
                ParamValue = startNo,
                Operation = ConditionOperate.LimitIndex,
                RightBrace = "",
                Logic = ""

            });

            conditions.Add(new Condition
            {
                LeftBrace = "",
                ParamName = "Length",
                DbColumnName = "",
                ParamValue = len,
                Operation = ConditionOperate.LimitLength,
                RightBrace = "",
                Logic = ""

            });


            return GenerateDal.LoadDataTableByConditions(CommonSqlKey.ToMachinePrice, conditions);
        }


        //向机器下行当前补货库存
        public DataTable GetToMachineStock(string machineId, int startNo, int len)
        {
            var conditions = new List<Condition>();

            if (!string.IsNullOrEmpty(machineId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "MachineId",
                    DbColumnName = "machine_id",
                    ParamValue = machineId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }



            conditions.Add(new Condition
            {
                LeftBrace = "  ",
                ParamName = "GoodsStuId",
                DbColumnName = "goods_stu_id",
                ParamValue = "asc",
                Operation = ConditionOperate.OrderBy,
                RightBrace = "",
                Logic = ""
            });

            conditions.Add(new Condition
            {
                LeftBrace = "",
                ParamName = "Index",
                DbColumnName = "",
                ParamValue = startNo,
                Operation = ConditionOperate.LimitIndex,
                RightBrace = "",
                Logic = ""

            });

            conditions.Add(new Condition
            {
                LeftBrace = "",
                ParamName = "Length",
                DbColumnName = "",
                ParamValue = len,
                Operation = ConditionOperate.LimitLength,
                RightBrace = "",
                Logic = ""

            });


            return GenerateDal.LoadDataTableByConditions(CommonSqlKey.ToMachineStock, conditions);
        }

        //机器端设置价格和最大库存上报
        public int PostMaxStockAndPrice(List<PriceAndMaxStockModel> lstPriceAndStock, string machineId)
        {
            try
            {
                GenerateDal.BeginTransaction();
                foreach (PriceAndMaxStockModel priceAndStock in lstPriceAndStock)
                {
                    TunnelConfigModel tc = new TunnelConfigModel();
                    tc.MachineId = machineId;
                    tc.TunnelId = priceAndStock.tid;
                    tc.CashPrices = priceAndStock.p1;
                    tc.AlipayPrices = priceAndStock.p2;
                    tc.WpayPrices = priceAndStock.p3;
                    tc.IcPrices = priceAndStock.p4;
                    tc.MaxPuts = priceAndStock.ms;

                    if (priceAndStock.p1 == 0 && priceAndStock.ms != 0)
                    {
                        GenerateDal.Update(CommonSqlKey.UpdateMaxPuts, tc);
                    }
                    else if (priceAndStock.p1 != 0 && priceAndStock.ms == 0)
                    {
                        GenerateDal.Update(CommonSqlKey.UpdatePrice, tc);
                    }
                    else
                    {
                        GenerateDal.Update(CommonSqlKey.PostPriceAndMaxStock, tc);
                    }


                }
                PostToMachine(machineId, "p");
                GenerateDal.CommitTransaction();

            }
            catch (Exception e)
            {
                //GenerateDal.RollBack();
                return 0;
            }
            return 1;
           
        }

        //机器配置发给机器
        public DataTable GetMachineSetting(string machineId)
        {
            var conditions = new List<Condition>();

            if (!string.IsNullOrEmpty(machineId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "MachineId",
                    DbColumnName = "machine_id",
                    ParamValue = machineId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }

            return GenerateDal.LoadDataTableByConditions(CommonSqlKey.GetMachineSetting, conditions);
        }
       
    }
}
