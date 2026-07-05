using static System.StringComparison;

namespace JJ.Framework.Business.Legacy;

internal static class DiagnosticsFormatter
{

    public static string DebuggerDisplay(IResult result)
    {
        if (result == null) throw new ArgumentNullException(nameof(result));

        var sb = new StringBuilder();


        var type = result.GetType();
        var typeName = type.Name;
        sb.Append($"{{{typeName}}}");

        if (result.Success)
        {
            sb.Append(" Success");
        }
        else
        {
            sb.Append(" Failed");
        }

        string formattedMessages = FormatMessages(result.Messages);
        if (!IsNullOrWhiteSpace(formattedMessages))
        {
            sb.Append($": {formattedMessages}");
        }

        return sb.ToString();
    }

    private static string FormatMessages(IList<string>? messages) 
        => Join(", ", (messages ?? [ ]).Select(x => x ?? "<null>"));
}