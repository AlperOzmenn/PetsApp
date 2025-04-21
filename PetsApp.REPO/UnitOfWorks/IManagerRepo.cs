using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.UnitOfWorks
{
    internal interface IManagerRepo
    {
        
        IPetRepo Pets { get; }
        IPetOwnerRepo PetOwners { get; }
        IHealthRecordRepo HealthRecords { get; }
        ITrackerDeviceRepo TrackerDevices { get; }
        IActivityLogRepo ActivityLogs { get; }
        IVetAppointmentRepo VetAppointments { get; }
        bool Save();
    }
    
}
