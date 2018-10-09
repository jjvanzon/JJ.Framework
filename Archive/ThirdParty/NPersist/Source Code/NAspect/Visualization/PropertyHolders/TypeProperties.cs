using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzle.NAspect.Visualization.PropertyHolders
{
    public class TypeProperties
    {
        public TypeProperties(Type type)
        {
            this.type = type;
        }

        private Type type;

        public Type GetTheType()
        {
            return this.type;
        }

        public string Name
        {
            get { return type.FullName; }
        }

    }
}
