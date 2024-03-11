using BuildingRegistrationAPI_BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Services
{
    public interface IDepartmentService
    {
        public ICollection<OccupantDTO> GetOccupantsOfDepartment(int departmentId);
    }
}
