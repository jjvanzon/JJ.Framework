using System;
using JJ.Framework.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.VectorGraphics.EventArg
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
