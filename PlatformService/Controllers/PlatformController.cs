using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controller;

[Route("api/[Controller]")]
[ApiController]
public class PlatformController : ControllerBase
{
    private readonly IPlatformRepo _repo;
    private IMapper _mapper;

    public PlatformController(IPlatformRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatform()
    {
        Console.WriteLine("Generating Data");
        var platforms = _repo.GetAll();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }

    [HttpGet("{id}")]
    public ActionResult<PlatformReadDto> GetById(int id)
    {
        var platform = _repo.GetById(id);
        if(platform is not null)
        {
            return Ok(_mapper.Map<PlatformReadDto> (platform));
        }
        return NotFound();        
    }
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto model)
    {
        var platformModel = _mapper.Map<Platform>(model);
        _repo.CreatePlatform(platformModel);
        _repo.SaveChanges();

        var returnobj = _mapper.Map<PlatformReadDto>(platformModel);
        return CreatedAtRoute(nameof(GetById), new {id = platformModel.Id}, returnobj);
    }
}