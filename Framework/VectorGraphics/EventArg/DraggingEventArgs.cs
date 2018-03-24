using System;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.EventArg
{
	public class DraggingEventArgs : EventArgs
	{
		public Element ElementBeingDragged { get; }
		public float X { get; }
		public float Y { get; }

		public DraggingEventArgs(Element elementBeingDragged, float x, float y)
		{
			ElementBeingDragged = elementBeingDragged ?? throw new NullException(() => elementBeingDragged);
			X = x;
			Y = y;
		}
	}
}
