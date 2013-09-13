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
using Puzzle.NPersist.Framework.Sql.Dom;

namespace Puzzle.NPersist.Framework.Sql.Visitor
{
	/// <summary>
	/// Summary description for SqlSqlServerVisitor.
	/// </summary>
	public class SqlSqlServerVisitor : SqlVisitorBase
	{
		public SqlSqlServerVisitor()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        protected override string FormatBoolean(bool content)
        {
            if (content)
                return "1";
            else
                return "0";
        }
	}
}
