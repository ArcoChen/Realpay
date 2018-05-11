using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModel
{
    /// <summary>
    /// 账号MODEL
    /// </summary>
    public class UserInfoModel:BaseModel
    {

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPasswd { get; set; }

        /// <summary>
        /// 头像路径
        /// </summary>
        public string UserAvatar { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        public string BusinessLicense { get; set; }

        /// <summary>
        /// 品牌Logo
        /// </summary>
        public string BrandLogo { get; set; }

        /// <summary>
        /// 登录ip
        /// </summary>
        public string LoginIP { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string FilePath { get; set; }

        public string Verification { get; set; }
    }
}
