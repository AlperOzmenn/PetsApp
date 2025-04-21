using PetsApp.CORE.Models;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.Concretes
{
    public class PetRepo : BaseRepo<Pet>, IPetRepo
    {
        private readonly PetsAppDbContext _context;
        public PetRepo(PetsAppDbContext context) : base(context)
        {
            _context = context;
        }

        public string GetChipNo(int petId)
        {
            return _context.Pets
                .Where(e => e.Id == petId)
                .Select(e => e.ChipNo)
                .FirstOrDefault().ToString();
        }
    }
}
