using System;
using Zero.Domain.Customs;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Customs
{
    public class CustomMap : EntityTypeConfiguration<Custom>
    {
        public CustomMap()
        {
            this.ToTable("Custom");
            this.HasKey(c => c.CustomId);

            //Ignore
            this.Ignore(c => c.id);
        }
    }
}
