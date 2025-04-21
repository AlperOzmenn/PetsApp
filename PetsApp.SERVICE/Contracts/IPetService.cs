using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsApp.CORE.Models;

namespace PetsApp.SERVICE.Contracts
{
    public interface IPetService
    {
        void Add(string name, string breed, string type, DateTime birthDate);
        void Update(int id, string name, string breed, string type, DateTime birthDate);
        void Delete(int id);
        void SoftDelete(int id);
        Pet Get(int id);
        IEnumerable<Pet> GetAllTrack();
        IEnumerable<Pet> GetAllNoTrack();
        IEnumerable<Pet> GetByName(string name);
    }
}
