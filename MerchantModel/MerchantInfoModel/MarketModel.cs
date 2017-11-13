﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModel
{
    /// <summary>
    /// 合作商家MODEL
    /// </summary>
    public class MarketModel:BaseModel
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        public string EnterPriseName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string UserSex { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IDNumber { get; set; }
        
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 物流公司名
        /// </summary>
        public string CarrierName { get; set; }

        /// <summary>
        /// 物流单位地址
        /// </summary>
        public string CarrierAddress { get; set; }

        /// <summary>
        /// 物流单位联系电话
        /// </summary>
        public string ContactNumber { get; set; }
    }
}