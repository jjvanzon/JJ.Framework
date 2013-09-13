using System;
using System.Collections.Generic;
using System.Text;

namespace AopDraw.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ResizableAttribute : Attribute
    {
        #region Property KeepProportions 
        private bool keepProportions;
        public bool KeepProportions
        {
            get
            {
                return this.keepProportions;
            }
            set
            {
                this.keepProportions = value;
            }
        }                        
        #endregion

        public ResizableAttribute()
        {
        }

        public ResizableAttribute(bool keepProportions)
        {
            this.KeepProportions = keepProportions;
        }
    }
}
