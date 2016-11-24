using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Interfaces;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;
using AopDraw.Classes.Shapes;

namespace AopDraw.Mixins
{
    public class MovableShape2DMixin : IMovable , IProxyAware
    {
        private Shape2D shape;

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


        public void RememberLocation()
        {
            this.OldX = shape.X;
            this.OldY = shape.Y;
        }

        public virtual void MoveTo(double x, double y)
        {
            shape.X = OldX + x;
            shape.Y = OldY + y;
        }        

        public void SetProxy(IAopProxy target)
        {
            Shape2D shape = target as Shape2D;

            if (shape == null)
                throw new ArgumentException("target is not an IShape2D");

            this.shape = shape;
        }        
    }
}
