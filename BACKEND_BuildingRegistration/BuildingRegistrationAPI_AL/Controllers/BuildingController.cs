using BuildingRegistrationAPI_BL.Dtos;
using BuildingRegistrationAPI_BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingRegistrationAPI_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }



        [HttpPost]
        public ActionResult<string> AddBuilding(BuildingDTO buildingDto)
        {
            return _buildingService.AddBuilding(buildingDto);
        }

        [HttpGet]
        public ActionResult<ICollection<BuildingDTO>> GetBuildings() 
        {
            return _buildingService.GetBuildings().ToList();
        }
    }
}
