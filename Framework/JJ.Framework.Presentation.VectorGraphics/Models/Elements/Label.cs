using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Label : Element
    {
        public string Text { get; set; }

        private TextStyle _textStyle = new TextStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public TextStyle TextStyle
        {
            [DebuggerHidden]
            get { return _textStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _textStyle = value;
            }
        }

        public override float X { get; set; }
        public override float Y { get; set; }

        public override float Width { get; set; }
        public override float Height { get; set; }

        private string DebuggerDisplay
        {
            get
            {
                var sb = new StringBuilder();

                sb.Append(String.Format("{{{0}}} ", GetType().Name));
                sb.Append(String.Format("'{0}', ", Text));

                string tag = Convert.ToString(Tag);
                if (!String.IsNullOrEmpty(tag))
                {
                    sb.Append(String.Format("Tag='{0}', ", Tag));
                }

                sb.Append(String.Format("X={0}, Y={1} ", X, Y));
                sb.Append(String.Format("(HashCode={0})", GetHashCode()));

                return sb.ToString();
            }
        }

        // TODO: Put DebuggerDisplay generation in a separate class DebugHelper and just put this here.
        // (Do this for the other classes too.)
        //private string DebuggerDisplay
        //{
        //    get { return DebugHelper.GetDebuggerDisplay(this); }
        //}
    }
}
