using System;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.EventArg
{
	public class ElementEventArgs : EventArgs
	{
		public Element Element { get; }

		public ElementEventArgs(Element element)
		{
			Element = element ?? throw new NullException(() => element);
		}
	}
}
