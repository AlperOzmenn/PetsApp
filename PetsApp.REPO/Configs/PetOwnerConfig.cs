using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetsApp.CORE.Models;
using PetsApp.CORE.Enums;

namespace PetsApp.REPO.Configs
{
    public class PetOwnerConfig : IEntityTypeConfiguration<PetOwner>
    {
        public void Configure(EntityTypeBuilder<PetOwner> builder)
        {
            builder.ToTable("PetOwners");
            builder.HasKey(p => p.Id);
            builder.HasQueryFilter(x => x.Status != Status.Deleted);
            builder.Property(p => p.FirstName).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.LastName).IsRequired().HasColumnType("nvarchar(50)");
            builder.Ignore(x => x.FullName);

            //1-n VetAppointment
            builder.HasMany(p => p.VetAppointments).WithOne(pd => pd.PetOwner).HasForeignKey(x => x.PetOwnerId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
