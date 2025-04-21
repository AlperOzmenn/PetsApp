using System;
using Microsoft.EntityFrameworkCore;
using PetsApp.CORE.Models;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.Concretes
{
    public class VetAppointmentRepo : BaseRepo<VetAppointment>, IVetAppointmentRepo
    {
        private readonly PetsAppDbContext _context;
        public VetAppointmentRepo(PetsAppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<VetAppointment> GetAppointmentsByPetOwnerId(int petOwnerId)
        {
            return _context.VetAppointments.Where(va => va.PetOwnerId == petOwnerId).OrderByDescending(va => va.AppointmentDate);
        }

        public IQueryable<VetAppointment> GetUpComingAppointment()
        {
            return _context.VetAppointments.Where(e => e.AppointmentDate > DateTime.Now).OrderBy(e => e.AppointmentDate);
        }
    }
}
