namespace PlatformService.Data;

using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

public class AppDbcontext : DbContext
{
    public AppDbcontext(DbContextOptions<AppDbcontext> options)
        :base(options)
    {
        
    }
    public DbSet<Platform> Platform { get; set; }

}