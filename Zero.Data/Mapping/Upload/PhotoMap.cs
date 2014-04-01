using System;
using Zero.Domain.Upload;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Upload
{
    public class PhotoMap : EntityTypeConfiguration<Photo>
    {
        public PhotoMap()
        {
            this.ToTable("Photo");
            this.HasKey(p => p.FileId);

            //Ignore
            this.Ignore(p=>p.Id);
        }
    }
}
