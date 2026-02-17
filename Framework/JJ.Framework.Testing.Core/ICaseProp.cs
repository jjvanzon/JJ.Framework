namespace JJ.Framework.Testing.Core
{
    public interface ICaseProp
    {
        void CloneFrom(ICaseProp obj);
        string Descriptor { get; }
    }
}
