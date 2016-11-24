using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using AopDraw.Attributes;
using System.Windows.Forms;

namespace AopDraw.Classes.Shapes
{
    [Movable]
    [Selectable]
    [Designable ("#000000",1,"#ff0000")]
    [Resizable]
    public class TextShape : Shape2D
    {
        #region Property Font 
        private Font font = new Font("Arial", 15, FontStyle.Regular);
        public virtual Font Font
        {
            get
            {
                return this.font;
            }
            set
            {
                this.font = value;
            }
        }                        
        #endregion

        #region Property Text 
        private string text = "TextShape";
        public virtual string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }                        
        #endregion

        public override void Render(CanvasPaintArgs e)
        {
            RectangleF bounds = GetBoundsF();
            e.g.DrawString(text, font, e.FillBrush, bounds, StringFormat.GenericTypographic);
            e.g.DrawRectangle(e.BorderPen, bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }
    }
}
