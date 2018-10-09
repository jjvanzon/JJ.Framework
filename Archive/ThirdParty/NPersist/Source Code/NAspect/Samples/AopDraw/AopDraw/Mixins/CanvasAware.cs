using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Interfaces;

namespace AopDraw.Mixins
{
    public class CanvasAwareMixin : ICanvasAware
    {
        #region Property Canvas 
        private ICanvas canvas;
        public ICanvas Canvas
        {
            get
            {
                return this.canvas;
            }
            set
            {
                this.canvas = value;
            }
        }                        
        #endregion
    }
}
