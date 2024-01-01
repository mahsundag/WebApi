using Atolla.Api.Framework.Models.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atolla.Api.Framework.Validators
{
    public class ParameterModelValidator : AbstractValidator<ParameterModel>
    {
        public ParameterModelValidator()
        {
            RuleFor(x => x.GroupCode).NotNull();
            RuleFor(x => x.ParameterCode).NotNull();
        }
    }
}
