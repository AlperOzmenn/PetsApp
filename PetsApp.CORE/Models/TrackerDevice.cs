using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsApp.CORE.Abstracts;
using PetsApp.CORE.Enums;

namespace PetsApp.CORE.Models
{
    public class TrackerDevice : BaseEntity
    {
        public TrackerDevice() { }
        public TrackerDevice(int petId, GpsLocation gpsLocation)
        {
            GpsLocation = gpsLocation;
            PetId = petId;
        }

        //Gps konumu
        public GpsLocation GpsLocation { get; set; } = 0;

        //Navigation Props
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

        public override string ToString()
        {
            return $"Takip Cihazı Id: {Id} - Gps Konum: {GpsLocation}";
        }
    }
}
