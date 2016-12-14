using Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    [Table("table_menu")]
    public class MenuModel
    {
        [Column(Name = "menu_id")]
        public string MenuId
        {
            get;
            set;
        }

        [Column(Name = "menu_name")]
        public string MenuName
        {
            get;
            set;
        }

        [Column(Name = "menu_father")]
        public string MenuFather
        {
            get;
            set;
        }

        [Column(Name = "url")]
        public string Url
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

        public List<MenuModel> Menus;
    }
}
