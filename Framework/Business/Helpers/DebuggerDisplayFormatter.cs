using JJ.Framework.Common;
using System;
using System.Text;

namespace JJ.Framework.Business.Helpers
{
    internal static class DebuggerDisplayFormatter
    {
        public static string GetDebuggerDisplay(Message message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            string debuggerDisplay = $"{{{nameof(Message)}}} {FormatMessage(message)}";
            return debuggerDisplay;
        }

        public static string GetDebuggerDisplay(Messages messages)
        {
            if (messages == null) throw new ArgumentNullException(nameof(messages));

            string debuggerDisplay = $"{{{nameof(Messages)}}} {FormatMessages(messages)}";
            return debuggerDisplay;
        }

        public static string GetDebuggerDisplay(IResult result)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));

            var sb = new StringBuilder();

            sb.Append($"{{{result.GetType().Name}}}");

            if (result.Successful)
            {
                sb.Append($" {nameof(result.Successful)}");
            }
            else
            {
                sb.Append($" Not {nameof(result.Successful)}");
            }

            if (result.Messages != null)
            {
                string formattedMessages = FormatMessages(result.Messages);
                if (!string.IsNullOrWhiteSpace(formattedMessages))
                {
                    sb.Append($": {formattedMessages}");
                }
            }

            return sb.ToString();
        }

        private static string FormatMessage(Message message) => $"{message.Key} - '{message.Text}'";

        private static string FormatMessages(Messages messages)
        {
            var sb = new StringBuilder();

            foreach (Message message in messages)
            {
                if (message != null)
                {
                    sb.Append($"{FormatMessage(message)}, ");
                }
                else
                {
                    sb.Append("<null>, ");
                }
            }

            string formattedMessages = sb.ToString().TrimEnd(", ");

            return formattedMessages;
        }
    }
}
