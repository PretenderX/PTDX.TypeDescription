using System.Collections.Generic;

namespace PTDX.TypeDescription
{
    public interface ITypeDescriptionManager : ITypeDescriptionContext
    {
        TypeDescription FindTypeDescription(string typeFullName);

        TypeDescription FindTypeDescription<T>();

        IList<TypeDescription> FindTypeDescriptions(IList<string> typeFullNames);

        IList<TypeDescription> GetCategoryTypeDescriptions(string categoryName);

        IList<TypeDescription> GetCategoryTypeDescriptions(TypeCategory category);
    }
}