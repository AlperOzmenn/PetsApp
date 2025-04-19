using PetsApp.CORE.Abstracts;
using PetsApp.CORE.Enums;
using PetsApp.CORE.Helpers;

namespace PetsApp.CORE.Models
{
    public class Pet : BaseEntity
    {
        private DateTime _birthDate;
        private string _type;
		private string _breed;
        private string _name;

        public Pet()
        {
            BirthDate = DateTime.Now;
			VaccinationInfo = VaccinationInfo.None;
        }
        public Pet(string breed, string type, DateTime birthDate, VaccinationInfo vaccinationInfo)
        {
            Breed = breed;
			Type = type;
			BirthDate = birthDate;
			VaccinationInfo = vaccinationInfo;
		}

		public Guid ChipNo { get; } = Guid.NewGuid();

        public string Name
		{
			get { return _name; }
			set { _name = ValidationHelper.SetData(value); }
		}

		public VaccinationInfo VaccinationInfo { get; set; }

        public string Type
        {
            get { return _type; }
            set { _type = ValidationHelper.SetData(value); }
        }

        public string Breed
		{
			get { return _breed; }
			set { _breed = ValidationHelper.SetData(value); }
		}

		public DateTime BirthDate
		{
			get { return _birthDate; }
			set { _birthDate = ValidationHelper.BirthDateCheck(value); }
		}

		public int Age => DateTime.Now.Year - BirthDate.Year;

        //Navigation Props
        public int PetOwnerId { get; set; }
        public virtual PetOwner PetOwner { get; set; }

        public int HealthRecordId { get; set; }
        public virtual HealthRecord HealthRecord { get; set; }

        public int TrackerDeviceId { get; set; }
        public virtual TrackerDevice TrackerDevice { get; set; }

        public override string ToString()
        {
			return $"Çip Numarası : {ChipNo} - Hayvan İsmi: {Name} - Tür: {Type} - Cins: {Breed} - Doğum Tarihi: {BirthDate} - Yaş: {Age}";
        }

    }
}
