using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Gestures
{
    public class DragDropGesture : IGesture
    {
        public event EventHandler<DragDropEventArgs> OnDragDrop;

        private Element _draggedElement;

        void IGesture.MouseDown(object sender, EventArg.MouseEventArgs e)
        {
            if (OnDragDrop == null)
            {
                return;
            }

            var element = sender as Element;
            if (element != null)
            {
                _draggedElement = element;
            }
        }

        void IGesture.MouseMove(object sender, EventArg.MouseEventArgs e)
        { }

        void IGesture.MouseUp(object sender, EventArg.MouseEventArgs e)
        {
            if (OnDragDrop == null || _draggedElement == null)
            {
                return;
            }

            var element = sender as Element;
            if (element != null)
            {
                OnDragDrop(_draggedElement, new DragDropEventArgs(_draggedElement, element));
            }
        }
    }
}