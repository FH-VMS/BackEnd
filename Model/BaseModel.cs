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
        public int PageIndex
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        [Column(Name = "create_date")]
        public DateTime CreateDate
        {
            get;
            set;
        }
        [Column(Name = "creator")]
        public string Creator
        {
            get;
            set;
        }
        
        [Column(Name = "remark")]
        public string Remark
        {
            get;
            set;
        }
    }
}
