using BuildingRegistrationAPI_BL.Dtos;
using BuildingRegistrationAPI_DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Services
{
    public interface IGarageService
    {
        public ICollection<GarageSectionOccupiedDTO> GetAllOccupiedGarageSectionsFromBuilding(string buildingName, string buildingAddress, string garageLevel);
        public ICollection<GarageSectionOccupantsDTO> GetGarageSectionsWithOccupants();
    }
}
