using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModel
{
    public class CommodityReportIdentModel:BaseModel
    {

        /// <summary>
        /// 举报累计
        /// </summary>
        public string ReportNumber { get; set; }

        /// <summary>
        /// 举报用户
        /// </summary>
        public string ReportUser { get; set; }

        /// <summary>
        /// 举报时间
        /// </summary>
        public string ReportTime { get; set; }

        /// <summary>
        /// 举报商品名
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 举报商品码
        /// </summary>
        public string CommodityCode { get; set; }

        /// <summary>
        /// 所属门店地址
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// 被举报门店
        /// </summary>
        public string ReportAddress { get; set; }

        /// <summary>
        /// 举报问题
        /// </summary>
        public string ReportProblem { get; set; }

        /// <summary>
        /// 举报图片
        /// </summary>
        public string Screenshot { get; set; }

        /// <summary>
        /// 举报状态(0-未处理、1-已处理、2-无效)
        /// </summary>
        public string ReportState { get; set; }
    }
}
