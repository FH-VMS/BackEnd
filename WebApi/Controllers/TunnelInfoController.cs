using Chuang.Back.Base;
using Interface;
using Model.Machine;
using Model.Sys;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Chuang.Back.Controllers
{
    public class TunnelInfoController : ApiBaseController
    {
        private static IBase<TunnelInfoModel> _IBase
        {
            get
            {
                return new TunnelInfoService();
            }
        }

        public ResultObj<List<TunnelInfoModel>> GetData(string machineId = "", string cabinetId = "", int pageIndex = 1, int pageSize = 10)
        {
            // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();

            TunnelInfoModel tunnelConfigInfo = new TunnelInfoModel();
            tunnelConfigInfo.MachineId = machineId;
            tunnelConfigInfo.CabinetId = cabinetId;
            tunnelConfigInfo.PageIndex = pageIndex;
            tunnelConfigInfo.PageSize = pageSize;
            var tunnels = _IBase.GetAll(tunnelConfigInfo);
            int totalcount = _IBase.GetCount(tunnelConfigInfo);

            var pagination = new Pagination { PageSize = pageSize, PageIndex = pageIndex, StartIndex = 0, TotalRows = totalcount, TotalPage = 0 };
            return Content(tunnels, pagination);
        }

        public ResultObj<int> PostData(TunnelInfoModel tunnelConfigInfo)
        {
            return Content(_IBase.PostData(tunnelConfigInfo));
        }

        public ResultObj<int> PutData(TunnelInfoModel tunnelConfigInfo)
        {
            return Content(_IBase.UpdateData(tunnelConfigInfo));
        }

        public ResultObj<int> DeleteData(string idList)
        {
            return Content(_IBase.DeleteData(idList));
        }

        //补货单生成
        public ResultObj<List<TunnelInfoModel>> GetFullfilAll(string machineId = "", string cabinetId = "", int pageIndex = 1, int pageSize = 10)
        {
            IFullfilBill ifullfilBill = new TunnelInfoService();
            TunnelInfoModel tunnelConfigInfo = new TunnelInfoModel();
            tunnelConfigInfo.MachineId=machineId;
            tunnelConfigInfo.CabinetId=cabinetId;
            tunnelConfigInfo.PageIndex=pageIndex;
            tunnelConfigInfo.PageSize=pageSize;
            var fullfilInfo = ifullfilBill.GetFullfilAll(tunnelConfigInfo);
            int totalcount = ifullfilBill.GetFullfilCount(tunnelConfigInfo);

            var pagination = new Pagination { PageSize = pageSize, PageIndex = pageIndex, StartIndex = 0, TotalRows = totalcount, TotalPage = 0 };
            return Content(fullfilInfo, pagination);
        }

        //手机补充库存
        public ResultObj<int> PutStockWithMobile(List<TunnelInfoModel> lstTunnelInfo)
        {
              IFullfilBill ifullfilBill = new TunnelInfoService();
              int result = ifullfilBill.UpdateStockWithMobile(lstTunnelInfo);
              return Content(result);
        }

        //导出补货单
        public void ExportFullfilData(string machineId = "", string cabinetId = "")
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("sheet1");

            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("教师姓名");
            row.CreateCell(1).SetCellValue("学校");
            row.CreateCell(2).SetCellValue("年级平均分");
            row.CreateCell(3).SetCellValue("年级最高分");
            row.CreateCell(4).SetCellValue("年级最低分");
            row.CreateCell(5).SetCellValue("全市所处名次");

            sheet.SetColumnWidth(1, 5000);
            sheet.SetColumnWidth(2, 5000);
            sheet.SetColumnWidth(3, 5000);
            sheet.SetColumnWidth(4, 5000);
            sheet.SetColumnWidth(5, 5000);
            /*
            for (var i = 0; i < list.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                row1.CreateCell(0).SetCellValue(list[i].XM);
                row1.CreateCell(1).SetCellValue(list[i].XXMC);
                row1.CreateCell(2).SetCellValue(list[i].AVGScore.ToFloat());
                row1.CreateCell(3).SetCellValue(list[i].MaxScore.ToFloat());
                row1.CreateCell(4).SetCellValue(list[i].MinScore.ToFloat());
                row1.CreateCell(5).SetCellValue(list[i].OrderNumber);
            }
             * */
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            workbook.Write(ms);
            ms.Position = 0;

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            var fileName = "教学排名.xls";


            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = System.Web.HttpUtility.UrlEncode(fileName)
            };
            //return response;
        }
    }
}