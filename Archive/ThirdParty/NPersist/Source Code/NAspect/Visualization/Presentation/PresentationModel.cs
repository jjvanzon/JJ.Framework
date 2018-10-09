using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Puzzle.NAspect.Visualization.Presentation
{
    public class PresentationModel
    {
        private IList aspects = new ArrayList();
        public virtual IList Aspects
        {
            get { return aspects; }
            set { aspects = value; }
        }

        public PresentationAspect GetAspect(string name)
        {
            name = name.ToLower();
            foreach (PresentationAspect aspect in aspects)
            {
                if (name == aspect.Name.ToLower())
                    return aspect;
            }
            return null;
        }
    }
}
