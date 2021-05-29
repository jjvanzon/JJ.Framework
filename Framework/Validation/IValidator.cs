namespace JJ.Framework.Validation
{
    public interface IValidator
    {
        ValidationMessages Messages { get; }
        bool IsValid { get; }
        void Assert();
    }
}
