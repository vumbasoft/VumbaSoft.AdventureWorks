using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VumbaSoft.AdventureWorks.Data.Core;
using System.IO;

namespace VumbaSoft.AdventureWorks.Data
{
    public class Startup
    {
        private IConfiguration Config { get; }

        public Startup(IHostEnvironment env)
        {
            Config = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .SetBasePath(Directory.GetParent(env.ContentRootPath).FullName)
                .AddJsonFile("VumbaSoft.AdventureWorks.Web/configuration.json")
                .AddJsonFile($"VumbaSoft.AdventureWorks.Web/configuration.{env.EnvironmentName.ToLower()}.json", optional: true)
                .Build();
        }

        public void Configure()
        {
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(Config["Data:Connection"]));
        }
    }
}
