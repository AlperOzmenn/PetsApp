using PetsApp.CORE.Models;

namespace PetsApp.SERVICE.Contracts
{
    public interface IPetOwnerService
    {
        void Add(string firstName, string lastName);
        void Update(int id, string firstName, string lastName);
        void Delete(int id);
        void SoftDelete(int id);
        PetOwner Get(int id);
        IEnumerable<PetOwner> GetAllTrack();
        IEnumerable<PetOwner> GetAllNoTrack();
        IEnumerable<PetOwner> GetByName(string fullName);
    }

}
