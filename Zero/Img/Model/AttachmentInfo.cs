using PetaPoco;
using System;

namespace Zero.Img.Model
{
    [TableName("Attachment")]
    [PrimaryKey("FileId")]
    public class AttachmentInfo
    {
        /// <summary>
        /// 图片ID
        /// </summary>
        public int FileId { get; set; }

        /// <summary>
        /// 类别编号
        /// </summary>
        public int CateId { get; set; }

        /// <summary>
        /// 管理员
        /// </summary>
        public string Uploader { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 图片路径
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
        /// 宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }

    public class AttachmentExpandInfo : AttachmentInfo
    {
        public string CateName { get; set; }

        
    }
}
