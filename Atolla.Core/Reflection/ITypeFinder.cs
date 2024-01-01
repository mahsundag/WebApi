using System;
using System.Collections.Generic;
using System.Reflection;

namespace Atolla.Core.Reflection
{
    public interface ITypeFinder
    {
        IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true);
        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true);
        IEnumerable<Type> FindClassesOfType<T>(Assembly assembly, bool onlyConcreteClasses = true);
        IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);
        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);
        bool HasProperty(Type type, string propertyName);
        void SetProperty(object _object, string propertyName, string value);
        IList<Assembly> GetAssemblies();
    }
}
