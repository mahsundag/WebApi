using Atolla.Api.Framework.Models.Base;

namespace Atolla.Api.Framework.Models.Common
{
    public class GroupModel : BaseModel
    {
        public int GroupId { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
    }
}
