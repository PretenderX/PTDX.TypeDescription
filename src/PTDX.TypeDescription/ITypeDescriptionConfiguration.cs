using System;
using System.Collections.Generic;

namespace PTDX.TypeDescription
{
    public interface ITypeDescriptionConfiguration
    {
        IList<Type> ProviderTypes { get; }

        ITypeDescriptionProvider ResolveProvider(Type type);
    }
}