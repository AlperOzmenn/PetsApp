using PetsApp.CORE.Models;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.Concretes
{
    public class VetAppointmentRepo : BaseRepo<VetAppointment>, IVetAppointmentRepo
    {
        public VetAppointmentRepo(PetsAppDbContext context) : base(context)
        {
        }
    }
}
