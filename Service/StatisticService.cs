using Interface;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utility;

namespace Service
{
    public class StatisticService : AbstractService, IStatistic
    {
        /// <summary>
        /// 取机器的销售额
        /// </summary>
        /// <returns></returns>
        public DataTable GetSalesAmountByMachine(string salesDateStart, string salesDateEnd, bool needPage, int pageIndex, int pageSize)
        {
            var clientId = HttpContextHandler.GetHeaderObj("UserClientId");
            var conditions = new List<Condition>();
            if (string.IsNullOrEmpty(clientId.ToString()))
            {
                return new DataTable();
            }
            conditions.Add(new Condition
            {
                LeftBrace = "",
                ParamName = "ClientId",
                DbColumnName = "",
                ParamValue = clientId,
                Operation = ConditionOperate.None,
                RightBrace = "",
                Logic = ""
            });

            if (!string.IsNullOrEmpty(salesDateStart))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "SaleDateStart",
                    DbColumnName = "sales_date",
                    ParamValue = salesDateStart,
                    Operation = ConditionOperate.GreaterThan,
                    RightBrace = "",
                    Logic = ""
                });
            }

            if (!string.IsNullOrEmpty(salesDateEnd))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "SaleDateEnd",
                    DbColumnName = "sales_date",
                    ParamValue = salesDateEnd,
                    Operation = ConditionOperate.LessThan,
                    RightBrace = "",
                    Logic = ""
                });
            }

            conditions.Add(new Condition
            {
                LeftBrace = "",
                ParamName = "",
                DbColumnName = "",
                ParamValue = "a.machine_id",
                Operation = ConditionOperate.GroupBy,
                RightBrace = "",
                Logic = ""
            });

            if (needPage)
            {
                conditions.AddRange(CreatePaginConditions(pageIndex, pageSize));
            }
            
            // 返回的三个数字按顺序分别代表未启用  离线  在线
            return GenerateDal.LoadDataTableByConditions(CommonSqlKey.GetSalesAmountByMachine, conditions);
        }
    }
}
