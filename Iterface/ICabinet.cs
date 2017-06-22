﻿using Model.Common;
using Model.Machine;
using Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface ICabinet
    {
         [Remark("根据机型取货柜", ParmsNote = "", ReturnNote = "返回返页列表")]
        List<CabinetConfigModel> GetCabinetByMachineTypeId(string machineTypeId);

         [Remark("根据机型取货柜", ParmsNote = "", ReturnNote = "返回返页列表")]
         List<CommonDic> GetCabinetByMachineId(string machineId);
    }
}
