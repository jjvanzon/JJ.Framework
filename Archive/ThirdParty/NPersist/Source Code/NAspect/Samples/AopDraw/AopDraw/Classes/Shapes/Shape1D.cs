using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using AopDraw.Attributes;
using AopDraw.Interfaces;

namespace AopDraw.Classes.Shapes
{
    public class Shape1D : Shape
    {
        #region Property X2 
        private double x2;
        public virtual double X2
        {
            get
            {
                return this.x2;
            }
            set
            {
                this.x2 = value;
            }
        }                        
        #endregion

        #region Property Y2 
        private double y2;
        public virtual double Y2
        {
            get
            {
                return this.y2;
            }
            set
            {
                this.y2 = value;
            }
        }                        
        #endregion

        public RectangleF GetBoundsF()
        {
            float minX = (float)Math.Min(X, X2);
            float maxX = (float)Math.Max(X, X2);
            float minY = (float)Math.Min(Y, Y2);
            float maxY = (float)Math.Max(Y, Y2);

            return new RectangleF(minX, minY, maxX - minX, maxY - minY);
        }
        public Rectangle GetBounds()
        {
            int minX = (int)Math.Min(X, X2);
            int maxX = (int)Math.Max(X, X2);
            int minY = (int)Math.Min(Y, Y2);
            int maxY = (int)Math.Max(Y, Y2);

            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }

        public override void Render(CanvasPaintArgs e)
        {
            e.g.DrawLine(e.BorderPen, (float)X, (float)Y, (float)X2, (float)Y2);
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
