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
            this.HasKey(ca => ca.CAID);

            // Table & Column Mappings
            this.ToTable("CateAttr");

            //Ignore
            this.Ignore(ca => ca.id);

            //
            this.HasRequired(ca => ca.Cate)
                .WithMany()
                .HasForeignKey(ca=>ca.CateId);

            this.HasRequired(ca => ca.Attr)
                .WithMany()
                .HasForeignKey(ca => ca.AttrId);
        }
    }
}
