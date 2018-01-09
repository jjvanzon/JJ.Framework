using System;
using JJ.Framework.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.VectorGraphics.EventArg
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
