using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_DL.Models
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string? EmployeeCheckIn { get; set; }
        public string? EmployeeCheckOut { get; set; }


        public ICollection<Occupant> Occupants { get; set; } = new List<Occupant>();
    }
}
