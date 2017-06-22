using Chuang.Back.Base;
using Interface;
using Model.Common;
using Model.Machine;
using Model.Sys;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chuang.Back.Controllers
{
    public class CabinetConfigController : ApiBaseController
    {
        public ResultObj<List<CabinetConfigModel>> GetCabinetByMachineTypeId(string machineTypeId)
        {
            ICabinet cabinetService = new CabinetService();
            var cabinetList = cabinetService.GetCabinetByMachineTypeId(machineTypeId);
            return Content(cabinetList);
        }

        public ResultObj<List<CommonDic>> GetCabinetByMachineId(string machineId)
        {
            ICabinet cabinetService = new CabinetService();
            var cabinetList = cabinetService.GetCabinetByMachineId(machineId);
            return Content(cabinetList);
        }
    }
}
