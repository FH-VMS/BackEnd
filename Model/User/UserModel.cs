using Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.User
{
    [Table("user")]
    public class UserModel:BaseModel
    {
        [Column(Name = "account")]
        public string Account
        {
            get;
            set;
        }
        [Column(Name = "password")]
        public string Password
        {
            get;
            set;
        }
    }
}
