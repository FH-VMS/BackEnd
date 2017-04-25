using Interface;
using Model.Machine;
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


       
    }
}
