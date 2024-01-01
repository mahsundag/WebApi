using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atolla.Services.GeneralServices;
using Atolla.Api.Framework.Extensions;
using Microsoft.AspNetCore.Mvc;
using Atolla.Api.Framework.Controllers;
using Atolla.Api.Framework.Models.Common;
using Atolla.Domain.General;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace Atolla.WebApi.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ParameterManagementController : BaseAtollaAppController<IParameterService>
    {
        readonly IParameterService _parameterService;
        readonly IGroupService _groupService;
        public ParameterManagementController(IParameterService parameterService, IGroupService groupService, ILogger logger) : base(parameterService, logger)
        {
            this._parameterService = parameterService;
            this._groupService = groupService;
        }

        [HttpGet("{parameterCode}", Name = "GetParameter")]
        public IActionResult GetParameter(string parameterCode)
        {
            return Execute<ParameterModel>(s => s.GetByParameterCode(parameterCode).ToModel<ParameterModel>());
        }

        [HttpGet("{groupCode}", Name = "GetParameterByGroupCode")]
        public IActionResult GetParameterByGroupCode(string groupCode)
        {
            return Execute<IEnumerable<ParameterModel>>(s => s.GetParametersByGroupCode(groupCode).ToModel<ParameterModel>());
        }

        [HttpGet("{groupId}", Name = "GetParameterByGroupId")]
        public IActionResult GetParameterByGroupId(int groupId)
        {
            return Execute<IEnumerable<ParameterModel>>(s => s.GetParametersByGroupId(groupId).ToModel<ParameterModel>());
        }

        [HttpPost]
        public IActionResult AddParameter([FromBody] ParameterModel parameter)
        {
            if (ModelState.IsValid)
                return Execute(() => _parameterService.Insert(parameter.ToEntity<Parameter>()));
            else
                return ErrorResponse();
        }


        [HttpPost(Name = "AddGroup")]
        public IActionResult AddGroup([FromBody] GroupModel group)
        {
            return Execute(() => _groupService.Insert(group.ToEntity<Group>()));
        }


        [HttpPost(Name = "UpdateGroup")]
        public IActionResult UpdateGroup([FromBody] GroupModel group)
        {
            return Execute(() => _groupService.Update(group.ToEntity<Group>()));
        }

        [HttpPost(Name = "DeleteGroup")]
        public IActionResult DeleteGroup([FromBody] GroupModel group)
        {
            return Execute(() => _groupService.DeleteWithParameter(group.ToEntity<Group>()));
        }

        [HttpGet]
        [Authorize]
        public IActionResult TestAuthorization()
        {
            return Ok("Authorization is working!");
        }


        [HttpGet]

        public IActionResult TestAnonymous()
        {
            return Ok("Anonymous is working!");
        }
    }
}
