using System;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
	public class MouseDownGesture : GestureBase
	{
		public event EventHandler<MouseEventArgs> MouseDown;

		protected override void HandleMouseDown(object sender, MouseEventArgs e)
		{
			MouseDown?.Invoke(sender, e);
		}
	}
}
