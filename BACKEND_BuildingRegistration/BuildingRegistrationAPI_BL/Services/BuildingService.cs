using BuildingRegistrationAPI_BL.Dtos;
using BuildingRegistrationAPI_DL.Data;
using BuildingRegistrationAPI_DL.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly BuildingRegistrationContext _context;
        private const string _DEFAULT_DEPARTMENT = "COMPLETE";

        public BuildingService(BuildingRegistrationContext context)
        {
            _context = context;
        }



        public string AddBuilding(BuildingDTO buildingDto)
        {
            Building building = _context.Buildings.FirstOrDefault(building =>
                (building.BuildingName.ToLower() == buildingDto.BuildingName.ToLower()) ||
                (building.BuildingAddress.ToLower() == buildingDto.BuildingAddress));

            if (building != null) return $"Building -{building.BuildingName}- already exist!";


            building = CreateBuilding(buildingDto);
            _context.Buildings.Add(building);

            var floors = CreateFloors(buildingDto.floorDtos.ToList(), building);
            _context.Floors.AddRange(floors);

            List<Department> departments = CreateDepartments(floors, buildingDto.floorDtos.ToList());
            _context.Departments.AddRange(departments);

            List<Garage>garages = CreateGarages(buildingDto.garageDtos.ToList(), building);
            _context.Garages.AddRange(garages);

            List<GarageSection> garageSections = CreateGarageSections(garages, buildingDto.garageDtos.ToList());
            _context.GaragesSections.AddRange(garageSections);

            _context.SaveChanges();
            _context.Dispose();

            return "Building and all sections saved";
        }

        

        public ICollection<BuildingDTO> GetBuildings()
        {
            List<BuildingDTO> buildingList = new List<BuildingDTO>();
            List<FloorDTO> floorList = new List<FloorDTO>();
            List<GarageDTO> garageList = new List<GarageDTO>();

            foreach (var building in _context.Buildings.ToList())
            {

                foreach(var floor in _context.Floors.Where(floor => floor.Building.BuildingId == building.BuildingId))
                {
                    floorList.Add(new FloorDTO() 
                        { 
                            FloorName = floor.FloorName, 
                            DepartmentsDtos = GetDepartmentsDtosFromFloor(floor) 
                        });
                }

                foreach(var garage in _context.Garages.Where(garage => garage.Building.BuildingId == building.BuildingId))
                {
                    garageList.Add(new GarageDTO()
                    {
                        GarageLevel = garage.GarageLevel,
                        GarageSectionsDtos = GetGarageSectionsDtosFromGarage(garage)

                    });
                }


                buildingList.Add(new BuildingDTO()
                {
                    BuildingName = building.BuildingName,
                    BuildingAddress = building.BuildingAddress,
                    BuildingHasGuard = building.BuildingHasGuard,
                    BuildingHasCleaningService = building.BuildingHasCleaningService,
                    BuildingAllowPet = building.BuildingAllowPet,
                    BuildingHasJanitor = building.BuildingHasJanitor,
                    BuildingHasWifi = building.BuildingHasWifi,
                    BuildingElevatorQty = building.BuildingElevatorQty,
                    BuildingNote = building.BuildingNote,

                    floorDtos = floorList.ToList(),
                    garageDtos = garageList.ToList(),
                });

                floorList.Clear();
                garageList.Clear();
            }

            return buildingList;
        }





        //----------PRIVATE FUNCTIONS-------------------------------
        
        private int CountOccupantsAtDepartent(int departmentId)
        {
            var query = _context.Departments.Join(_context.Occupants,
                department => department.DepartmentId,
                occupant => occupant.Department.DepartmentId,
                (department, occupant) => new { department, occupant }).
                Where(departmentOccupant => departmentOccupant.department.DepartmentId == departmentId).
                Select(occupants => occupants.occupant).
                Count();

            return query;
        }

        private List<DepartmentDTO> GetDepartmentsDtosFromFloor(Floor floor)
        {
            List<DepartmentDTO> departmentsDtos = new List<DepartmentDTO>();
            foreach(var department in _context.Departments.Where(dep => dep.Floor.FloorId == floor.FloorId))
            {
                departmentsDtos.Add(new DepartmentDTO()
                {
                    DepartmentId = department.DepartmentId,
                    DepartmentName = department.DepartmentName,
                    OccupantsQty = CountOccupantsAtDepartent(department.DepartmentId)
                });
            }

            return departmentsDtos;
        }


        private int CountOccupantsAtGarageSection(int garageSectionId)
        {
            List<Occupant> occupants = _context.Occupants.Include(o => o.GarageSections).ToList();
            List<GarageSection> gs = new List<GarageSection>();
            foreach (var occupant in occupants)
            {
                foreach (var section in occupant.GarageSections)
                {
                    if (section.GarageSectionId == garageSectionId)
                        gs.Add(section);
                }
            }

            return gs.Count;
        }

        private List<GarageSectionDTO> GetGarageSectionsDtosFromGarage(Garage garage)
        {
            List<GarageSectionDTO> garageSectionDtos = new List<GarageSectionDTO>();
            foreach (var garageSection in _context.GaragesSections.Where(gs => gs.Garage.GarageId == garage.GarageId))
            {
                garageSectionDtos.Add(new GarageSectionDTO()
                {
                    GarageSectionId = garageSection.GarageSectionId,
                    GarageSectionName = garageSection.GarageSectionName,
                    OccupantsQty = CountOccupantsAtGarageSection(garageSection.GarageSectionId)
                });
            }
            return garageSectionDtos;
        }



        private Building CreateBuilding(BuildingDTO buildingDto)
        {
            Building building = new Building()
            {
                BuildingName = buildingDto.BuildingName,
                BuildingAddress = buildingDto.BuildingAddress,
                BuildingHasGuard = buildingDto.BuildingHasGuard,
                BuildingHasCleaningService = buildingDto.BuildingHasCleaningService,
                BuildingAllowPet = buildingDto.BuildingAllowPet,
                BuildingHasJanitor = buildingDto.BuildingHasJanitor,
                BuildingHasWifi = buildingDto.BuildingHasWifi,
                BuildingElevatorQty = buildingDto.BuildingElevatorQty,
                BuildingNote = buildingDto.BuildingNote,
            };
            return building;
        }

        private List<Floor> CreateFloors(List<FloorDTO> floors, Building building)
        {
            List<Floor> newFloors = new List<Floor>();
            foreach (FloorDTO floorDto in floors)
            {
                newFloors.Add(new Floor()
                {
                    FloorName = floorDto.FloorName,
                    Building = building
                });
            }
            return newFloors;
        }

        private List<Department> CreateDepartments(List<Floor> floors, List<FloorDTO> floorDtos)
        {
            List<Department> departments = new List<Department>();
            

            for (int i = 0; i < floors.Count; i++)
            {
                //If the current floor doesen't have any department, create a default one
                if (floorDtos[i].DepartmentsDtos.Count == 0)
                {
                    departments.Add(new Department() 
                    { 
                        DepartmentName = _DEFAULT_DEPARTMENT, Floor = floors[i] 
                    });
                    continue;
                }

                foreach (var department in floorDtos[i].DepartmentsDtos)
                    departments.Add(new Department()
                    {
                        DepartmentName = department.DepartmentName,
                        Floor = floors[i]
                    });
            }

            return departments;
        }

        private List<Garage> CreateGarages(List<GarageDTO> garagesDtos, Building building)
        {
            List<Garage> garages = new List<Garage>();
            foreach (var garage in garagesDtos)
            {
                garages.Add(new Garage()
                {
                    GarageLevel = garage.GarageLevel,
                    Building = building
                });
            }

            return garages;
        }

        private List<GarageSection> CreateGarageSections(List<Garage> garages, List<GarageDTO> garagesDtos)
        {
            List<GarageSection> garageSections = new List<GarageSection>();
            for (int i = 0; i < garagesDtos.Count; i++)
            {
                foreach (var garageSection in garagesDtos[i].GarageSectionsDtos)
                {
                    garageSections.Add(new GarageSection()
                    {
                        GarageSectionName = garageSection.GarageSectionName,
                        Garage = garages[i]
                    });
                }
            }

            return garageSections;
        }
    }
}
