using System;

namespace JJ.Framework.Business.Helpers
{
    internal static class DebugHelper
    {
        internal static string GetDebuggerDisplay(Message message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            string debuggerDisplay = $"{{{nameof(Message)}}} {message.Key} - '{message.Text}'";
            return debuggerDisplay;
        }
    }
}
