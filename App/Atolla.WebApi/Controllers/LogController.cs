using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atolla.Api.Framework;
using Atolla.Api.Framework.Controllers;
using Atolla.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Atolla.WebApi.Controllers
{
    [Route(Constants.PUBLIC_API_ROUTE)]
    [ApiController]
    public class LogController : BaseAtollaAppController<ILogService>
    {
        private readonly ILogService _logService;
        public LogController(ILogService logService, ILogger<LogController> logger) : base(logService, logger)
        {
            _logService = logService;
        }

    }
}
