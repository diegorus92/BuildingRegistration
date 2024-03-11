using BuildingRegistrationAPI_BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Services
{
    public interface IBuildingService
    {
        public string AddBuilding(BuildingDTO buildingDto);
        public ICollection<BuildingDTO> GetBuildings();
    }
}
