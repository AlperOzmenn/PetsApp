using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsApp.CORE.Models;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.Concretes
{
    public class PetRepo : BaseRepo<Pet>, IPetRepo
    {
        public PetRepo(PetsAppDbContext context) : base(context)
        {
        }
    }
}
