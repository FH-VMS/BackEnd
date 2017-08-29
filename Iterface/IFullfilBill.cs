using Model.Machine;
using Model.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Interface
{
    public interface IFullfilBill
    {
         [Remark("生成补货单", ParmsNote = "实体", ReturnNote = "返回实体列表")]
        List<TunnelInfoModel> GetFullfilAll(TunnelInfoModel tunnelInfoInfo);

         [Remark("生成补货单的数量", ParmsNote = "", ReturnNote = "int")]
        int GetFullfilCount(TunnelInfoModel tunnelInfoInfo);

         [Remark("手机端补充库存", ParmsNote = "列表实体", ReturnNote = "int")]
         int UpdateStockWithMobile(List<TunnelInfoModel> lstTunnelInfo);

         //DataTable ExportByProduct(string machineId);
    }
}
