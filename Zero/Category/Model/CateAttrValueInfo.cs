using PetaPoco;

namespace Zero.Category.Model
{
    [TableName("Cate_AttrValue")]
    [PrimaryKey("CPVID")]
    public class CateAttrValueInfo
    {
        /// <summary>
        /// 类别属性值编号
        /// </summary>
        public int CPVID { get; set; }

        /// <summary>
        /// 类别编号
        /// </summary>
        public int CateId { get; set; }

        /// <summary>
        /// 属性编号
        /// </summary>
        public int AttrId { get; set; }

        /// <summary>
        /// 属性值编号
        /// </summary>
        public int ValueId { get; set; }
    }

    /// <summary>
    /// 类别属性值扩展编号
    /// </summary>
    public class CateAttrValueExpandInfo : CateAttrValueInfo
    {

    }
}
