using System;
using Zero.Domain.Users;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Users
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(u => u.UserId);

            // Table & Column Mappings
            this.ToTable("User");

            //Ignore
            this.Ignore(u => u.id);
        }
    }
}
