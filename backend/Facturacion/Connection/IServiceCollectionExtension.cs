using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection ConfigureService(this IServiceCollection service, IConfiguration Configuration)
        {
            string filePath = @"C:\Users\wba_\source\repos\Facturacion\Connection\appsettings.json";

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Path.GetDirectoryName(filePath))
               .AddJsonFile("appsettings.json")
               .Build();

            service.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            return service;
        }
    }
}
