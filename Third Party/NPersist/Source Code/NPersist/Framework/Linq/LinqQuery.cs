// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NPersist.Framework;
using System.Linq;

namespace Puzzle.NPersist.Framework.Linq
{
    public class LinqQuery<T> 
    {
        public IContext Context { get; set; }
        public ILoadSpan LoadSpan { get; set; }

        string selectClause = "select *";
        public string SelectClause
        {
            get
            {
                return selectClause;
            }
            set
            {
                selectClause = value;
            }
        }

        public string FromClause
        {
            get
            {
                return "from " + this.GetType().GetGenericArguments()[0].Name;
            }
        }

        #region Property WhereClause
        private string whereClause = "";
        public virtual string WhereClause
        {
            get
            {
                return this.whereClause;
            }
            set
            {
                this.whereClause = value;
            }
        }
        #endregion

        public string ToNPath()
        {
            ApplyLoadSpan();
            string selectClause = AddSpaces(SelectClause);
            string fromClause = AddSpaces(FromClause);
            string whereClause = AddSpaces(WhereClause);
            string orderByClause = AddSpaces(OrderByClause);


            return (selectClause + fromClause + whereClause + orderByClause).Trim () ;
        }

        private string AddSpaces(string source)
        {
            return (source + " ").TrimStart();
        }

        private void ApplyLoadSpan()
        {
            if (LoadSpan == null || LoadSpan.PropertyPaths.Length == 0)
            {
                SelectClause = "select *";
            }
            else
            {
                SelectClause = "select " + LoadSpan.PropertyPaths.Aggregate((left, right) => left + ", " + right);
            }
        }

        #region Property OrderByClause
        private string orderByClause = "";
        public virtual string OrderByClause
        {
            get
            {
                return this.orderByClause;
            }
            set
            {
                this.orderByClause = value;
            }
        }
        #endregion

        public LinqQuery<T> Clone()
        {
            LinqQuery<T> clone = new LinqQuery<T>();
            clone.Context = this.Context;            
            clone.OrderByClause = this.OrderByClause;
            clone.SelectClause = this.SelectClause;
            clone.WhereClause = this.WhereClause;
            clone.LoadSpan = this.LoadSpan;

            return clone;
        }
    }
}
