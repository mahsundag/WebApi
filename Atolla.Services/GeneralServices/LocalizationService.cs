using Atolla.Core.Caching;
using Atolla.Core.Data;
using Atolla.Domain.General;
using Atolla.Services.Interfaces;
using Atolla.Services.ServiceInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atolla.Services.GeneralServices
{
    public class LocalizationService : EntityService<Localization>, ILocalizationService
    {
        public LocalizationService(IUnitOfWork unitOfWork
            , IStaticCacheManager staticCacheManager) : base(unitOfWork, staticCacheManager)
        {

        }
        public override string GetCacheName() => "LocalizationCache";

        public override bool IsCacheEnabled() => true;

        public List<Localization> GetLanguageValues(string languageCode)
        {
            if (_staticCacheManager.IsSet(GetCacheName()))
                return _staticCacheManager.Get<List<Localization>>(GetCacheName()).Where(s => s.LanguageCode == languageCode).ToList();
            else
            {
                var data = this.CurrentRepository.Table.ToList();
                Task.Run(() => _staticCacheManager.Set(GetCacheName(), data));
                return data.Where(s => s.LanguageCode == languageCode).ToList();
            }
        }
    }
}
