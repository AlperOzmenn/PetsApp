using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using PetsApp.CORE.Abstracts;

namespace PetsApp.CORE.Models
{
    public class ActivityLog : BaseEntity
    {
        public ActivityLog() { }

        public ActivityLog(int trackerDeviceId, int distanceTraveledInMeters, int minutesOfWalking,int minutesOfSleeping )
        {
            TrackerDeviceId = trackerDeviceId;
            DistanceTraveledInMeters = distanceTraveledInMeters;
            MinutesOfWalking = minutesOfWalking;
            MinutesOfSleeping = minutesOfSleeping;
        }

        public int DistanceTraveledInMeters { get; set; } = 0;
        public int MinutesOfWalking { get; set; } = 0;
        public int MinutesOfSleeping { get; set; } = 0;

        //Navigation Props
        public int TrackerDeviceId { get; set; }
        public virtual TrackerDevice TrackerDevice { get; set; }

        public override string ToString()
        {
            return $"Günlük Veriler:\nKat Edilen Mesafe: {DistanceTraveledInMeters} Metre - Yürüyüş Süresi: {MinutesOfWalking} DK - Uyku Süresi: {MinutesOfSleeping} DK";
        }

    }
}
