using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetsApp.CORE.Models;
using PetsApp.CORE.Enums;

namespace PetsApp.REPO.Configs
{
    public class HealthRecordConfig : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            builder.ToTable("HealthRecords");
            builder.HasKey(p => p.Id);
            builder.HasQueryFilter(x => x.Status != Status.Deleted);
            builder.Property(p => p.Weight).IsRequired().HasPrecision(5, 2);
            builder.Ignore(x => x.Allergies);

            //builder.HasOne(p => p.Pet).WithOne(pd => pd.HealthRecord).HasForeignKey<Pet>(x => x.Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
   
}
