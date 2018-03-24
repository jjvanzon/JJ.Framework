using System;
using System.Collections.Generic;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
	public class DropGesture : GestureBase
	{
		public event EventHandler<DroppedEventArgs> Dropped;

		private readonly IList<DragGesture> _dragGestures;

		public DropGesture(params DragGesture[] dragGestures)
			: this((IList<DragGesture>)dragGestures)
		{ }

		public DropGesture(IList<DragGesture> dragGestures)
		{
			_dragGestures = dragGestures ?? throw new NullException(() => dragGestures);
		}

		protected override void HandleMouseUp(object sender, MouseEventArgs e)
		{
			foreach (DragGesture dragGesture in _dragGestures)
			{
				if (dragGesture.DraggedElement != null)
				{
					if (e.Element != null)
					{
						Dropped?.Invoke(sender, new DroppedEventArgs(dragGesture.DraggedElement, e.Element));
					}

					dragGesture.DraggedElement = null;
				}
			}
		}
	}
}
