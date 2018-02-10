using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace JJ.Framework.Presentation
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public sealed class ActionInfo
	{
		public string PresenterName { get; set; }
		public string ActionName { get; set; }

		/// <summary> nullable </summary>
		public IList<ActionParameterInfo> Parameters { get; set; }

		/// <summary> nullable </summary>
		public ActionInfo ReturnAction { get; set; }

		[UsedImplicitly]
		private string DebuggerDisplay
		{
			get
			{
				var sb = new StringBuilder();

				sb.Append(PresenterName);
				sb.Append('.');
				sb.Append(ActionName);

				if (Parameters != null && Parameters.Count != 0)
				{
					sb.Append('(');
					foreach (ActionParameterInfo parameter in Parameters)
					{
						sb.Append(parameter.Name);
						sb.Append(": ");
						sb.Append(parameter.Value);
						if (parameter != Parameters.Last())
						{
							sb.Append(", ");
						}
					}
					sb.Append(')');
				}

				if (ReturnAction != null)
				{
					sb.Append(" (has ReturnAction)");
				}

				return sb.ToString();
			}
		}
	}
}
