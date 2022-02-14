using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo : IPlatformRepo
{
    private readonly AppDbcontext _context;
    public PlatformRepo(AppDbcontext context)
    {
        _context = context;
    }

    public void CreatePlatform(Platform model)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));
            
        _context.Platform.Add(model);
    }

    public IEnumerable<Platform> GetAll()
    {
        return _context.Platform.ToList();
    }

    public Platform GetById(int id)
    {
        return _context.Platform.FirstOrDefault(x=>x.Id == id);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}
