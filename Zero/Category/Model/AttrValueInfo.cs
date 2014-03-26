using PetaPoco;

namespace Zero.Category.Model
{
    [TableName("Attr_Value")]
    [PrimaryKey("ValueId")]
    public partial class AttrValueInfo
    {
        /// <summary>
        /// 属性值编号
        /// </summary>
        public int ValueId { get; set; }

        /// <summary>
        /// 属性编号
        /// </summary>
        public int AttrId { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 排列序号
        /// </summary>
        public int Oid { get; set; }
    }

    [TableName("Attr_View_Value")]
    [PrimaryKey("ValueId")]
    public partial class AttrValueExpandInfo : AttrValueInfo
    {
        public string Attr { get; set; }
    }
}
