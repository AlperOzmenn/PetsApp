using PetsApp.CORE.Enums;
using PetsApp.CORE.Models;
using PetsApp.REPO.UnitOfWorks;
using PetsApp.SERVICE.Contracts;
using PetsApp.SERVICE.Exceptions;

namespace PetsApp.SERVICE.Concretes
{
    public class TrackerDeviceService : ITrackerDeviceService
    {
        private readonly IManagerRepo _repo;
        public TrackerDeviceService(IManagerRepo repo)
        {
            _repo = repo;
        }
        public void Add(int petId, GpsLocation gpsLocation)
        {
            if (string.IsNullOrEmpty(petId.ToString()) || string.IsNullOrEmpty(gpsLocation.ToString()))
                throw new ValidationException("PetId - GpsLocation", "PetId veya GpsLocation alanı boş geçildi");
            _repo.TrackerDevices.Create(new TrackerDevice(petId, gpsLocation));
            if (!_repo.Save())
                throw new Exception("TrackerDevice kayıt edilmedi!");
        }

        public void Delete(int id)
        {
            var trackerDevice = _repo.TrackerDevices.GetById(id);
            if (trackerDevice is null)
                throw new NotFoundException("trackerDevice", id);
            _repo.TrackerDevices.Delete(trackerDevice, false);
            if (!_repo.Save())
                throw new Exception("TrackerDevice kayıt edilmedi!!");
        }

        public TrackerDevice Get(int id)
        {
            var trackerDevice = _repo.TrackerDevices.GetById(id);
            if (trackerDevice is null)
                throw new NotFoundException("trackerDevice", id);
            return trackerDevice;
        }

        public IEnumerable<TrackerDevice> GetAllNoTrack()
        {
            return _repo.TrackerDevices.GetAll(false);
        }

        public IEnumerable<TrackerDevice> GetAllTrack()
        {
            return _repo.TrackerDevices.GetAll();
        }

        public void SoftDelete(int id)
        {
            var trackerDevice = _repo.TrackerDevices.GetById(id);
            if (trackerDevice is null)
                throw new NotFoundException("trackerDevice", id);
            _repo.TrackerDevices.Delete(trackerDevice);
            if (!_repo.Save())
                throw new Exception("TrackerDevice kayıt edilemedi!");
        }

        public void Update(int id, int petId, GpsLocation gpsLocation)
        {
            var trackerDevice = _repo.TrackerDevices.GetById(id);
            trackerDevice.PetId = petId;
            trackerDevice.GpsLocation = gpsLocation;
            _repo.TrackerDevices.Update(trackerDevice);
            if (!_repo.Save())
                throw new Exception("TrackerDevice güncellenemedi!");
        }
    }
}
