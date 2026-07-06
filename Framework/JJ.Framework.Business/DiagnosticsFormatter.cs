// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace JJ.Framework.Business.Legacy;

internal static class DiagnosticsFormatter
{
    public static string DebuggerDisplay(IResult? result)
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

        var noMessagesText = FormatSuccess(result.Success) + " without message.";

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