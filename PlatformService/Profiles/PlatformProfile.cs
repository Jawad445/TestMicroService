namespace PlatformService.Profiles;
using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

public class PlatformProfile : Profile
{
    public PlatformProfile()
    {
        CreateMap<Platform, PlatformReadDto>();
        CreateMap<PlatformReadDto, Platform>(); 
    }
}