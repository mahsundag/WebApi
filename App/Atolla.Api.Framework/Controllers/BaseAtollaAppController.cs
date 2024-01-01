using Microsoft.AspNetCore.Mvc;
using Atolla.Api.Framework.Models.Base;
using Atolla.Services.ServiceInfrastructure;
using System;
using System.Collections;
using System.Linq.Expressions;
using Atolla.Api.Framework.Controllers;
using Atolla.Api.Framework.Extensions;
using Atolla.Core.BaseRepository;
using Microsoft.Extensions.Logging;
using Atolla.Api.Framework.Models.Common;
using System.Security.Authentication;
using System.Linq;
using System.Security.Claims;

namespace Atolla.Api.Framework.Controllers
{
    public class BaseAtollaAppController : ControllerBase
    {
        public ILogger _logger;

        public AuthUserModel AuthUser
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                    throw new AuthenticationException();

                return new AuthUserModel
                {
                    UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value,
                    Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                    Name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName).Value,
                    Surname = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname).Value
                };
            }
        }
        public BaseAtollaAppController(ILogger logger)
        {
            this._logger = logger;
        }

        protected IActionResult NullResult()
        {
            AtollaAppResponse response = new AtollaAppResponse();
            response.HasError = false;
            response.ErrorMessage = string.Empty;
            response.Message = "NoRecordFound";
            return Ok(response);
        }

        protected IActionResult ErrorResponse(Exception ex = null)
        {
            AtollaAppResponse response = new AtollaAppResponse();
            response.HasError = true;
            response.ErrorMessage = ex.Message ?? "";
            response.Message = ex.Message ?? "";
            return Ok(response);
        }

        protected IActionResult SuccessResponse()
        {
            AtollaAppResponse response = new AtollaAppResponse();
            response.HasError = false;
            response.ErrorMessage = string.Empty;
            response.Message = string.Empty;
            return Ok(response);
        }

        protected IActionResult SuccessResponse<T>(T response)
        {
            AtollaAppResponse<T> atollaAppSingleResponse = new AtollaAppResponse<T>();
            atollaAppSingleResponse.Model = response;
            atollaAppSingleResponse.HasError = false;
            atollaAppSingleResponse.Message = string.Empty;
            atollaAppSingleResponse.ErrorMessage = string.Empty;
            return Ok(atollaAppSingleResponse);
        }

        protected IActionResult Execute(Action action)
        {
            try
            {
                action();
                _logger.LogWarning("RequestSuccess");

                return SuccessResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "RequestFailed");
                return ErrorResponse(ex);
            }
        }

    }

    public class BaseAtollaAppController<T> : BaseAtollaAppController
    {
        public readonly T _service;
        public ILogger _logger;

        public BaseAtollaAppController(T service, ILogger logger) : base(logger)
        {
            this._service = service;
            this._logger = logger;
        }
        protected IActionResult Execute<R>(Func<T, R> action)
        {
            try
            {
                var result = action(_service);
                if (result == null)
                    return NullResult();
                return SuccessResponse<R>(result);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "ArgumentNull");
                return NullResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "RequestFailed");
                return ErrorResponse(ex);
            }
        }
    }
}

