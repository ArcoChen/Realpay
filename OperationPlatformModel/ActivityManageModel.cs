using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationPlatformModel
{
    public class ActivityManageModel
    {
        public string SOURCE { get; set; }

        public string CREDENTIALS { get; set; }

        public string TERMINAL { get; set; }

        public string INDEX { get; set; }

        public string METHOD { get; set; }

        public string ADDRESS { get; set; }

        public string DATA { get; set; }

        /// <summary>
        /// 所属账号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 广告图
        /// </summary>
        public string FilePosition { get; set; }

        /// <summary>
        /// 广告链接
        /// </summary>
        public string LinkPosition { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 推送人次
        /// </summary>
        public string PushNum { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public string TollAmount { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public string ApplyTime { get; set; }

        /// <summary>
        /// 审核状态（0-未审核、1-待缴费、2-进行中、3-未通过）
        /// </summary>
        public string PushState { get; set; }

        /// <summary>
        /// 位置编号
        /// </summary>
        public string PositionNumber { get; set; }

        /// <summary>
        /// 推送群体
        /// </summary>
        public string IndustryName { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        public string EnterpriseName { get; set; }

        /// <summary>
        /// 已推送人次
        /// </summary>
        public string PushAlreadyNum { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 审核意见
        /// </summary>
        public string CheckOpinition { get; set; }
    }
}
