using Interface;
using Model.User;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Service
{
    public class UserServicee : AbstractService, IBase<UserModel>
    {
        public List<UserModel> GetAll(UserModel userInfo)
        {
            string userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();
            var userStatus = HttpContextHandler.GetHeaderObj("Sts").ToString();
            var conditions = new List<Condition>();
            var conditionAccount = new Condition
            {
                LeftBrace = "",
                ParamName = "UserAccount",
                DbColumnName = "usr_account",
                ParamValue = userInfo.UserAccount + "%",
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
                ParamValue = userInfo.UserName + "%",
                Operation = ConditionOperate.RightLike,
                RightBrace = "",
                Logic = ""

            };
            conditions.Add(conditionUserName);

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
                    LeftBrace = " AND ",
                    ParamName = "UserClientId",
                    DbColumnName = "b.client_father_id",
                    ParamValue = userClientId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }
           
              

          
            conditions.AddRange(CreatePaginConditions(userInfo.PageIndex, userInfo.PageSize));
            return GetCustomersFinalResult(GenerateDal.LoadByConditions<UserModel>(CommonSqlKey.GetUser, conditions));
        }

        private List<UserModel> GetCustomersFinalResult(List<UserModel> result)
        {
            if (result != null && result.Count > 0)
            {
                foreach (UserModel userInfo in result)
                {
                    var conditions = new List<Condition>();
                    conditions.Add(new Condition
                    {
                        LeftBrace = "",
                        ParamName = "ClientFatherId",
                        DbColumnName = "b.client_father_id",
                        ParamValue = userInfo.UserClientId,
                        Operation = ConditionOperate.Equal,
                        RightBrace = "",
                        Logic = ""
                    });
                    userInfo.children = GenerateDal.LoadByConditions<UserModel>(CommonSqlKey.GetUser, conditions);
                    GetCustomersFinalResult(userInfo.children);
                }
            }



            return result;
        }

        public int GetCount(UserModel userInfo)
        {
            var result = 0;

            var conditions = new List<Condition>();

            string userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();
            var userStatus = HttpContextHandler.GetHeaderObj("Sts").ToString();
            if (userStatus == "100" || userStatus == "99")
            {

            }
            else
            {
                conditions.Add(new Condition
                {
                    LeftBrace = "",
                    ParamName = "UserClientId",
                    DbColumnName = "b.client_father_id",
                    ParamValue = userClientId,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = "AND"
                });
            }
                var conditionUserAccount = new Condition
                {
                    LeftBrace = "",
                    ParamName = "UserAccount",
                    DbColumnName = "usr_account",
                    ParamValue = userInfo.UserAccount + "%",
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
                    ParamValue = userInfo.UserName + "%",
                    Operation = ConditionOperate.RightLike,
                    RightBrace = "",
                    Logic = ""

                };
                conditions.Add(conditionUserName);
            

            result = GenerateDal.CountByConditions(CommonSqlKey.GetUserCount, conditions);

            return result;
        }


        /// <summary>
        /// 新增/修改会员信息
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public int PostData(UserModel userInfo)
        {
            int result;


            userInfo.Id = Guid.NewGuid().ToString();
            userInfo.Sts = 1;
            result = GenerateDal.Create(userInfo);
            



            return result;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public int DeleteData(string id)
        {
            UserModel userInfo = new UserModel();
            userInfo.Id = id;
          return GenerateDal.Delete<UserModel>(CommonSqlKey.DeleteUser, userInfo); 
        }

        public int UpdateData(UserModel userInfo)
        {
            return GenerateDal.Update(CommonSqlKey.UpdateUser, userInfo);
        }
       

    }
}
