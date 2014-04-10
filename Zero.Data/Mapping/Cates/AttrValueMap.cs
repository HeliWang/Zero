using System;
using Zero.Domain.Cates;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Cates
{
    public class AttrValueMap : EntityTypeConfiguration<AttrValue>
    {
        public AttrValueMap()
        {
            // Primary Key
            this.HasKey(m => m.ValueId);

            // Table & Column Mappings
            this.ToTable("AttrValue");

            //Ignore
            this.Ignore(m => m.id);
        }
    }
}
