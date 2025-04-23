using PetsApp.CORE.Models;
using PetsApp.REPO.UnitOfWorks;
using PetsApp.SERVICE.Contracts;
using PetsApp.SERVICE.Exceptions;

namespace PetsApp.SERVICE.Concretes
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IManagerRepo _repo;
        public ActivityLogService(IManagerRepo repo)
        {
            _repo = repo;
        }

        public void Add(double tempature, int trackerDeviceId, int distanceTraveledInMeters, int minutesOfWalking, int minutesOfSleeping)
        {
            if (string.IsNullOrEmpty(tempature.ToString())|| string.IsNullOrEmpty(trackerDeviceId.ToString())||string.IsNullOrEmpty(distanceTraveledInMeters.ToString()) || string.IsNullOrEmpty(minutesOfWalking.ToString()) || string.IsNullOrEmpty(minutesOfSleeping.ToString()))
            {
                throw new ValidationException("Tempature - TrackerDeviceId - DistanceTraveledInMeters - MinutesOfWalking - minutesOfSleeping", "Sıcaklık - Cihaz Id - Mesafe - Yürüyüş Süresi - Uyuma Süresi alanları boş geçildi");
            }
            
            _repo.ActivityLogs.Create(new ActivityLog(tempature, trackerDeviceId, distanceTraveledInMeters, minutesOfWalking, minutesOfSleeping));

            if (!_repo.Save())
                throw new Exception("Activity kayıt edilmedi!");

        }

        public void Delete(int id)
        {
            var activityLog = _repo.ActivityLogs.GetById(id);
            if (activityLog is null)
                throw new NotFoundException("aktivite", id);

            _repo.ActivityLogs.Delete(activityLog, false);

            if (!_repo.Save())
                throw new Exception("Aktivite kayıt edilemedi!");
        }

        public ActivityLog Get(int id)
        {
            var activityLog = _repo.ActivityLogs.GetById(id);
            if (activityLog is null)
                throw new NotFoundException("aktivite", id);

            return activityLog;
        }

        public IEnumerable<ActivityLog> GetAllNoTrack()
        {
            return _repo.ActivityLogs.GetAll(false);
        }

        public IEnumerable<ActivityLog> GetAllTrack()
        {
            return _repo.ActivityLogs.GetAll();
        }

        public void SoftDelete(int id)
        {
            var activityLog = _repo.ActivityLogs.GetById(id);
            if (activityLog is null)
                throw new NotFoundException("aktivite", id);

            _repo.ActivityLogs.Delete(activityLog);

            if (!_repo.Save())
                throw new Exception("Aktivite kayıt edilemedi!");
        }

        public void Update(int id, double tempature, int trackerDeviceId, int distanceTraveledInMeters, int minutesOfWalking, int minutesOfSleeping)
        {
            var activityLog = _repo.ActivityLogs.GetById(id);

            activityLog.Temperature = tempature;
            activityLog.TrackerDeviceId = trackerDeviceId;
            activityLog.DistanceTraveledInMeters = distanceTraveledInMeters;
            activityLog.MinutesOfWalking = minutesOfWalking;
            activityLog.MinutesOfSleeping = minutesOfSleeping;

            _repo.ActivityLogs.Update(activityLog);

            if (!_repo.Save())
                throw new Exception("Aktivite güncellenemedi!");
        }
    }
}
