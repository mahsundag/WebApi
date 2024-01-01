using Atolla.Api.Framework.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atolla.Api.Framework.Models.Common
{
    public class LocalizationModel : BaseModel
    {
        public string StringKey { get; set; }
        public string LanguageCode { get; set; }
        public string StringValue { get; set; }
    }
}
