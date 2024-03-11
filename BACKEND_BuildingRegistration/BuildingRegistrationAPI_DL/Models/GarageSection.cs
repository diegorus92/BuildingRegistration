using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_DL.Models
{
    public class GarageSection
    {
        public int GarageSectionId { get; set; }
        public string GarageSectionName { get; set; }
        
        
        public Garage Garage { get; set; }
        public ICollection<Occupant> Occupants { get; set; } = new List<Occupant>();
    }
}
