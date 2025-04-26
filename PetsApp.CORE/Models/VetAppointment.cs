using PetsApp.CORE.Abstracts;
using PetsApp.CORE.Helpers;

namespace PetsApp.CORE.Models
{
    public class VetAppointment : BaseEntity
    {
        private DateTime _appointmentDate;
        private string _vetName;
        private string _description;

        public VetAppointment(){ }
        public VetAppointment(int petOwnerId, string vetName, string description, DateTime appointmentDate)
        {
            PetOwnerId = petOwnerId;
            AppointmentDate = appointmentDate;
            VetName = vetName;
            Description = description;
        }

        //Randevu tarihi
        public DateTime AppointmentDate
        {
            get { return _appointmentDate; }
            set { _appointmentDate = ValidationHelper.AppointmentCheck(value); }
        }

        //Veteriner adı
        public string VetName
        {
            get { return _vetName; }
            set { _vetName = ValidationHelper.SetData(value); }
        }

        //Açıklama
        public string Description
        {
            get { return _description; }
            set { _description = ValidationHelper.SetData(value); }
        }

        //Navigation Props
        public int PetOwnerId { get; set; }
        public virtual PetOwner PetOwner { get; set; }

        public override string ToString()
        {
            return $"Appointment Date: {AppointmentDate} - Veterinarian Name: {VetName} - Description: {Description}";
        }
    }
}
