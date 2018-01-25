using System;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
	public class KeyDownGesture : GestureBase
	{
		public event EventHandler<KeyEventArgs> KeyDown;

		protected override void HandleKeyDown(object sender, EventArg.KeyEventArgs e)
		{
			KeyDown?.Invoke(sender, e);
		}
	}
}
