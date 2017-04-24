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
            return "ok, get pay result";
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
            AnalizeKey(k);
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();
            k = "248cacdb-6f6e-468c-bd7c-7d294ca5fa31";
            ProductForMachineModel machineInfo = new ProductForMachineModel();
            machineInfo.MachineId = k;
            machineInfo.PageIndex = pageIndex;
            machineInfo.PageSize = pageSize;
            var users = _IMachine.GetProductByMachine(machineInfo);
            int totalcount = _IMachine.GetCount(machineInfo);

            var pagination = new Pagination { PageSize = pageSize, PageIndex = pageIndex, StartIndex = 0, TotalRows = totalcount, TotalPage = 0 };
            return Content(users, pagination);
        }


        //对k进行解码
        private void AnalizeKey(string key)
        {

        }


    }
}