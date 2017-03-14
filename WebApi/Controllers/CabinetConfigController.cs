using Chuang.Back.Base;
using Interface;
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
        public ResultObj<List<CabinetConfigModel>> GetCabinetByMachineId(string machineTypeId)
        {
            ICabinet menusService = new CabinetService();
            var menuList = menusService.GetCabinetByMachineId(machineTypeId);
            return Content(menuList);
        }
    }
}
