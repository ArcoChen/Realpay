using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;

namespace AppModel
{
    public class UserInfoModel:BaseModel
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string UserPasswd { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// 支付密码
        /// </summary>
        public string PayPasswd { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserAvatar { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        public string UserSex { get; set; }

        /// <summary>
        /// 用户地址
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIP { get; set; }

        public string CommodityCode { get; set; }

        public string NewPhoneNumber { get; set; }
    }
}
