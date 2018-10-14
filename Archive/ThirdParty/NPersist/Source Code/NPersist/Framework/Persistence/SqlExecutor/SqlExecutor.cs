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
using System.Collections;
using System.Data;
using Puzzle.NCore.Framework.Data;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NCore.Framework.Logging;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class SqlExecutor : ContextChild, ISqlExecutor
	{
		private ExecutionMode m_ExecutionMode = ExecutionMode.DirectExecution;
		private Hashtable m_BatchStatements = new Hashtable();

		public virtual object ExecuteScalar(string sql) => ExecuteScalar(sql, this.Context.GetDataSource(), new ArrayList());

	    public virtual int ExecuteNonQuery(string sql) => ExecuteNonQuery(sql,this.Context.GetDataSource(), new ArrayList() );

	    //public virtual IDataReader ExecuteReader(string sql, IDataSource dataSource, IDbConnection connection)
		public virtual IDataReader ExecuteReader(string sql) => ExecuteReader(sql, this.Context.GetDataSource(), new ArrayList() );

	    public virtual object ExecuteArray(string sql) => ExecuteArray(sql, this.Context.GetDataSource(), new ArrayList() );

	    public virtual DataTable ExecuteDataTable(string sql) => ExecuteDataTable(sql, this.Context.GetDataSource(), new ArrayList() );

	    public virtual object ExecuteScalar(string sql, IDataSource dataSource) => ExecuteScalar(sql, dataSource, new ArrayList());

	    public virtual int ExecuteNonQuery(string sql, IDataSource dataSource) => ExecuteNonQuery(sql, dataSource, new ArrayList() );

	    //public virtual IDataReader ExecuteReader(string sql, IDataSource dataSource, IDbConnection connection)
		public virtual IDataReader ExecuteReader(string sql, IDataSource dataSource) => ExecuteReader(sql, dataSource, new ArrayList() );

	    public virtual object ExecuteArray(string sql, IDataSource dataSource) => ExecuteArray(sql, dataSource, new ArrayList() );

	    public virtual DataTable ExecuteDataTable(string sql, IDataSource dataSource) => ExecuteDataTable(sql, dataSource, new ArrayList() );

	    public virtual object ExecuteScalar(string sql, IDataSource dataSource, IList parameters)
		{
            LogMessage message = new LogMessage("Executing scalar sql query");
            LogMessage verbose = new LogMessage ("Sql: {0}" , sql);
			this.Context.LogManager.Info(this,message , verbose);// do not localize
			IDbConnection connection;
			IDbCommand cmd;
			object result;
			ITransaction transaction;
			SqlExecutorCancelEventArgs e = new SqlExecutorCancelEventArgs(sql, dataSource, parameters);
			this.Context.EventManager.OnExecutingSql(this, e);
			if (e.Cancel)
			{
                message = new LogMessage("Executing scalar sql query canceled by observer!");
                verbose = new LogMessage("Sql: {0}", sql);
				this.Context.LogManager.Warn(this, message, verbose); // do not localize
				return 0;
			}
			sql = e.Sql;
			dataSource = e.DataSource;
			parameters = e.Parameters;
			connection = dataSource.GetConnection();
			cmd = connection.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;
			AddParametersToCommand(cmd, parameters);
			transaction = this.Context.GetTransaction(connection);
			if (transaction != null)
			{
				cmd.Transaction = transaction.DbTransaction;
			}
			result = cmd.ExecuteScalar();
			dataSource.ReturnConnection();
			
			SqlExecutorEventArgs e2 = new SqlExecutorEventArgs(sql, dataSource, parameters);

			this.Context.EventManager.OnExecutedSql(this, e2);
			return result;
		}

		public virtual int ExecuteNonQuery(string sql, IDataSource dataSource, IList parameters)
		{
            if (dataSource == null)
                throw new ArgumentNullException("dataSource");

            LogMessage message = new LogMessage("Executing non query");
            LogMessage verbose = new LogMessage("Sql: {0}" , sql);
			this.Context.LogManager.Info(this, message, verbose); // do not localize
			IDbConnection connection;
			IDbCommand cmd;
			int result = 0;
			ITransaction transaction;
			bool postPoned = false;
			if (m_ExecutionMode == ExecutionMode.BatchExecution)
				postPoned = true;

			SqlExecutorCancelEventArgs e = new SqlExecutorCancelEventArgs(sql, dataSource, parameters, postPoned);
			this.Context.EventManager.OnExecutingSql(this, e);
			if (e.Cancel)
			{
                message = new LogMessage("Executing non query canceled by observer!");
                verbose = new LogMessage("Sql: {0}", sql);
                this.Context.LogManager.Info(this, message, verbose); // do not localize				
				return 0;
			}
			sql = e.Sql;
			dataSource = e.DataSource;
			parameters = e.Parameters;
			if (m_ExecutionMode == ExecutionMode.NoExecution || m_ExecutionMode == ExecutionMode.NoWriteExecution)
			{
				result = 1;
			}
			else if (m_ExecutionMode == ExecutionMode.BatchExecution)
			{
				result = 1;
				BatchStatement(sql, dataSource, parameters);
			}
			else if (m_ExecutionMode == ExecutionMode.DirectExecution)
			{
				connection = dataSource.GetConnection();
				cmd = connection.CreateCommand();
				cmd.CommandType = CommandType.Text;
				AddParametersToCommand(cmd, parameters);
				cmd.CommandText = sql;
				transaction = this.Context.GetTransaction(connection);
				if (transaction != null)
				{
					cmd.Transaction = transaction.DbTransaction;
				}
				result = cmd.ExecuteNonQuery();
				dataSource.ReturnConnection();
			}

			SqlExecutorEventArgs e2 = new SqlExecutorEventArgs(sql, dataSource, parameters, postPoned);

			this.Context.EventManager.OnExecutedSql(this, e2);
			return result;
		}

		//public virtual IDataReader ExecuteReader(string sql, IDataSource dataSource, IDbConnection connection, IList parameters)
		public virtual IDataReader ExecuteReader(string sql, IDataSource dataSource, IList parameters)
		{
            LogMessage message = new LogMessage("Executing sql query and returning data reader");
            LogMessage verbose = new LogMessage("Sql: {0}", sql);
            this.Context.LogManager.Info(this, message, verbose); // do not localize	
			IDbConnection connection;
			IDbCommand cmd;
			IDataReader dr;
			ITransaction transaction;
			SqlExecutorCancelEventArgs e = new SqlExecutorCancelEventArgs(sql, dataSource, parameters);
			this.Context.EventManager.OnExecutingSql(this, e);
			if (e.Cancel)
			{
                message = new LogMessage("Executing sql query and returning data reader canceled by observer!");
                verbose = new LogMessage("Sql: {0}", sql);
                this.Context.LogManager.Info(this, message, verbose); // do not localize	
				return null;
			}
			sql = e.Sql;
			dataSource = e.DataSource;
			parameters = e.Parameters;
			if (m_ExecutionMode == ExecutionMode.NoExecution)
			{
				return null;
			}
			ExecuteBatchedStatements(dataSource);
			connection = dataSource.GetConnection();
			cmd = connection.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;
			AddParametersToCommand(cmd, parameters);
			transaction = this.Context.GetTransaction(connection);
			if (transaction != null)
			{
				cmd.Transaction = transaction.DbTransaction;
			}
			
			dr = cmd.ExecuteReader();

			SqlExecutorEventArgs e2 = new SqlExecutorEventArgs(sql, dataSource, parameters);

			this.Context.EventManager.OnExecutedSql(this, e2);

			//clone data and return the offline data to the rest of NP
			return new OfflineDataReader(dr);
		}

		public virtual object ExecuteArray(string sql, IDataSource dataSource, IList parameters)
		{
            LogMessage message = new LogMessage("Executing sql query and returning array");
            LogMessage verbose = new LogMessage("Sql: {0}", sql);
            this.Context.LogManager.Info(this, message, verbose); // do not localize	

			IDbConnection connection;
			IDbCommand cmd;
			IDataReader dr;
			object result = null;
			ITransaction transaction;
			SqlExecutorCancelEventArgs e = new SqlExecutorCancelEventArgs(sql, dataSource, parameters);
			this.Context.EventManager.OnExecutingSql(this, e);
			if (e.Cancel)
			{
                message = new LogMessage("Executing sql query and returning array canceled by observer!");
                verbose = new LogMessage("Sql: {0}", sql);
                this.Context.LogManager.Info(this, message, verbose); // do not localize	
				return null;
			}
			sql = e.Sql;
			parameters = e.Parameters;
			if (!(m_ExecutionMode == ExecutionMode.NoExecution))
			{
				ExecuteBatchedStatements(dataSource);
				connection = dataSource.GetConnection();
				cmd = connection.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = sql;
				AddParametersToCommand(cmd, parameters);
				transaction = this.Context.GetTransaction(connection);
				if (transaction != null)
				{
					cmd.Transaction = transaction.DbTransaction;
				}
				dr = cmd.ExecuteReader();
				result = ReaderToArray(dr);
				dr.Close();
				dataSource.ReturnConnection();
			}

			SqlExecutorEventArgs e2 = new SqlExecutorEventArgs(sql, dataSource, parameters);

			this.Context.EventManager.OnExecutedSql(this, e2);
			return result;
		}

		public DataTable ExecuteDataTable(string sql, IDataSource dataSource, IList parameters)
		{
            LogMessage message = new LogMessage("Executing sql query and returning data table");
            LogMessage verbose = new LogMessage("Sql: {0}", sql);
            this.Context.LogManager.Info(this, message, verbose); // do not localize	
			IDbConnection connection;
			IDbCommand cmd;
			IDataReader dr;
			DataTable result = null;
			ITransaction transaction;
			SqlExecutorCancelEventArgs e = new SqlExecutorCancelEventArgs(sql, dataSource, parameters);
			this.Context.EventManager.OnExecutingSql(this, e);
			if (e.Cancel)
			{
                message = new LogMessage("Executing sql query and returning data table canceled by observer!");
                verbose = new LogMessage("Sql: {0}", sql);
                this.Context.LogManager.Info(this, message, verbose); // do not localize
				return null;
			}
			sql = e.Sql;
			parameters = e.Parameters;
			if (!(m_ExecutionMode == ExecutionMode.NoExecution))
			{
				ExecuteBatchedStatements(dataSource);
				connection = dataSource.GetConnection();
				cmd = connection.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = sql;
				AddParametersToCommand(cmd, parameters);
				transaction = this.Context.GetTransaction(connection);
				if (transaction != null)
				{
					cmd.Transaction = transaction.DbTransaction;
				}
				dr = cmd.ExecuteReader();
				result = ReaderToDataTable(dr);
				dr.Close();
				dataSource.ReturnConnection();
			}

			SqlExecutorEventArgs e2 = new SqlExecutorEventArgs(sql, dataSource, parameters);

			this.Context.EventManager.OnExecutedSql(this, e2);
			return result;
		}

		public virtual object ReaderToArray(IDataReader dr)
		{
			int cnt = dr.FieldCount - 1;
			ArrayList arr = new ArrayList();
			ArrayList arrRow;
			int c = 0;
			int r = 0;
			bool HadRows = false;
			while (dr.Read())
			{
				arrRow = new ArrayList();
				arr.Add(arrRow);
				for (int i = 0; i <= cnt; i++)
				{
					arrRow.Add(dr.GetValue(i));
				}
				HadRows = true;
			}
			if (!(HadRows))
			{
				return null;
			}
			object[,] arrRet = new object[cnt + 1,arr.Count];
			foreach (ArrayList row in arr)
			{
				foreach (object value in row)
				{
					arrRet[c, r] = value;
					c++;
				}
				c = 0;
				r++;
			}
			return arrRet;
		}

		public virtual DataTable ReaderToDataTable(IDataReader dr)
		{
			DataTable dataTableSchema = dr.GetSchemaTable();
			int cnt = dr.FieldCount - 1;
			DataRow row;
			DataTable dtSchema = new DataTable();
			foreach (DataRow iRrow in dataTableSchema.Rows)
			{
				dtSchema.Columns.Add(Convert.ToString(iRrow["ColumnName"]), Type.GetType(Convert.ToString(iRrow["DataType"])));
			}
			while (dr.Read())
			{
				row = dtSchema.NewRow();
				for (int i = 0; i <= cnt; i++)
				{
					object value = dr.GetValue(i);
					row[i] = value;
				}
				dtSchema.Rows.Add(row);
			}
			return dtSchema;
		}

		public virtual ExecutionMode ExecutionMode
		{
			get => m_ExecutionMode;
		    set => m_ExecutionMode = value;
		}

		public virtual ArrayList GetBatchedStatements(IDataSource dataSource)
		{
			if (!(m_BatchStatements.ContainsKey(dataSource)))
			{
				return new ArrayList();
			}
			else
			{
				return ((ArrayList) (m_BatchStatements[dataSource]));
			}
		}

		public virtual void ExecuteBatchedStatements()
		{
			foreach (IDataSource dataSource in m_BatchStatements.Keys)
			{
				ExecuteBatchedStatements(dataSource);
			}
			CleatBatchedStatements();
		}

		public virtual void ExecuteBatchedStatements(IDataSource dataSource)
		{
			if (!(m_BatchStatements.ContainsKey(dataSource)))
			{
				return;
			}

			IDbConnection connection;
			IDbCommand cmd;
			int result;
			string sqlBatch = "";
			long matchResult = 0;
			IList parameters = new ArrayList() ;
			foreach (BatchedSqlStatement sql in ((ArrayList) (m_BatchStatements[dataSource])))
			{
				sqlBatch += sql.Sql + ";";
				matchResult += 1;
				foreach (QueryParameter parameter in sql.Parameters)
					parameters.Add(parameter);
			}

			SqlExecutorCancelEventArgs e = new SqlExecutorCancelEventArgs(sqlBatch, dataSource, parameters);
			this.Context.EventManager.OnExecutingSql(this, e);
			if (e.Cancel)
			{
                LogMessage message = new LogMessage("Executing batched statements canceled by observer!");
                LogMessage verbose = new LogMessage("Sql: {0}" , e.Sql);

				this.Context.LogManager.Warn(this, message,verbose); // do not localize
			}
			sqlBatch = e.Sql;
			dataSource = e.DataSource;
			parameters = e.Parameters;

			connection = dataSource.GetConnection();
			cmd = connection.CreateCommand();
			cmd.CommandText = sqlBatch;
			AddParametersToCommand(cmd, parameters);
			result = cmd.ExecuteNonQuery();
			cmd.Dispose();
			dataSource.ReturnConnection();
			
			SqlExecutorEventArgs e2 = new SqlExecutorEventArgs(sqlBatch, dataSource, parameters);

			this.Context.EventManager.OnExecutedSql(this, e2);

			if (!(result == matchResult))
			{
				throw new OptimisticConcurrencyException("An optimistic concurrency exception occurred when executing a batch statement!", null); // do not localize
			}
		}

		protected virtual void BatchStatement(string sql, IDataSource dataSource, IList parameters)
		{
			if (!(m_BatchStatements.ContainsKey(dataSource)))
			{
				m_BatchStatements[dataSource] = new ArrayList();
			}
			IList parametersClone = new ArrayList();
			foreach (QueryParameter param in parameters)
				parametersClone.Add(param);
			((ArrayList) (m_BatchStatements[dataSource])).Add(new BatchedSqlStatement(sql, parametersClone));
		}

		protected virtual void AddParametersToCommand(IDbCommand cmd, IList parameters)
		{
			foreach (IQueryParameter param in parameters)
			{
				param.AddToDbCommand(cmd);
			}
		}

		public void CleatBatchedStatements() => this.m_BatchStatements.Clear();

	    public virtual void Clear() => m_BatchStatements.Clear();
	}
}