using PetsApp.CORE.Models;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.Concretes
{
    public class TrackerDeviceRepo : BaseRepo<TrackerDevice>, ITrackerDeviceRepo
    {
        public TrackerDeviceRepo(PetsAppDbContext context) : base(context)
        {
        }
    }
}
