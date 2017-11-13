using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModel
{
    /// <summary>
    /// 促销活动MODEL
    /// </summary>
    public  class AdvertiseMentModel:BaseModel
    {
        /// <summary>
        /// 广告位置编号
        /// </summary>
        public string PositionNumber { get; set; }

        /// <summary>
        /// 广告位置
        /// </summary>
        public string AdvertisementName { get; set; }

        /// <summary>
        /// 广告图
        /// </summary>
        public string FilePosition { get; set; }

        /// <summary>
        /// 广告链接
        /// </summary>
        public string LinkPosition { get; set; }

        /// <summary>
        /// 免费人次
        /// </summary>
        public string PushSum { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public string TollAmount { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public string ApplyTime { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public string PushState { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 商品图
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 已推送人次
        /// </summary>
        public string CumulativeSum { get; set; }

        /// <summary>
        /// 红包金额
        /// </summary>
        public string MonySum { get; set; }

        /// <summary>
        /// 最大红包
        /// </summary>
        public string UnitMoney { get; set; }

        /// <summary>
        /// 剩余金额
        /// </summary>
        public string SurplusMoney { get; set; }

        /// <summary>
        /// 审核状态(0-未审核、1-待缴费、3-未通过)
        /// </summary>
        public string DistributeState { get; set; }
    }
}
