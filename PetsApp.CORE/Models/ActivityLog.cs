using PetsApp.CORE.Abstracts;
using PetsApp.CORE.Helpers;

namespace PetsApp.CORE.Models
{
    public class ActivityLog : BaseEntity
    {
        private double _temperature;
        private int _distanceTraveledInMeters;
        private int _minutesOfWalking;
        private int _minutesOfSleeping;

        public ActivityLog() { }

        public ActivityLog(double tempature, int trackerDeviceId, int distanceTraveledInMeters, int minutesOfWalking,int minutesOfSleeping )
        {
            Temperature = tempature;
            TrackerDeviceId = trackerDeviceId;
            DistanceTraveledInMeters = distanceTraveledInMeters;
            MinutesOfWalking = minutesOfWalking;
            MinutesOfSleeping = minutesOfSleeping;
        }

        //Ateşi kaç
        public double Temperature
        {
            get { return _temperature; }
            set { _temperature = ValidationHelper.TemperatureCheck(value); }
        }


        //Günlük kat edilen mesafe (metre)
        public int DistanceTraveledInMeters
        {
            get { return _distanceTraveledInMeters; }
            set { _distanceTraveledInMeters = ValidationHelper.DistanceOrTimeCheck(value); }
        }


        //Yürüme süresi (dk)
        public int MinutesOfWalking
        {
            get { return _minutesOfWalking; }
            set { _minutesOfWalking = ValidationHelper.DistanceOrTimeCheck(value); }
        }

        //Uyku süresi (dk)
        public int MinutesOfSleeping
        {
            get { return _minutesOfSleeping; }
            set { _minutesOfSleeping = ValidationHelper.DistanceOrTimeCheck(value); }
        }

        //Navigation Props
        public int TrackerDeviceId { get; set; }
        public virtual TrackerDevice TrackerDevice { get; set; }

        public override string ToString()
        {
            return $"Günlük Veriler:\nKat Edilen Mesafe: {DistanceTraveledInMeters} Metre - Yürüyüş Süresi: {MinutesOfWalking} DK - Uyku Süresi: {MinutesOfSleeping} DK";
        }

    }
}
