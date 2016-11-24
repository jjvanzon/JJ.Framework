using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NAspect.Visualization.PropertyHolders
{
    public class PointcutTargetProperties
    {

        public PointcutTargetProperties(PointcutTarget target)
        {
            this.target = target;
        }

        private PointcutTarget target;

        public PointcutTarget GetPointcutTarget()
        {
            return this.target;
        }

        public string Signature
        {
            get { return target.Signature; }
            set { target.Signature = value; }
        }

        public PointcutTargetType TargetType
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
