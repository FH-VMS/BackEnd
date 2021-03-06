﻿using Chuang.Back.Base;
using Interface;
using Model.Pay;
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
    public class PayConfigController : ApiBaseController
    {
        private static IBase<ConfigModel> _IBase
        {
            get
            {
                return new PayConfigService();
            }
        }

        public ResultObj<List<ConfigModel>> GetData(int pageIndex = 1, int pageSize = 10)
        {
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();

            ConfigModel configInfo = new ConfigModel();
            configInfo.PageIndex = pageIndex;
            configInfo.PageSize = pageSize;
            var users = _IBase.GetAll(configInfo);
            int totalcount = _IBase.GetCount(configInfo);

            var pagination = new Pagination { PageSize = pageSize, PageIndex = pageIndex, StartIndex = 0, TotalRows = totalcount, TotalPage = 0 };
            return Content(users, pagination);
        }

        public ResultObj<int> PostData(ConfigModel configInfo)
        {
                return Content(_IBase.PostData(configInfo));
        }

        public ResultObj<int> PutData(ConfigModel configInfo)
        {
            return Content(_IBase.UpdateData(configInfo));
        }

        public ResultObj<int> DeleteData(string idList)
        {
            return Content(_IBase.DeleteData(idList));
        }


    }
}