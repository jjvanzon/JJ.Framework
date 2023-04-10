using System;
using JJ.Framework.VectorGraphics.EventArg;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Gestures
{
    /// <inheritdoc />
    public class MouseLeaveGesture : GestureBase
    {
        /// <summary> Would go off when a mouse cursor would leave an element. </summary>
        public event EventHandler<MouseEventArgs> MouseLeave;

        private Diagram _diagram;
        private readonly MouseMoveGesture _diagramMouseMoveGesture;
        private Element _previousSender;

        /// <inheritdoc cref="MouseLeaveGesture" />
        public MouseLeaveGesture()
        {
            _diagramMouseMoveGesture = new MouseMoveGesture();
            _diagramMouseMoveGesture.MouseMove += DiagramMouseMoveGesture_MouseMove;
        }

        /// <summary>
        /// Attempts to clean up a diagram-bound mouse move gesture,
        /// that would be created on-they-fly by this gesture.
        /// </summary>
        ~MouseLeaveGesture()
        {
            if (_diagram == null) return;
            if (_diagramMouseMoveGesture == null) return;

            _diagramMouseMoveGesture.MouseMove -= DiagramMouseMoveGesture_MouseMove;
            if (_diagram.Gestures.Contains(_diagramMouseMoveGesture))
            {
                _diagram.Gestures.Remove(_diagramMouseMoveGesture);
            }
        }
        
        /// <summary>
        /// Handling element-bound move move events, the element moved over might be tracked (the sender).
        /// Also, the diagram field would be set (lazily upon first mouse move).
        /// The diagram might then be extended with a mouse move gesture, created on-the-fly by this gesture.
        /// </summary>
        /// <param name="sender"> Might be the element moved over. </param>
        /// <param name="e"></param>
        protected override void HandleMouseMove(object sender, MouseEventArgs e)
        {
            if (MouseLeave == null)
            {
                return;
            }

            // It would bind to the first diagram encountered,
            // because it might be bothersome to burden to the programmer
            // with passing a Diagram to the constructor.
            if (_diagram == null)
            {
                if (e.Element.Diagram != null)
                {
                    _diagram = e.Element.Diagram;
                    _diagram.Gestures.Add(_diagramMouseMoveGesture);
                }
            }

            _previousSender = sender as Element;
        }

        /// <summary>
        /// A diagram-bound mouse move event might be handled.
        /// It would aim to track if the element currently moved over is still the same.
        /// If a different element would be moved over, a MouseLeave event might be triggered
        /// upon the original element.
        /// </summary>
        /// <param name="sender">Would be the element moved over.</param>
        private void DiagramMouseMoveGesture_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender != _previousSender)
            {
                var e2 = new MouseEventArgs(_previousSender, e.XInPixels, e.YInPixels, e.MouseButtonEnum);
                MouseLeave?.Invoke(sender, e2);

                _previousSender = sender as Element;
            }
        }
    }
}