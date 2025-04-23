using PetsApp.CORE.Models;

namespace PetsApp.SERVICE.Contracts
{
    public interface IActivityLogService
    {
        void Add(double tempature, int trackerDeviceId, int distanceTraveledInMeters, int minutesOfWalking, int minutesOfSleeping);
        void Update(int id, double tempature, int trackerDeviceId, int distanceTraveledInMeters, int minutesOfWalking, int minutesOfSleeping);
        void Delete(int id);
        void SoftDelete(int id);
        ActivityLog Get(int id);
        IEnumerable<ActivityLog> GetAllTrack();
        IEnumerable<ActivityLog> GetAllNoTrack();
    }

}
