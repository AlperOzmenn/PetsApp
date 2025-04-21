using PetsApp.CORE.Enums;
using PetsApp.CORE.Models;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.Concretes
{
    public class TrackerDeviceRepo : BaseRepo<TrackerDevice>, ITrackerDeviceRepo
    {
        private readonly PetsAppDbContext _context;
        public TrackerDeviceRepo(PetsAppDbContext context) : base(context)
        {
            _context = context;
        }

        public GpsLocation GetLocation(int petId)
        {
            return _context.TrackerDevices
                .Where(e => e.PetId == petId)
                .Select(e => e.GpsLocation)
                .FirstOrDefault();
        }
    }
}
