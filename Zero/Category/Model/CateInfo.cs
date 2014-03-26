using System.Collections.Generic;
using PetaPoco;

namespace Zero.Category.Model
{
    [TableName("Cate")]
    [PrimaryKey("CateId")]
    public class CateInfo : CateBaseInfo
    {
        [Ignore]
        public string Intro { get; set; }

        [Ignore]
        public List<CateInfo> children { get; set; }
    }
}
