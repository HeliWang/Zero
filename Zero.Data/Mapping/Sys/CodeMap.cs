using System;
using Zero.Domain.Sys;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Sys
{
    public class CodeMap : EntityTypeConfiguration<Code>
    {
        public CodeMap()
        {
            this.ToTable("Code");
            this.HasKey(d => d.CodeId);

            //Ignore
            //this.Ignore(s => s.id);
        }
    }
}
