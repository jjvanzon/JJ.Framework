using JJ.Framework.Presentation.Svg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Svg.Models
{
    public class SvgModel
    {
        private IList<Line> _lines = new List<Line>();
        public IList<Line> Lines
        {
            get { return _lines; }
        }

        private IList<Rectangle> _rectangles = new List<Rectangle>();
        public IList<Rectangle> Rectangles
        {
            get { return _rectangles; }
        }

        private IList<Label> _labels = new List<Label>();
        public IList<Label> Labels
        {
            get { return _labels; }
        }
    }
}
