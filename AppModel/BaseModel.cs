using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModel
{
    public class BaseModel
    {
        public string SOURCE { get; set; }

        public string CREDENTIALS { get; set; }

        public string TERMINAL { get; set; }

        public string INDEX { get; set; }

        public string METHOD { get; set; }

        public string ADDRESS { get; set; }

        public string DATA { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string UserMobile { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Verification { get; set; }
    }
}
