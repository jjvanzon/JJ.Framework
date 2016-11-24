// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class ListValueTemplate
	{
        #region Property PropertyMaps 
        private ArrayList propertyMaps = new ArrayList ();
        public ArrayList PropertyMaps
        {
            get
            {
                return this.propertyMaps;
            }
            set
            {
                this.propertyMaps = value;
            }
        }                        
        #endregion
	}
}
