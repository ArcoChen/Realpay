using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationPlatformModel
{
    public class PlatformReportModel
    {
        public string SOURCE { get; set; }

        public string CREDENTIALS { get; set; }

        public string TERMINAL { get; set; }

        public string INDEX { get; set; }

        public string METHOD { get; set; }

        public string ADDRESS { get; set; }

        public string DATA { get; set; }

        /// <summary>
        /// 被举报商品码
        /// </summary>
        public string CommodityCode { get; set; }

        /// <summary>
        /// 被举报商家
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 举报时间
        /// </summary>
        public string ReportTime { get; set; }

        /// <summary>
        /// 举报用户
        /// </summary>
        public string ReportUser { get; set; }

        /// <summary>
        /// 举报地址
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// 举报问题
        /// </summary>
        public string ReportProblem { get; set; }

        /// <summary>
        /// 举报图片
        /// </summary>
        public string ScreenShot { get; set; }

        /// <summary>
        /// 举报状态（0-待处理，1-已确认，2-无效举报）
        /// </summary>
        public string ReportState { get; set; }

        /// <summary>
        /// 审核意见
        /// </summary>
        public string CheckIdea { get; set; }
    }
}
