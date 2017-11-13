using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationPlatformModel
{
    public class UserInfoModel
    {
        public string SOURCE { get; set; }

        public string CREDENTIALS { get; set; }

        public string TERMINAL { get; set; }

        public string INDEX { get; set; }

        public string METHOD { get; set; }

        public string ADDRESS { get; set; }

        public string DATA { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPasswd { get; set; }

        /// <summary>
        /// 头像字符串
        /// </summary>
        public string UserAvatar { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 性别（0-男、1-女）
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 用户手机号
        /// </summary>
        public string UserMobile { get; set; }

        /// <summary>
        /// 手机验证码
        /// </summary>
        public string Verification { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 企业类型
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// 支付状态（0-开通支付、1-未开通）
        /// </summary>
        public string PaymentBind { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIP { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public string LoginTime { get; set; }

        /// <summary>
        /// 服务产品
        /// </summary>
        public string ServiceProduct { get; set; }

        /// <summary>
        /// 缴费状态（ 0-缴费、1-未缴费）
        /// </summary>
        public string PayState { get; set; }

        /// <summary>
        /// 账号状态
        /// </summary>
        public string UserState { get; set; }

        /// <summary>
        /// 实名认证状态
        /// </summary>
        public string Certification { get; set; }

        /// <summary>
        /// 验证状态(0-验证码错误，1-验证成功)
        /// </summary>
        public string VerifyState { get; set; }
    }
}
