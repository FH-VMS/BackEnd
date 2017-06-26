﻿using Interface;
using Model.Machine;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class TunnelInfoService : AbstractService, IBase<TunnelInfoModel>, IFullfilBill
    {
        public List<TunnelInfoModel> GetAll(TunnelInfoModel tunnelInfoInfo)
        {
                var conditions = new List<Condition>();

                if (!string.IsNullOrEmpty(tunnelInfoInfo.MachineId))
                {
                    conditions.Add(new Condition
                    {
                        LeftBrace = " AND ",
                        ParamName = "MachineId",
                        DbColumnName = "a.machine_id",
                        ParamValue = tunnelInfoInfo.MachineId,
                        Operation = ConditionOperate.Equal,
                        RightBrace = "",
                        Logic = ""
                    });
                }

                if (!string.IsNullOrEmpty(tunnelInfoInfo.CabinetId))
                {
                    conditions.Add(new Condition
                    {
                        LeftBrace = " AND ",
                        ParamName = "CabinetId",
                        DbColumnName = "a.cabinet_id",
                        ParamValue = tunnelInfoInfo.CabinetId,
                        Operation = ConditionOperate.Equal,
                        RightBrace = "",
                        Logic = ""
                    });
                }

                conditions.Add(new Condition
                {
                    LeftBrace = "  ",
                    ParamName = "TunnelId",
                    DbColumnName = "TunnelId",
                    ParamValue = "asc",
                    Operation = ConditionOperate.OrderBy,
                    RightBrace = "",
                    Logic = ""
                });
                conditions.AddRange(CreatePaginConditions(tunnelInfoInfo.PageIndex, tunnelInfoInfo.PageSize));

                return GenerateDal.LoadByConditions<TunnelInfoModel>(CommonSqlKey.GetTunnelInfo, conditions);


        }



        public int GetCount(TunnelInfoModel tunnelInfoInfo)
        {
            var result = 0;


            var conditions = new List<Condition>();

            if (!string.IsNullOrEmpty(tunnelInfoInfo.MachineId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "MachineId",
                    DbColumnName = "a.machine_id",
                    ParamValue = tunnelInfoInfo.MachineId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }

            if (!string.IsNullOrEmpty(tunnelInfoInfo.CabinetId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "CabinetId",
                    DbColumnName = "a.cabinet_id",
                    ParamValue = tunnelInfoInfo.CabinetId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }



            result = GenerateDal.CountByConditions(CommonSqlKey.GetTunnelInfoCount, conditions);

            return result;
        }


        /// <summary>
        /// 新增/修改会员信息
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public int PostData(TunnelInfoModel tunnelInfoInfo)
        {
            int result;
            tunnelInfoInfo.UpdateDate = DateTime.Now;
            result = GenerateDal.Create(tunnelInfoInfo);

            return result;


        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public int DeleteData(string id)
        {
            TunnelInfoModel tunnelInfoInfo = new TunnelInfoModel();
            tunnelInfoInfo.MachineId = id;
            return GenerateDal.Delete<TunnelInfoModel>(CommonSqlKey.DeleteTunnelInfo, tunnelInfoInfo);
        }

        public int UpdateData(TunnelInfoModel tunnelInfoInfo)
        {
            try
            {
                
                //GenerateDal.BeginTransaction();
                tunnelInfoInfo.UpdateDate = DateTime.Now;
                GenerateDal.Update(CommonSqlKey.UpdateTunnelInfo, tunnelInfoInfo);
                //操作日志
                OperationLogService operationService = new OperationLogService();
                operationService.PostData(new OperationLogModel() { MachineId = tunnelInfoInfo.MachineId, OptContent = "货道" + (tunnelInfoInfo.CurrStatus=="1"? "启用":"停用") });
                /*
                TunnelConfigModel tunnelConfig = new TunnelConfigModel();
                tunnelConfig.MachineId = tunnelInfoInfo.MachineId;
                tunnelConfig.CabinetId = tunnelInfoInfo.CabinetId;
                tunnelConfig.TunnelId = tunnelInfoInfo.GoodsStuId;
                tunnelConfig.IsUsed = Convert.ToInt32(tunnelInfoInfo.CurrStatus);
                GenerateDal.Update(CommonSqlKey.UpdateTunnelConfigStatus, tunnelConfig);
               */
                //GenerateDal.CommitTransaction();
              
            }
            catch (Exception e)
            {
                //GenerateDal.RollBack();
                return 0;
            }
            return 1;
           
        }



        /*******************************补货单生成********************************/
        public List<TunnelInfoModel> GetFullfilAll(TunnelInfoModel tunnelInfoInfo)
        {
            var conditions = new List<Condition>();

            if (!string.IsNullOrEmpty(tunnelInfoInfo.MachineId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "MachineId",
                    DbColumnName = "a.machine_id",
                    ParamValue = tunnelInfoInfo.MachineId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }

            if (!string.IsNullOrEmpty(tunnelInfoInfo.CabinetId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "CabinetId",
                    DbColumnName = "a.cabinet_id",
                    ParamValue = tunnelInfoInfo.CabinetId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }

            conditions.Add(new Condition
            {
                LeftBrace = "  ",
                ParamName = "TunnelId",
                DbColumnName = "a.tunnel_id",
                ParamValue = "asc",
                Operation = ConditionOperate.OrderBy,
                RightBrace = "",
                Logic = ""
            });
            conditions.AddRange(CreatePaginConditions(tunnelInfoInfo.PageIndex, tunnelInfoInfo.PageSize));

            return GenerateDal.LoadByConditions<TunnelInfoModel>(CommonSqlKey.GenerateFullfilBill, conditions);


        }



        public int GetFullfilCount(TunnelInfoModel tunnelInfoInfo)
        {
            var result = 0;


            var conditions = new List<Condition>();

            if (!string.IsNullOrEmpty(tunnelInfoInfo.MachineId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "MachineId",
                    DbColumnName = "a.machine_id",
                    ParamValue = tunnelInfoInfo.MachineId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }

            if (!string.IsNullOrEmpty(tunnelInfoInfo.CabinetId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "CabinetId",
                    DbColumnName = "a.cabinet_id",
                    ParamValue = tunnelInfoInfo.CabinetId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }



            result = GenerateDal.CountByConditions(CommonSqlKey.GetFullfilCount, conditions);

            return result;
        }

        public int UpdateStockWithMobile(List<TunnelInfoModel> lstTunnelInfo)
        {
            try
            {

                GenerateDal.BeginTransaction();
                foreach (TunnelInfoModel tunnelInfo in lstTunnelInfo)
                {
                    tunnelInfo.UpdateDate = DateTime.Now;
                    GenerateDal.Update(CommonSqlKey.UpdateTunnelCurrStock, tunnelInfo);
                }
                MachineService ms = new MachineService();
                //往机器下行表里插入库存改变的数据
                ms.PostToMachine(lstTunnelInfo[0].MachineId, "st");
                //操作日志
                OperationLogService operationService = new OperationLogService();
                operationService.PostData(new OperationLogModel() { MachineId = lstTunnelInfo[0].MachineId, OptContent = "手机补充库存"});
                /*
                TunnelConfigModel tunnelConfig = new TunnelConfigModel();
                tunnelConfig.MachineId = tunnelInfoInfo.MachineId;
                tunnelConfig.CabinetId = tunnelInfoInfo.CabinetId;
                tunnelConfig.TunnelId = tunnelInfoInfo.GoodsStuId;
                tunnelConfig.IsUsed = Convert.ToInt32(tunnelInfoInfo.CurrStatus);
                GenerateDal.Update(CommonSqlKey.UpdateTunnelConfigStatus, tunnelConfig);
               */
                GenerateDal.CommitTransaction();

            }
            catch (Exception e)
            {
               GenerateDal.RollBack();
                return 0;
            }
            return 1;
        }
    }
}
