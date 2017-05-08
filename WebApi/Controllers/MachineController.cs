using Chuang.Back.Base;
using Interface;
using Model.Machine;
using Model.Pay;
using Model.Sale;
using Model.Sys;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;
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
            //trade_status: (0:待支付，1:支付成功待出货,2：支付成功且已全部出货,3：支付成功部分出货成功未退款，4:支付成功部分出货成功已退款，5：支付成功此货道出货全部出货失败未退款，5：支付成功此货道出货全部出货失败已退款)
            List<KeyTunnelModel> lstSales = _isale.GetPayResult("", "1", keyJsonInfo.m);
            if (lstSales.Count == 0)
            {
                return "";
            }
            return JsonHandler.GetJsonStrFromObject(lstSales,false);
        }

        //出货后，告诉汇报出货情况并更新库存
        public string GetOutResult(string k)
        {
            KeyJsonModel keyJsonInfo = AnalizeKey(k);
            int result = _IMachine.PutPayResult(keyJsonInfo);

            return result==1?"OK":"NG";
        }

        // 心跳
        public string GetHeartBeep(string k)
        {
            KeyJsonModel keyJsonInfo = AnalizeKey(k);
            DataTable dt = _IMachine.GetBeepHeart(keyJsonInfo.m);
            return JsonHandler.DataTable2Json(dt);
        }

        // 上报机器下行处理结果
        public string GetHandleResult(string k)
        {
            ToMachineModel toMachineInfo = JsonHandler.GetObjectFromJson<ToMachineModel>(k);
            int result = _IMachine.GetHandleResult(toMachineInfo.m, toMachineInfo.s);
            return result == 1 ? "OK" : "NG";
        }

        //向机器下行价格
        public string GetToMachinePrice(string k)
        {
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(k);
            return JsonHandler.DataTable2Json(_IMachine.GetToMachinePrice(values["m"], Convert.ToInt32(values["start"]), Convert.ToInt32(values["len"])));
        }

         //向机器下行当前补货库存
        public string GetToMachineStock(string k)
        {
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(k);
            return JsonHandler.DataTable2Json(_IMachine.GetToMachineStock(values["m"], Convert.ToInt32(values["start"]), Convert.ToInt32(values["len"])));
        }

        //一键补货
        public string GetFullfilGood(string k)
        {
            KeyJsonModel keyJsonInfo = AnalizeKey(k);
            int result = _IMachine.GetFullfilGood(keyJsonInfo.m);
            return result == 1 ? "OK" : "NG";
        }

        //按货道补货
        public string GetFullfilGoodByTunnel(string k)
        {
            KeyJsonModel keyJsonInfo = AnalizeKey(k);
            int result = _IMachine.GetFullfilGoodByTunnel(keyJsonInfo);
            return result == 1 ? "OK" : "NG";
        }

        //机器端设置价格和最大库存上报
        public string GetReportMaxStockAndPrice(string k)
        {
            PriceAndMaxStock priceAndMaxStock = JsonHandler.GetObjectFromJson<PriceAndMaxStock>(k);
            int result = _IMachine.PostMaxStockAndPrice(priceAndMaxStock.t, priceAndMaxStock.m);
            return result == 1 ? "OK" : "NG";
        }

        public string GetMachineSetting(string k)
        {
            KeyJsonModel keyJsonInfo = AnalizeKey(k);
            DataTable dt = _IMachine.GetMachineSetting(keyJsonInfo.m);
            return JsonHandler.DataTable2Json(dt);
        }

        // 微信支付结果
        public ResultObj<int> PostPayResultW()
        {
           
            Stream s = System.Web.HttpContext.Current.Request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            string postStr = Encoding.UTF8.GetString(b);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(postStr);
            // 商户交易号
            XmlNode tradeNoNode = xmlDoc.SelectSingleNode("xml/out_trade_no");
             IMachine _imachine = new MachineService();
             if (_imachine.GetCountByTradeNo(tradeNoNode.InnerText) > 0)
             {
                 return Content(1);
             }
            //支付结果
            XmlNode payResultNode = xmlDoc.SelectSingleNode("xml/result_code");
            if(payResultNode.InnerText.ToUpper()=="SUCCESS")
            {
                /*******************************放到微信支付通知参数里，因参数只支付最大128个字符长度，所以注释修改*****************************/
                //XmlNode tunnelNode = xmlDoc.SelectSingleNode("xml/attach");
                //KeyJsonModel keyJsonModel = JsonHandler.GetObjectFromJson<KeyJsonModel>(tunnelNode.InnerText);

                string jsonProduct = FileHandler.ReadFile("data/" + tradeNoNode.InnerText + ".wa");
                KeyJsonModel keyJsonModel = JsonHandler.GetObjectFromJson<KeyJsonModel>(jsonProduct);

                _imachine.PostPayResultW(keyJsonModel, tradeNoNode.InnerText);
                //删除文件
                FileHandler.DeleteFile("data/" + tradeNoNode.InnerText + ".wa");
            }

            return Content(1);
            //File.WriteAllText(@"c:\text.txt", postStr); 
        }

        //支付宝支付结果
        /*
        public ResultObj<int> PostPayResultA(List<ProductModel> listProductInfo)
        {
            
            IMachine _imachine = new MachineService();
            _imachine.PostPayResultA(listProductInfo);
            return Content(1);
        }
        */
        public ResultObj<int> PostPayResultA()
        {
           
            string outTradeNo = HttpContext.Current.Request.Form["out_trade_no"];
            IMachine _imachine = new MachineService();
            if (_imachine.GetCountByTradeNo(outTradeNo) > 0)
            {
                return Content(1);
            }

            string tradeStatus = HttpContext.Current.Request.Form["trade_status"].ToUpper();
            if (tradeStatus == "TRADE_SUCCESS")
            {
                /*******************************放到微信支付通知参数里，因参数只支付最大128个字符长度，所以注释修改*****************************/
                //string jsonProduct = HttpContext.Current.Request.Form["body"];
                //KeyJsonModel keyJsonModel = JsonHandler.GetObjectFromJson<KeyJsonModel>(jsonProduct);

                string jsonProduct = FileHandler.ReadFile("data/" + outTradeNo + ".wa");
                KeyJsonModel keyJsonModel = JsonHandler.GetObjectFromJson<KeyJsonModel>(jsonProduct);
                _imachine.PostPayResultA(keyJsonModel, outTradeNo);
                //删除文件
                FileHandler.DeleteFile("data/" + outTradeNo + ".wa");
            }
            return Content(1);
        }


        //取商品列表
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


        public ResultObj<string> GetTest()
        {
            return Content("中文中文");
        }
    }
}