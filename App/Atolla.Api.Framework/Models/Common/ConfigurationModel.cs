using System;
using System.Collections.Generic;
using System.Text;
using Atolla.Api.Framework.Models.Base;


namespace Atolla.Api.Framework.Models.Common
{
    public class ConfigurationModel : BaseModel
    {
        public string ConfigurationKey { get; set; }
        public string ConfigurationValue { get; set; }
        public string Environment { get; set; }
    }
}
