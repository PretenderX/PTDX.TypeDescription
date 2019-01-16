namespace PTDX.TypeDescription
{
    public class TypeDescriptor
    {
        private readonly TypeCategory _category;
        private readonly ITypeDescriptionContext _typeDescriptionContext;

        public TypeDescriptor(TypeCategory category, ITypeDescriptionContext typeDescriptionContext = null)
        {
            _category = category;
            _typeDescriptionContext = typeDescriptionContext;
        }

        public TypeDescription Describe<T>(string description)
        {
            var entityType = typeof(T);

            var  typeDescription = new TypeDescription(entityType.FullName, description, _category);

            _typeDescriptionContext?.Add<T>(description, _category);

            return typeDescription;
        }
    }
}