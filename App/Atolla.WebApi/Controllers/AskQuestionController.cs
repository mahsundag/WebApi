using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Atolla.Api.Framework;
using Atolla.Api.Framework.Controllers;
using Atolla.Api.Framework.Models.Base;
using Atolla.Domain.General;
using Atolla.Services.GeneralServices;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Atolla.WebApi.Controllers
{
    [Route(Constants.PUBLIC_API_ROUTE)]
    [ApiController]
    public class AskQuestionController : BaseAtollaAppController
    {
        public AskQuestionController(ILogger<AskQuestionController> logger) :base(logger)
        {

        }
        [HttpPost]
        public IActionResult GetAskQuestion(int appealNo)
        {
            var data = TestMethods.GetAnswer(appealNo);
            return SuccessResponse<QuestionAnswer>(data);
        }
        [HttpPost]
        public IActionResult AddQuestion(AskQuestion askQuestion)
        {
            AtollaAppResponse response = new AtollaAppResponse();
            var result =  TestMethods.AddAskQuestion(askQuestion);
            response.Message = result;
            return SuccessResponse<string>(result);
        }
        [HttpGet]
        public IActionResult GetStatusAskQuestion()
        {
            List<QuestionStatus> data = TestMethods.GetQuestionStatus();
            return SuccessResponse<List<QuestionStatus>>(data);
        }
    }
}
