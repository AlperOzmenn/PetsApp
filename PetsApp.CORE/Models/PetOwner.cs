using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsApp.CORE.Abstracts;
using PetsApp.CORE.Helpers;

namespace PetsApp.CORE.Models
{
    public class PetOwner : BaseEntity
    {
		private string _firstName;
		private string _lastName;
        
		public PetOwner() { }

        public PetOwner(string firstName, string lastName)
        {
            FirstName = firstName;
			LastName = lastName;
        }

        //İsim
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = ValidationHelper.SetData(value); }
        }

        //Soyisim
        public string LastName
		{
			get { return _lastName; }
			set { _lastName = ValidationHelper.SetData(value); }
		}

        //Tamad
		public string FullName => _firstName + " " + _lastName;

		//Navigation Props
		public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
		
		public virtual ICollection<VetAppointment> VetAppointments { get; set; } = new List<VetAppointment>();

        public override string ToString()
        {
			return $"Hayvan Sahibi Id: {Id} - Hayvan Sahibi İsmi: {FullName}";
        }

    }
}
