using PetsApp.CORE.Models;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.Concretes
{
    public class HealthRecordRepo : BaseRepo<HealthRecord>, IHealthRecordRepo
    {
        public HealthRecordRepo(PetsAppDbContext context) : base(context)
        {
        }
    }
}
