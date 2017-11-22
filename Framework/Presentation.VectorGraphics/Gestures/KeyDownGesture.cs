using JJ.Framework.Presentation.VectorGraphics.EventArg;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
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
