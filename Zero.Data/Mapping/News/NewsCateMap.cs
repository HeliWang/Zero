using System;
using Zero.Domain.News;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.News
{
    /// <summary>
    /// Rolu http://www.cnblogs.com/libingql/archive/2012/03/28/2421084.html
    /// http://msdn.microsoft.com/zh-cn/data/jj591617
    /// </summary>
    public class NewsCateMap : EntityTypeConfiguration<NewsCate>
    {
        public NewsCateMap()
        {
            // Primary Key
            this.HasKey(c => c.CateId);

            // Table & Column Mappings
            this.ToTable("NewsCate");
            this.Property(t => t.CateName).HasColumnName("CateName");

            // Properties
            this.Property(t => t.CateName).IsRequired().HasMaxLength(200);

            //Ignore
            this.Ignore(t => t.ChildCount);
            this.Ignore(t => t.Intro);
            this.Ignore(t => t.children);

            // Relationships  1:1
            //this.HasRequired(t => t.Cate)
            //     .WithMany(t => t.Products)
            //     .HasForeignKey(t => t.CategoryID)
            //     .WillCascadeOnDelete(false);

            // Relationships N:N
            //this.HasMany(t => t.Roles)
            //     .WithMany(t => t.Users)
            //     .Map(t => t.MapLeftKey("RoleID").MapRightKey("UserID"));


            //this.MapToStoredProcedures(s =>
            //        s.Insert(i => i.HasName("SB_CategoryInsert")
            //            .Parameter(c => c.CateName, ""))
            //    );
        }
    }
}
