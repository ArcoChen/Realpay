using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModel
{
    /// <summary>
    /// 容错处理MODEL
    /// </summary>
     public class FaultToleranceModel:BaseModel
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 商品码
        /// </summary>
        public string CommodityCode { get; set; }

        /// <summary>
        /// 所属门店
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 门店地址
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// 销售累计
        /// </summary>
        public string ScanFrequency { get; set; }

        /// <summary>
        /// 上次扫码时间
        /// </summary>
        public string ScanTime { get; set; }

        /// <summary>
        /// 开始编码
        /// </summary>
        public string CodeStart { get; set; }

        /// <summary>
        /// 结束编码
        /// </summary>
        public string CodeEnd { get; set; }

        /// <summary>
        /// 消费用户
        /// </summary>
        public string PaymentUser { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string DealNumber { get; set; }

        /// <summary>
        /// 实际购买数量
        /// </summary>
        public string SalesVolume { get; set; }

        /// <summary>
        /// 退货数
        /// </summary>
        public string SalesReturnNumber { get; set; }

    }
}
