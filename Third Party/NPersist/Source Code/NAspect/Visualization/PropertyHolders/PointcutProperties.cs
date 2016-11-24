using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NAspect.Visualization.PropertyHolders
{
    public class PointcutProperties
    {
        public PointcutProperties(IPointcut pointcut)
        {
            this.pointcut = pointcut;
        }

        private IPointcut pointcut;

        public IPointcut GetPointcut()
        {
            return pointcut;
        }

        public string Name
        {
            get { return pointcut.Name; }
            set { pointcut.Name = value; }
        }
    }
}
