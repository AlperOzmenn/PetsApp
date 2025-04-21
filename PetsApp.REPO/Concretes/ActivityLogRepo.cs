using Microsoft.EntityFrameworkCore;
using PetsApp.CORE.Models;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.Concretes
{
    public class ActivityLogRepo : BaseRepo<ActivityLog>, IActivityLogRepo
    {
        private readonly PetsAppDbContext _context;
        public ActivityLogRepo(PetsAppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Pet> GetTheMostWalkers() //En çok yürüyen hayvanların IQueryable'ını döndürür.
        {
            int mostWalking = _context.ActivityLogs.Max(e => e.DistanceTraveledInMeters);
            return _context.ActivityLogs.Include(e => e.TrackerDevice) //Eagle Loading
                .ThenInclude(e => e.Pet)
                .Where(e => e.DistanceTraveledInMeters == mostWalking)
                .Select(e => e.TrackerDevice.Pet);
        }
    }
}
