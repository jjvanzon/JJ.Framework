namespace JJ.Framework.PlatformCompatibility.Core.TestBase;

public class ExceptionSupport_TestBase
{
    private const string? NullText = null;
    private const string? EmptyText = "";
    private const string? SpaceText = " \t \n ";
    private const string? FilledText = "Hi!";
    
    public void Test_ThrowIfNull()
    {
        Throws<ArgumentNullException>(() => ThrowIfNull(NullText), "NullText", "null");
        ThrowIfNull(EmptyText);
        ThrowIfNull(SpaceText);
        ThrowIfNull(FilledText);
    }

    public void Test_ThrowIfNullOrWhiteSpace()
    {
        Throws<ArgumentNullException>(() => ThrowIfNullOrWhiteSpace(NullText ), "NullText",  "null");
        Throws<ArgumentException    >(() => ThrowIfNullOrWhiteSpace(EmptyText), "EmptyText", "empty");
        Throws<ArgumentException    >(() => ThrowIfNullOrWhiteSpace(SpaceText), "SpaceText", "space");
        ThrowIfNullOrWhiteSpace(FilledText);
    }
}