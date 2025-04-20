using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsApp.CORE.Models;

namespace PetsApp.REPO.Contracts
{
    public interface IPetRepo : IBaseRepo<Pet>
    {
    }
}
