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
    public class TunnelConfigController : ApiBaseController
    {

        private static IBase<TunnelConfigModel> _IBase
        {
            get
            {
                return new TunnelConfigService();
            }
        }

        public ResultObj<List<TunnelConfigModel>> GetData(string machineId = "", string cabinetId = "")
        {
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();

            TunnelConfigModel tunnelConfigInfo = new TunnelConfigModel();
            tunnelConfigInfo.MachineId = machineId;
            tunnelConfigInfo.CabinetId = cabinetId;
            var tunnels = _IBase.GetAll(tunnelConfigInfo);
            return Content(tunnels);
        }

        public ResultObj<int> PostData(TunnelConfigModel tunnelConfigInfo)
        {
            return Content(_IBase.PostData(tunnelConfigInfo));
        }

        public ResultObj<int> PutData(TunnelConfigModel tunnelConfigInfo)
        {
            return Content(_IBase.UpdateData(tunnelConfigInfo));
        }

        public ResultObj<int> DeleteData(string idList)
        {
            return Content(_IBase.DeleteData(idList));
        }
    }
}
