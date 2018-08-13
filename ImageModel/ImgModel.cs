using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageModel
{
    public class ImgModel
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 保存图片的根目录
        /// </summary>
        public string ImgRoot { get; set; }

        /// <summary>
        /// 图片字符串
        /// </summary>
        public string ImgString { get; set; }

        /// <summary>
        /// 图片所属属性
        /// </summary>
        public string ImgAttribute { get; set; }

        /// <summary>
        /// 存放磁盘
        /// </summary>
        public string ImgDisk { get; set; }

        /// <summary>
        /// 图片IP
        /// </summary>
        public string ImgIp { get; set; }

        /// <summary>
        /// 图片上传日期（用于举报）
        /// </summary>
        public string ImgUpLoadDate { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImgName { get; set; }

        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 源地址
        /// </summary>
        public string SourceFileName { get; set; }

        /// <summary>
        /// 保存的新地址
        /// </summary>
        public string DestFileName { get; set; }

        /// <summary>
        /// 7位商品码
        /// </summary>
        public string CommodityNumber{ get; set; }

    }
}
