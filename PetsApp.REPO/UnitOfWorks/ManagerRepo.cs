using PetsApp.REPO.Concretes;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.UnitOfWorks
{
    public class ManagerRepo : IManagerRepo
    {
        private readonly PetsAppDbContext _context;
        private readonly Lazy<IPetRepo> _petRepo;
        private readonly Lazy<IPetOwnerRepo> _petOwnerRepo;
        private readonly Lazy<IHealthRecordRepo> _healthRecordRepo;
        private readonly Lazy<ITrackerDeviceRepo> _trackerDeviceRepo;
        private readonly Lazy<IActivityLogRepo> _activityLogRepo;
        private readonly Lazy<IVetAppointmentRepo> _vetAppointmentRepo;

        public ManagerRepo(PetsAppDbContext context)
        {
            _context = context;
            _petRepo = new Lazy<IPetRepo>(() => new PetRepo(_context));
            _petOwnerRepo = new Lazy<IPetOwnerRepo>(() => new PetOwnerRepo(_context));
            _healthRecordRepo = new Lazy<IHealthRecordRepo>(() => new HealthRecordRepo(_context));
            _trackerDeviceRepo = new Lazy<ITrackerDeviceRepo>(() => new TrackerDeviceRepo(_context));
            _activityLogRepo = new Lazy<IActivityLogRepo>(() => new ActivityLogRepo(_context));
            _vetAppointmentRepo = new Lazy<IVetAppointmentRepo>(() => new VetAppointmentRepo(_context));
        }
        public IPetRepo Pets => _petRepo.Value;

        public IPetOwnerRepo PetOwners => _petOwnerRepo.Value;

        public IHealthRecordRepo HealthRecords => _healthRecordRepo.Value;

        public ITrackerDeviceRepo TrackerDevices => _trackerDeviceRepo.Value;

        public IActivityLogRepo ActivityLogs => _activityLogRepo.Value;

        public IVetAppointmentRepo VetAppointments => _vetAppointmentRepo.Value;

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
