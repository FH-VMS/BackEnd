using Model.Pay;
using Model.Refund;
using Model.Sale;
using Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface
{
    public interface ISale
    {
        [Remark("获取支付结果", ParmsNote = "随机码,交易状态，机器编号", ReturnNote = "支付结果")]
        List<KeyTunnelModel> GetPayResult(string randomId, string tradeStatus, string machineId);

        [Remark("退款详情", ParmsNote = "商户订单号,交易号", ReturnNote = "支付结果")]
        RefundModel GetRefundDetail(string orderNo, string typ);
    }
}
