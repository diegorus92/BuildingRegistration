using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Dtos
{
    public class GarageDTO
    {
        public string GarageLevel { get; set; }

        public ICollection<GarageSectionDTO> GarageSectionsDtos { get; set; } = new List<GarageSectionDTO>();
    }
}
