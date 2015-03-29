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
    public class SvgModel
    {
        public SvgModel()
        {
            Elements = new SvgModelElements(model: this);

            _rootRectangle = new Rectangle();
            _rootRectangle.SvgModel = this;
        }

        private Rectangle _rootRectangle;
        [DebuggerHidden]
        public Rectangle RootRectangle
        {
            get { return _rootRectangle; }
        }

        public SvgModelElements Elements { get; private set; }

        public Point CreatePoint(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);

            var child = new Point();
            child.SvgModel = this;

            parent.Children.Add(child);
            child.Parent = parent;

            return child;
        }

        public Line CreateLine(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);

            var child = new Line();
            child.SvgModel = this;

            parent.Children.Add(child);
            child.Parent = parent;
            
            return child;
        }

        public Rectangle CreateRectangle(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);

            var child = new Rectangle();
            child.SvgModel = this;

            parent.Children.Add(child);
            child.Parent = parent;
            
            return child;
        }

        public Label CreateLabel(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);

            var child = new Label();
            child.SvgModel = this;
            
            parent.Children.Add(child);
            child.Parent = parent;
            
            return child;
        }

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
    }
}
