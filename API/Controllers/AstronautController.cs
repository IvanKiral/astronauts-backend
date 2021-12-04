using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AstronautController: ControllerBase
{
    [HttpGet]
    [Route("")]
    public ActionResult<AstronautAllResponseModel> GetAstronauts() => new AstronautAllResponseModel
    {
        Astroanuts = new List<AstronautResponseModel>()
    };
    
    [HttpPost]
    [Route("")]
    public ActionResult<AstronautResponseModel> CreateNote([FromBody] AstronautRequestModel requestModel)
    {
        return new AstronautResponseModel
        {
            Name = "Test",
            Surname = "TestSurname",
            Birthday = DateTime.Now,
            Ability = "TestAbility"
        };
    }

    [HttpPut]
    [Route("{id:guid}")]
    public ActionResult<AstronautResponseModel> UpdateNote([FromRoute] Guid id, [FromBody] AstronautRequestModel requestModel)
    {
        return new AstronautResponseModel
        {
            Name = "Test",
            Surname = "TestSurname",
            Birthday = DateTime.Now,
            Ability = "TestAbility"
        };
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public ActionResult DeleteNote([FromRoute] Guid id)
    {
        return Ok();
    }
}