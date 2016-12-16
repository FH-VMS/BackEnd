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
    public class AuthService : AbstractService, IBase<AuthModel>
    {
        public List<AuthModel> GetAll(AuthModel authInfo)
        {
            //var x = HttpContextHandler.GetHeaderObj("UserAccount");
            var conditions = new List<Condition>();

            conditions.AddRange(CreatePaginConditions(authInfo.PageIndex, authInfo.PageSize));
            return GenerateDal.LoadByConditions<AuthModel>(CommonSqlKey.GetAuth, conditions);
        }

        public int GetCount(AuthModel authInfo)
        {
            var result = 0;

            var conditions = new List<Condition>();


            result = GenerateDal.CountByConditions(CommonSqlKey.GetAuthCount, conditions);

            return result;
        }


        /// <summary>
        /// 新增/修改会员信息
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public int PostData(AuthModel authInfo)
        {
            int result;


            authInfo.Id = Guid.NewGuid().ToString();

            result = GenerateDal.Create(authInfo);




            return result;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public int DeleteData(string id)
        {
            AuthModel authInfo = new AuthModel();
            authInfo.Id = id;
            return GenerateDal.Delete<AuthModel>(CommonSqlKey.DeleteAuth, authInfo);
        }

        public int UpdateData(AuthModel authInfo)
        {
            return GenerateDal.Update(CommonSqlKey.UpdateAuth, authInfo);
        }
    }
}
