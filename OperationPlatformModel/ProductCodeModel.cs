using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationPlatformModel
{
    public class ProductCodeModel:BaseModel
    {


        /// <summary>
        /// 所属企业
        /// </summary>
        public string EnterpriseName { get; set; }

        /// <summary>
        /// 品牌名
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 商品图片路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string CommodityCode { get; set; }

        /// <summary>
        /// 请求编码时间
        /// </summary>
        public string ApplyTime { get; set; }

        /// <summary>
        /// 厂家地址
        /// </summary>
        public string EnterpriseAddress { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public string ProductionTime { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public string ApplyBatch { get; set; }

        /// <summary>
        /// 开始编码
        /// </summary>
        public string CodeStart { get; set; }

        /// <summary>
        /// 终止编码
        /// </summary>
        public string CodeEnd { get; set; }

        /// <summary>
        /// 编码总数
        /// </summary>
        public string CodeTotal { get; set; }

        /// <summary>
        /// 已激活数
        /// </summary>
        public string ActivatedNumber { get; set; }

        /// <summary>
        /// 为激活数
        /// </summary>
        public string InactiveNumber { get; set; }

        /// <summary>
        /// 激活比例
        /// </summary>
        public string ActivationRatio { get; set; }

        /// <summary>
        /// 已激活编码
        /// </summary>
        public string ActivatedCode { get; set; }

        /// <summary>
        /// 激活时间
        /// </summary>
        public string ActivationTime { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public string AuditingState { get; set; }

        /// <summary>
        /// 终端审核状态
        /// </summary>
        public string ValidateStatus { get; set; }
    }
}
