using System.Collections.Generic;

namespace JJ.Framework.Business
{
	public interface IResult
	{
		bool Successful { get; set; }

		/// <summary> not nullable, auto-instantiated </summary>
		IList<string> Messages { get; set; }
	}
}
