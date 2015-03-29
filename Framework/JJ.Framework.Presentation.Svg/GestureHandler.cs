using JJ.Framework.Presentation.Svg.EventArgs;
using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Presentation.Svg.Infos;
using JJ.Framework.Presentation.Svg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using JJ.Framework.Common;

namespace JJ.Framework.Presentation.Svg
{
    internal class GestureHandler
    {
        private IList<IGesture> _gestures;
        private Element _rootElement;

        public event EventHandler<GestureEventArgs> OnGesture;

        public GestureHandler(Element rootElement, IList<IGesture> gestures)
        {
            if (rootElement == null) throw new NullException(() => rootElement);
            if (gestures == null) throw new NullException(() => gestures);

            _rootElement = rootElement;
            _gestures = gestures;
        }

        public void MouseDown(MouseDownInfo info)
        {
            if (OnGesture == null)
            {
                return;
            }

            // ZOrdered list should not be recalculated for each gesture.
            IList<Element> zOrdereredElements = _rootElement.Children
                                                                .UnionRecursive(x => x.Children)
                                                                .OrderBy(x => x.CalculatedZIndex).ToArray();

            Element hitElement = HitTester.TryGetHitElement(zOrdereredElements, info.X, info.Y);
            if (hitElement != null)
            {
                OnGesture(hitElement, new GestureEventArgs(null, hitElement));
            }

            // Event bubbling
            Element parent = hitElement.Parent;
            while (parent != null && parent.EventBubblingEnabled)
            {
                OnGesture(hitElement, new GestureEventArgs(null, hitElement));

                parent = parent.Parent;
            }
        }

        public void MouseMove(MouseMoveInfo info)
        {
            throw new NotImplementedException();
        }

        public void MouseUp(MouseUpInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
