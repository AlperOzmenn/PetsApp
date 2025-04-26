using PetsApp.CORE.Models;
using PetsApp.REPO.UnitOfWorks;
using PetsApp.SERVICE.Contracts;
using PetsApp.SERVICE.Exceptions;
using PetsApp.CORE.Enums;

namespace PetsApp.SERVICE.Concretes
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly IManagerRepo _repo;
        public HealthRecordService(IManagerRepo repo)
        {
            _repo = repo;
        }
        public void Add(int petId, double weight, Gender gender, VaccinationInfo vaccinationInfo, List<Allergie> allergies)
        {
            if (string.IsNullOrEmpty(petId.ToString()) || string.IsNullOrEmpty(weight.ToString()) || string.IsNullOrEmpty(gender.ToString()) || string.IsNullOrEmpty(vaccinationInfo.ToString()))
            
                throw new ValidationException("PetId - Weight - Gender - VaccinationInfo", "PetId, Weight, Gender or Vaccination Info areas passed empty.");


                _repo.HealthRecords.Create(new HealthRecord(petId, weight, gender, vaccinationInfo, allergies));

                if (!_repo.Save())
                    throw new Exception("Health Record not registered!");
            
        }

        public void Delete(int id)
        {
            var healthRecord = _repo.HealthRecords.GetById(id);
            if (healthRecord is null)
                throw new NotFoundException("health record", id);

            _repo.HealthRecords.Delete(healthRecord, false);

            if (!_repo.Save())
                throw new Exception("Health Record not registered!");
        }

        public HealthRecord Get(int id)
        {
            var healthRecord = _repo.HealthRecords.GetById(id);
            if (healthRecord is null)
                throw new NotFoundException("health record", id);

            return healthRecord;
        }

        public IEnumerable<HealthRecord> GetAllNoTrack()
        {
            return _repo.HealthRecords.GetAll(false);
        }

        public IEnumerable<HealthRecord> GetAllTrack()
        {
            return _repo.HealthRecords.GetAll();
        }

        public void SoftDelete(int id)
        {
            var healthRecord = _repo.HealthRecords.GetById(id);
            if (healthRecord is null)
                throw new NotFoundException("health record", id);

            _repo.HealthRecords.Delete(healthRecord);

            if (!_repo.Save())
                throw new Exception("Health Record not registered!");
        }

        public void Update(int id, int petId, double weight, Gender gender, VaccinationInfo vaccinationInfo, List<Allergie> allergies)
        {
            if (string.IsNullOrEmpty(petId.ToString()) || string.IsNullOrEmpty(weight.ToString()) || string.IsNullOrEmpty(gender.ToString()) || string.IsNullOrEmpty(vaccinationInfo.ToString()))
            
                throw new ValidationException("PetID - Weight - Gender - VaccinationInfo", "PetID, Weight, Gender or Vaccination Info areas passed empty.");

                var healthRecord = _repo.HealthRecords.GetById(id);

                healthRecord.PetId = petId;
                healthRecord.Weight = weight;
                healthRecord.Gender = gender;
                healthRecord.VaccinationInfo = vaccinationInfo;
                healthRecord.Allergies = allergies;

                _repo.HealthRecords.Update(healthRecord);

                if (!_repo.Save())
                    throw new Exception("Failed to update the Health Record.!");
            
        }
    }
}
