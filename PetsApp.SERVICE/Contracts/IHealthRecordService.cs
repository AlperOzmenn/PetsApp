using PetsApp.CORE.Enums;
using PetsApp.CORE.Models;

namespace PetsApp.SERVICE.Contracts
{
    public interface IHealthRecordService
    {
        void Add(double weight, Gender gender, VaccinationInfo vaccinationInfo, List<Allergie> allergies);
        void Update(int id, double weight, Gender gender, VaccinationInfo vaccinationInfo, List<Allergie> allergies);
        void Delete(int id);
        void SoftDelete(int id);
        HealthRecord Get(int id);
        IEnumerable<HealthRecord> GetAllTrack();
        IEnumerable<HealthRecord> GetAllNoTrack();
    }

}
