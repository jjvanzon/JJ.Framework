using JJ.Framework.Presentation.VectorGraphics.EventArg;
using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    /// <summary> For when you need to send primitive gestures to the diagram. </summary>
    public class DiagramGestureHandling
    {
        private Diagram _diagram;

        internal DiagramGestureHandling(Diagram diagram)
        {
            if (diagram == null) throw new NullException(() => diagram);

            _diagram = diagram;
            _gestureHandler = new GestureHandler(_diagram);
        }

        private readonly GestureHandler _gestureHandler;

        public void HandleMouseDown(MouseEventArgs e)
        {
            _gestureHandler.HandleMouseDown(e);

            _diagram.Recalculate();
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            _gestureHandler.HandleMouseMove(e);

            //if (e.MouseButtonEnum != MouseButtonEnum.None)
            {
                _diagram.Recalculate();
            }
        }

        public void HandleMouseUp(MouseEventArgs e)
        {
            _gestureHandler.HandleMouseUp(e);

            _diagram.Recalculate();
        }

        public void HandleKeyDown(KeyEventArgs keyEventArgs)
        {
            _gestureHandler.HandleKeyDown(keyEventArgs);
        }

        public void HandleKeyUp(KeyEventArgs keyEventArgs)
        {
            _gestureHandler.HandleKeyUp(keyEventArgs);
        }
    }
}
