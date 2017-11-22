using System;
using System.Diagnostics;
using JJ.Framework.Presentation.VectorGraphics.EventArg;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Presentation.VectorGraphics.Gestures
{
	public class DoubleClickGesture : GestureBase
	{
		public event EventHandler<ElementEventArgs> DoubleClick;

		private readonly int _doubleClickSpeedInMilliseconds;
		/// <summary>
		/// Do realize that when you start scaling things, 
		/// there is no 1-to-1 mapping between X and Y coordinates and pixels anymore, 
		/// so you'd have to adapt this class to that.. 
		/// </summary>
		private readonly int _doubleClickDeltaInPixels;
		private readonly Stopwatch _stopWatch = new Stopwatch();

		private bool _isFirstMouseDown = true;
		private MouseEventArgs _firstMouseDownEventArgs;

		/// <summary>
		/// To create a DoubleClickGesture that automatically takes on the Windows settings as double click speed and delta,
		/// use either WinFormsVectorGraphicsHelper.CreateDoubleClickGesture or DiagramControl.CreateDoubleClickGesture instead.
		/// </summary>
		public DoubleClickGesture(int doubleClickSpeedInMilliseconds, int doubleClickDeltaInPixels)
		{
			if (doubleClickSpeedInMilliseconds < 1) throw new LessThanException(() => doubleClickSpeedInMilliseconds, 1);
			if (doubleClickDeltaInPixels < 0) throw new LessThanException(() => doubleClickDeltaInPixels, 0);

			_doubleClickSpeedInMilliseconds = doubleClickSpeedInMilliseconds;
			_doubleClickDeltaInPixels = doubleClickDeltaInPixels;
		}

		protected override bool MouseCaptureRequired => false;

		protected override void HandleMouseDown(object sender, MouseEventArgs e)
		{
			if (_isFirstMouseDown)
			{
				HandleFirstMouseDown(e);
			}
			else
			{
				bool secondMouseDownCompletedTheDoubleClick = HandleSecondMouseDown(sender, e);
				if (!secondMouseDownCompletedTheDoubleClick)
				{
					// If e.g. the time expired, it should be considered the first mouse down again.
					HandleFirstMouseDown(e);
				}
			}
		}

		private void HandleFirstMouseDown(MouseEventArgs e)
		{
			_stopWatch.Reset();
			_stopWatch.Start();

			// Flip boolean in preparation of next click.
			_isFirstMouseDown = false;

			_firstMouseDownEventArgs = e;
		}

		private bool HandleSecondMouseDown(object sender, MouseEventArgs e)
		{
			if (DoubleClick == null)
			{
				return true;
			}

			_stopWatch.Stop();

			// Flip boolean in preparation of next click.
			_isFirstMouseDown = true;
 
			if (_firstMouseDownEventArgs == null)
			{
				return false;
			}

			bool isSameElement = e.Element == _firstMouseDownEventArgs.Element;
			if (!isSameElement)
			{
				return false;
			}

			bool deltaIsInRange = DeltaIsInRange(_firstMouseDownEventArgs, e);
			if (!deltaIsInRange)
			{
				return false;
			}

			bool speedIsInRange = _stopWatch.ElapsedMilliseconds <= _doubleClickSpeedInMilliseconds;
			if (!speedIsInRange)
			{
				return false;
			}

			var e2 = new ElementEventArgs(e.Element);
			DoubleClick?.Invoke(sender, e2);
			return true;
		}

		private bool DeltaIsInRange(MouseEventArgs mouseDownEventArgs1, MouseEventArgs mouseDownEventArgs2)
		{
			float deltaX = mouseDownEventArgs2.XInPixels - mouseDownEventArgs1.XInPixels;

			if (deltaX > _doubleClickDeltaInPixels)
			{
				return false;
			}

			if (-deltaX > _doubleClickDeltaInPixels) // Probably faster than Math.Abs.
			{
				return false;
			}

			float deltaY = Math.Abs(mouseDownEventArgs2.YInPixels - mouseDownEventArgs1.YInPixels);

			if (deltaY > _doubleClickDeltaInPixels)
			{
				return false;
			}

			if (-deltaY > _doubleClickDeltaInPixels) // Probably faster than Math.Abs.
			{
				return false;
			}

			return true;
		}
	}
}
