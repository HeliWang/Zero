using PetaPoco;

namespace Zero.Category.Model
{
    [TableName("Attr")]
    [PrimaryKey("AttrId")]
    public partial class AttrInfo
    {
        /// <summary>
        /// 属性编号
        /// </summary>
        public int AttrId { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string Attr { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}
