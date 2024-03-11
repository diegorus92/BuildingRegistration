using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Dtos
{
    public class GarageSectionOccupantsDTO
    {
        public int GarageSectionId { get; set; }
        public string GarageSectionName { get; set; }

        public ICollection<string> OccupantsName { get; set; } = new List<string>();
    }
}
