using Atolla.Core.Caching;
using Atolla.Core.Data;
using Atolla.Domain.General;
using Atolla.Services.Interfaces;
using Atolla.Services.ServiceInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atolla.Services.GeneralServices
{
    public class LogService : EntityService<Log>, ILogService
    {
        public LogService(IUnitOfWork _uow, IStaticCacheManager staticCacheManager) : base(_uow, staticCacheManager)
        {

        }
    }
}
