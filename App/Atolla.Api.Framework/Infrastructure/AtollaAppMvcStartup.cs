using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Atolla.Core;
using Atolla.Core.Infrastructure;
using System;
using System.Linq;
using Atolla.Api.Framework.ActionFilters;

namespace QB.Api.Framework.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring MVC on application startup
    /// </summary>
    public class AtollaAppMvcStartup : IAppStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddCors();

            //add basic MVC feature
            var mvcBuilder = services.AddControllersWithViews(s =>
            {
                s.Filters.Add(typeof(ValidateModelStateAttribute));
            });

            mvcBuilder.AddRazorRuntimeCompilation();


            //we use legacy (from previous versions) routing logic
            mvcBuilder.AddMvcOptions(options => options.EnableEndpointRouting = false);

            //sets the default value of settings on MvcOptions to match the behavior of asp.net core mvc 2.2
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            var config = services.BuildServiceProvider().GetRequiredService<Config>();
            if (config.UseSessionStateTempDataProvider)
            {
                //use session-based temp data provider
                mvcBuilder.AddSessionStateTempDataProvider();
            }
            else
            {
                //use cookie-based temp data provider
                mvcBuilder.AddCookieTempDataProvider(options =>
                {
                    options.Cookie.Name = $"{AtollaCookieDefaults.Prefix}{AtollaCookieDefaults.TempDataCookie}";

                    //whether to allow the use of cookies from SSL protected page on the other store pages which are not
                    //options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                    //    ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
                });
            }

            services.AddRazorPages();


            mvcBuilder.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());


            //add fluent validation
            mvcBuilder.AddFluentValidation(s =>
            {
                var assemblies = mvcBuilder.PartManager.ApplicationParts
                    .OfType<AssemblyPart>()
                    .Where(part => part.Name.StartsWith("Atolla.", StringComparison.InvariantCultureIgnoreCase))
                    .Select(part => part.Assembly);
                s.RegisterValidatorsFromAssemblies(assemblies);
                //implicit/automatic validation of child properties
                s.ImplicitlyValidateChildProperties = true;
            });


            //register controllers as services, it'll allow to override them
            mvcBuilder.AddControllersAsServices();
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            //use MiniProfiler
            application.UseCors(
                options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            application.UseMiniProfiler();
            //MVC routing
            application.UseMvc();
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order => 1000; //MVC should be loaded last
    }
}
