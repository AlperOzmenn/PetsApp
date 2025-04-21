using PetsApp.CORE.Models;

namespace PetsApp.REPO.Contracts
{
    public interface IPetRepo : IBaseRepo<Pet>
    {
        string GetChipNo(int petId);
    }
}
