using BuildingRegistrationAPI_BL.Dtos;
using BuildingRegistrationAPI_DL.Data;
using BuildingRegistrationAPI_DL.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_BL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly BuildingRegistrationContext _context;

        public DepartmentService(BuildingRegistrationContext context)
        {
            _context = context;
        }



        public ICollection<OccupantDTO> GetOccupantsOfDepartment(int departmentId)
        {
            List<Occupant> occupants = _context.Occupants.
                Include(occupant => occupant.Employees).
                Include(occupant => occupant.Vehicles).
                Where(occupant => occupant.Department.DepartmentId == departmentId).ToList();

            ICollection<OccupantDTO> occupantsDto = new List<OccupantDTO>();
            
            if(occupants.Count > 0 ) 
            {
                foreach(var occupant in occupants)
                {
                    occupantsDto.Add(new OccupantDTO()
                    {
                        OccupantId = occupant.OccupantId,
                        OccupantName = occupant.OccupantName,
                        OccupantSurname = occupant.OccupantSurname,
                        OccupantEmail = occupant.OccupantEmail,
                        OccupantCellPhone = occupant.OccupantCellPhone,
                        Employees = _GetEmployeesOfOccupant(occupant.Employees.ToList()),
                        Vehicles = _GetVehiclesOfOccupant(occupant.Vehicles.ToList()),
                    });
                }  
            }

            return occupantsDto;
        }



        //-------------------PRIVATE FUNCTIONS--------------------------------------------
        private List<VehicleDTO> _GetVehiclesOfOccupant(List<Vehicle> vehicles)
        {
            List<VehicleDTO> vehiclesDto = new List<VehicleDTO>();

            foreach(var vehicle in vehicles)
            {
                vehiclesDto.Add(new VehicleDTO()
                {
                    VehicleID = vehicle.VehicleId,
                    VehicleBrand = vehicle.VehicleBrand,
                    VehicleModel = vehicle.VehicleModel,
                    VehicleColor = vehicle.VehicleColor,
                    VehicleLicensePlate = vehicle.VehicleLicensePlate,
                });
            }

            return vehiclesDto;
        }
        private List<EmployeeDTO> _GetEmployeesOfOccupant(List<Employee> employees)
        {
            List<EmployeeDTO> employeesDto = new List<EmployeeDTO>();

            foreach(var employee in employees)
            {
                employeesDto.Add(new EmployeeDTO()
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeName = employee.EmployeeName,
                    EmployeeSurname = employee.EmployeeSurname,
                    EmployeeCheckIn = employee.EmployeeCheckIn,
                    EmployeeCheckOut = employee.EmployeeCheckOut,
                });
            }

            return employeesDto;
        }
    }
}
