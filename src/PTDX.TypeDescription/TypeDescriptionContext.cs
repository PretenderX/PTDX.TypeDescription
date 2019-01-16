using System.Collections.Generic;

namespace PTDX.TypeDescription
{
    public class TypeDescriptionContext : ITypeDescriptionContext
    {
        public readonly List<TypeDescription> TypeDescriptions;

        public TypeDescriptionContext()
        {
            TypeDescriptions = new List<TypeDescription>();
        }

        public void Add(TypeDescription description)
        {
            TypeDescriptions.Add(description);
        }

        public void Add<T>(string description, TypeCategory category = null)
        {
            var type = typeof(T);

            TypeDescriptions.Add(new TypeDescription(type.FullName, description, category));
        }

        public void AddRange(IEnumerable<TypeDescription> descriptions)
        {
            TypeDescriptions.AddRange(descriptions);
        }

        public IList<TypeDescription> GetAllTypeDescriptions()
        {
            return TypeDescriptions;
        }
    }
}