using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsApp.CORE.Abstracts;
using PetsApp.CORE.Enums;
using PetsApp.CORE.Helpers;

namespace PetsApp.CORE.Models
{
    public class HealthRecord : BaseEntity
    {
        private double _weight;

        public HealthRecord()
        {
            VaccinationInfo = VaccinationInfo.Unknown;
            Allergies.Add(Allergie.Unknown); // Default UNKNOWN eğer alerji eklenirse unknown silinicek.

        }
        public HealthRecord(double weight, Gender gender, VaccinationInfo vaccinationInfo)
        {
            VaccinationInfo = vaccinationInfo;
            Allergies.Add(Allergie.Unknown); // Default UNKNOWN eğer alerji eklenirse unknown silinicek.
            Weight = weight;
            Gender = gender;
        }
        public HealthRecord(double weight, Gender gender, VaccinationInfo vaccinationInfo, List<Allergie> allergies)
        {
            VaccinationInfo = vaccinationInfo;
            Allergies = allergies;
            Weight = weight;
            Gender = gender;
        }

        //Kilo
        public double Weight
        {
            get { return _weight; }
            set { _weight = ValidationHelper.SetWeight(value); }
        }

        //Cinsiyet
        public Gender Gender { get; set; }

        //Aşı Bilgileri
        public VaccinationInfo VaccinationInfo { get; set; }

        //Alerjiler
        public List<Allergie>? Allergies { get; set; } = new List<Allergie>();

        //Navigation Props
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }

        public override string ToString()
        {
            return $"Aşı Bilgileri: {VaccinationInfo} - Alerjiler: {Allergies?.ToString()}";//alerjiler gelicek mi bilmiyorum :D
        }
    }
}
