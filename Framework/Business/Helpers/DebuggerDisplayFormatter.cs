using JJ.Framework.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JJ.Framework.Business.Helpers
{
	internal static class DebuggerDisplayFormatter
	{
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

		private static string FormatMessages(IList<string> messages)
		{
			var sb = new StringBuilder();

			foreach (string message in messages)
			{
				if (message != null)
				{
					sb.Append($"{message}, ");
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
