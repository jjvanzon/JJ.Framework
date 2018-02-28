using System;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Validation
{
	internal static class DebugHelper
	{
		internal static string GetDebuggerDisplay(ValidationMessages validationMessages)
		{
			if (validationMessages == null) throw new NullException(() => validationMessages);

			return String.Join(Environment.NewLine, validationMessages);
		}
	}
}
