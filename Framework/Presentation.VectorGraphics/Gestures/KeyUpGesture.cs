using System;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
	public class KeyUpGesture : GestureBase
	{
		public event EventHandler<KeyEventArgs> KeyUp;

		protected override void HandleKeyUp(object sender, EventArg.KeyEventArgs e)
		{
			KeyUp?.Invoke(sender, e);
		}
	}
}
