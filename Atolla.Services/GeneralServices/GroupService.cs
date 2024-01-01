using Atolla.Core.Caching;
using Atolla.Core.Data;
using Atolla.Domain.General;
using Atolla.Services.ServiceInfrastructure;

namespace Atolla.Services.GeneralServices
{
    public interface IGroupService : IEntityService<Group>
    {
        void DeleteWithParameter(Group group);
    }
    public class GroupService : EntityService<Group>, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork, IStaticCacheManager staticCacheManager) : base(unitOfWork, staticCacheManager)
        {

        }

        public void DeleteWithParameter(Group group)
        {

        }
    }
}
