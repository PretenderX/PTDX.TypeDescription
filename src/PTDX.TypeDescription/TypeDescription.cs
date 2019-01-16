namespace PTDX.TypeDescription
{
    public class TypeDescription
    {
        public TypeDescription(string fullName, string description, TypeCategory category)
        {
            FullName = fullName;
            Description = description;
            Category = category;
        }

        public TypeCategory Category { get; private set; }

        public string FullName { get; private set; }

        public string Description { get; private set; }
    }
}