using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Label : Element
    {
        public Label()
        {
            _position = new LabelPosition(this);
        }

        private ElementPosition _position;
        public override ElementPosition Position
        {
            get { return _position; }
        }

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

        private string DebuggerDisplay
        {
            get { return DebugHelper.GetDebuggerDisplay(this); }
        }
    }
}
