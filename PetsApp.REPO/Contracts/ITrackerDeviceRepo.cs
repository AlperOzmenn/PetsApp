using PetsApp.CORE.Enums;
using PetsApp.CORE.Models;

namespace PetsApp.REPO.Contracts
{
    public interface ITrackerDeviceRepo : IBaseRepo<TrackerDevice>
    {
        GpsLocation GetLocation(int petId);
    }
}
