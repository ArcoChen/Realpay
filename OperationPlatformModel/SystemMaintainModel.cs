using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationPlatformModel
{
    public class SystemMaintainModel
    {
        public string SOURCE { get; set; }

        public string CREDENTIALS { get; set; }

        public string TERMINAL { get; set; }

        public string INDEX { get; set; }

        public string METHOD { get; set; }

        public string ADDRESS { get; set; }

        public string DATA { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public string EditTime { get; set; }

        /// <summary>
        /// 行业名称
        /// </summary>
        public string IndustryName { get; set; }

        /// <summary>
        /// 品牌编码
        /// </summary>
        public string BrandCode { get; set; }

        /// <summary>
        /// 所属用户
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 品牌信息
        /// </summary>
        public string BrandProfile { get; set; }
        /// <summary>
        /// 广告位置
        /// </summary>
        public string AdvertisementName { get; set; }
        
        /// <summary>
        /// 收费标准
        /// </summary>
        public string TollStandard { get; set; }

        /// <summary>
        /// 免费次数
        /// </summary>
        public string FreeSum { get; set; }

        /// <summary>
        /// 图片大小限制
        /// </summary>
        public string FileSize { get; set; }

        /// <summary>
        /// 图片宽度
        /// </summary>
        public string DimensionWide { get; set; }

        /// <summary>
        /// 图片高度
        /// </summary>
        public string DimensionLong { get; set; }

        /// <summary>
        /// 是否启用（0-不启用，1-启用）
        /// </summary>
        public string EnableState { get; set; }
    }
}
