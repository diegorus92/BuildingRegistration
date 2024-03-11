using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_DL.Models
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string? BuildingName { get; set; }
        public string BuildingAddress { get; set; }
        public bool? BuildingHasGuard { get; set; }
        public bool? BuildingHasCleaningService { get; set; }
        public bool? BuildingHasJanitor { get; set; }
        public bool? BuildingHasWifi { get; set; }
        public bool? BuildingAllowPet { get; set; }
        public short BuildingElevatorQty { get; set; } 
        public string? BuildingNote { get; set; }
    }
}
