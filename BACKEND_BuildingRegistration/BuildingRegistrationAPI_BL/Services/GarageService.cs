using BuildingRegistrationAPI_BL.Dtos;
using BuildingRegistrationAPI_DL.Data;
using BuildingRegistrationAPI_DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Services
{
    public class GarageService : IGarageService
    {
        private readonly BuildingRegistrationContext _context;

        public GarageService(BuildingRegistrationContext context)
        {
            _context = context;
        }



        public ICollection<GarageSectionOccupiedDTO> GetAllOccupiedGarageSectionsFromBuilding(string buildingName, string buildingAddress, string garageLevel)
        {
            var query = _context.Buildings.
                Join(_context.Garages,
                building => building.BuildingId,
                garage => garage.Building.BuildingId,
                (building, garage) => new { building, garage }).
                Where(buildingGarage =>
                    (buildingGarage.building.BuildingName.ToLower() == buildingName.ToLower() && (buildingGarage.building.BuildingAddress.ToLower() == buildingAddress.ToLower()))
                    && (buildingGarage.garage.GarageLevel.ToLower() == garageLevel.ToLower())).
                        Join(_context.GaragesSections,
                        buildingGarage => buildingGarage.garage.GarageId,
                        garageSection => garageSection.Garage.GarageId,
                        (buildingGarage, garageSection) => new { buildingGarage, garageSection }).
                        Where(buildingGarageSection => buildingGarageSection.garageSection.Occupants.Count > 0).
                        Select(buildingGarageSection => new {
                            buildingGarageSection.buildingGarage.building.BuildingName,
                            buildingGarageSection.buildingGarage.building.BuildingAddress,
                            buildingGarageSection.buildingGarage.garage.GarageLevel,
                            buildingGarageSection.garageSection.GarageSectionName
                        });

            List<GarageSectionOccupiedDTO> garageSections = new List<GarageSectionOccupiedDTO>();

            foreach(var section in query)
            {
                garageSections.Add(new GarageSectionOccupiedDTO 
                { 
                    BuildingName = section.BuildingName,
                    BuildingAddress = section.BuildingAddress,
                    GarageLevel = section.GarageLevel,
                    GarageSectionName = section.GarageSectionName
                });
            }

            return garageSections;
        }

        public ICollection<GarageSectionOccupantsDTO> GetGarageSectionsWithOccupants()
        {
            List<GarageSectionOccupantsDTO> gso = new List<GarageSectionOccupantsDTO>();
            
            List<GarageSection> gs = _context.GaragesSections.Include(gs => gs.Occupants).ToList();
            foreach (var section in gs)
            {
                gso.Add(new GarageSectionOccupantsDTO()
                {
                    GarageSectionId = section.GarageSectionId,
                    GarageSectionName = section.GarageSectionName,
                    OccupantsName = section.Occupants.Select(o => o.OccupantName).ToList()
                });
            }

            return gso;
        }
    }
}
