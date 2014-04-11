using System;
using Zero.Domain.Cates;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Cates
{
    public class CateAttrMap : EntityTypeConfiguration<CateAttr>
    {
        public CateAttrMap()
        {
            // Primary Key
            this.HasKey(m => m.CAID);

            // Table & Column Mappings
            this.ToTable("CateAttr");

            //Ignore
            this.Ignore(m => m.id);
        }
    }
}
