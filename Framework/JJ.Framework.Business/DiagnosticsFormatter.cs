// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
// ReSharper disable DuplicatedSequentialIfBodies

namespace JJ.Framework.Business.Legacy;

internal static class DiagnosticsFormatter
{
    public static string DebuggerDisplay(IResult? result)
    {
        var typeName = GetTypeName(result);

        if (result == null) return $"{typeName}=<null>";

        return Stringify(result, typeName + " -");
    }

    public static string Stringify(IResult? result)
    {
        var typeName = GetTypeName(result);
        var formattedTypeName = '{' + typeName + '}';

        if (result == null) return $"{formattedTypeName}=<null>";

        return Stringify(result, formattedTypeName);
    }

    private static string Stringify(IResult result, string formattedTypeName)
    {
        string formattedSuccess = FormatSuccess(result.Success);
        string formattedMessages = FormatMessages(result.Messages);

        if (IsNullOrWhiteSpace(formattedMessages))
        {
            return $"{formattedTypeName} {formattedSuccess}";
        }
        else
        {
            return $"{formattedTypeName} {formattedSuccess}: {formattedMessages}";
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
    
    private static string GetTypeName(IResult? result)
    {
        Type type = result?.GetType() ?? typeof(IResult);
        return type.Name;
        //return $"{{{type.Name}}}";
    }

    private static string FormatSuccess(bool success) => success ? "Success" : "Failed";

    private static string FormatMessages(IList<string>? messages)
    {
        return Join(", ", (messages ?? []).Select(FormatMessage));
    }

    private static string FormatMessage(string? message) => message ?? "<null>";
}