using PetsApp.CORE.Models;

namespace PetsApp.REPO.Contracts
{
    public interface IActivityLogRepo : IBaseRepo<ActivityLog>
    {
        IQueryable<Pet> GetTheMostWalkers();
    }
}
