using System;
using System.Collections.Generic;
using System.Text;

namespace Atolla.Api.Framework.Models.Common
{
    public class AuthUserModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
