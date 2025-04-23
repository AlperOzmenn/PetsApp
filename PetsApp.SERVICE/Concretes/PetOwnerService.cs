using PetsApp.CORE.Models;
using PetsApp.REPO.UnitOfWorks;
using PetsApp.SERVICE.Contracts;
using PetsApp.SERVICE.Exceptions;

namespace PetsApp.SERVICE.Concretes
{
    public class PetOwnerService : IPetOwnerService
    {
        private readonly IManagerRepo _repo;
        public PetOwnerService(IManagerRepo repo)
        {
            _repo = repo;
        }

        public void Add(string firstName, string lastName)
        {

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                throw new ValidationException("FirstName - LastName ", "Ad  veya Soyad alanı boş geçildi");

            _repo.PetOwners.Create(new PetOwner(firstName, lastName));

            if (!_repo.Save())
                throw new Exception("PetOwner kayıt edilmedi!");
        }

        public void Delete(int id)
        {
            var petOwner = _repo.PetOwners.GetById(id);
            if (petOwner is null)
                throw new NotFoundException("pet", id);

            _repo.PetOwners.Delete(petOwner, false);

            if (!_repo.Save())
                throw new Exception("PetOwner silinemedi!");
        }

        public PetOwner Get(int id)
        {
            var petOwner = _repo.PetOwners.GetById(id);
            if (petOwner is null)
                throw new NotFoundException("petOwner", id);

            return petOwner;
        }

        public IEnumerable<PetOwner> GetAllNoTrack()
        {
            return _repo.PetOwners.GetAll(false);
        }

        public IEnumerable<PetOwner> GetAllTrack()
        {
            return _repo.PetOwners.GetAll();
        }

        public IEnumerable<PetOwner> GetByName(string fullName)
        {
            return _repo.PetOwners.GetByCondition(x => x.FullName.Contains(fullName)).ToList();
        }

        public void SoftDelete(int id)
        {
            var petOwner = _repo.PetOwners.GetById(id);
            if (petOwner is null)
                throw new NotFoundException("petOwner", id);

            _repo.PetOwners.Delete(petOwner);

            if (!_repo.Save())
                throw new Exception("PetOwner kayıt edilemedi!");
        }

        public void Update(int id, string firstName, string lastName)
        {
            var petOwner = _repo.PetOwners.GetById(id);

            petOwner.FirstName = firstName;
            petOwner.LastName = lastName;

            _repo.PetOwners.Update(petOwner);

            if (!_repo.Save())
                throw new Exception("PetOwner güncellenemedi!");
        }
    }
}
