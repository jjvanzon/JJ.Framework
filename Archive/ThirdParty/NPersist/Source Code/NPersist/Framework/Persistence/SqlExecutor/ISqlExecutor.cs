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
using System.Data;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Persistence
{
	public interface ISqlExecutor : IContextChild
	{
		object ExecuteScalar(string sql, IDataSource dataSource);

		int ExecuteNonQuery(string sql, IDataSource dataSource);

		//IDataReader ExecuteReader(string sql, IDataSource dataSource, IDbConnection connection);
		IDataReader ExecuteReader(string sql, IDataSource dataSource);

		object ExecuteArray(string sql, IDataSource dataSource);

		DataTable ExecuteDataTable(string sql, IDataSource dataSource);


		object ExecuteScalar(string sql);

		int ExecuteNonQuery(string sql);

		//IDataReader ExecuteReader(string sql, IDataSource dataSource, IDbConnection connection);
		IDataReader ExecuteReader(string sql);

		object ExecuteArray(string sql);

		DataTable ExecuteDataTable(string sql);

		
		object ExecuteScalar(string sql, IDataSource dataSource, IList parameters);

		int ExecuteNonQuery(string sql, IDataSource dataSource, IList parameters);

		//IDataReader ExecuteReader(string sql, IDataSource dataSource, IDbConnection connection, IList parameters);
		IDataReader ExecuteReader(string sql, IDataSource dataSource, IList parameters);

		object ExecuteArray(string sql, IDataSource dataSource, IList parameters);

		DataTable ExecuteDataTable(string sql, IDataSource dataSource, IList parameters);

		ExecutionMode ExecutionMode { get; set; }

		ArrayList GetBatchedStatements(IDataSource dataSource);

		void ExecuteBatchedStatements();

		void ExecuteBatchedStatements(IDataSource dataSource);

		object ReaderToArray(IDataReader dr);

		DataTable ReaderToDataTable(IDataReader dr);

		void CleatBatchedStatements();

        void Clear();
    }
}