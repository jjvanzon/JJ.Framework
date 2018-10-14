using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NAspect.Visualization.PropertyHolders
{
    public class AspectProperties
    {
        public AspectProperties(IGenericAspect aspect)
        {
            this.aspect = aspect;
        }

        private IGenericAspect aspect;
        public virtual IGenericAspect GetAspect()
        { 
            return aspect; 
        }

        public virtual string Name
        {
            get { return aspect.Name; }
            set { aspect.Name = value; }
        }
    }
}
