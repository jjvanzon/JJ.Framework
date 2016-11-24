// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzle.NPersist.Framework.Linq
{
    public interface ILoadSpan
    {
        string[] PropertyPaths {get;}

    }

    public class LoadSpan<T> : ILoadSpan
    {
        private string[] propertyPaths;
        public string[] PropertyPaths
        {
            get
            {
                return propertyPaths;
            }
        }
        public LoadSpan()
        {
            this.propertyPaths = new string[] { };
        }

        public LoadSpan(params string[] propertyPaths)
        {
            if (propertyPaths == null)
                this.propertyPaths = new string[] {};
            else
                this.propertyPaths = propertyPaths;
        }
    }
}
