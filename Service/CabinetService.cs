using Interface;
using Model.Machine;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CabinetService : AbstractService, ICabinet
    {
        // 取货柜作字典
        public List<CabinetConfigModel> GetCabinetByMachineId(string machineTypeId)
        {
            var conditions = new List<Condition>();
            conditions.Add(new Condition
            {
                LeftBrace = " AND ",
                ParamName = "MachineTypeId",
                DbColumnName = "b.machine_type_id",
                ParamValue = machineTypeId,
                Operation = ConditionOperate.Equal,
                RightBrace = "",
                Logic = ""
            });
            return GenerateDal.LoadByConditions<CabinetConfigModel>(CommonSqlKey.GetCabinetByMachineTypeId, conditions);
        }


        public int PostCabinetRelationData(MachineTypeAndCabinetModel cabinetConfigInfo)
        {
            try
            {
                GenerateDal.BeginTransaction();

                GenerateDal.Create(cabinetConfigInfo);
                GenerateDal.CommitTransaction();

                return 1;
            }
            catch (Exception e)
            {
                GenerateDal.RollBack();
                return 0;
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public int DeleteData(string id)
        {
            MachineTypeAndCabinetModel machineConfigInfo = new MachineTypeAndCabinetModel();
            machineConfigInfo.MachineTypeId = id;
            return GenerateDal.Delete<MachineTypeAndCabinetModel>(CommonSqlKey.DeleteMachineTypeAndCabinet, machineConfigInfo);
        }
    }
}
