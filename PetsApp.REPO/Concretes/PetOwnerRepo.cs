using PetsApp.CORE.Models;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.Concretes
{
    public class PetOwnerRepo : BaseRepo<PetOwner>, IPetOwnerRepo
    {
        public PetOwnerRepo(PetsAppDbContext context) : base(context)
        {
        }
    }
}
