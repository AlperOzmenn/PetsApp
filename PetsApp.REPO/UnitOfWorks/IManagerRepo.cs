using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
