using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atolla.Api.Framework.Controllers;
using Atolla.Api.Framework.Models.Common;
using Atolla.Services.GeneralServices;
using Microsoft.AspNetCore.Mvc;
using Atolla.Api.Framework.Extensions;
using Atolla.Domain.General;
using Atolla.Services.Interfaces;
using System.Reflection.Metadata;
using Atolla.Api.Framework;
using Microsoft.Extensions.Logging;

namespace Atolla.WebApi.Controllers
{
    [Route(Constants.PUBLIC_API_ROUTE)]
    [ApiController]
    public class ConfigurationController : BaseAtollaAppController<IConfigurationService>
    {
        private readonly IConfigurationService _configurationService;
        public ConfigurationController(IConfigurationService configurationService, ILogger<ConfigurationController> logger) : base(configurationService, logger)
        {
            this._configurationService = configurationService;
        }

        [HttpPost]
        public IActionResult AddConfiguration([FromBody] ConfigurationModel request)
        {
            return Execute(() => _configurationService.Insert(request.ToEntity<Configuration>()));
        }

        [HttpGet]
        public IActionResult GetConfigurationValue([FromQuery] string keyName)
        {
            return Execute(s => s.GetConfigurationValue(keyName));
        }
    }
}
