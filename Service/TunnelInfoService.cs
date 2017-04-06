﻿using Interface;
using Model.Machine;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class TunnelInfoService : AbstractService, IBase<TunnelInfoModel>
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

                return GenerateDal.LoadByConditionsWithOrder<TunnelInfoModel>(CommonSqlKey.GetTunnelInfo, conditions, "TunnelId", "asc");


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
            return GenerateDal.Update(CommonSqlKey.UpdateTunnelInfo, tunnelInfoInfo);
        }
    }
}
