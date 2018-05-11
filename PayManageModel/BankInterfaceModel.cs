using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayManageMentModel
{
    public class BankInterfaceModel:BaseModel
    {
        /// <summary>
        /// 支付机构名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 银行类型（0-银行、1-第三方机构）
        /// </summary>
        public string BankType { get; set; }

        /// <summary>
        /// 平台账号
        /// </summary>
        public string PlatformAccount { get; set; }

        /// <summary>
        /// 平台编号
        /// </summary>
        public string PlatformNumber { get; set; }

        /// <summary>
        /// 接口密钥
        /// </summary>
        public string InterfacePasswd { get; set; }

        /// <summary>
        /// 接口地址
        /// </summary>
        public string InterfaceAddress { get; set; }

        /// <summary>
        /// 支付密码
        /// </summary>
        public string PayPasswd { get; set; }

        /// <summary>
        /// 接口状态（0-启用、1-禁用、2-异常）
        /// </summary>
        public string InterfaceState { get; set; }

        /// <summary>
        /// 单笔限额
        /// </summary>
        public string SingleLimit { get; set; }

        /// <summary>
        /// 单日限额
        /// </summary>
        public string DayLimit { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public string RegisterTime { get; set; }

        public string PageNum { get; set; }

    }
}
