using BuildingRegistrationAPI_BL.Dtos;
using BuildingRegistrationAPI_BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingRegistrationAPI_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        [HttpGet("occupants-department/{departmentId}")]
        public ActionResult<ICollection<OccupantDTO>> GetOccupantsOfDepartment(int departmentId)
        {
            return Ok(_departmentService.GetOccupantsOfDepartment(departmentId).ToList());
        }
    }
}
