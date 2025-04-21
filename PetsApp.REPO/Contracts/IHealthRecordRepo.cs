using PetsApp.CORE.Models;

namespace PetsApp.REPO.Contracts
{
    public interface IHealthRecordRepo : IBaseRepo<HealthRecord>
    {
        IQueryable<Pet> GetMissingOrNoneVaccines();

    }
}
