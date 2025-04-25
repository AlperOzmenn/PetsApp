using PetsApp.CORE.Models;
using PetsApp.REPO.UnitOfWorks;
using PetsApp.SERVICE.Contracts;
using PetsApp.SERVICE.Exceptions;

namespace PetsApp.SERVICE.Concretes
{
    public class VetAppointmentService : IVetAppointmentService
    {
        private readonly IManagerRepo _repo;
        public VetAppointmentService(IManagerRepo repo)
        {
            _repo = repo;
        }

        public void Add(string vetName, string description, DateTime appointmentDate)
        {

            if (string.IsNullOrEmpty(vetName) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(appointmentDate.ToString()))
                throw new ValidationException("VetName - Description - AppointmentDate", "VetName, Description or AppointmentDate areas passed empty.");
            _repo.VetAppointments.Create(new VetAppointment(vetName, description, appointmentDate));
            if (!_repo.Save())
                throw new Exception("VetAppointment not registered!");
        }

        public void Delete(int id)
        {
            var vetAppointment = _repo.VetAppointments.GetById(id);
            if (vetAppointment is null)
                throw new NotFoundException("vetAppointment", id);
            _repo.VetAppointments.Delete(vetAppointment, false);
            if (!_repo.Save())
                throw new Exception("VetAppointment not registered!");
        }

        public VetAppointment Get(int id)
        {
            var vetAppointment = _repo.VetAppointments.GetById(id);
            if (vetAppointment is null)
                throw new NotFoundException("vetAppointment", id);
            return vetAppointment;
        }

        public IEnumerable<VetAppointment> GetAllNoTrack()
        {
            return _repo.VetAppointments.GetAll(false);
        }

        public IEnumerable<VetAppointment> GetAllTrack()
        {
            return _repo.VetAppointments.GetAll();
        }

        public void SoftDelete(int id)
        {
            var vetAppointment = _repo.VetAppointments.GetById(id);
            if (vetAppointment is null)
                throw new NotFoundException("vetAppointment", id);
            _repo.VetAppointments.Delete(vetAppointment);
            if (!_repo.Save())
                throw new Exception("VetAppointment not registered!");
        }

        public void Update(int id, string vetName, string description, DateTime appointmentDate)
        {
            if (string.IsNullOrEmpty(vetName) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(appointmentDate.ToString()))
                throw new ValidationException("VetName - Description - AppointmentDate", "VetName, Description or AppointmentDate areas passed empty.");

            var vetAppointment = _repo.VetAppointments.GetById(id);
            vetAppointment.VetName = vetName;
            vetAppointment.Description = description;
            vetAppointment.AppointmentDate = appointmentDate;
            _repo.VetAppointments.Update(vetAppointment);
            if (!_repo.Save())
                throw new Exception("VetAppointment failed to update!");
        }
    }


}
