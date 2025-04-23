using PetsApp.CORE.Enums;
using PetsApp.CORE.Models;

namespace PetsApp.SERVICE.Contracts
{
    public interface ITrackerDeviceService
    {
        void Add(int petId, GpsLocation gpsLocation);
        void Update(int id, int petId, GpsLocation gpsLocation);
        void Delete(int id);
        void SoftDelete(int id);
        TrackerDevice Get(int id);
        IEnumerable<TrackerDevice> GetAllTrack();
        IEnumerable<TrackerDevice> GetAllNoTrack();
    }

}
