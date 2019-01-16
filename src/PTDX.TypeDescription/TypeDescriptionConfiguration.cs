using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PTDX.TypeDescription
{
    public class TypeDescriptionConfiguration : ITypeDescriptionConfiguration
    {
        public TypeDescriptionConfiguration(params Assembly[] providerAssemblies)
        {
            var providerInterfaceType = typeof(ITypeDescriptionProvider);
            ProviderTypes = providerAssemblies
                .SelectMany(a => a.GetTypes().Where(t => providerInterfaceType.IsAssignableFrom(t))).ToList();
        }

        public IList<Type> ProviderTypes { get; protected set; }

        public virtual ITypeDescriptionProvider ResolveProvider(Type type)
        {
            return (ITypeDescriptionProvider)Activator.CreateInstance(type);
        }
    }
}