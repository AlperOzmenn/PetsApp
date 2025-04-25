using PetsApp.CORE.Models;

namespace PetsApp.SERVICE.Contracts
{
    public interface IPetService
    {
        void Add(int petOwnerId,string name, string breed, string type, DateTime birthDate);
        void Update(int id, string name, string breed, string type, DateTime birthDate);
        void Delete(int id);
        void SoftDelete(int id);
        Pet Get(int id);
        IEnumerable<Pet> GetAllTrack();
        IEnumerable<Pet> GetAllNoTrack();
        IEnumerable<Pet> GetByName(string name);
    }

}
