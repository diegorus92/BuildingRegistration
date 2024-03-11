using BuildingRegistrationAPI_BL.Dtos;
using BuildingRegistrationAPI_DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Services
{
    public interface IOccupantService
    {
        public string AddOccupant(OccupantDTO occupantDto);
    }
}
