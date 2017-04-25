using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Pay
{
    //对k进行解码 k格式："{"m":"123128937","t":[{"tid":"1-2","n":3},{"tid":"1-3","n":2}]}"
    public class KeyJsonModel
    {
        public string m
        {
            get;
            set;
        }

        public List<KeyTunnelModel> t
        {
            get;
            set;
        }
    }

    public class KeyTunnelModel{
        public string tid
        {
            get;
            set;
        }

        public string n
        {
            get;
            set;
        }

        //销售货物的状态
        public string s
        {
            get;
            set;
        }
    }
}
