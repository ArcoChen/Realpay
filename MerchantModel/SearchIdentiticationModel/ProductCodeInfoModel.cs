using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModel
{
    /// <summary>
    /// 赋码管理MODEL
    /// </summary>
    public class ProductCodeInfoModel : BaseModel
    {

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 编码状态0-未扫码、1-已扫码、2-作废（已销售）
        /// </summary>
        public string ScanState { get; set; }

        /// <summary>
        /// 开始编码
        /// </summary>
        public string CodeStart { get; set; }

        /// <summary>
        /// 结束编码
        /// </summary>
        public string CodeEnd { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public string ApplyBatch { get; set; }

        /// <summary>
        /// 编码总数
        /// </summary>
        public string ApplySum { get; set; }

        /// <summary>
        /// 已激活数
        /// </summary>
        public string ActivationSum { get; set; }

        /// <summary>
        /// 申请用户
        /// </summary>
        public string ApplyUser { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public string ApplyTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public string ActivationTime { get; set; }
    }
}
