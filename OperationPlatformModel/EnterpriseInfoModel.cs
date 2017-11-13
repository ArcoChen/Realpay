using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationPlatformModel
{
    public class EnterpriseInfoModel
    {
        public string SOURCE { get; set; }

        public string CREDENTIALS { get; set; }

        public string TERMINAL { get; set; }

        public string INDEX { get; set; }

        public string METHOD { get; set; }

        public string ADDRESS { get; set; }

        public string DATA { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        public string EnterpriseName { get; set; }

        /// <summary>
        /// 企业注册地址
        /// </summary>
        public string RegisterAddress { get; set; }

        /// <summary>
        /// 企业代码
        /// </summary>
        public string EnterpriseCode { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        public string BusinessLicense { get; set; }

        /// <summary>
        /// 法人
        /// </summary>
        public string LegalPerson { get; set; }

        /// <summary>
        /// 法人身份证
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 品牌简介
        /// </summary>
        public string BrandProfile { get; set; }

        /// <summary>
        /// 服务信息编号
        /// </summary>
        public string ServiceNumber { get; set; }

        /// <summary>
        /// 开通时间
        /// </summary>
        public string ServiceOpenDate { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public string ServiceCloseDate { get; set; }

        /// <summary>
        /// 账号状态（0-正常    1-暂停   2-注销）
        /// </summary>
        public string UserState { get; set; }

        /// <summary>
        /// 认证状态（0-未认证    1-已认证   2-认证不通过）
        /// </summary>
        public string Cerification { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string UserAccount { get; set; }
    }
}
