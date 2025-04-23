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
        public void Add(double weight, Gender gender, VaccinationInfo vaccinationInfo, List<Allergie> allergies)
        {
            if (string.IsNullOrEmpty(weight.ToString()) || string.IsNullOrEmpty(gender.ToString()) || string.IsNullOrEmpty(vaccinationInfo.ToString()))
            {
                throw new ValidationException("Weight - Gender - VaccinationInfo", "Kilo, cins veya aşı bilgileri alanı boş geçildi.");


                _repo.HealthRecords.Create(new HealthRecord(weight, gender, vaccinationInfo, allergies));

                if (!_repo.Save())
                    throw new Exception("Sağlık Kaydı kayıt edilmedi!");
            }
        }

        public void Delete(int id)
        {
            var healthRecord = _repo.HealthRecords.GetById(id);
            if (healthRecord is null)
                throw new NotFoundException("sağlık kaydı", id);

            _repo.HealthRecords.Delete(healthRecord, false);

            if (!_repo.Save())
                throw new Exception("Sağlık Kaydı, kayıt edilemedi!");
        }

        public HealthRecord Get(int id)
        {
            var healthRecord = _repo.HealthRecords.GetById(id);
            if (healthRecord is null)
                throw new NotFoundException("sağlık kaydı", id);

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
                throw new NotFoundException("sağlık kaydı", id);

            _repo.HealthRecords.Delete(healthRecord);

            if (!_repo.Save())
                throw new Exception("Sağlık Kaydı, kayıt edilemedi!");
        }

        public void Update(int id, double weight, Gender gender, VaccinationInfo vaccinationInfo, List<Allergie> allergies)
        {
            var healthRecord = _repo.HealthRecords.GetById(id);

            healthRecord.Weight = weight;
            healthRecord.Gender = gender;
            healthRecord.VaccinationInfo = vaccinationInfo;
            healthRecord.Allergies = allergies;

            _repo.HealthRecords.Update(healthRecord);

            if (!_repo.Save())
                throw new Exception("Sağlık Kaydı güncellenemedi!");
        }
    }
}
