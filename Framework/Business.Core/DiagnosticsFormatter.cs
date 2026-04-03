// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract

namespace JJ.Framework.Business.Core;

internal static class DiagnosticsFormatter
{
    public static string DebuggerDisplay(IResult result)
    {
        if (result == null) throw new ArgumentNullException(nameof(result));

        var sb = new StringBuilder();

        sb.Append($"{{{result.GetType().Name}}}");

        if (result.Success)
        {
            sb.Append($" {nameof(result.Success)}");
        }
        else
        {
            sb.Append($" Not {nameof(result.Success)}");
        }

        if (result.Messages != null)
        {
            string formattedMessages = FormatMessages(result.Messages);
            if (!IsNullOrWhiteSpace(formattedMessages))
            {
                sb.Append($": {formattedMessages}");
            }
        }

        return sb.ToString();
    }

    private static string FormatMessages(IList<string> messages) 
        => Join(", ", (messages ?? [ ]).Select(x => x ?? "<null>"));
}