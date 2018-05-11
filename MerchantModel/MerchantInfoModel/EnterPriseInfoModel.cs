using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModel
{
    public class EnterPriseInfoModel:BaseModel
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        public string EnterPriseName { get; set; }

        /// <summary>
        /// 企业代码
        /// </summary>
        public string EnterPriseCode { get; set; }

        /// <summary>
        /// 注册地址
        /// </summary>
        public string RegisterAddress { get; set; }


        /// <summary>
        /// 法人
        /// </summary>
        public string LegalPerson { get; set; }

        /// <summary>
        /// 法人身份证
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 行业分类
        /// </summary>
        public string IndustryType { get; set; }

        /// <summary>
        /// 行业名称
        /// </summary>
        public string IndustryName { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 品牌简介
        /// </summary>
        public string BrandProfile { get; set; }

        /// <summary>
        /// 营业执照（图片地址）
        /// </summary>
        public string BusinessLicense { get; set; }

        /// <summary>
        /// 品牌编码
        /// </summary>
        public string BrandCode { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 账号头像
        /// </summary>
        public string UserAvatar { get; set; }

        /// <summary>
        /// 邮箱绑定状态
        /// </summary>
        public string UserEmailBind { get; set; }

        /// <summary>
        /// 企业认证状态(0 - 认证 1 - 未认证)
        /// </summary>
        public string Certification { get; set; }

    }
}
