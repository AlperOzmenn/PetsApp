using Microsoft.EntityFrameworkCore;
using PetsApp.CORE.Enums;
using PetsApp.CORE.Models;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.Concretes
{
    public class HealthRecordRepo : BaseRepo<HealthRecord>, IHealthRecordRepo
    {
        private readonly PetsAppDbContext _context;
        public HealthRecordRepo(PetsAppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Pet> GetMissingOrNoneVaccines()
        {
            return _context.HealthRecords.Include(e => e.Pet) //Eagle Loading
                .ThenInclude(e => e.HealthRecord)
                .Where(e => e.VaccinationInfo == VaccinationInfo.None && e.VaccinationInfo == VaccinationInfo.Missing)
                .Select(e => e.Pet);
        }
    }
}
