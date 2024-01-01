using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Atolla.Core;
using Atolla.Core.Infrastructure;
using Atolla.Domain;
using System;
using System.Text;

namespace Atolla.Api.Framework.Infrastructure
{
    public class AtollaAppDbStartup : IAppStartup
    {
        public int Order => 10;

        public void Configure(IApplicationBuilder application)
        {

        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            string connectionStringOracl = $"Password=Atolla21;User Id=Atolla;Data Source=atollavm.francecentral.cloudapp.azure.com:1521/XE";
            Config atollaConfig = services.BuildServiceProvider().GetRequiredService<Config>();
            string connectionString = configuration.GetConnectionString("Default");
            //add object context
            services.AddDbContextPool<AtollaObjectContext>(optionsBuilder =>
            {
                var config = services.BuildServiceProvider().GetRequiredService<Config>();
                var dbContextOptionsBuilder = optionsBuilder.UseLazyLoadingProxies();
                dbContextOptionsBuilder.UseOracle(connectionStringOracl, s => s.UseOracleSQLCompatibility("11"));
            });
            //add EF services
            services.AddEntityFrameworkOracle();
            services.AddEntityFrameworkProxies();
        }
    }
}
