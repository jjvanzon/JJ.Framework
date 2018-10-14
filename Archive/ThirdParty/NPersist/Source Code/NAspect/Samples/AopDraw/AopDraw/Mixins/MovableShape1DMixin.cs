using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Interfaces;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;
using AopDraw.Classes.Shapes;

namespace AopDraw.Mixins
{
    public class MovableShape1DMixin : IMovable, IProxyAware
    {
        private Shape1D shape;

        #region Property OldX
        private double oldX;
        public double OldX
        {
            get
            {
                return this.oldX;
            }
            set
            {
                this.oldX = value;
            }
        }
        #endregion

        #region Property OldY
        private double oldY;
        public double OldY
        {
            get
            {
                return this.oldY;
            }
            set
            {
                this.oldY = value;
            }
        }
        #endregion

        #region Property OldX2 
        private double oldX2;
        public double OldX2
        {
            get
            {
                return this.oldX2;
            }
            set
            {
                this.oldX2 = value;
            }
        }                        
        #endregion

        #region Property OldY2 
        private double oldY2;
        public double OldY2
        {
            get
            {
                return this.oldY2;
            }
            set
            {
                this.oldY2 = value;
            }
        }                        
        #endregion


        public void RememberLocation()
        {
            this.OldX = shape.X;
            this.OldY = shape.Y;
            this.OldX2 = shape.X2;
            this.OldY2 = shape.Y2;
        }

        public virtual void MoveTo(double x, double y)
        {
            shape.X = OldX + x;
            shape.Y = OldY + y;
            shape.X2 = OldX2 + x;
            shape.Y2 = OldY2 + y;

            
        }

        public void SetProxy(IAopProxy target)
        {
            Shape1D shape = target as Shape1D;

            if (shape == null)
                throw new ArgumentException("target is not an IShape1D");

            this.shape = shape;
        }
    }
}
