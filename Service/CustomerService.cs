using Interface;
using Model.Customer;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Service
{
    public class CustomerService:AbstractService, IBase<CustomerModel>
    {

        public List<CustomerModel> GetAll(CustomerModel customerInfo)
        {
            string userStatus = HttpContextHandler.GetHeaderObj("Sts").ToString();
            var userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();
            var conditions = new List<Condition>();
            var conditionAccount = new Condition
            {
                LeftBrace = "",
                ParamName = "ClientName",
                DbColumnName = "client_name",
                ParamValue = customerInfo.ClientName + "%",
                Operation = ConditionOperate.RightLike,
                RightBrace = "",
                Logic = ""

            };
            List<CustomerModel> result = null;
            conditions.Add(conditionAccount);
            if (userStatus == "100" || userStatus == "99")
            {
                conditions.Add(new Condition
                {
                    LeftBrace = "AND ",
                    ParamName = "ClientFatherId",
                    DbColumnName = "client_father_id",
                    ParamValue = "self",
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }
            else
            {
               
                conditions.Add(new Condition
                {
                    LeftBrace = "AND ",
                    ParamName = "ClientFatherId",
                    DbColumnName = "client_father_id",
                    ParamValue = userClientId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
               
            }


            conditions.AddRange(CreatePaginConditions(customerInfo.PageIndex, customerInfo.PageSize));
            result = GetCustomersFinalResult(GenerateDal.LoadByConditions<CustomerModel>(CommonSqlKey.GetCustomer, conditions));


            return result;
        }

        private List<CustomerModel> GetCustomersFinalResult(List<CustomerModel> result)
        {
            if (result != null && result.Count > 0)
            {
                foreach (CustomerModel cusInfo in result)
                {
                    var conditions = new List<Condition>();
                    conditions.Add(new Condition
                    {
                        LeftBrace = "",
                        ParamName = "ClientFatherId",
                        DbColumnName = "client_father_id",
                        ParamValue = cusInfo.Id,
                        Operation = ConditionOperate.Equal,
                        RightBrace = "",
                        Logic = ""
                    });
                   cusInfo.children = GenerateDal.LoadByConditions<CustomerModel>(CommonSqlKey.GetCustomer, conditions);
                   GetCustomersFinalResult(cusInfo.children);
                }
            }



            return result;
        }

        public int GetCount(CustomerModel customerInfo)
        {
            var result = 0;
            string userStatus = HttpContextHandler.GetHeaderObj("Sts").ToString();
            var userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();

            var conditions = new List<Condition>();
          
            /*
            var conditionUserAccount = new Condition
            {
                LeftBrace = "",
                ParamName = "UserAccount",
                DbColumnName = "usr_account",
                ParamValue = customerInfo.UserAccount + "%",
                Operation = ConditionOperate.RightLike,
                RightBrace = "",
                Logic = "AND"

            };
            conditions.Add(conditionUserAccount);

            var conditionUserName = new Condition
            {
                LeftBrace = "",
                ParamName = "UserName",
                DbColumnName = "usr_name",
                ParamValue = customerInfo.UserName + "%",
                Operation = ConditionOperate.RightLike,
                RightBrace = "",
                Logic = ""

            };
            
            conditions.Add(conditionUserName);
            */
            if (userStatus == "100" || userStatus == "99")
            {
                
            }
            else
            {
                conditions.Add(new Condition
                {
                    LeftBrace = "",
                    ParamName = "ClientFatherId",
                    DbColumnName = "client_father_id",
                    ParamValue = userClientId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = "AND"
                });
            }
            var conditionAccount = new Condition
            {
                LeftBrace = "",
                ParamName = "ClientName",
                DbColumnName = "client_name",
                ParamValue = customerInfo.ClientName + "%",
                Operation = ConditionOperate.RightLike,
                RightBrace = "",
                Logic = ""

            };
            conditions.Add(conditionAccount);
            result = GenerateDal.CountByConditions(CommonSqlKey.GetCustomerCount, conditions);

            return result;
        }


        /// <summary>
        /// 新增/修改会员信息
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public int PostData(CustomerModel customerInfo)
        {
            int result;
            string userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();
            string userAccount = HttpContextHandler.GetHeaderObj("UserAccount").ToString();
            if(!string.IsNullOrEmpty(userClientId))
            {
                customerInfo.ClientFatherId = userClientId;
            }

            if (!string.IsNullOrEmpty(userAccount))
            {
                customerInfo.Creator = userAccount;
            }

            customerInfo.Id = Guid.NewGuid().ToString();

            result = GenerateDal.Create(customerInfo);




            return result;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public int DeleteData(string id)
        {
            string userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();
            try
            {

                GenerateDal.BeginTransaction();
                CustomerModel customerInfo = new CustomerModel();
                customerInfo.Id = id;
                int delResult = GenerateDal.Delete<CustomerModel>(CommonSqlKey.DeleteCustomer, customerInfo);
                if (delResult > 0)
                {
                    CustomerModel updInfo = new CustomerModel();
                    updInfo.ClientFatherId = userClientId;
                    updInfo.Id = id;
                    string userAccount = HttpContextHandler.GetHeaderObj("UserAccount").ToString();
                    if (!string.IsNullOrEmpty(userAccount))
                    {
                        updInfo.Updater = userAccount;
                    }
                    GenerateDal.Update(CommonSqlKey.UpdateChildCustomer, updInfo);
                }
                GenerateDal.CommitTransaction();
                return 1;
            }
            catch (Exception ee)
            {
                GenerateDal.RollBack();
                return 0;
            }
           
        }

        public int UpdateData(CustomerModel customerInfo)
        {
            string userAccount = HttpContextHandler.GetHeaderObj("UserAccount").ToString();
            if (!string.IsNullOrEmpty(userAccount))
            {
                customerInfo.Updater = userAccount;
            }
            return GenerateDal.Update(CommonSqlKey.UpdateCustomer, customerInfo);
        }
    }
}
