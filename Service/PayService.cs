using Interface;
using Model.Pay;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class PayService : AbstractService, IPay
    {
        public List<ProductModel> GetProducInfo(string machineId,  List<KeyTunnelModel> lstTunnels)
        {
            var conditions = new List<Condition>();

            if (!string.IsNullOrEmpty(machineId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "MachineId",
                    DbColumnName = "a.machine_id",
                    ParamValue = machineId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "  ",
                    Logic = ""
                });
            }
            if(lstTunnels.Count>0) {
               for(int i=0;i<lstTunnels.Count;i++)
               {
                   if(i==0) {
                       if (lstTunnels.Count == 1)
                       {
                           conditions.Add(new Condition
                           {
                               LeftBrace = " AND (",
                               ParamName = "TunnelId" + i,
                               DbColumnName = "a.tunnel_id",
                               ParamValue = lstTunnels[i].tid,
                               Operation = ConditionOperate.Equal,
                               RightBrace = " )",
                               Logic = ""
                           });
                       }
                       else
                       {
                           conditions.Add(new Condition
                           {
                               LeftBrace = " AND (",
                               ParamName = "TunnelId" + i,
                               DbColumnName = "a.tunnel_id",
                               ParamValue = lstTunnels[i].tid,
                               Operation = ConditionOperate.Equal,
                               RightBrace = "",
                               Logic = ""
                           });
                       }
                        
                   } else if(i==lstTunnels.Count-1) {
                       conditions.Add(new Condition
                        {
                            LeftBrace = " OR ",
                            ParamName = "TunnelId" + i,
                            DbColumnName = "a.tunnel_id",
                            ParamValue = lstTunnels[i].tid,
                            Operation = ConditionOperate.Equal,
                            RightBrace = ")",
                            Logic = ""
                        });
                   } else {
                        conditions.Add(new Condition
                        {
                            LeftBrace = " OR ",
                            ParamName = "TunnelId" + i,
                            DbColumnName = "a.tunnel_id",
                            ParamValue = lstTunnels[i].tid,
                            Operation = ConditionOperate.Equal,
                            RightBrace = "",
                            Logic = ""
                        });
                   }
                   
                }
            }

            return GenerateDal.LoadByConditions<ProductModel>(CommonSqlKey.GetProductInfo, conditions);


        }
    }
}
