using Atolla.Core.Caching;
using Atolla.Core.Data;
using Atolla.Domain.General;
using Atolla.Services.ServiceInfrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Atolla.Services.GeneralServices
{
    public interface IParameterService : IEntityService<Parameter>
    {
        Parameter GetByParameterCode(string parameterCode);
        IEnumerable<Parameter> GetParametersByGroupCode(string groupCode);
        IEnumerable<Parameter> GetParametersByGroupId(int groupId);
    }
    public class ParameterService : EntityService<Parameter>, IParameterService
    {
        public ParameterService(IUnitOfWork unitOfWork, IStaticCacheManager staticCacheManager) : base(unitOfWork, staticCacheManager)
        {

        }

        public Parameter GetByParameterCode(string parameterCode)
        {
            return CurrentRepository.Table.FirstOrDefault(s => s.ParameterCode == parameterCode);
        }

        public IEnumerable<Parameter> GetParametersByGroupCode(string groupCode)
        {
            return CurrentRepository.Table.Where(s => s.GroupCode == groupCode);
        }

        public IEnumerable<Parameter> GetParametersByGroupId(int groupId)
        {
            return CurrentRepository.Table.Where(s => s.GroupId == groupId);
        }
    }
}
