using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_DL.Models
{
    public class Occupant
    {
        public long OccupantId { get; set; }   
        public string OccupantName { get; set; }
        public string OccupantSurname { get; set; }
        public string? OccupantCellPhone { get; set; }
        public string? OccupantEmail { get; set; }
        
        public Department Department { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public ICollection<GarageSection> GarageSections { get; set; } = new List<GarageSection>();
    }
}
