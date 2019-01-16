namespace PTDX.TypeDescription
{
    /// <summary>
    /// Suggest to implement this interface with parameterless constructor,
    /// then you can use the buildin TypeDescriptionConfiguration,
    /// otherwise, you have to implement your own ITypeDescriptionConfiguration
    /// </summary>
    public interface ITypeDescriptionProvider
    {
        void SetDescriptions(ITypeDescriptionContext context);
    }
}