using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Domain.Upload
{
    /// <summary>
    /// 附件
    /// </summary>
    public class Annex : BaseEntity
    {
        public int Id { get { return FileId; } }

        /// <summary>
        /// 图片ID
        /// </summary>
        public int FileId { get; set; }

        /// <summary>
        /// 类别编号
        /// </summary>
        public int CateId { get; set; }

        /// <summary>
        /// 上传者
        /// </summary>
        public string Uploader { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 扩展名
        /// </summary>
        public string Ext { get; set; }

        /// <summary>
        /// 图片大小
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 允许的格式
        /// </summary>
        public string AllowExt { get; set; }

        /// <summary>
        /// 允许的大小
        /// </summary>
        public int AllowSize { get; set; }

        /// <summary>
        /// 允许的数量
        /// </summary>
        public int AllowCount { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
    
    /// <summary>
    /// 图片
    /// </summary>
    public class Photo : Annex
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 缩略图路径
        /// </summary>
        public string TbUrl { get; set; }
    }
}
