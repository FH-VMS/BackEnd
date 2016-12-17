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

        private bool _add = true;
        public bool Add
        {
            get{
                return _add;
            }

            set
            {
                _add = value;
            }
        }

        private bool _del=true;
        public bool Del
        {
            get
            {
                return _del;
            }

            set
            {
                _del = value;
            }
        }

        private bool _mod = true;
        public bool Mod
        {
            get
            {
                return _mod;
            }

            set
            {
                _mod = value;
            }
        }

        private bool _sear = true;
        public bool Sear
        {
            get
            {
                return _sear;
            }

            set
            {
                _sear = value;
            }
        }

        private bool _checked = true;
        public bool Checked
        {
            get
            {
                return _checked;
            }

            set
            {
                _checked = value;
            }
        }


        public List<MenuModel> Menus;
    }
}
