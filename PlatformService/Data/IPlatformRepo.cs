namespace PlatformService.Data;

using PlatformService.Models;

public interface IPlatformRepo
{
    bool SaveChanges();
    IEnumerable<Platform> GetAll();
    Platform GetById(int id);
    void CreatePlatform(Platform model);

}

