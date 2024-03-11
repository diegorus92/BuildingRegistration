using BuildingRegistrationAPI_DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRegistrationAPI_DL.Data
{
    public class BuildingRegistrationContext:DbContext
    {
        public BuildingRegistrationContext(DbContextOptions<BuildingRegistrationContext>options):base(options)
        {

        }


        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Occupant> Occupants { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Garage> Garages { get; set; }
        public virtual DbSet<GarageSection> GaragesSections { get; set;}
        
    }
}
