using PetsApp.CORE.Models;

namespace PetsApp.SERVICE.Contracts
{
    public interface IVetAppointmentService
    {
        void Add(string vetName, string description, DateTime appointmentDate);
        void Update(int id, string vetName, string description, DateTime appointmentDate);
        void Delete(int id);
        void SoftDelete(int id);
        VetAppointment Get(int id);
        IEnumerable<VetAppointment> GetAllTrack();
        IEnumerable<VetAppointment> GetAllNoTrack();
    }

}
