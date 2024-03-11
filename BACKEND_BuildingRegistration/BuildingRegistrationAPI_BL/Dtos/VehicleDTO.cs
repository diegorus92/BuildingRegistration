using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Dtos
{
    public class VehicleDTO
    {
        public long? VehicleID { get; set; } 
        public string VehicleBrand { get; set; }
        public string? VehicleModel { get; set; }
        public string? VehicleColor { get; set; }
        public string? VehicleLicensePlate { get; set; }
    }
}
