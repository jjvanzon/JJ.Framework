using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NAspect.Visualization.Presentation
{
    public class PresentationMixin
    {
        public PresentationMixin(IGenericAspect aspect)
        {
            this.aspect = aspect;
        }

        public PresentationMixin(IGenericAspect aspect, string mixin)
        {
            this.aspect = aspect;
            this.typeName = mixin;
        }

        private IGenericAspect aspect;
        public virtual IGenericAspect Aspect
        {
            get { return aspect; }
            set { aspect = value; }
        }
	
        private string typeName;
        public virtual string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }
    }
}
