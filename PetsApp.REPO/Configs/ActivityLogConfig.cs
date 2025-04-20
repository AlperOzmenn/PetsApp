using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetsApp.CORE.Models;
using PetsApp.CORE.Enums;

namespace PetsApp.REPO.Configs
{
    public class ActivityLogConfig : IEntityTypeConfiguration<ActivityLog>
    {
        public void Configure(EntityTypeBuilder<ActivityLog> builder)
        {
            builder.ToTable("ActivityLogs");
            builder.HasKey(p => p.Id);
            builder.HasQueryFilter(x => x.Status != Status.Deleted);
            builder.Property(p => p.Temperature).IsRequired().HasPrecision(5,2);
            builder.Property(p => p.DistanceTraveledInMeters).IsRequired();
            builder.Property(p => p.MinutesOfSleeping).IsRequired();
            builder.Property(p => p.MinutesOfWalking).IsRequired();
        }
    }
}
