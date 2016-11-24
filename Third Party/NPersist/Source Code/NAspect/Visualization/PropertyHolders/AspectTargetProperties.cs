using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NAspect.Visualization.PropertyHolders
{
    public class AspectTargetProperties
    {
        public AspectTargetProperties(AspectTarget target)
        {
            this.target = target;
        }

        private AspectTarget target;

        public AspectTarget GetAspectTarget()
        {
            return this.target;
        }

        public string Signature
        {
            get { return target.Signature; }
            set { target.Signature = value; }
        }

        public AspectTargetType TargetType
        {
            get { return target.TargetType; }
            set { target.TargetType = value; }
        }

        public bool Exclude
        {
            get { return target.Exclude; }
            set { target.Exclude = value; }
        }
	
    }
}
