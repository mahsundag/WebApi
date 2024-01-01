using Autofac;
using Atolla.Core.Reflection;

namespace Atolla.Core.Dependency
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder, Config config);
        int Order { get; }
    }
}
