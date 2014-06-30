using System;
using Zero.Domain.News;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.News
{
    public class NewsDetailMap : EntityTypeConfiguration<NewsDetail>
    {
        public NewsDetailMap()
        {
            this.ToTable("NewsDetail");
            this.HasKey(nc => nc.DetailId);

            //Ignore
            //this.Ignore(s => s.id);
        }
    }
}
