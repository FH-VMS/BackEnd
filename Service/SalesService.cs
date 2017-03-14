using Interface;
using Model.Sale;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Service
{
    public class SalesService : AbstractService, ISale, IBase<SaleModel>
    {
        public int PostData(SaleModel saleInfo)
        {
            int result = 0;
            saleInfo.TradeStatus = 0;
            saleInfo.SalesDate = DateTime.Now;
            result = GenerateDal.Create(saleInfo);

            return result;
        }

        public int UpdateData(SaleModel saleInfo)
        {
            saleInfo.PayDate = DateTime.Now;
            return GenerateDal.Update(CommonSqlKey.UpdateSale, saleInfo);

        }

        public string GetPayResultById(string randomId)
        {
            SaleModel saleInfo = new SaleModel();
            saleInfo.RandomId = randomId;
            return GenerateDal.Single<SaleModel>(CommonSqlKey.GetPayResultById, saleInfo).ToString();
        }

        public List<SaleModel> GetAll(SaleModel saleInfo)
        {
            string userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();
            string userStatus = HttpContextHandler.GetHeaderObj("Sts").ToString();
            var result = new List<SaleModel>();
            var conditions = new List<Condition>();
            if (!string.IsNullOrEmpty(saleInfo.MachineId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "DeviceId",
                    DbColumnName = "DeviceId",
                    ParamValue = "%" + saleInfo.DeviceId + "%",
                    Operation = ConditionOperate.Like,
                    RightBrace = "",
                    Logic = ""
                });
            }

            if (!string.IsNullOrEmpty(saleInfo.PayType))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "PayType",
                    DbColumnName = "pay_type",
                    ParamValue = saleInfo.PayType,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }

            conditions.AddRange(CreatePaginConditions(saleInfo.PageIndex, saleInfo.PageSize));

            if (userStatus == "100" || userStatus == "99")
            {
                result = GenerateDal.LoadByConditions<SaleModel>(CommonSqlKey.GetSaleAllList, conditions);
            }
            else
            {
                conditions.Add(new Condition
                {
                    LeftBrace = "",
                    ParamName = "ClientId",
                    DbColumnName = "",
                    ParamValue = userClientId,
                    Operation = ConditionOperate.None,
                    RightBrace = "",
                    Logic = ""
                });
                result = GenerateDal.LoadByConditions<SaleModel>(CommonSqlKey.GetSaleList, conditions);
            }





            return result;
        }


        public int GetCount(SaleModel saleInfo)
        {
            var result = 0;

            string userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();
            string userStatus = HttpContextHandler.GetHeaderObj("Sts").ToString();
            var conditions = new List<Condition>();
            if (!string.IsNullOrEmpty(saleInfo.MachineId))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "DeviceId",
                    DbColumnName = "DeviceId",
                    ParamValue = "%" + saleInfo.DeviceId + "%",
                    Operation = ConditionOperate.Like,
                    RightBrace = "",
                    Logic = ""
                });
            }

            if (!string.IsNullOrEmpty(saleInfo.PayType))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "PayType",
                    DbColumnName = "pay_type",
                    ParamValue = saleInfo.PayType,
                    Operation = ConditionOperate.Equal,
                    RightBrace = "",
                    Logic = ""
                });
            }


            if (userStatus == "100" || userStatus == "99")
            {
                result = GenerateDal.CountByConditions(CommonSqlKey.GetSaleListAllCount, conditions);
            }
            else
            {
                conditions.Add(new Condition
                {
                    LeftBrace = "",
                    ParamName = "ClientId",
                    DbColumnName = "",
                    ParamValue = userClientId,
                    Operation = ConditionOperate.None,
                    RightBrace = "",
                    Logic = ""
                });
                result = GenerateDal.CountByConditions(CommonSqlKey.GetSaleListCount, conditions);
            }




            return result;
        }

        public int DeleteData(string id)
        {
            SaleModel salesInfo = new SaleModel();
            salesInfo.SalesIcId = id;
            return GenerateDal.Delete<SaleModel>(CommonSqlKey.DeleteSaleList, salesInfo);
        }


    }
}
