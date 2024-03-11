using BuildingRegistrationAPI_BL.Dtos;
using BuildingRegistrationAPI_BL.Services;
using BuildingRegistrationAPI_DL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingRegistrationAPI_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageController : ControllerBase
    {
        private readonly IGarageService _garageService;

        public GarageController(IGarageService garageService)
        {
            _garageService = garageService;
        }



        [HttpGet("garage-section/{buildingName}/{buildingAddress}/{garageLevel}")]
        public ActionResult<ICollection<GarageSectionOccupiedDTO>> GetAllOccupiedGarageSectionFromBuilding(string buildingName, string buildingAddress, string garageLevel)
        {
            return Ok(_garageService.GetAllOccupiedGarageSectionsFromBuilding(buildingName, buildingAddress, garageLevel)); 
        }

        [HttpGet("garage-sections")]
        public ActionResult<ICollection<GarageSectionOccupantsDTO>> GetGarageSectionsWithOccupants()
        {
            return Ok(_garageService.GetGarageSectionsWithOccupants());
        }
    }
}
