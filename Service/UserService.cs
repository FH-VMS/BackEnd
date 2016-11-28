using Interface;
using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserServicee : AbstractService, IBase
    {
        public List<UserModel> GetAll<UserModel>()
        {
            return GenerateDal.Load<UserModel>();
        }
    }
}
