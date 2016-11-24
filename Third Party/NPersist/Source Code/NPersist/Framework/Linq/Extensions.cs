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
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPath.Framework.CodeDom;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Puzzle.NPersist.Framework.Linq
{
    public delegate T Func<T>();
    public delegate T Func<A0, T>(A0 arg0);
    public delegate T Func<A0, A1, T>(A0 arg0, A1 arg1);
    public delegate T Func<A0, A1, A2, T>(A0 arg0, A1 arg1, A2 arg2);
    public delegate T Func<A0, A1, A2, A3, T>(A0 arg0, A1 arg1, A2 arg2, A3 arg3);

    public static class Sequence
    {
        public static ITable<T> Where<T>(this IList source, Expression<Func<T, bool>> predicate)
        {
            Table<T> list = new Table<T>();

            return list;
        }

        public static ITable<T> Where<T>(this IList<T> source, Expression<Func<T, bool>> predicate)
        {
            Table<T> list = new Table<T>();

            return list;
        }

        public static ITable<T> Where<T>(this ITable<T> source, Expression<Func<T, bool>> predicate)
        {
            source = source.Clone();

            source.IsDirty = true;

            string whereClause = source.Converter.ConvertToString(predicate);

            if (source.Query.WhereClause != "")
            {
                source.Query.WhereClause += string.Format(" and ({0})", whereClause);
            }
            else
            {
                source.Query.WhereClause = string.Format("where ({0})", whereClause);
            }

            return source;
        }

        public static ITable<T> Select<T, S>(this ITable<T> source, Expression<Func<T, S>> selector)
        {
            source = source.Clone();

            source.IsDirty = true;

            //if (selector.Body is NewExpression)
            //{
            //    LinqToNPathConverter.CreateLoadspan((NewExpression)selector.Body, source.Query);
            //    //throw new NotSupportedException("Not supported yet");
            //}

            //if (selector.Body is MemberInitExpression)
            //{
            //    LinqToNPathConverter.CreateLoadspan((MemberInitExpression)selector.Body, source.Query);
            //}

            return source;
        }

        public static ITable<T> OrderBy<T, K>(this ITable<T> source, Expression<Func<T, K>> keySelector)
        {
            source = source.Clone();

            source.IsDirty = true;

            source.Query.OrderByClause = "order by " + source.Converter.ConvertToString(keySelector);
            return source;
        }

        public static ITable<T> OrderByDescending<T, K>(this ITable<T> source, Expression<Func<T, K>> keySelector)
        {
            source = source.Clone();

            source.IsDirty = true;

            source.Query.OrderByClause = "order by " + source.Converter.ConvertToString(keySelector) + " desc";
            return source;
        }

        public static ITable<T> ThenBy<T, K>(this ITable<T> source, Expression<Func<T, K>> keySelector)
        {
            source = source.Clone();

            source.IsDirty = true;

            source.Query.OrderByClause += ", " + source.Converter.ConvertToString(keySelector);
            return source;
        }

        public static ITable<T> ThenByDescending<T, K>(this ITable<T> source, Expression<Func<T, K>> keySelector)
        {
            source = source.Clone();

            source.IsDirty = true;

            source.Query.OrderByClause += ", " + source.Converter.ConvertToString(keySelector) + " desc";
            return source;
        }


        public static BindingList<T> ToBindingList<T>(this ITable<T> source)
        {
            return new EntityBindingList<T>(source,source.Query.Context);           
        }
    }
}

