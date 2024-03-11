using BuildingRegistrationAPI_BL.Dtos;
using BuildingRegistrationAPI_BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingRegistrationAPI_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupantController : ControllerBase
    {
        private readonly IOccupantService _occupantService;

        public OccupantController(IOccupantService occupantService)
        {
            _occupantService = occupantService;
        }


        [HttpPost]
        public ActionResult<string> AddOccupant(OccupantDTO occupantDto)
        {
            return _occupantService.AddOccupant(occupantDto);
        }
    }
}
