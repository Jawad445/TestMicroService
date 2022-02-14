using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;

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
}