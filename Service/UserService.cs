using Interface;
using Model.User;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserServicee : AbstractService, IBase<UserModel>
    {
        public List<UserModel> GetAll(UserModel userInfo)
        {
           
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
          
            conditions.AddRange(CreatePaginConditions(userInfo.PageIndex, userInfo.PageSize));
            return GenerateDal.LoadByConditions<UserModel>(CommonSqlKey.GetUser, conditions);
        }

        public int GetCount(UserModel userInfo)
        {
            var result = 0;

            var conditions = new List<Condition>();

         
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
