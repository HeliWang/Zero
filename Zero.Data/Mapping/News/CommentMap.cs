using System;
using Zero.Domain.News;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.News
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            this.ToTable("NewsComment");
            this.HasKey(c => c.CommentId);

            //Ignore
            //this.Ignore(s => s.id);
        }
    }
}
