using System.Collections.Generic;

namespace PTDX.TypeDescription
{
    public interface ITypeDescriptionContext
    {
        void Add(TypeDescription description);

        void Add<T>(string description, TypeCategory category = null);

        void AddRange(IEnumerable<TypeDescription> descriptions);

        IList<TypeDescription> GetAllTypeDescriptions();
    }
}