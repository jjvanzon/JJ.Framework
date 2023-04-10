using System;
using System.Diagnostics;
using JJ.Framework.Exceptions.Comparative;
using JJ.Framework.VectorGraphics.EventArg;

namespace JJ.Framework.VectorGraphics.Gestures
{
    /// <inheritdoc />
    public class DoubleClickGesture : GestureBase
    {
        /// <summary> Goes off when a user has double clicked an element. </summary>
        public event EventHandler<ElementEventArgs> DoubleClick;

        private readonly int _doubleClickSpeedInMilliseconds;

        /// <summary>
        /// When things start scaling, there might not be a 1-to-1 mapping between X and Y
        /// coordinates and pixels anymore. Perhaps this class then might need changes
        /// to keep it practically usable.
        /// </summary>
        private readonly int _doubleClickDeltaInPixels;

        private readonly Stopwatch _stopWatch = new Stopwatch();

        private bool _isFirstMouseDown = true;
        private MouseEventArgs _firstMouseDownEventArgs;

        /// <summary>
        /// To create a DoubleClickGesture that automatically
        /// takes on the Windows settings as double click speed and delta,
        /// WinFormsVectorGraphicsHelper.CreateDoubleClickGesture or
        /// DiagramControl.CreateDoubleClickGesture might be used.
        /// </summary>
        public DoubleClickGesture(int doubleClickSpeedInMilliseconds, int doubleClickDeltaInPixels)
        {
            if (doubleClickSpeedInMilliseconds < 1) throw new LessThanException(() => doubleClickSpeedInMilliseconds, 1);
            if (doubleClickDeltaInPixels < 0) throw new LessThanException(() => doubleClickDeltaInPixels, 0);

            _doubleClickSpeedInMilliseconds = doubleClickSpeedInMilliseconds;
            _doubleClickDeltaInPixels = doubleClickDeltaInPixels;
        }

        /// <inheritdoc />
        protected override bool MouseCaptureRequired => false;

        /// <summary>
        /// Would evaluate the first mouse down and the second mouse down.
        /// Evaluating whether it is an actual double click might be tricky.
        /// There would be a time-out value upon which a 'second' click might become
        /// a 'first' click again, involving a stop watch,
        /// it should be on the same element and
        /// the coordinates of the two clicked would be within a certain distance range.
        /// It might involve some fine-tuned flipping the Boolean _isFirstMouseDown
        /// and starting, stopping and resetting the Stopwatch,
        /// which might be trickiness and error prone.
        /// </summary>
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

        /// <summary>
        /// Would handle the first mouse down,
        /// involving for instance starting a stop watch timer anew,
        /// and remembering info about the first mouse down,
        /// to be evaluated later (upon the second click).
        /// </summary>
        private void HandleFirstMouseDown(MouseEventArgs e)
        {
            _stopWatch.Reset();
            _stopWatch.Start();

            // Flip boolean in preparation of next click.
            _isFirstMouseDown = false;

            _firstMouseDownEventArgs = e;
        }

        /// <summary>
        /// Would handle the second mouse down,
        /// which may for instance involve stopping a stop watch, setting _isFirstMouseDown to false
        /// and evaluating if the two clicks are 'compatible' enough to be considered a double click.
        /// </summary>
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
