using JJ.Framework.Presentation.Svg.Models.Styling;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    public class Rectangle : ElementBase
    {
        public override float X { get; set; }
        public override float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        private BackStyle _backStyle = new BackStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public BackStyle BackStyle
        {
            get { return _backStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _backStyle = value;
            }
        }

        private LineStyle _topLineStyle = new LineStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public LineStyle TopLineStyle
        {
            get { return _topLineStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _topLineStyle = value;
            }
        }

        private LineStyle _rightLineStyle = new LineStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public LineStyle RightLineStyle
        {
            get { return _rightLineStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _rightLineStyle = value;
            }
        }

        private LineStyle _bottomLineStyle = new LineStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public LineStyle BottomLineStyle
        {
            get { return _bottomLineStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _bottomLineStyle = value;
            }
        }

        private LineStyle _leftLineStyle = new LineStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public LineStyle LeftLineStyle
        {
            get { return _leftLineStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _leftLineStyle = value;
            }
        }

        /// <summary>
        /// Sets the style of all 4 lines at the same time.
        /// </summary>
        public void SetLineStyle(LineStyle lineStyle)
        {
            TopLineStyle = lineStyle;
            RightLineStyle = lineStyle;
            BottomLineStyle = lineStyle;
            LeftLineStyle = lineStyle;
        }

        /// <summary>
        /// Return a single LineStyle in case all border lines have the same style.
        /// </summary>
        public LineStyle TryGetLineStyle()
        {
            if (TopLineStyle == RightLineStyle &&
                RightLineStyle == BottomLineStyle &&
                BottomLineStyle == LeftLineStyle)
            {
                return TopLineStyle;
            }

            return null;
        }
    }
}
