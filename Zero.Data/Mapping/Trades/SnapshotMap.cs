using System;
using Zero.Domain.Trades;
using Zero.Domain.Products;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Trades
{
    public class SnapshotMap : EntityTypeConfiguration<Snapshot>
    {
        public SnapshotMap()
        {
            // Primary Key
            this.HasKey(s=>s.SnapshotId);

            // Table & Column Mappings
            this.ToTable("Trade_Snapshot");

            ////TPC
            //this.Map(m =>
            //{
            //    m.MapInheritedProperties();
            //});

            //Ignore
            //this.Ignore(s => s.id);
        }
    }
}
