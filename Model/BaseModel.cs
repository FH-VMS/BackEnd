using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Sys;
using System.ComponentModel;

namespace Model
{
    public class BaseModel
    {
        [Description("id")]
        [Column(Name = "id")]
        public int Id
        {
            get;
            set;
        }

         [Column(Name = "name")]
        public string Name { get; set; }

        public string Creator { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
