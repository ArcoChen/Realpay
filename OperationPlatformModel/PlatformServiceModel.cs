using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationPlatformModel
{
    public class PlatformServiceModel:BaseModel
    {

        /// <summary>
        /// 服务选项
        /// </summary>
        public string ServiceOption { get; set; }

        /// <summary>
        /// 选项介绍
        /// </summary>
        public string OptionIntroduce { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public string EditTime { get; set; }

        /// <summary>
        /// 选项编号
        /// </summary>
        public string OptionNumber { get; set; }

        /// <summary>
        /// 服务茶品
        /// </summary>
        public string ServiceProduct { get; set; }

        /// <summary>
        /// 服务产品（EnglishName）
        /// </summary>
        public string EnServiceProduct { get; set; }

        /// <summary>
        /// 服务单价
        /// </summary>
        public string ChargePrice { get; set; }

        /// <summary>
        /// 收费单位
        /// </summary>
        public string ChargeUnit { get; set; }

        /// <summary>
        /// 包含选项
        /// </summary>
        public string ContainOption { get; set; }

        /// <summary>
        /// 服务介绍
        /// </summary>
        public string ServiceIntroduce { get; set; }


        /// <summary>
        /// 缴费状态
        /// </summary>
        public string PayState { get; set; }
    }
}
