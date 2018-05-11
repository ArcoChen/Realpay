using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationPlatformModel
{
    public class RedpacketManageModel:BaseModel
    {


        /// <summary>
        /// 企业名称
        /// </summary>
        public string EnterpriseName { get; set; }

        /// <summary>
        /// 发放商品
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string CommodityCode { get; set; }

        /// <summary>
        /// 红包总额
        /// </summary>
        public string MoneySum { get; set; }

        /// <summary>
        /// 最大红包
        /// </summary>
        public string UnitMoney { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        public string StartName { get; set; }

        /// <summary>
        /// 支付状态(0-待支付，1-已支付)
        /// </summary>
        public string DistributeState { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public string ApplyTime { get; set; }

        /// <summary>
        /// 剩余金额
        /// </summary>
        public string SurplusMoney { get; set; }

        /// <summary>
        /// 审核状态（0：未审核，1：已通过，2：不通过）
        /// </summary>
        public string CheckState { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 支付状态（0：待支付，1：已支付）
        /// </summary>
        public string PayState { get; set; }
    }
}
