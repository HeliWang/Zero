using System;
using Zero.Domain.News;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.News
{
    public class NewsItemMap : EntityTypeConfiguration<NewsItem>
    {
        public NewsItemMap()
        {
            this.ToTable("NewsItem");
            this.HasKey(n => n.NewsId);

            this.HasRequired(n => n.Detail)
                .WithMany()
                .HasForeignKey(n => n.DetailId);

            //Ignore
            this.Ignore(s => s.id);
            this.Ignore(s => s.DetailUrl);
        }
    }
}
