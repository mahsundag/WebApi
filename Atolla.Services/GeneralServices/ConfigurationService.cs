using Atolla.Core.Caching;
using Atolla.Core.Data;
using Atolla.Domain.General;
using Atolla.Services.Interfaces;
using Atolla.Services.ServiceInfrastructure;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atolla.Services.GeneralServices
{
    public class ConfigurationService : EntityService<Configuration>, IConfigurationService
    {
        ILogger<Configuration> _logger;

        public ConfigurationService(IUnitOfWork _uow
            , ILogger<ConfigurationService> logger
            , IStaticCacheManager staticCacheManager) : base(_uow, staticCacheManager)
        {
            logger.LogWarning("configuration working");
        }

        public override string GetCacheName() => "ConfigurationCache";

        public override bool IsCacheEnabled() => true;

        public IEnumerable<Configuration> GetEnvironmentConfigurations(string environment)
        {
            throw new System.NotImplementedException();
        }

        public Configuration GetConfigurationValue(string key)
        {
            if (_staticCacheManager.IsSet(GetCacheName()))
                return _staticCacheManager.Get<List<Configuration>>(GetCacheName()).FirstOrDefault(s => s.ConfigurationKey == key);
            else
            {
                var data = this.CurrentRepository.Table.ToList();
                Task.Run(() => _staticCacheManager.Set(GetCacheName(), data));
                return data.FirstOrDefault(s => s.ConfigurationKey == key);
            }
        }
    }
}
