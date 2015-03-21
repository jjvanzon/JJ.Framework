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

namespace JJ.Framework.Presentation.Svg
{
    public class GestureHandler
    {
        private IList<IGesture> _gestures;

        public event EventHandler<GestureEventArgs> OnGesture;

        // TODO: Some sort of wrapper model instead of a bunch of collections?
        public GestureHandler(
            IList<Rectangle> rectangles, IList<Line> lines, IList<Point> points, 
            IList<IGesture> gestures)
        {
            _gestures = gestures;

            throw new NotImplementedException();
        }

        public void MouseDown(MouseDownInfo info)
        {
            throw new NotImplementedException();
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
