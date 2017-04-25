using Model.Pay;
using Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface
{
    public interface IPay
    {
        [Remark("获取商品信息", ParmsNote = "机器编号,货道编号逗号隔开", ReturnNote = "商品信息列表")]
        List<ProductModel> GetProducInfo(string machineId, List<KeyTunnelModel> lstTunnels);
    }
}
