using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Interfaces;
using System.Drawing;

namespace AopDraw.Classes.Shapes
{
    public abstract class Shape2D : Shape
    {
        #region Property Width
        private double width;
        public virtual double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }
        #endregion

        #region Property Height
        private double height;
        public virtual double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }
        #endregion

        public RectangleF GetBoundsF()
        {
            return new RectangleF((float)X, (float)Y, (float)width, (float)height);
        }
        public Rectangle GetBounds()
        {
            return new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
        }


        public override bool HitTest(double x, double y)
        {
            if (this.GetBoundsF().Contains((float)x, (float)y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
