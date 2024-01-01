using Atolla.Api.Framework.Extensions;
using Atolla.Core;
using Atolla.Core.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Atolla.Api.Framework.Infrastructure
{
    public class AuthenticationStartup : IAppStartup
    {
        public int Order => 900;
        public void Configure(IApplicationBuilder application)
        {
            application.UseAuthentication();
            application.UseAuthorization();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
            {
                return true;
            };

            Config config = services.BuildServiceProvider().GetRequiredService<Config>();
            services.AddAuthentication(options => { options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(options =>
                {
                    ConfigureDefaultJwtAuthentication(options);

                    options.Audience = config.KeycloakClientId;
                    options.Authority = config.KeycloakAuthority;
                    options.TokenValidationParameters.ValidIssuer = options.Authority;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false
                    };
                });



            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder(
                 JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());

            });

        }
        private static void ConfigureDefaultJwtAuthentication(JwtBearerOptions options)
        {
            options.RequireHttpsMetadata = false;
            options.IncludeErrorDetails = true;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateLifetime = true
            };

            options.Events = new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    MapKeycloakRolesToRoleClaims(context);
                    return Task.CompletedTask;
                },
                OnAuthenticationFailed = context =>
                {
                    Serilog.Log.Error(context.Exception, "OnAuthenticationFailed");
                    return null;
                }
            };
        }


        private static void MapKeycloakRolesToRoleClaims(TokenValidatedContext context)
        {
            var resourceAccess = JObject.Parse(context.Principal.FindFirst("resource_access").Value);
            var clientResource = resourceAccess[context.Principal.FindFirstValue("aud")];
            var clientRoles = clientResource["roles"];
            var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity == null)
            {
                return;
            }

            foreach (var clientRole in clientRoles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, clientRole.ToString()));
            }
        }
    }
}
