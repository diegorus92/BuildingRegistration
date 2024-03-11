using BuildingRegistrationAPI_DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Dtos
{
    public class EmployeeDTO
    {
        public long? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string? EmployeeCheckIn { get; set; }
        public string? EmployeeCheckOut { get; set; }


    }
}
