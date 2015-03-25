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

namespace JJ.Framework.Presentation.Svg
{
    public class GestureHandler
    {
        private IList<IGesture> _gestures;
        private ElementBase _rootElement;

        public event EventHandler<GestureEventArgs> OnGesture;

        public GestureHandler(ElementBase rootElement, IList<IGesture> gestures)
        {
            if (rootElement == null) throw new NullException(() => rootElement);
            if (gestures == null) throw new NullException(() => gestures);

            _rootElement = rootElement;
            _gestures = gestures;
        }

        public void MouseDown(MouseDownInfo info)
        {
            ElementBase hitElement = HitTester.TryGetHitElement(_rootElement, info.X, info.Y);
            if (hitElement != null)
            {
                if (OnGesture != null)
                {
                    OnGesture(hitElement, new GestureEventArgs(null, hitElement));
                }
            }

            // TODO: I do not have a Parent property!
            //if (hitElement.EventBubblingEnabled)
            //{
            //    hitElement.Parent
            //}
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
