﻿using Chuang.Back.Base;
using Interface;
using Model.Common;
using Model.Machine;
using Model.Sys;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
              

                var file = ExcelStream(machineIds);
                //string csv = _service.GetData(model);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StreamContent(file);
                //a text file is actually an octet-stream (pdf, etc)
                //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
                //we used attachment to force download
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = "补货单" + DateTime.Now.ToString("yyyyMMddHHmmss") +".xls";
                return result;
         }


         //得到excel文件流
         private System.IO.Stream ExcelStream(string machineIds)
         {
             HSSFWorkbook hssfworkbook = new HSSFWorkbook();
             MemoryStream file = new MemoryStream();
             
             foreach (string machineId in machineIds.Split('^'))
             {
                 int nowRow = 0;
                 IFullfilBill ifullFill = new TunnelInfoService();
                 DataTable dtProduct = ifullFill.ExportByProduct(machineId);
                 DataTable dtTunnel = ifullFill.ExportByTunnel(machineId);
                 ISheet sheet1 = hssfworkbook.CreateSheet(machineId);
                 IRow rowHeader = sheet1.CreateRow(nowRow);

                 sheet1.AddMergedRegion(new CellRangeAddress(nowRow, nowRow, 0, 3));
                 //生成excel标题
                 rowHeader.CreateCell(0).SetCellValue("补货单   导出时间:"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                 //第二行
                 nowRow += 1;
                 ICommon icommon = new CommonService();
                 List<CommonDic> lstCommon=icommon.GetMachineNameById(machineId);
                 sheet1.CreateRow(nowRow).CreateCell(0).SetCellValue("机器编号：" + lstCommon[0].Id + lstCommon[0].Name);
                 sheet1.AddMergedRegion(new CellRangeAddress(nowRow, nowRow, 0, 3));

                 nowRow = nowRow+1;
                 IRow titleRow = sheet1.CreateRow(nowRow);
                 sheet1.AddMergedRegion(new CellRangeAddress(nowRow, nowRow, 0, 1));
                 sheet1.AddMergedRegion(new CellRangeAddress(nowRow, nowRow, 2, 3));
                 titleRow.CreateCell(0).SetCellValue("商品名称");
                 titleRow.CreateCell(2).SetCellValue("缺货数");
                 for (int i = 0; i < dtProduct.Rows.Count; i++)
                 {
                     nowRow = nowRow + 1;
                     NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(nowRow);
                     sheet1.AddMergedRegion(new CellRangeAddress(nowRow,nowRow, 0, 1));
                     sheet1.AddMergedRegion(new CellRangeAddress(nowRow, nowRow, 2, 3));
                     rowtemp.CreateCell(0).SetCellValue(dtProduct.Rows[i]["wares_name"].ToString());
                     rowtemp.CreateCell(2).SetCellValue(dtProduct.Rows[i]["currMissing"].ToString());
                     sheet1.AutoSizeColumn(i);
                 }
                 nowRow = nowRow + 1;
                 sheet1.CreateRow(nowRow);
                 sheet1.AddMergedRegion(new CellRangeAddress(nowRow, nowRow, 0, 3));
                 nowRow = nowRow + 1;
                 NPOI.SS.UserModel.IRow secondRowTitle = sheet1.CreateRow(nowRow);
                 secondRowTitle.CreateCell(0).SetCellValue("货道号");
                 secondRowTitle.CreateCell(1).SetCellValue("商品名称");
                 secondRowTitle.CreateCell(2).SetCellValue("满货容量");
                 secondRowTitle.CreateCell(3).SetCellValue("缺货数");
                  for (int i = 0; i < dtTunnel.Rows.Count; i++)
                  {
                      nowRow = nowRow + 1;
                      NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(nowRow);
                      rowtemp.CreateCell(0).SetCellValue(dtTunnel.Rows[i]["tunnel_id"].ToString());
                      rowtemp.CreateCell(1).SetCellValue(dtTunnel.Rows[i]["wares_name"].ToString());
                      rowtemp.CreateCell(2).SetCellValue(dtTunnel.Rows[i]["max_puts"].ToString());
                      rowtemp.CreateCell(3).SetCellValue(dtTunnel.Rows[i]["curr_missing"].ToString());
                      sheet1.AutoSizeColumn(i);
                  }
                  
                  hssfworkbook.Write(file);
                  file.Seek(0, SeekOrigin.Begin);
             }
             //var list = dc.v_bs_dj_bbcdd1.Where(eps).ToList();
            
 
           


           

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


           
           

            return file;

            //return File(file, "application/vnd.ms-excel", "保税订单.xls");
        }
    }
}