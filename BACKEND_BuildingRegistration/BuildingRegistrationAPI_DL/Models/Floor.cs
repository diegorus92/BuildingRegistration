using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_DL.Models
{
    public class Floor
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; }


        public Building Building { get; set; }
    }
}
