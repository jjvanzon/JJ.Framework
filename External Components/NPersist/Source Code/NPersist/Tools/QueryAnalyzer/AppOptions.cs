// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Tools.QueryAnalyzer
{
	public enum NPathEngine
	{
		Aplha = 0,
		Omega = 1
	}
	/// <summary>
	/// Summary description for AppOptions.
	/// </summary>
	public class AppOptions
	{
		public AppOptions()
		{
		}

		private NPathEngine nPathEngine = NPathEngine.Omega;
		
		public NPathEngine NPathEngine
		{
			get { return this.nPathEngine; }
			set { this.nPathEngine = value; }
		}

	}
}
