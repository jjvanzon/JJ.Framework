using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Interfaces;
using System.Drawing;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;
using AopDraw.Attributes;
using AopDraw.Classes.Shapes;

namespace AopDraw.Mixins
{
    public class DesignableMixin : IDesignable, IProxyAware
    {
        private Shape shape;

        public void SetProxy(IAopProxy target)
        {
            Shape shape = target as Shape;

            if (shape == null)
                throw new ArgumentException("target is not an IShape");

            this.shape = shape;

            DesignableAttribute attrib = (DesignableAttribute)shape.GetType().GetCustomAttributes(typeof(DesignableAttribute), true)[0];
            this.FillColor = attrib.FillColor;
            this.BorderColor = attrib.BorderColor;
            this.BorderSize = attrib.BorderSize;
        }    

        #region Property BorderSize 
        private float borderSize ;
        public float BorderSize
        {
            get
            {
                return this.borderSize;
            }
            set
            {
                this.borderSize = value;
            }
        }                        
        #endregion

        #region Property BorderColor 
        private Color borderColor ;
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                this.borderColor = value;
            }
        }                        
        #endregion

        #region Property FillColor 
        private Color fillColor ;
        public Color FillColor
        {
            get
            {
                return this.fillColor;
            }
            set
            {
                this.fillColor = value;
            }
        }                        
        #endregion       
    }
}
