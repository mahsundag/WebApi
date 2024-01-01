using Atolla.Api.Framework.Models.Base;

namespace Atolla.Api.Framework.Models.Common
{
    public class ParameterModel : BaseModel
    {
        public int ParameterId { get; set; }
        public int GroupId { get; set; }
        public string GroupCode { get; set; }
        public string ParameterCode { get; set; }
        public string ParameterName { get; set; }
        public string ParameterDescription { get; set; }
    }
}
