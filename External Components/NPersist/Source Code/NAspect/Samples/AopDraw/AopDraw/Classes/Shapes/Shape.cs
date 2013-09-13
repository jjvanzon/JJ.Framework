using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Interfaces;
using System.Drawing;

namespace AopDraw.Classes.Shapes
{
    public abstract class Shape 
    {
        #region Property X 
        private double x;
        public virtual double X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }                        
        #endregion

        #region Property Y 
        private double y;
        public virtual double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }                        
        #endregion

        public abstract void Render(CanvasPaintArgs e);

        public virtual bool HitTest(double x, double y)
        {
            return false;
        }
    }
}
