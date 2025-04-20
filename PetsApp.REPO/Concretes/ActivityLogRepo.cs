using PetsApp.CORE.Models;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.Concretes
{
    public class ActivityLogRepo : BaseRepo<ActivityLog>, IActivityLogRepo
    {
        public ActivityLogRepo(PetsAppDbContext context) : base(context)
        {
        }
    }
}
