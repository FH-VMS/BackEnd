using Chuang.Back.Base;
using Interface;
using Model.Machine;
using Model.Sys;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
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
        public HttpResponseMessage GetExportFullfilData(string machineIds) // 以逗号隔开
        {
                if(string.IsNullOrEmpty(machineIds))
                {
                    return null;
                }
                foreach (string machineId in machineIds.Split('^'))
                {

                }
                
                var file = ExcelStream();
                //string csv = _service.GetData(model);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StreamContent(file);
                //a text file is actually an octet-stream (pdf, etc)
                //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
                //we used attachment to force download
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = "补货单"+"file.xls";
                return result;
         }


         //得到excel文件流
         private System.IO.Stream ExcelStream()
         {
             //var list = dc.v_bs_dj_bbcdd1.Where(eps).ToList();
             HSSFWorkbook hssfworkbook = new HSSFWorkbook();
 
            ISheet sheet1 = hssfworkbook.CreateSheet("保税订单");


            IRow rowHeader = sheet1.CreateRow(0);

            //生成excel标题
            rowHeader.CreateCell(0).SetCellValue("汇通单号");
            rowHeader.CreateCell(1).SetCellValue("单据日期");
            rowHeader.CreateCell(2).SetCellValue("订单号");
            rowHeader.CreateCell(3).SetCellValue("收件人");
            rowHeader.CreateCell(4).SetCellValue("收件人电话");
            rowHeader.CreateCell(5).SetCellValue("收件人地址");
            rowHeader.CreateCell(6).SetCellValue("物流公司");
            rowHeader.CreateCell(7).SetCellValue("运单号");
            rowHeader.CreateCell(8).SetCellValue("数量");
            rowHeader.CreateCell(9).SetCellValue("状态");

            //生成excel内容
            //for (int i = 0; i < list.Count; i++)
            //{
            //    NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
            //    rowtemp.CreateCell(0).SetCellValue(list[i].bh_user);
            //    rowtemp.CreateCell(1).SetCellValue(list[i].rq.Value.ToString("yyyy-MM-dd HH:mm:dd"));
            //    rowtemp.CreateCell(2).SetCellValue(list[i].bh_khdd);
            //    rowtemp.CreateCell(3).SetCellValue(list[i].re_name);
            //    rowtemp.CreateCell(4).SetCellValue(list[i].re_tel);
            //    rowtemp.CreateCell(5).SetCellValue(list[i].re_fulladdress);
            //    rowtemp.CreateCell(6).SetCellValue(list[i].bm_kdgs);
            //    rowtemp.CreateCell(7).SetCellValue(list[i].kddh);
            //    rowtemp.CreateCell(8).SetCellValue((int)list[i].sl_total);
            //    rowtemp.CreateCell(9).SetCellValue(list[i].mc_state_dd);
            //}

            for (int i = 0; i < 10; i++)
                sheet1.AutoSizeColumn(i);

            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            file.Seek(0, SeekOrigin.Begin);

            return file;

            //return File(file, "application/vnd.ms-excel", "保税订单.xls");
        }
    }
}