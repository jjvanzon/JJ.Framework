namespace JJ.Framework.Business.Legacy;

/// <inheritdoc cref="_iresult"/>
public interface IResult
{
    /// <inheritdoc cref="_success"/>
    bool Success { get; set; }
    /// <inheritdoc cref="_messages"/>
    IList<string> Messages { get; set; }
}