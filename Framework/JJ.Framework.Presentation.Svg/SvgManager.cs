using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.Svg.Visitors;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg
{
    public class SvgManager
    {
        private Rectangle _rootRectangle = new Rectangle();
        public Rectangle RootRectangle
        {
            get { return _rootRectangle; }
        }

        private IList<ElementBase> _elementsOrderByZIndex = new ElementBase[0];

        public Point CreatePoint(ElementBase parent)
        {
            if (parent == null) throw new NullException(() => parent);

            var child = new Point();
            parent.Children.Add(child);
            child.Parent = parent;
            return child;
        }

        public Line CreateLine(ElementBase parent)
        {
            if (parent == null) throw new NullException(() => parent);

            var child = new Line();
            parent.Children.Add(child);
            child.Parent = parent;
            return child;
        }

        public Rectangle CreateRectangle(ElementBase parent)
        {
            if (parent == null) throw new NullException(() => parent);

            var child = new Rectangle();
            parent.Children.Add(child);
            child.Parent = parent;
            return child;
        }

        public Label CreateLabel(ElementBase parent)
        {
            if (parent == null) throw new NullException(() => parent);

            var child = new Label();
            parent.Children.Add(child);
            child.Parent = parent;
            return child;
        }

        public void Recalculate()
        {
             var visitor = new CalculationVisitor();
             _elementsOrderByZIndex = visitor.Execute(_rootRectangle);
        }

        public IEnumerable<ElementBase> EnumerateElementsByZIndex()
        {
            for (int i = 0; i < _elementsOrderByZIndex.Count; i++)
            {
                yield return _elementsOrderByZIndex[i];
            }
        }
    }
}
