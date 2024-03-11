using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_DL.Models
{
    public class Garage
    {
        public int GarageId { get; set; }
        public string GarageLevel { get; set; }

        public Building Building { get; set; }
    }
}
