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
            var dics = new Dictionary<string, object>();
            dics.Add("UserAccount", userInfo.UserAccount + "%");
            dics.Add("UserName", userInfo.UserName + "%");
            if (userInfo.PageIndex == 1)
            {
                dics.Add("PageIndex", userInfo.PageIndex-1);
            }
            else
            {
                dics.Add("PageIndex", userInfo.PageIndex);
            }
            dics.Add("PageSize", userInfo.PageSize);

            

            if (userStatus == "100" || userStatus == "99")
            {
                dics.Add("ClientFatherId", "self");
            }
            else
            {
                dics.Add("ClientFatherId", userClientId);
            }




            return GenerateDal.Load<UserModel>(CommonSqlKey.GetUser, dics);
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


            string userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();
            var userStatus = HttpContextHandler.GetHeaderObj("Sts").ToString();
            var dics = new Dictionary<string, object>();
            dics.Add("UserAccount", userInfo.UserAccount + "%");
            dics.Add("UserName", userInfo.UserName + "%");
           



            if (userStatus == "100" || userStatus == "99")
            {
                dics.Add("ClientFatherId", "self");
            }
            else
            {
                dics.Add("ClientFatherId", userClientId);
            }


            result = GenerateDal.CountByDictionary<UserModel>(CommonSqlKey.GetUserCount, dics);

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
