using Interface;
using Model.Refund;
using Model.Sale;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class RefundService : AbstractService, IRefund
    {
        public List<SaleModel> GetRefundOrder(List<string> lstTradeNo)
        {

            var conditions = new List<Condition>();


            conditions.Add(new Condition
            {
                LeftBrace = " AND ",
                ParamName = "TradeNo",
                DbColumnName = "trade_no",
                ParamValue = string.Join(",", lstTradeNo),
                Operation = ConditionOperate.IN,
                RightBrace = "  ",
                Logic = "AND"
            });

            conditions.Add(new Condition
            {
                LeftBrace = "  ( ",
                ParamName = "TradeStatus0",
                DbColumnName = "trade_status",
                ParamValue = 3,
                Operation = ConditionOperate.Equal,
                RightBrace = "  ",
                Logic = "OR"
            });

            conditions.Add(new Condition
            {
                LeftBrace = "  ",
                ParamName = "TradeStatus1",
                DbColumnName = "trade_status",
                ParamValue = 5,
                Operation = ConditionOperate.Equal,
                RightBrace = " ) ",
                Logic = ""
            });
            return GenerateDal.LoadByConditions<SaleModel>(CommonSqlKey.GetRefundData, conditions);
            //HttpContext.Current.Response.Write(sHtmlText);
        }

        public int UpdateRefundResult(SaleModel saleInfo)
        {
            return GenerateDal.Update(CommonSqlKey.UpdateRefundResult, saleInfo);
        }

        /// <summary>
        /// 新增/修改会员信息
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public int PostRefundDetail(RefundModel refundInfo)
        {
            int result=0;

            try
            {
                result = GenerateDal.Create(refundInfo);
            }
            catch (Exception e)
            {

            }

            return result;
        }

       
    }
}
