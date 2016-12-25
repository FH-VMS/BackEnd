using Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
      [Table("table_book")]
    public class DicModel
    {
          [Column(Name = "id")]
          public string Id
          {
              get;
              set;
          }

        [Column(Name = "value")]
        public string Value
        {
            get;
            set;
        }

        [Column(Name = "book_chinese")]
        public string BookChinese
        {
            get;
            set;
        }
    }
}
