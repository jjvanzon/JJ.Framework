// *
// * Copyright (C) 2008 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Data;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NCore.Framework.Logging;
using System.Collections;

namespace Puzzle.NPersist.Framework.Persistence
{
    public abstract class TransactionBase : ContextChild, ITransaction
	{
		public TransactionBase(IContext ctx) : base(ctx)
        {
        }

        #region ITransaction Members


		private Guid guid = Guid.NewGuid();

		public Guid Guid => guid;

	    private bool autoPersistAllOnCommit = true;

        public bool AutoPersistAllOnCommit
        {
            get => this.autoPersistAllOnCommit;
            set => this.autoPersistAllOnCommit = value;
        }

        private Hashtable inverseHelpers;

        public Hashtable InverseHelpers
        {
            get
            {
                if (inverseHelpers == null)
                    inverseHelpers = new Hashtable();
                return inverseHelpers;
            }
        }

        protected void ClearInverseHelpers()
        {
            if (inverseHelpers == null)
                return;

            foreach (IInverseHelper inverseHelper in inverseHelpers.Values)
                inverseHelper.Clear(this);

            inverseHelpers = null;
        }

        public abstract IDbTransaction DbTransaction
        {
            get;
            set;
        }

        public abstract IDataSource DataSource
        {
            get;
            set;
        }

        #endregion

        #region IDbTransaction Members

        public virtual void Commit() => ClearInverseHelpers();

	    public abstract IDbConnection Connection
        {
            get;
        }

        public abstract IsolationLevel IsolationLevel
        {
            get; 
        }

        public virtual void Rollback() => ClearInverseHelpers();

	    #endregion

        #region IDisposable Members

        public abstract void Dispose();

        #endregion
    }
}
