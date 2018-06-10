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
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for CompositeTransaction.
	/// </summary>
	public class CompositeTransaction : TransactionBase
	{
		public CompositeTransaction(IContext ctx, IsolationLevel iso, bool autoPersistAllOnCommit) : base(ctx)
		{
			this.AutoPersistAllOnCommit = autoPersistAllOnCommit ;
			foreach (ISourceMap sourceMap in this.Context.DomainMap.SourceMaps )
			{
				if (sourceMap.PersistenceType == PersistenceType.Default || sourceMap.PersistenceType == PersistenceType.ObjectRelational )
				{
					IDataSource dataSource = this.Context.GetDataSource(sourceMap);
					if (this.Context.HasTransactionPending(dataSource) == false)
					{
						ITransaction transaction = this.Context.BeginTransaction(dataSource, iso);
						transaction.AutoPersistAllOnCommit = false;
						transactions.Add(transaction);
					}
				}
			}
		}

		#region Property  Transactions
		
		private IList transactions = new ArrayList() ;
		
		public IList Transactions
		{
			get => this.transactions;
		    set => this.transactions = value;
		}
		
		#endregion

		public override void Commit()
		{
            base.Commit();

			if (this.AutoPersistAllOnCommit)
				this.Context.Commit() ;

			foreach (ITransaction transaction in this.transactions)
			{
				//could we implement 2-phase when sources support it ?
				transaction.Commit() ;
			}
		}

        public override void Rollback()
		{
            base.Rollback();

			IList exceptions = new ArrayList() ;
			foreach (ITransaction transaction in this.transactions)
			{
				try
				{
					transaction.Rollback() ;					
				} 
				catch (Exception ex)
				{
					exceptions.Add(ex);
				}
			}
			//Bug in following line fixed by Vlad Ivanov
			if (exceptions!=null && exceptions.Count > 0)
				throw new ExceptionLimitExceededException("Exceptions were encountered during rollback! One or more databases are potentially in a corrupt state!");
		}

        public override IDbConnection Connection => throw new IAmOpenSourcePleaseImplementMeException();

	    public override IDbTransaction DbTransaction
		{
			get => throw new IAmOpenSourcePleaseImplementMeException();
	        set => throw new IAmOpenSourcePleaseImplementMeException();
	    }

        public override IDataSource DataSource
		{
			get => throw new IAmOpenSourcePleaseImplementMeException();
            set => throw new IAmOpenSourcePleaseImplementMeException();
        }

        public override IsolationLevel IsolationLevel => throw new IAmOpenSourcePleaseImplementMeException();

	    public override void Dispose()
		{
			foreach (ITransaction transaction in this.transactions)
			{
				transaction.Dispose() ;
			}
		}

	}
}
