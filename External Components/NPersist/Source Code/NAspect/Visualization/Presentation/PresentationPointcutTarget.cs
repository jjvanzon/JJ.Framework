using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NAspect.Visualization.Presentation
{
    public class PresentationPointcutTarget : PointcutTarget
    {
        public PresentationPointcutTarget(IPointcut pointcut) 
        {
            this.pointcut = pointcut;
        }

        public PresentationPointcutTarget(IPointcut pointcut, PointcutTarget target)
        {
            this.pointcut = pointcut;

            this.Exclude = target.Exclude;
            this.Signature = target.Signature;
            this.TargetType = target.TargetType;
        }

        private IPointcut pointcut;
        public virtual IPointcut Pointcut
        {
            get { return pointcut; }
            set { pointcut = value; }
        }
    }
}
