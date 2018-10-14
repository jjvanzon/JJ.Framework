// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Diagnostics;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Persistence;


namespace Puzzle.NPersist.Framework.Aop.Mixins
{
	public class CloneHelperMixin : ICloneHelper
	{
		private IObjectClone objectClone = null;

		public CloneHelperMixin(object target)
		{
		}

		public CloneHelperMixin()
		{
		}

		
		public IObjectClone GetObjectClone() => objectClone;

	    public void SetObjectClone(IObjectClone value) => objectClone = value;
	}
}
