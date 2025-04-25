
using PetsApp.CORE.Models;
using PetsApp.REPO.UnitOfWorks;
using PetsApp.SERVICE.Contracts;
using PetsApp.SERVICE.Exceptions;

namespace PetsApp.SERVICE.Concretes
{
    public class PetService : IPetService
    {
        private readonly IManagerRepo _repo;
        public PetService(IManagerRepo repo)
        {
            _repo = repo;
        }
        public void Add(string name, string breed, string type, DateTime birthDate)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(breed) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(birthDate.ToString()))
                throw new ValidationException("Name - Breed - Type - BirthDate", "Name Breed or Type areas passed empty.");

            _repo.Pets.Create(new Pet(name, breed, type, birthDate));

            if (!_repo.Save())
                throw new Exception("Pet not registered!");
        }

        public void Delete(int id)
        {
            var pet = _repo.Pets.GetById(id);
            if (pet is null)
                throw new NotFoundException("pet", id);

            _repo.Pets.Delete(pet, false);

            if (!_repo.Save())
                throw new Exception("Pet not registered!");
        }

        public Pet Get(int id)
        {
            var pet = _repo.Pets.GetById(id);
            if (pet is null)
                throw new NotFoundException("pet", id);

            return pet;
        }

        public IEnumerable<Pet> GetAllNoTrack()
        {
            return _repo.Pets.GetAll(false);
        }

        public IEnumerable<Pet> GetAllTrack()
        {
            return _repo.Pets.GetAll();
        }

        public IEnumerable<Pet> GetByName(string name)
        {
            return _repo.Pets.GetByCondition(x => x.Name.Contains(name)).ToList();
        }

        public void SoftDelete(int id)
        {
            var pet = _repo.Pets.GetById(id);
            if (pet is null)
                throw new NotFoundException("pet", id);

            _repo.Pets.Delete(pet);

            if (!_repo.Save())
                throw new Exception("Pet not registered!");
        }

        public void Update(int id, string name, string breed, string type, DateTime birthDate)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(breed) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(birthDate.ToString()))
                throw new ValidationException("Name - Breed - Type - BirthDate", "Name Breed or Type areas passed empty.");

            var pet = _repo.Pets.GetById(id);

            pet.Name = name;
            pet.Breed = breed;
            pet.Type = type;

            _repo.Pets.Update(pet);

            if (!_repo.Save())
                throw new Exception("Pet failed to update!");
        }
    }
}
