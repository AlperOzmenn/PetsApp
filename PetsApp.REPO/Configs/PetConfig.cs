﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsApp.CORE.Enums;
using PetsApp.CORE.Models;

namespace PetsApp.REPO.Configs
{
    public class PetConfig : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pets");
            builder.HasKey(p => p.Id);
            builder.HasQueryFilter(x => x.Status != Status.Deleted);
            builder.Property(p => p.Type).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.Breed).IsRequired().HasColumnType("nvarchar(50)");
            builder.Ignore(x => x.Age);

            //Relations
            //1-1 HealtRecord
            

            //1-1 TrackerDevice
            

            //1-n PetOwner
            //builder.HasOne(p => p.PetOwner).WithMany(pd => pd.Pets).HasForeignKey(x => x.PetOwnerId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
