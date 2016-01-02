namespace JJ.Framework.Validation
{
    public interface IValidator
    {
        ValidationMessages ValidationMessages { get; }
        bool IsValid { get; }
        void Assert();
    }
}
