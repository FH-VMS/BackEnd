using Model.Machine;
using Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface
{
    public interface IMachine
    {
        [Remark("根据机器取商品", ParmsNote = "", ReturnNote = "返回返页列表")]
        List<ProductForMachineModel> GetProductByMachine(ProductForMachineModel machineInfo);

        [Remark("根据机器取商品的总共数据", ParmsNote = "", ReturnNote = "返回返页列表")]
        int GetCount(ProductForMachineModel machineInfo);
    }
}
