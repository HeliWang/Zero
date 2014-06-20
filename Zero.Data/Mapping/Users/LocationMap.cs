using System;
using Zero.Domain.Users;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Users
{
    public class LocationMap : EntityTypeConfiguration<Location>
    {
        public LocationMap()
        {
            // Primary Key
            this.HasKey(l => l.LocationId);

            // Table & Column Mappings
            this.ToTable("User_Location");

            //Ignore
            //this.Ignore(m => m.id);
        }
    }
}
