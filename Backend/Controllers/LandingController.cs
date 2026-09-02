using Backend.Services;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LandingController : ControllerBase
{
    private readonly Service _Service;

    public LandingController(Service Service)
    {
        _Service = Service;
    }

    [HttpPost]
    [Route("GetLandingData")]
     public IActionResult GetLandingData([FromBody] LandingModel model)
     {
         return Ok(_Service.GetLandingData(model));
     }
}