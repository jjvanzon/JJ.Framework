// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
// ReSharper disable DuplicatedSequentialIfBodies

namespace JJ.Framework.Business;

internal static class DiagnosticsFormatter
{
    public static string DebuggerDisplay(IResult? result)
    {
        var formattedTypeName = FormatTypeName(result);

        if (result == null)
        {
            return $"{formattedTypeName}=<null>";
        }

        return $"{formattedTypeName} - {StringifyWithoutType(result)}";
    }

    public static string Stringify(IResult? result)
    {
        var formattedTypeName = FormatTypeName('{', result, '}');

        if (result == null)
        {
            return $"{formattedTypeName}=<null>";
        }

        return $"{formattedTypeName} {StringifyWithoutType(result)}";
    }

    private static string StringifyWithoutType(IResult result)
    {
        if (result == null) throw new Exception("Internal error. Result was null.");

        string formattedSuccess = FormatSuccess(result.Success);
        string formattedMessages = FormatMessages(result, "<no messages>");

        if (IsNullOrWhiteSpace(formattedMessages))
        {
            return $"{formattedSuccess}";
        }
        else
        {
            return $"{formattedSuccess}: {formattedMessages}";
        }
    }

    public static string ExceptionMessage(IResult? result)
    {
        if (result == null) 
        {
            return "Result=<null>";
        }

        const string successTrueMessage =
            "Internal error. " +
            "Attempted to throw an exception asserting a Successful result. " +
            "Only failed results should have thrown an exception.";
        if (result.Success) throw new Exception(successTrueMessage);

        return FormatMessages(result, "Result failed without messages.");
    }
    
    // Format Elements

    private static string FormatTypeName(char prefix, IResult? result, char suffix) 
        => prefix + FormatTypeName(result) + suffix;

    private static string FormatTypeName(IResult? result)
    {
        Type type = result?.GetType() ?? typeof(IResult);
        return type.Name;
    }

    private static string FormatSuccess(bool success) => success ? "Success" : "Failed";

    private static string FormatMessages(IResult result, string failedWithoutMessagesText = "")
    {
        if (result == null) throw new Exception("Internal error. Result was null.");

        IList<string>? messages = result.Messages;
        string fallbackText = result.Success ? "" : failedWithoutMessagesText;

        if (messages == null)
        {
            return fallbackText;
        }

        if (messages.Count == 0)
        {
            return fallbackText;
        }

        var formattedMessages = Join(", ", messages.Select(FormatMessage));

        if (IsNullOrWhiteSpace(formattedMessages))
        {
            return fallbackText;
        }

        if (formattedMessages == "<null>")
        {
            return fallbackText;
        }

        return formattedMessages;
    }

    private static string FormatMessage(string? message) => message ?? "<null>";
}