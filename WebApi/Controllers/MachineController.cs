using Chuang.Back.Base;
using Interface;
using Model.Machine;
using Model.Pay;
using Model.Sale;
using Model.Sys;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utility;

namespace Chuang.Back.Controllers
{
    public class MachineController : ApiBaseController
    {
        private static IMachine _IMachine
        {
            get
            {
                return new MachineService();
            }
        }
        // 返回支付结果，需要出货的东东
        public string GetPayResult(string k)
        {
            KeyJsonModel keyJsonInfo = AnalizeKey(k);
            ISale _isale = new SalesService();
            //trade_status: (0:待支付，1:支付待出货,2：支付成功且已出货,3：支付成功出货失败未退款，4:支付成功出货失败已退款，5：支付失败)
            List<KeyTunnelModel> lstSales = _isale.GetPayResult("", "1", keyJsonInfo.m);
            if (lstSales.Count == 0)
            {
                return "";
            }
            return JsonHandler.GetJsonStrFromObject(lstSales,false);
        }

        //出货后，告诉汇报出货情况并更新库存
        public string GetDeliverSitu(string k)
        {
            return "ok, get deliver situation";
        }

        // 心跳
        public string GetHeartBeep(string k)
        {
            return "ok, heart beat";
        }

        //一键补货
        public string GetFullfilGood(string k)
        {
            return "ok, get fullfil good";
        }



        public ResultObj<List<ProductForMachineModel>> GetProductByMachine(string k = "", int pageIndex = 1, int pageSize = 10)
        {
            //KeyJsonModel keyJsonInfo = AnalizeKey(k);
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();
            //k = "ABC123456789";
            ProductForMachineModel machineInfo = new ProductForMachineModel();
            machineInfo.MachineId = k;
            machineInfo.PageIndex = pageIndex;
            machineInfo.PageSize = pageSize;
            var users = _IMachine.GetProductByMachine(machineInfo);
            int totalcount = _IMachine.GetCount(machineInfo);

            var pagination = new Pagination { PageSize = pageSize, PageIndex = pageIndex, StartIndex = 0, TotalRows = totalcount, TotalPage = 0 };
            return Content(users, pagination);
        }


        //对k进行解码 k格式：{"m":"123128937","t":[{"tid":"1-2","n":3},{"tid":"1-3","n":2}]}
        private KeyJsonModel AnalizeKey(string key)
        {
           KeyJsonModel keyJsonInfo = JsonHandler.GetObjectFromJson<KeyJsonModel>(key);
           return keyJsonInfo;
        }


    }
}