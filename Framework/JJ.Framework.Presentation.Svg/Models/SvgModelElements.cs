using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using JJ.Framework.Presentation.Svg.LinkTo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg
{
    public class SvgModelElements : IEnumerable<Element>
    {
        private SvgModel _model;

        private IList<Element> _list = new List<Element>();

        internal SvgModelElements(SvgModel model)
        {
            if (model == null) throw new NullException(() => model);
            _model = model;
        }

        public void Add(Element element)
        {
            if (element == null) throw new NullException(() => element);

            if (_list.Contains(element)) return;

            if (element.SvgModel != null)
            {
                if (element.SvgModel.Elements.Contains(element))
                {
                    element.SvgModel.Elements.Remove(element);
                }
            }

            _list.Add(element);

            element.SvgModel = _model;

            // Side-effect: When added to the model, it is added as a child of the root rectangle.
            if (element.Parent == null)
            {
                if (element != _model.RootRectangle)
                {
                    element.Parent = _model.RootRectangle;
                }
            }
        }

        public void Remove(Element element)
        {
            if (element == null) throw new NullException(() => element);

            if (!_list.Contains(element)) return;

            _list.Remove(element);

            element.SvgModel = null;

            //element.UnlinkSvgModel();
        }

        [DebuggerHidden]
        internal bool Contains(Element child)
        {
            return _list.Contains(child);
        }

        // IEnumerable

        [DebuggerHidden]
        public IEnumerator<Element> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        [DebuggerHidden]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
