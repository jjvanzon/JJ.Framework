using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;
using System.Collections;

namespace Puzzle.NAspect.Visualization.Presentation
{
    public class PresentationAspectTarget : AspectTarget
    {
        public PresentationAspectTarget(PresentationAspect aspect) 
        {
            this.Aspect = aspect;
        }

        public PresentationAspectTarget(PresentationAspect aspect, AspectTarget target)
        {
            this.Aspect = aspect;

            this.Exclude = target.Exclude;
            this.Signature = target.Signature;
            this.TargetType = target.TargetType;
        }

        private IGenericAspect aspect;
        public virtual IGenericAspect Aspect
        {
            get { return aspect; }
            set { aspect = value; }
        }
    }
}
