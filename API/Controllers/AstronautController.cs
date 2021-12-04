using API.DTO;
using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AstronautController: ControllerBase
{
    private readonly IAstronautService _astronautService;
    private readonly IMapper _mapper;
    
    public AstronautController(IAstronautService astronautService, IMapper mapper)
    {
        _astronautService = astronautService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<AstronautAllResponseModel>> GetAstronauts()
    {
        try
        {
            var astronauts = _astronautService.GetALlAstronauts();
            var astronautsList = await astronauts.ToListAsync();

            return new AstronautAllResponseModel
            {
                Astroanuts = astronautsList
                    .Select(astronaut => _mapper.Map<Astronaut, AstronautResponseModel>(astronaut))
            };
        }  catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpPost]
    [Route("")]
    public async Task<ActionResult<AstronautResponseModel>> CreateNote([FromBody] AstronautRequestModel requestModel)
    {
        try
        {
            var astronautModel = _mapper.Map<AstronautRequestModel, AddAstronaut>(requestModel);
            var astronaut = await _astronautService.AddAstronaut(astronautModel);

            return _mapper.Map<Astronaut, AstronautResponseModel>(astronaut);
        } 
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<ActionResult<AstronautResponseModel>> UpdateNote([FromRoute] Guid id,
        [FromBody] AstronautRequestModel requestModel)
    {
        try
        {
            var astronautModel = _mapper.Map<AstronautRequestModel, AddAstronaut>(requestModel);
            var astronaut = await _astronautService.UpdateAstronaut(id, astronautModel);

            return _mapper.Map<Astronaut, AstronautResponseModel>(astronaut);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
}

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult> DeleteNote([FromRoute] Guid id)
    {
        try
        {
            await _astronautService.DeleteAstronaut(id);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}