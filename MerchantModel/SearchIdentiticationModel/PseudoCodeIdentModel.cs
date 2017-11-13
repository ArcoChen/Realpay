using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModel
{
    public class PseudoCodeIdentModel : BaseModel
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 商品码
        /// </summary>
        public string CommodityCode { get; set; }

        /// <summary>
        /// 门店地址
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// 伪码累计
        /// </summary>
        public string PseudoCodeNumber { get; set; }

        /// <summary>
        /// 扫码用户
        /// </summary>
        public string PaymentUser { get; set; }

        /// <summary>
        /// 扫码时间
        /// </summary>
        public string ScanTime { get; set; }

        /// <summary>
        /// 是否举报
        /// </summary>
        public string ReportState { get; set; }
    }
}
