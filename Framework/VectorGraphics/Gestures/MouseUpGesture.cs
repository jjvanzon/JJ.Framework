using System;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
	public class MouseUpGesture : GestureBase
	{
		public event EventHandler<MouseEventArgs> MouseUp;

		protected override void HandleMouseUp(object sender, MouseEventArgs e)
		{
			MouseUp?.Invoke(sender, e);
		}
	}
}
