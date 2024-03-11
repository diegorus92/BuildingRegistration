using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Dtos
{
    public class GarageSectionOccupiedDTO
    {
        public string BuildingName { get; set; }
        public string BuildingAddress { get; set; }
        public string GarageLevel { get; set; }
        public string GarageSectionName { get; set; }
    }
}
