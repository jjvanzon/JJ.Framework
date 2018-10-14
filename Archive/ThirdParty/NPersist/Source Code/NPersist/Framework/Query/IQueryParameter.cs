// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Data;
using System.Data.SqlClient;

namespace Puzzle.NPersist.Framework.Querying
{
	/// <summary>
	/// Summary description for IQueryParameter.
	/// </summary>
	public interface IQueryParameter
	{

		string Name
		{
			get ;
			set ;
		}

		object Value
		{
			get ;
			set ;
		}
		
		DbType DbType
		{
			get ;
			set ;
		}

		void AddToDbCommand(IDbCommand dbCommand);
	
	}

}
