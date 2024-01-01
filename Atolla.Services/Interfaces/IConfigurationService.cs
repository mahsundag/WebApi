using Atolla.Domain.General;
using Atolla.Services.ServiceInfrastructure;
using System.Collections.Generic;

namespace Atolla.Services.Interfaces
{
    public interface IConfigurationService : IEntityService<Configuration>
    {
        IEnumerable<Configuration> GetEnvironmentConfigurations(string environment);
        Configuration GetConfigurationValue(string key);
    }
}
