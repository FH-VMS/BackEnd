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
    public class MachineTypeService : AbstractService, IBase<MachineTypeModel>
    {

        public List<MachineTypeModel> GetAll(MachineTypeModel machineTypeInfo)
        {
           
            var conditions = new List<Condition>();
            var conditionAccount = new Condition
            {
                LeftBrace = " AND ",
                ParamName = "TypeName",
                DbColumnName = "type_name",
                ParamValue = machineTypeInfo.TypeName + "%",
                Operation = ConditionOperate.RightLike,
                RightBrace = "",
                Logic = ""

            };
            conditions.Add(conditionAccount);
            if (!string.IsNullOrEmpty(machineTypeInfo.TypeType.ToString()))
            {
                var conditionUserName = new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "TypeType",
                    DbColumnName = "type_type",
                    ParamValue = machineTypeInfo.TypeType,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""

                };
                conditions.Add(conditionUserName);
            }

            conditions.AddRange(CreatePaginConditions(machineTypeInfo.PageIndex, machineTypeInfo.PageSize));
            return GenerateDal.LoadByConditions<MachineTypeModel>(CommonSqlKey.GetMachineType, conditions);
        }


        public int GetCount(MachineTypeModel machineTypeInfo)
        {
            var result = 0;

            var conditions = new List<Condition>();

            var conditionAccount = new Condition
            {
                LeftBrace = " AND ",
                ParamName = "TypeName",
                DbColumnName = "type_name",
                ParamValue = machineTypeInfo.TypeName + "%",
                Operation = ConditionOperate.RightLike,
                RightBrace = "",
                Logic = ""

            };
            conditions.Add(conditionAccount);
            if (!string.IsNullOrEmpty(machineTypeInfo.TypeType.ToString()))
            {
                var conditionUserName = new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "TypeType",
                    DbColumnName = "type_type",
                    ParamValue = machineTypeInfo.TypeType,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""

                };
                conditions.Add(conditionUserName);
            }
            


            result = GenerateDal.CountByConditions(CommonSqlKey.GetMachineTypeCount, conditions);

            return result;
        }


        /// <summary>
        /// 新增/修改会员信息
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public int PostData(MachineTypeModel machineTypeInfo)
        {
            int result;


            machineTypeInfo.Id = Guid.NewGuid().ToString();
            result = GenerateDal.Create(machineTypeInfo);




            return result;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public int DeleteData(string id)
        {
            MachineTypeModel machineTypeInfo = new MachineTypeModel();
            machineTypeInfo.Id = id;
            return GenerateDal.Delete<MachineTypeModel>(CommonSqlKey.DeleteMachineType, machineTypeInfo);
        }

        public int UpdateData(MachineTypeModel machineTypeInfo)
        {
            return GenerateDal.Update(CommonSqlKey.UpdateMachineType, machineTypeInfo);
        }
       
    }
}
