using System;
using Zero.Domain.News;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.News
{
    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            this.ToTable("NewsTag");
            this.HasKey(d => d.TagId);

            //Ignore
            //this.Ignore(s => s.id);
        }
    }
}
