using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Puzzle.NAspect.Debug.Controls
{
    public partial class Caption : Control
    {
        public Caption()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color c1 = SystemColors.ActiveCaption;
            Color c2 = Tools.MixColors(c1, Color.Black);
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush bgBrush = new LinearGradientBrush(bounds, c1, c2, 90, false); 
            e.Graphics.FillRectangle (bgBrush,bounds);

            StringFormat sf = StringFormat.GenericDefault;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(this.Text, this.Font, Brushes.White, bounds,sf);
        }

        [Browsable(true)]
        [DesignerSerializationVisibility (DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
    }
}
