using System;
using JJ.Framework.Exceptions;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.EventArg
{
	public class DroppedEventArgs : EventArgs
	{
		public Element DraggedElement { get; }
		public Element DroppedOnElement { get; }

		public DroppedEventArgs(Element draggedElement, Element droppedOnElement)
		{
			DraggedElement = draggedElement ?? throw new NullException(() => draggedElement);
			DroppedOnElement = droppedOnElement ?? throw new NullException(() => droppedOnElement);
		}
	}
}
