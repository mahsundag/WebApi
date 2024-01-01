using Atolla.Domain.General;
using Atolla.Services.ServiceInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atolla.Services.Interfaces
{
    public interface ILocalizationService : IEntityService<Localization>
    {
        List<Localization> GetLanguageValues(string languageCode);
    }
}
