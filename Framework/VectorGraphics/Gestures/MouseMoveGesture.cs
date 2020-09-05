using System;
using JJ.Framework.VectorGraphics.EventArg;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace JJ.Framework.VectorGraphics.Gestures
{
	/// <summary>
	/// It was observed that WinForms may send a mouse move event,
	/// even when the mouse was not moved, in case of a move up.
	/// This gesture would aim to block that and only send
	/// a mouse move event when a user actually moved the mouse.
	/// See also: GestureBase for explanations for how gestures would work in this API in general.
	/// </summary>
	public class MouseMoveGesture : GestureBase
	{
		/// <inheritdoc cref="MouseMoveGesture" />
		public event EventHandler<MouseEventArgs> MouseMove;

		private float _previousXInPixels;
		private float _previousYInPixels;

		/// <summary> Would track the pointer's X and Y coordinates upon mouse down. </summary>
		protected override void HandleMouseDown(object sender, MouseEventArgs e)
		{
			_previousXInPixels = e.XInPixels;
			_previousYInPixels = e.YInPixels;
		}

		/// <summary>
		/// Would track the pointer's X and Y coordinates upon mouse move.
		/// Aims to only raise the mouse move event if coordinates ever changed.
		/// </summary>
		protected override void HandleMouseMove(object sender, MouseEventArgs e)
		{
			if (MouseMove == null)
			{
				return;
			}

			if (_previousXInPixels != e.XInPixels ||
				_previousYInPixels != e.YInPixels)
			{
				MouseMove(sender, e);
			}

			_previousXInPixels = e.XInPixels;
			_previousYInPixels = e.YInPixels;
		}
	}
}
