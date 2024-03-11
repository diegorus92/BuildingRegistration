using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Dtos
{
    public class BuildingMinimalInfoDTO
    {
        public string BuildingName { get; set; }
        public string BuildingAddress { get; set; }
        public string FloorName {  get; set; }
        public string? DepartmentName { get; set; } //Maybe the Floor doesen't have a Department
        public string? GarageLevel { get; set; }
        public ICollection<GarageSectionDTO> GarageSections { get; set; } = new List<GarageSectionDTO>();
    }
}
