using System.Collections.Generic;
using JetBrains.Annotations;

namespace JJ.Framework.Business
{
	[PublicAPI]
	public interface IResult
	{
		bool Successful { get; set; }

		/// <summary> not nullable, auto-instantiated </summary>
		IList<string> Messages { get; set; }
	}
}
