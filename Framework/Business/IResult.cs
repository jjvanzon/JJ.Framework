namespace JJ.Framework.Business;

/// <inheritdoc cref="_iresult"/>
public interface IResult
{
    /// <inheritdoc cref="_success"/>
    bool Success { get; set; }
    /// <inheritdoc cref="_messages"/>
    IList<string> Messages { get; set; }
    /// <inheritdoc cref="_assert" />
    void Assert();
    
    /// <inheritdoc cref="_successful" />
    [Obsolete("Use Success instead.")]
    bool Successful { get; set; }
}