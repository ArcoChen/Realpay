using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModel
{
    public class TerminalModel:BaseModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string UserWorkstation { get; set; }

        /// <summary>
        /// 工作站名称
        /// </summary>
        public string WorkstationName { get; set; }

        /// <summary>
        /// 终端功能(0-采集、1-打码、2-包装)
        /// </summary>
        public string FunctionType { get; set; }

        /// <summary>
        /// 绑定手机
        /// </summary>
        public string ConfirmMobile { get; set; }

        /// <summary>
        /// 工作地址
        /// </summary>
        public string WorkAddress { get; set; }

        /// <summary>
        /// MAC地址
        /// </summary>
        public string MACAddress { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string LogintudeValue { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string LatitudeValue { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public string LoginNum { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public string LoginTime { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIP { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public string LoginLastTime { get; set; }

        /// <summary>
        /// 上次登录IP
        /// </summary>
        public string LoginLastIP { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        public string NewPasswd { get; set; }

        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPasswd { get; set; }

        public string UpdateType { get; set; }
    }
}
