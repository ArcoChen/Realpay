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

        public string COMMODITY_DATA { get; set; }

        public string FilePath { get; set; }

        /// <summary>
        /// 商品图片 （0-添加 1-删除）
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// 7位商品码
        /// </summary>
        public string CommodityNumber { get; set; }

        /// <summary>
        /// 商品详情图
        /// </summary>
        public string CommodityProfile { get; set; }

        public string ImgStatus { get; set; }
    }
}
