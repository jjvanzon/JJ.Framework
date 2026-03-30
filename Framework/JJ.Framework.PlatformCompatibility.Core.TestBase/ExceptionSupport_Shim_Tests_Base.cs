namespace JJ.Framework.PlatformCompatibility.Core.TestBase;

public class ExceptionSupport_Shim_Tests_Base
{
    public void Test_ExceptionSupport_PlatformStub()
    {
        const string? nullText = null;
        const string? emptyText = "";
        const string? spaceText = " \t \n ";
        ThrowsExceptionContaining<ArgumentNullException>(() => ThrowIfNull            (nullText ), "nullText",  "null");
        ThrowsExceptionContaining<ArgumentNullException>(() => ThrowIfNullOrWhiteSpace(nullText ), "nullText",  "null");
        ThrowsExceptionContaining<ArgumentException    >(() => ThrowIfNullOrWhiteSpace(emptyText), "emptyText", "empty");
        ThrowsExceptionContaining<ArgumentException    >(() => ThrowIfNullOrWhiteSpace(spaceText), "spaceText", "space");
    }
}