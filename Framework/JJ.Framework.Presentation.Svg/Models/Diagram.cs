using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.Svg.Visitors;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg
{
    public class Diagram
    {
        public Diagram()
        {
            Elements = new DiagramElements(diagram: this);

            _rootRectangle = new Rectangle();
            _rootRectangle.Diagram = this;
        }

        private Rectangle _rootRectangle;
        /// <summary>
        /// read-only
        /// </summary>
        [DebuggerHidden]
        public Rectangle RootRectangle
        {
            get { return _rootRectangle; }
        }

        public DiagramElements Elements { get; private set; }

        public void Recalculate()
        {
             var visitor = new CalculationVisitor();
             _elementsOrderByZIndex = visitor.Execute(_rootRectangle);
        }

        private IList<Element> _elementsOrderByZIndex = new Element[0];

        public IEnumerable<Element> EnumerateElementsByZIndex()
        {
            for (int i = 0; i < _elementsOrderByZIndex.Count; i++)
            {
                yield return _elementsOrderByZIndex[i];
            }
        }

        public Point CreatePoint(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);

            var child = new Point();
            child.Diagram = this;

            parent.Children.Add(child);
            child.Parent = parent;

            return child;
        }

        public Line CreateLine(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);

            var child = new Line();
            child.Diagram = this;

            parent.Children.Add(child);
            child.Parent = parent;

            return child;
        }

        public Rectangle CreateRectangle(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);

            var child = new Rectangle();
            child.Diagram = this;

            parent.Children.Add(child);
            child.Parent = parent;

            return child;
        }

        public Label CreateLabel(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);

            var child = new Label();
            child.Diagram = this;

            parent.Children.Add(child);
            child.Parent = parent;

            return child;
        }
    }
}
