namespace PTDX.TypeDescription
{
    public class TypeCategory
    {
        public TypeCategory(string name, string description = null)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }

        public string Description { get; }
    }
}