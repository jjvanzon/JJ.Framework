// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract

namespace JJ.Framework.Business.Legacy;

internal static class DiagnosticsFormatter
{
    public static string DebuggerDisplay(IResult? result)
    {
        Type type = result?.GetType() ?? typeof(IResult);
        return $"{{{type.Name}}} {FormatResult(result)}";
    }

    public static string ExceptionMessage(IResult result) => FormatResult(result);

    public static string FormatResult(IResult? result)
    {
        if (result == null) return "Result=<null>";

        string formattedSuccess = FormatSuccess(result.Success);
        string formattedMessages = FormatMessages(result.Messages);

        if (string.IsNullOrWhiteSpace(formattedMessages))
        {
            return formattedSuccess;
        }

        return formattedSuccess + ": " + formattedMessages;
    }

    private static string FormatSuccess(bool success) => success ? "Success" : "Failed";

    private static string FormatMessages(IList<string>? messages)
    {
        return Join(", ", (messages ?? []).Select(FormatMessage));
    }

    private static string FormatMessage(string? message) => message ?? "<null>";
}