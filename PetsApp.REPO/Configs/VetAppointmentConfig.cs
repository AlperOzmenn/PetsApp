using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetsApp.CORE.Models;
using PetsApp.CORE.Enums;

namespace PetsApp.REPO.Configs
{
    public class VetAppointmentConfig : IEntityTypeConfiguration<VetAppointment>
    {
        public void Configure(EntityTypeBuilder<VetAppointment> builder)
        {
            builder.ToTable("VetAppointments");
            builder.HasKey(p => p.Id);
            builder.HasQueryFilter(x => x.Status != Status.Deleted);
            builder.Property(p => p.VetName).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.Description).IsRequired().HasColumnType("nvarchar(250)");

        }
    }
}
