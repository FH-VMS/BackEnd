﻿using Chuang.Back.Base;
using Interface;
using Model.Customer;
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
    public class CustomerController :  ApiBaseController
    {
        private static IBase<CustomerModel> _IBase
        {
            get
            {
                return new CustomerService();
            }
        }

        public ResultObj<List<CustomerModel>> GetData(string clientName = "", int pageIndex = 1, int pageSize = 10)
        {
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();
            CustomerModel cusInfo = new CustomerModel();
            cusInfo.ClientName = clientName;
            cusInfo.PageIndex = pageIndex;
            cusInfo.PageSize = pageSize;
            int totalcount = _IBase.GetCount(cusInfo);
            var data = _IBase.GetAll(cusInfo);
            var pagination = new Pagination { PageSize = pageSize, PageIndex = pageIndex, StartIndex = 0, TotalRows = totalcount, TotalPage = 0 };
            return Content(data, pagination);
        }

        public ResultObj<int> PostData(CustomerModel customerInfo)
        {
            customerInfo.CreateDate = DateTime.Now;
            return Content(_IBase.PostData(customerInfo));
        }

        public ResultObj<int> PutData(CustomerModel customerInfo)
        {
            customerInfo.UpdateDate = DateTime.Now;
            return Content(_IBase.UpdateData(customerInfo));
        }

        public ResultObj<int> DeleteData(string idList)
        {
            return Content(_IBase.DeleteData(idList));
        }

        


    }
}
