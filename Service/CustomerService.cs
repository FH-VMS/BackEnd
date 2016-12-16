using Interface;
using Model.Customer;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerService:AbstractService, IBase<CustomerModel>
    {

        public List<CustomerModel> GetAll(CustomerModel customerInfo)
        {
            
            var conditions = new List<Condition>();
            /* 
            var conditionAccount = new Condition
            {
                LeftBrace = "",
                ParamName = "UserAccount",
                DbColumnName = "usr_account",
                ParamValue = customerInfo.UserAccount + "%",
                Operation = ConditionOperate.RightLike,
                RightBrace = "",
                Logic = "AND"

            };
            conditions.Add(conditionAccount);

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
            conditions.AddRange(CreatePaginConditions(customerInfo.PageIndex, customerInfo.PageSize));
            return GenerateDal.LoadByConditions<CustomerModel>(CommonSqlKey.GetCustomer, conditions);
        }

        public int GetCount(CustomerModel customerInfo)
        {
            var result = 0;

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
            CustomerModel customerInfo = new CustomerModel();
            customerInfo.Id = id;
            return GenerateDal.Delete<CustomerModel>(CommonSqlKey.DeleteCustomer, customerInfo);
        }

        public int UpdateData(CustomerModel customerInfo)
        {
            return GenerateDal.Update(CommonSqlKey.UpdateCustomer, customerInfo);
        }
    }
}
