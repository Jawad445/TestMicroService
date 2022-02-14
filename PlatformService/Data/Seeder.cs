namespace PlatformService.Data;

public static class Seeder
{
    public static void prePopulation(IApplicationBuilder app)
    {
        using(var scope = app.ApplicationServices.CreateScope())
        {
            SeedData(scope.ServiceProvider.GetService<AppDbcontext>());
        }
    }

    private static void SeedData (AppDbcontext context)
    {   
        if(!context.Platform.Any())
        {
            Console.WriteLine("........ Seeding Data!");
            
            context.Platform.AddRange(
                new Models.Platform() {Name = "Dotnet", Publisher="Microsoft", Cost = "Free" },
                new Models.Platform() {Name = "SQL Server", Publisher="Microsoft", Cost = "Free" },
                new Models.Platform() {Name = "Docker", Publisher="Cloud computing", Cost = "Free" },
                new Models.Platform() {Name = "Kubernet", Publisher="Cloud Computing", Cost = "Free" }
            );
            
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Already Data Seeded!!!");
        }
    }
}