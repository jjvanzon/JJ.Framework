using System;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
	// ReSharper disable once UnusedMember.Global
	public class KeyUpGesture : GestureBase
	{
		// ReSharper disable once EventNeverSubscribedTo.Global
		public event EventHandler<KeyEventArgs> KeyUp;

		protected override void HandleKeyUp(object sender, KeyEventArgs e) => KeyUp?.Invoke(sender, e);
	}
}
