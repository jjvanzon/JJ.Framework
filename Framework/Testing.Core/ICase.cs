namespace JJ.Framework.Testing.Core
{
    public interface ICase : ICaseProp
    {
        string             Name        { get; set; }
        string             Key         { get; }
        object[]           DynamicData { get; }
        bool               Strict      { get; set; }
        ICaseProp          MainProp    { get; }
        IList<ICaseProp>   Props       { get; }
        IList<object>      KeyElements { get; }
        /// <inheritdoc cref="_casetemplate" />
        ICollection<ICase> FromTemplate(ICollection<ICase> cases);
    }
}