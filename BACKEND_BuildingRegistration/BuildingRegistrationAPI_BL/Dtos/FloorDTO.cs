using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Dtos
{
    public class FloorDTO
    {
        public string FloorName { get; set; }

        public ICollection<DepartmentDTO> DepartmentsDtos { get; set; } = new List<DepartmentDTO>();
    }
}
