using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_DL.Models
{
    public class Vehicle
    {
        public long VehicleId { get; set; }
        public string VehicleBrand { get; set; }
        public string? VehicleModel { get; set; }
        public string? VehicleColor { get; set; }
        public string? VehicleLicensePlate { get; set; }

        public ICollection<Occupant> Occupants { get; set;} = new List<Occupant>();
    }
}
