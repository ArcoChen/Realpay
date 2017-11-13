using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModel
{
    /// <summary>
    /// 编码管理MODEL
    /// </summary>
    public class CodeServiceInfoModel:BaseModel
    {
        /// <summary>
        /// 服务产品
        /// </summary>
        public string ServiceProduct { get; set; }

        /// <summary>
        /// 编码数
        /// </summary>
        public string ProductSum { get; set; }

        /// <summary>
        /// 编码单价
        /// </summary>
        public string UnitPrice { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public string OpenTime { get; set; }

        /// <summary>
        /// 缴费状态
        /// </summary>
        public string PayState { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 包装码
        /// </summary>
        public string PackingCode { get; set; }
    }
}
