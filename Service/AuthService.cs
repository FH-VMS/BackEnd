using Interface;
using Model.Common;
using Model.User;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthService : AbstractService, IBase<AuthModel>,IAuth
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

        public int PostAuthTemplate(string name, int rank, List<MenuModel> lstAuthModel)
        {
           
                try
                {

                    GenerateDal.BeginTransaction();
                   
                    AuthModel authModel = new AuthModel();
                    authModel.Id=Guid.NewGuid().ToString();
                    authModel.DmsName = name;
                    authModel.Rank=rank;
                    foreach(var menuModel in lstAuthModel)
                    {
                        
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
