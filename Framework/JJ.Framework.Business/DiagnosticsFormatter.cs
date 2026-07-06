// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
// ReSharper disable DuplicatedSequentialIfBodies

namespace JJ.Framework.Business.Legacy;

internal static class DiagnosticsFormatter
{
    public static string Stringify(IResult? result)
    {
        var formattedType = FormatType(result);

        if (result == null) return $"{formattedType}=<null>";

        string formattedSuccess = FormatSuccess(result.Success);
        string formattedMessages = FormatMessages(result.Messages);

        if (IsNullOrWhiteSpace(formattedMessages))
        {
            return $"{formattedType} {formattedSuccess}";
        }
        else
        {
            return $"{formattedType} {formattedSuccess}: {formattedMessages}";
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

        var noMessagesText = "Result failed without messages.";

        if (result.Messages == null)
        {
            return noMessagesText;
        }

        if (result.Messages.Count == 0)
        {
            return noMessagesText;
        }

        string formattedMessages = FormatMessages(result.Messages);

        if (IsNullOrWhiteSpace(formattedMessages))
        {
            return noMessagesText;
        }

        if (formattedMessages == "<null>")
        {
            return noMessagesText;
        }

        return formattedMessages;
    }
    
    private static string FormatType(IResult? result)
    {
        Type type = result?.GetType() ?? typeof(IResult);
        return $"{{{type.Name}}}";
    }

    private static string FormatSuccess(bool success) => success ? "Success" : "Failed";

    private static string FormatMessages(IList<string>? messages)
    {
        return Join(", ", (messages ?? []).Select(FormatMessage));
    }

    private static string FormatMessage(string? message) => message ?? "<null>";
}