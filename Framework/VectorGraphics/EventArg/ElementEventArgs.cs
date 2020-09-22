using System;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.EventArg
{
	/// <summary>
	/// This EventArgs class might be fit for events
	/// that can make due with just passing an Element along as the EventArgs.
	/// The Element here would not be nullable.
	/// </summary>
	public class ElementEventArgs : EventArgs
	{
		/// <summary>
		/// The element that might be relevant to the event. Not nullable.
		/// </summary>
		public Element Element { get; }

		/// <inheritdoc cref="ElementEventArgs"/>>
		/// <param name="element"> See Element property. </param>
		public ElementEventArgs(Element element) => Element = element ?? throw new NullException(() => element);
	}
}
