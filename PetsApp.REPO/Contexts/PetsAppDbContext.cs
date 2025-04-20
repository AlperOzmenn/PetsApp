using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PetsApp.CORE.Models;

namespace PetsApp.REPO.Contexts
{
    public class PetsAppDbContext : DbContext
    {

        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<TrackerDevice> TrackerDevices { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<VetAppointment> VetAppointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-P5IQJOK\\SQLEXPRESS;Initial Catalog=PetsApp;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Bütün Configsleri ekler.
        }

    }
}
