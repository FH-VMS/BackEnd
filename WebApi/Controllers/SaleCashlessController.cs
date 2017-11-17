﻿using Chuang.Back.Base;
using Interface;
using Model.Refund;
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
    public class SaleCashlessController : ApiBaseController
    {
        private static IBase<SaleModel> _IBase
        {
            get
            {
                return new SalesService();
            }
        }

        public ResultObj<List<SaleModel>> GetData(string deviceId = "", string payType = "", string tradeStatus="", string salesDate="",string tradeNo="", int pageIndex = 1, int pageSize = 10)
        {
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();

            SaleModel saleInfo = new SaleModel();
            saleInfo.DeviceId = deviceId;
            saleInfo.PayType = payType;
            saleInfo.TradeNo = tradeNo;
            if (!string.IsNullOrEmpty(tradeStatus))
            {
                saleInfo.TradeStatus = Convert.ToInt32(tradeStatus);
            }

            if (!string.IsNullOrEmpty(salesDate))
            {
                saleInfo.SaleDateStart = salesDate.Split('^')[0];
                saleInfo.SaleDateEnd = salesDate.Split('^')[1];
            }
            
            saleInfo.PageIndex = pageIndex;
            saleInfo.PageSize = pageSize;
            var sales = _IBase.GetAll(saleInfo);
            int totalcount = _IBase.GetCount(saleInfo);

            var pagination = new Pagination { PageSize = pageSize, PageIndex = pageIndex, StartIndex = 0, TotalRows = totalcount, TotalPage = 0 };
            return Content(sales, pagination);
        }

        public ResultObj<int> PostData(SaleModel saleInfo)
        {
            return Content(_IBase.PostData(saleInfo));
        }

        public ResultObj<int> PutData(SaleModel saleInfo)
        {
            return Content(_IBase.UpdateData(saleInfo));
        }

        public ResultObj<int> DeleteData(string idList)
        {
            return Content(_IBase.DeleteData(idList));
        }

        public ResultObj<RefundModel> GetRefundDetail(string orderNo, string typ)
        {
            ISale isale = new SalesService();
            return Content(isale.GetRefundDetail(orderNo, typ));
        }

        public ResultObj<string> GetStatisticSalesMoneyByDate(string salesDate="")
        {
            SaleModel saleInfo = new SaleModel();

            if (!string.IsNullOrEmpty(salesDate))
            {
                saleInfo.SaleDateStart = salesDate.Split('^')[0];
                saleInfo.SaleDateEnd = salesDate.Split('^')[1];
            }
            IStatistic istatistic = new StatisticService();
            string retutStr = JsonHandler.DataTable2Json(istatistic.GetStatisticSalesMoneyByDate(saleInfo));
            return Content(retutStr);
        }
    }
}