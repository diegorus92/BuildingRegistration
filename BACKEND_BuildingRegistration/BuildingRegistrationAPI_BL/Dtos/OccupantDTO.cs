using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Dtos
{
    public class OccupantDTO
    {
        public long? OccupantId { get; set; }    
        public string OccupantName { get; set; }
        public string OccupantSurname { get; set; }
        public string? OccupantCellPhone { get; set; }
        public string? OccupantEmail { get; set; }

        public BuildingMinimalInfoDTO Building {  get; set; } //Info about Building, Floor and Garage
        public ICollection<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
        public ICollection<VehicleDTO> Vehicles { get; set; } = new List<VehicleDTO>();
    }
}
