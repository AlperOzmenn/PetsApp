﻿using PetsApp.CORE.Abstracts;
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
        }
        public Pet(int petOwnerId, string name, string breed, string type, DateTime birthDate)
        {
            PetOwnerId = petOwnerId;
            Name = name;
            Breed = breed;
			Type = type;
			BirthDate = birthDate;
		}

        //Chip No
		public Guid ChipNo { get; } = Guid.NewGuid();

        //İsim
        public string Name
		{
			get { return _name; }
			set { _name = ValidationHelper.SetData(value); }
		}

        //Tür
        public string Type
        {
            get { return _type; }
            set { _type = ValidationHelper.SetData(value); }
        }

        //Cins
        public string Breed
		{
			get { return _breed; }
			set { _breed = ValidationHelper.SetData(value); }
		}

        //Doğum Tarihi
        public DateTime BirthDate
		{
			get { return _birthDate; }
			set { _birthDate = ValidationHelper.BirthDateCheck(value); }
		}

        //Yaş
        public int Age => DateTime.Now.Year - BirthDate.Year;

        //Navigation Props
        public int PetOwnerId { get; set; }
        public virtual PetOwner PetOwner { get; set; }

        public virtual HealthRecord HealthRecord { get; set; }

        public virtual TrackerDevice TrackerDevice { get; set; }

        public override string ToString()
        {
			return $"Chip Number: {ChipNo} - Animal Name: {Name} - Type: {Type} - Breed: {Breed} - Birth Date: {BirthDate} - Age: {Age}";
        }

    }
}
