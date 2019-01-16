using System;
using System.Collections.Generic;
using System.Linq;

namespace PTDX.TypeDescription
{
    public class TypeDescriptionManager : TypeDescriptionContext, ITypeDescriptionManager
    {
        private readonly ITypeDescriptionConfiguration _typeDescriptionConfiguration;

        public TypeDescriptionManager(ITypeDescriptionConfiguration typeDescriptionConfiguration)
        {
            _typeDescriptionConfiguration = typeDescriptionConfiguration;

            Initialize();
        }

        private void Initialize()
        {
            var providerInterfaceType = typeof(ITypeDescriptionProvider);

            foreach (var providerType in _typeDescriptionConfiguration.ProviderTypes)
            {
                if (!providerInterfaceType.IsAssignableFrom(providerType))
                {
                    throw new ArgumentException($"{providerType.FullName} is not assignable from {providerInterfaceType.FullName}");
                }

                var provider = _typeDescriptionConfiguration.ResolveProvider(providerType);

                provider?.SetDescriptions(this);
            }
        }

        public TypeDescription FindTypeDescription(string typeFullName)
        {
            return TypeDescriptions.FirstOrDefault(d => d.FullName == typeFullName);
        }

        public TypeDescription FindTypeDescription<T>()
        {
            var type = typeof(T);

            return TypeDescriptions.FirstOrDefault(d => d.FullName == type.FullName);
        }

        public IList<TypeDescription> FindTypeDescriptions(IList<string> typeFullNames)
        {
            return TypeDescriptions.Where(d => typeFullNames.Contains(d.FullName)).ToList();
        }

        public IList<TypeDescription> GetCategoryTypeDescriptions(string categoryName)
        {
            return TypeDescriptions.Where(d => d.Category.Name == categoryName).ToList();
        }

        public IList<TypeDescription> GetCategoryTypeDescriptions(TypeCategory category)
        {
            return TypeDescriptions.Where(d => d.Category.Name == category.Name).ToList();
        }
    }
}