using System;
using Zero.Domain.Cates;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Cates
{
    public class AttrMap : EntityTypeConfiguration<Attr>
    {
        public AttrMap()
        {
            // Primary Key
            this.HasKey(m => m.AttrId);

            // Table & Column Mappings
            this.ToTable("Attr");

            //Ignore
            this.Ignore(m => m.id);
        }
    }
}
