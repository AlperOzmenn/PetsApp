using Microsoft.Extensions.Logging;
using PetsApp.CORE.Models;

namespace PetsApp.REPO.Contracts
{
    public interface IVetAppointmentRepo : IBaseRepo<VetAppointment>
    {
        IQueryable<VetAppointment> GetUpComingAppointment();
        IQueryable<VetAppointment> GetAppointmentsByPetOwnerId(int petOwnerId);
    }
}
