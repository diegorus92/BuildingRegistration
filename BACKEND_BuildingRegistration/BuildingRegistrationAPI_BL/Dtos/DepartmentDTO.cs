using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Dtos
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int OccupantsQty { get; set; } = 0;

    }
}
