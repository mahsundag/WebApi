using Autofac;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Atolla.Core;
using Atolla.Core.BaseRepository;
using Atolla.Core.Data;
using Atolla.Core.Dependency;
using Atolla.Core.Helpers;
using Atolla.Core.Infrastructure;
using Atolla.Core.Reflection;
using Atolla.Domain;
using Atolla.Services.GeneralServices;
using Atolla.Services.ServiceInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Atolla.Services.Interfaces;
using Atolla.Core.Caching;

namespace Atolla.Api.Framework.Infrastructure
{
    public class DependenyRegistryModule : IDependencyRegistrar
    {
        public int Order => 0;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, Config config)
        {
            //file provider
            //builder.RegisterType<QBFileProvider>().As<IQBFileProvider>().InstancePerLifetimeScope();
            builder.Register(s => CommonHelper.DefaultFileProvider).As<IAtollaFileProvider>().InstancePerLifetimeScope();
            //web helper
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();

            //data layer
            builder.Register(context => new AtollaObjectContext(context.Resolve<DbContextOptions<AtollaObjectContext>>()))
                .As<IDbContext>().InstancePerLifetimeScope();
            //repositories
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EntityService<>)).As(typeof(IEntityService<>)).InstancePerLifetimeScope();
            
            builder.Register(c => new UnitOfWork(c.Resolve<AtollaObjectContext>())).As<IUnitOfWork>();

            //Cache Manager Register
            builder.RegisterType<MemoryCacheManager>()
                  .As<ILocker>()
                  .As<IStaticCacheManager>()
                  .SingleInstance();

            //create and sort instances of dependency registrars
            builder.RegisterType<ParameterService>().As<IParameterService>().InstancePerLifetimeScope();
            builder.RegisterType<GroupService>().As<IGroupService>().InstancePerLifetimeScope();
            builder.RegisterType<ConfigurationService>().As<IConfigurationService>().InstancePerLifetimeScope();
            builder.RegisterType<LogService>().As<ILogService>().InstancePerLifetimeScope();
            builder.RegisterType<LocalizationService>().As<ILocalizationService>().InstancePerLifetimeScope();

            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<ActionContextAccessor>().As<IActionContextAccessor>().InstancePerLifetimeScope();

        }
    }
}
