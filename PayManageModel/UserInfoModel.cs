using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayManageMentModel
{
    public class UserInfoModel:BaseModel
    {

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPasswd { get; set; }

        /// <summary>
        /// 支付密码
        /// </summary>
        public string PayPasswd { get; set; }

        /// <summary>
        /// 用户状态（0-正常、1-异常、2-注销、3-黑户、4-未开通）
        /// </summary>
        public string UserState { get; set; }

        /// <summary>
        /// 用户类型（0-平台、1-品牌、2-厂家、3-分销、4-门店、5-会员）
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserAvatar { get; set; }

        /// <summary>
        /// 用户身份证
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public string RegisterTime { get; set; }

        /// <summary>
        /// 账户余额
        /// </summary>
        public string UserBalance { get; set; }

        /// <summary>
        /// 单笔限额
        /// </summary>
        public string SingleLimit { get; set; }

        /// <summary>
        /// 单日限额
        /// </summary>
        public string DayLimit { get; set; }

        /// <summary>
        /// 用户唯一ID
        /// </summary>
        public string UserId { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string PageNum { get; set; }
    }
}
