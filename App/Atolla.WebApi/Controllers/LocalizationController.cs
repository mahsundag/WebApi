using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Atolla.Api.Framework;
using Atolla.Api.Framework.Controllers;
using Atolla.Api.Framework.Extensions;
using Atolla.Api.Framework.Models.Common;
using Atolla.Domain.General;
using Atolla.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Atolla.WebApi.Controllers
{
    [Route(Constants.PUBLIC_API_ROUTE)]
    [ApiController]
    public class LocalizationController : BaseAtollaAppController<ILocalizationService>
    {
        private readonly ILocalizationService _localizationService;
        public LocalizationController(ILocalizationService localizationService, ILogger<LocalizationController> logger) : base(localizationService, logger)
        {
            _localizationService = localizationService;
        }


        [HttpGet("{languageCode}")]
        [ResponseCache(Duration = 60 * 60, Location = ResponseCacheLocation.None)]
        public IActionResult GetLocalization(string languageCode)
        {
            return Ok(this._localizationService.GetLanguageValues(languageCode).ToDictionary(s => s.StringKey, m => m.StringValue));
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddLocalization([FromBody] LocalizationModel localization)
        {
            var user = this.AuthUser;
            return Execute(() => _localizationService.Insert(localization.ToEntity<Localization>()));
        }
        [HttpPut]
        public IActionResult UpdateLocalization([FromBody] LocalizationModel localization)
        {
            return Execute(() => _localizationService.Update(localization.ToEntity<Localization>()));
        }
        [HttpDelete]
        public IActionResult DeleteLocalization([FromBody] LocalizationModel localization)
        {
            return Execute(() => _localizationService.Delete(localization.ToEntity<Localization>()));
        }
    }
}
