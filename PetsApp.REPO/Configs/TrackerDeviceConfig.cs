using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetsApp.CORE.Enums;
using PetsApp.CORE.Models;

namespace PetsApp.REPO.Configs
{
    public class TrackerDeviceConfig : IEntityTypeConfiguration<TrackerDevice>
    {
        public void Configure(EntityTypeBuilder<TrackerDevice> builder)
        {
            builder.ToTable("TrackerDevices");
            builder.HasKey(p => p.Id);
            builder.HasQueryFilter(x => x.Status != Status.Deleted);

            //1-n Activity Log
            builder.HasMany(p => p.ActivityLogs)
                .WithOne(pd => pd.TrackerDevice)
                .HasForeignKey(x => x.TrackerDeviceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
