namespace JJ.Framework.Business.Legacy.Tests.Helpers;

internal class ResultBaseAccessor(ResultBase result)
{
    private readonly Accessor _accessor = new(result, typeof(ResultBase));

    public string _messages 
    { 
        get => (string)_accessor.GetFieldValue(nameof(_messages));
        set => _accessor.SetFieldValue(nameof(_messages), value);
    }

    public string DebuggerDisplay
        => (string)_accessor.GetPropertyValue(nameof(DebuggerDisplay));
}
