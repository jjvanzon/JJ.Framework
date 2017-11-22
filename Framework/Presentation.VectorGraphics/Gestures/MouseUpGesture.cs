using JJ.Framework.Presentation.VectorGraphics.EventArg;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
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
