// ReSharper disable ExplicitCallerInfoArgument
// ReSharper disable RedundantArgumentDefaultValue

namespace JJ.Framework.Business.Legacy.Tests.Helpers;

internal class ResultBaseAccessor(ResultBase result)
{
    private readonly Accessor _accessor = new(result, typeof(ResultBase));

    private const string MESSAGES_FIELD_NAME = "<Messages>k__BackingField";

    public string _messages 
    { 
        get => (string)_accessor.GetFieldValue(MESSAGES_FIELD_NAME);
        set => _accessor.SetFieldValue(MESSAGES_FIELD_NAME, (object)value);
    }

    public string DebuggerDisplay
        => (string)_accessor.GetPropertyValue(nameof(DebuggerDisplay));
}
