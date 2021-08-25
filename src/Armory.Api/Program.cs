using Armory.Api.Extensions;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Armory.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase<ArmoryDbContext>().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}
