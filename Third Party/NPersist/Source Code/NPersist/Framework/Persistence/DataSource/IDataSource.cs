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
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	public interface IDataSource : IDisposable
	{
		IDataSourceManager DataSourceManager { get; set; }

		string Name { get; set; }

		ISourceMap SourceMap { get; set; }

        bool HasConnection();

        bool HasOpenConnection();
        
        IDbConnection GetConnection();

		void ReturnConnection();

		void SetConnection(IDbConnection connection);

		bool KeepConnectionOpen { get; set; }
	}
}