using System;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Presentation.VectorGraphics.EventArg;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    /// <summary> Explicit interface for when you need to send primitive gestures to the diagram. </summary>
    public interface IDiagramGestureHandling
    {
        void HandleMouseDown(MouseEventArgs e);
        void HandleMouseMove(MouseEventArgs e);
        void HandleMouseUp(MouseEventArgs e);
        void HandleKeyDown(KeyEventArgs keyEventArgs);
        void HandleKeyUp(KeyEventArgs keyEventArgs);
    }
}
