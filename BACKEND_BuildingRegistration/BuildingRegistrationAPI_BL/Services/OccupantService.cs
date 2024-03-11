using Azure;
using BuildingRegistrationAPI_BL.Dtos;
using BuildingRegistrationAPI_DL.Data;
using BuildingRegistrationAPI_DL.Models;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Services
{
    public class OccupantService : IOccupantService
    {

        private readonly BuildingRegistrationContext _context;

        public OccupantService(BuildingRegistrationContext context)
        {
            _context = context;
        }



        public string AddOccupant(OccupantDTO occupantDto)
        {
            string response = "";
            Occupant occupant = _context.Occupants.
                FirstOrDefault(occupant => occupant.OccupantName.ToLower() == occupantDto.OccupantName.ToLower() &&
                occupant.OccupantSurname.ToLower() == occupantDto.OccupantSurname.ToLower());

            if(occupant != null)
            {
                response += $"Occupant -{occupant.OccupantSurname} {occupant.OccupantName}- already exist";
                return response;
            }

            Occupant newOccupant = new Occupant()
            {
                OccupantName = occupantDto.OccupantName,
                OccupantSurname = occupantDto.OccupantSurname,
                OccupantCellPhone = occupantDto.OccupantCellPhone,
                OccupantEmail = occupantDto.OccupantEmail
            };

            //Assigning Department to Occupant
            response += AssignDepartmentToOccupant(occupantDto, newOccupant) + "\n";

            //Assigning Garage to Occupant (or not)
            response += AssignGarageSectionToOccupant(occupantDto, newOccupant) + "\n";

            //Asigning Vehicles (or not)
            response += AssignVehiclesToOccupant(occupantDto, newOccupant) + "\n";

            //Asigning Employee/s (or not)
            response += AssignEmployeesToOccupant(occupantDto, newOccupant) + "\n";

            _context.Occupants.Add(newOccupant);
            response += $"New occupant added: {newOccupant.OccupantSurname} {newOccupant.OccupantName}" +
                $" at {newOccupant.Department.Floor.FloorName} '{newOccupant.Department.DepartmentName}'";

            _context.SaveChanges();
            _context.Dispose();

            return response.ToString();
        }




        private string AssignDepartmentToOccupant(OccupantDTO occupantDto,Occupant occupant)
        {
            string response = "";


            //If floor have departments
            if (occupantDto.Building.DepartmentName != null && occupantDto.Building.DepartmentName != "")
            {
                //Get departments related to a floor of a building
                var queryWithDepartment = _context.Buildings.Join(_context.Floors,
                    building => new { building.BuildingName, building.BuildingAddress },
                    floor => new { floor.Building.BuildingName, floor.Building.BuildingAddress },
                    (building, floor) => new { building, floor }).
                    Where(buildingFloor =>
                    ((buildingFloor.building.BuildingName.ToLower() == occupantDto.Building.BuildingName.ToLower()) ||
                    buildingFloor.building.BuildingAddress.ToLower() == occupantDto.Building.BuildingAddress.ToLower())
                        && (buildingFloor.floor.Building.BuildingId == buildingFloor.building.BuildingId &&
                        buildingFloor.floor.FloorName.ToLower() == occupantDto.Building.FloorName.ToLower())).
                        Join(_context.Departments,
                        buildingFloor => buildingFloor.floor.FloorId,
                        department => department.Floor.FloorId,
                        (buildingFloor, department) => new { buildingFloor, department }).
                        Where(BuildingFloorDepartment =>
                        (BuildingFloorDepartment.buildingFloor.floor.FloorId == BuildingFloorDepartment.department.Floor.FloorId) &&
                        (BuildingFloorDepartment.department.DepartmentName.ToLower() == occupantDto.Building.DepartmentName));

                //Building, Floor and Department correct???
                if (queryWithDepartment.Count() > 0)
                {
                    //Add into DB
                    occupant.Department = queryWithDepartment.ElementAt(0).department; //Add department to Occupant

                    response += $" //Building: {queryWithDepartment.ElementAt(0).buildingFloor.building.BuildingName} from {queryWithDepartment.ElementAt(0).buildingFloor.building.BuildingAddress} - " +
                        $"Floor: {queryWithDepartment.ElementAt(0).buildingFloor.floor.FloorName} " +
                        $"'{queryWithDepartment.ElementAt(0).department.DepartmentName}'";
                }
                else
                    response += "//Building, floor or department not existent";
            }
            //------------------------------------------------------

            return response;
        }

        private string AssignGarageSectionToOccupant(OccupantDTO occupantDto, Occupant occupant)
        {
            string response = "";

            //If user doesn't select garage or garage section, return from this function
            if (occupantDto.Building.GarageSections.Count <= 0 || 
                (occupantDto.Building.GarageLevel == "" || occupantDto.Building.GarageLevel == null))
            {
                response += "No garage or garage section was selected by user";
                return response;
            }

            var query = _context.Buildings.Join(_context.Garages,
                building => building.BuildingId,
                garage => garage.Building.BuildingId,
                (building, garage) => new { building, garage }).
                Where(
                buildingGarage =>
                (buildingGarage.garage.GarageLevel.ToLower() == occupantDto.Building.GarageLevel.ToLower()) &&
                (buildingGarage.building.BuildingName.ToLower() == occupantDto.Building.BuildingName ||
                    buildingGarage.building.BuildingAddress.ToLower() == occupantDto.Building.BuildingAddress.ToLower())
                    );

            List<GarageSection> garageSections = new List<GarageSection>();

            if (query.Count() > 0)
            {
                response += $"Building: {query.ElementAt(0).building.BuildingName} - Garage: {query.ElementAt(0).garage.GarageLevel}";

                garageSections.AddRange(_context.GaragesSections.
                    Where(
                            garageSections => garageSections.Garage.GarageId == query.ElementAt(0).garage.GarageId).
                            ToList()
                        ); 

                foreach (var garageSection in occupantDto.Building.GarageSections)
                {
                    GarageSection garageSectionOriginal = garageSections.
                        FirstOrDefault(
                        section => section.GarageSectionName.ToLower() == garageSection.GarageSectionName.ToLower());
                    
                    if (garageSectionOriginal == null)
                    {
                        response += $"--Section {garageSection.GarageSectionName} not exist into Garage {query.ElementAt(0).garage.GarageLevel}--\n";
                    }
                    else //Garage Section and related Garage correct
                    {
                        //Add Garage Section to Occupant
                        occupant.GarageSections.Add(garageSectionOriginal);
                        //Add Occupant to Garage Section
                        garageSectionOriginal.Occupants.Add(occupant);

                        response += $"\n--Section {garageSection.GarageSectionName} into Garage {query.ElementAt(0).garage.GarageLevel} asigned--\n";
                    }
                }
            }
            else
            {
                response += "Building or Garage not existent";
            }



            return response;
        }

        private string AssignVehiclesToOccupant(OccupantDTO occupantDto, Occupant occupant)
        {
            string response = "";

            //No vehicles selected?...return
            if(occupantDto.Vehicles.Count <= 0)
            {
                response += "No vehicles was selected by user";
                return response;
            }

            foreach (VehicleDTO vehicleDto in occupantDto.Vehicles)
            {
                Vehicle v = _context.Vehicles.
                    FirstOrDefault(vehicle => vehicle.VehicleLicensePlate.ToLower() == vehicleDto.VehicleLicensePlate.ToLower());

                if (v != null)
                {
                    //Add existent vehicle to occupant and occupant to vehicle
                    v.Occupants.Add(occupant);
                    _context.Update(v); //Update existent vehicle in DB
                    occupant.Vehicles.Add(v);

                    response += $"\nVehicle {v.VehicleLicensePlate} already exist," +
                        $" assigned to new occupant {occupant.OccupantSurname} {occupant.OccupantSurname}\n";
                }
                else
                {
                    Vehicle vehicle = new Vehicle
                    {
                        VehicleBrand = vehicleDto.VehicleBrand,
                        VehicleColor = vehicleDto.VehicleColor,
                        VehicleModel = vehicleDto.VehicleModel,
                        VehicleLicensePlate = vehicleDto.VehicleLicensePlate,
                    };
                    vehicle.Occupants.Add(occupant);
                    _context.Vehicles.Add(vehicle);//Add new vehicle into DB
                    occupant.Vehicles.Add(vehicle);

                    response += $"\nNew vehcle {vehicle.VehicleLicensePlate} assigned to " +
                        $"a new occupant {occupant.OccupantSurname} {occupant.OccupantSurname}\n";
                }
            }

            return response;
        }

        private string AssignEmployeesToOccupant(OccupantDTO occupantDto, Occupant occupant)
        {
            string response = "";

            //No employees to save?...return
            if(occupantDto.Employees.Count <= 0)
            {
                response += "No employees was found to save";
                return response;
            }

            foreach(EmployeeDTO employee in occupantDto.Employees)
            {
                Employee e = _context.Employees.FirstOrDefault(
                    emp =>
                    (emp.EmployeeName.ToLower() == employee.EmployeeName.ToLower()) && 
                    (emp.EmployeeSurname == employee.EmployeeSurname.ToLower()));

                if(e != null)//Employee already exist
                {
                    //Add Occupant to Employee and viceversa
                    e.Occupants.Add(occupant);
                    _context.Employees.Update(e);//Update existen Employee into DB
                    occupant.Employees.Add(e);

                    response += $"\nEmployee {e.EmployeeSurname} {e.EmployeeName} already exist." +
                        $"Employee assinged to occupant {occupant.OccupantSurname} {occupant.OccupantName}\n";
                }
                else //Employee not exist, so we create a new one
                {
                    Employee newEmployee = new Employee()
                    {
                        EmployeeName = employee.EmployeeName,
                        EmployeeSurname = employee.EmployeeSurname,
                        EmployeeCheckIn = employee.EmployeeCheckIn,
                        EmployeeCheckOut = employee.EmployeeCheckOut,
                    };

                    newEmployee.Occupants.Add(occupant);
                    _context.Employees.Add(newEmployee);//Add new employee into DB
                    newEmployee.Occupants.Add(occupant);

                    response += $"\nNew Employee {newEmployee.EmployeeSurname} {newEmployee.EmployeeName} " +
                        $"assinged to occupant {occupant.OccupantSurname} {occupant.OccupantName}\n";
                }
            }

            return response;
        }
    }
}
