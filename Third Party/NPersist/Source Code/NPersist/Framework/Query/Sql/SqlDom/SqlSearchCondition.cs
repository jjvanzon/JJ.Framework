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
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlSearchCondition.
	/// </summary>
	public class SqlSearchCondition : SqlExpression, ISqlConditionChainPart
	{
		public SqlSearchCondition(ISqlNode parent) => this.Parent = parent;

	    public SqlSearchCondition(SqlWhereClause sqlWhereClause) => this.Parent = sqlWhereClause;

	    public SqlSearchCondition(SqlSearchCondition sqlSearchCondition, bool isSubClause)
		{
			this.Parent = sqlSearchCondition;
			this.isSubClause = isSubClause;
		}

		private bool isSubClause = false;

		public SqlSearchCondition PrevSqlSearchCondition
		{
			get
			{
				if (!isSubClause)
					return this.Parent as SqlSearchCondition;
				return null;
			} 
		}

		public SqlSearchCondition ParentSqlSearchCondition
		{
			get
			{
				if (isSubClause)
					return this.Parent as SqlSearchCondition;
				return null;
			} 
		}

		public SqlWhereClause SqlWhereClause => this.Parent as SqlWhereClause;

	    public SqlComparePredicate GetSqlComparePredicate(SqlExpression leftExpression, SqlCompareOperatorType sqlCompareOperatorType, SqlExpression rightExpression)
		{
			SqlComparePredicate newSqlComparePredicate = new SqlComparePredicate(this, leftExpression, sqlCompareOperatorType, rightExpression) ;
			this.sqlPredicate = newSqlComparePredicate;
			return newSqlComparePredicate;
		}

		public SqlComparePredicate GetSqlComparePredicate(SqlColumnAlias leftColumnAlias, SqlCompareOperatorType sqlCompareOperatorType, SqlExpression rightExpression)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			return GetSqlComparePredicate(leftSqlColumnAliasReference, sqlCompareOperatorType, rightExpression);
		}

		public SqlComparePredicate GetSqlComparePredicate(SqlExpression leftExpression, SqlCompareOperatorType sqlCompareOperatorType, SqlColumnAlias rightColumnAlias)
		{
			SqlColumnAliasReference rightSqlColumnAliasReference = new SqlColumnAliasReference(rightColumnAlias) ;
			return GetSqlComparePredicate(leftExpression, sqlCompareOperatorType, rightSqlColumnAliasReference);
		}

		public SqlComparePredicate GetSqlComparePredicate(SqlColumnAlias leftColumnAlias, SqlCompareOperatorType sqlCompareOperatorType, SqlColumnAlias rightColumnAlias)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			SqlColumnAliasReference rightSqlColumnAliasReference = new SqlColumnAliasReference(rightColumnAlias) ;
			return GetSqlComparePredicate(leftSqlColumnAliasReference, sqlCompareOperatorType, rightSqlColumnAliasReference);
		}

		public SqlBetweenPredicate GetSqlBetweenPredicate(SqlExpression leftExpression, SqlExpression middleExpression, SqlExpression rightExpression) => GetSqlBetweenPredicate(leftExpression, middleExpression, rightExpression, false);

	    public SqlBetweenPredicate GetSqlBetweenPredicate(SqlExpression leftExpression, SqlExpression middleExpression, SqlExpression rightExpression, bool negative)
		{
			SqlBetweenPredicate newSqlBetweenPredicate = new SqlBetweenPredicate(this, leftExpression, middleExpression, rightExpression, negative) ;
			this.sqlPredicate = newSqlBetweenPredicate;
			return newSqlBetweenPredicate;
		}


		public SqlIsNullPredicate GetSqlIsNullPredicate(SqlExpression leftExpression) => GetSqlIsNullPredicate(leftExpression, false);

	    public SqlIsNullPredicate GetSqlIsNullPredicate(SqlColumnAlias leftColumnAlias)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			return GetSqlIsNullPredicate(leftSqlColumnAliasReference, false);
		}

		public SqlIsNullPredicate GetSqlIsNullPredicate(SqlColumnAlias leftColumnAlias, bool negative)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			return GetSqlIsNullPredicate(leftSqlColumnAliasReference, negative);
		}

		public SqlIsNullPredicate GetSqlIsNullPredicate(SqlExpression leftExpression, bool negative)
		{
			SqlIsNullPredicate newSqlIsNullPredicate = new SqlIsNullPredicate(this, leftExpression, negative) ;
			this.sqlPredicate = newSqlIsNullPredicate;
			return newSqlIsNullPredicate;
		}

		public SqlContainsPredicate GetSqlContainsPredicate(SqlExpression leftExpression, SqlExpression rightExpression)
		{
			SqlContainsPredicate newSqlContainsPredicate = new SqlContainsPredicate(this, leftExpression, rightExpression) ;
			this.sqlPredicate = newSqlContainsPredicate;
			return newSqlContainsPredicate;
		}

		public SqlContainsPredicate GetSqlContainsPredicate(SqlColumnAlias leftColumnAlias, SqlExpression rightExpression)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			return GetSqlContainsPredicate(leftSqlColumnAliasReference, rightExpression);
		}

		public SqlFreeTextPredicate GetSqlFreeTextPredicate(SqlExpression leftExpression, SqlExpression rightExpression)
		{
			SqlFreeTextPredicate newSqlFreeTextPredicate = new SqlFreeTextPredicate(this, leftExpression, rightExpression) ;
			this.sqlPredicate = newSqlFreeTextPredicate;
			return newSqlFreeTextPredicate;
		}

		public SqlFreeTextPredicate GetSqlFreeTextPredicate(SqlColumnAlias leftColumnAlias, SqlExpression rightExpression)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			return GetSqlFreeTextPredicate(leftSqlColumnAliasReference, rightExpression);
		}

		public SqlLikePredicate GetSqlLikePredicate(SqlExpression leftExpression, SqlExpression rightExpression) => GetSqlLikePredicate(leftExpression, rightExpression, false, "");

	    public SqlLikePredicate GetSqlLikePredicate(SqlExpression leftExpression, SqlExpression rightExpression, bool negative) => GetSqlLikePredicate(leftExpression, rightExpression, negative, "");

	    public SqlLikePredicate GetSqlLikePredicate(SqlExpression leftExpression, SqlExpression rightExpression, bool negative, string escapeCharacter)
		{
			SqlLikePredicate newSqlLikePredicate = new SqlLikePredicate(this, leftExpression, rightExpression, negative, escapeCharacter) ;
			this.sqlPredicate = newSqlLikePredicate;
			return newSqlLikePredicate;
		}

		public SqlLikePredicate GetSqlLikePredicate(SqlColumnAlias leftColumnAlias, SqlExpression rightExpression)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			return GetSqlLikePredicate(leftSqlColumnAliasReference, rightExpression, false, "");
		}

		public SqlLikePredicate GetSqlLikePredicate(SqlColumnAlias leftColumnAlias, SqlExpression rightExpression, bool negative)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			return GetSqlLikePredicate(leftSqlColumnAliasReference, rightExpression, negative, "");
		}
		
		public SqlLikePredicate GetSqlLikePredicate(SqlColumnAlias leftColumnAlias, SqlExpression rightExpression, bool negative, string escapeCharacter)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			return GetSqlLikePredicate(leftSqlColumnAliasReference, rightExpression, negative, escapeCharacter);
		}

		public SqlInPredicate GetSqlInPredicate(SqlExpression leftExpression) => GetSqlInPredicate(leftExpression, false);

	    public SqlInPredicate GetSqlInPredicate(SqlExpression leftExpression, bool negative)
		{
			SqlInPredicate newSqlInPredicate = new SqlInPredicate(this, leftExpression, negative) ;
			this.sqlPredicate = newSqlInPredicate;
			return newSqlInPredicate;
		}

		public SqlInPredicate GetSqlInPredicate(SqlColumnAlias leftColumnAlias)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			return GetSqlInPredicate(leftSqlColumnAliasReference, false);
		}

		public SqlInPredicate GetSqlInPredicate(SqlColumnAlias leftColumnAlias, bool negative)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			return GetSqlInPredicate(leftSqlColumnAliasReference, negative );
		}


		public SqlAllPredicate GetSqlAllPredicate(SqlExpression leftExpression, SqlCompareOperatorType sqlCompareOperatorType, SqlAllPredicateType sqlAllPredicateType)
		{
			SqlAllPredicate newSqlAllPredicate = new SqlAllPredicate(this, leftExpression, sqlCompareOperatorType, sqlAllPredicateType) ;
			this.sqlPredicate = newSqlAllPredicate;
			return newSqlAllPredicate;
		}

		public SqlAllPredicate GetSqlAllPredicate(SqlExpression leftExpression, SqlCompareOperatorType sqlCompareOperatorType)
		{
			SqlAllPredicate newSqlAllPredicate = new SqlAllPredicate(this, leftExpression, sqlCompareOperatorType, SqlAllPredicateType.All) ;
			this.sqlPredicate = newSqlAllPredicate;
			return newSqlAllPredicate;
		}

		public SqlAllPredicate GetSqlAllPredicate(SqlColumnAlias leftColumnAlias, SqlCompareOperatorType sqlCompareOperatorType, SqlAllPredicateType sqlAllPredicateType)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			return GetSqlAllPredicate(leftSqlColumnAliasReference , sqlCompareOperatorType, sqlAllPredicateType);
		}

		public SqlAllPredicate GetSqlAllPredicate(SqlColumnAlias leftColumnAlias, SqlCompareOperatorType sqlCompareOperatorType)
		{
			SqlColumnAliasReference leftSqlColumnAliasReference = new SqlColumnAliasReference(leftColumnAlias) ;
			return GetSqlAllPredicate(leftSqlColumnAliasReference , sqlCompareOperatorType, SqlAllPredicateType.All);
		}

		
		public SqlExistsPredicate GetSqlExistsPredicate()
		{
			SqlExistsPredicate newSqlExistsPredicate = new SqlExistsPredicate(this) ;
			this.sqlPredicate = newSqlExistsPredicate;
			return newSqlExistsPredicate;
		}

		public bool HasChild()
		{
			if (this.subSqlSearchCondition != null || this.nextSqlSearchCondition != null)
				return true;
			return false;
		}
		
		#region Property  Negative
		
		private bool negative;
		
		public bool Negative
		{
			get => this.negative;
		    set => this.negative = value;
		}
		
		#endregion

		#region Property  SqlPredicate
		
		private SqlPredicate sqlPredicate;
		
		public SqlPredicate SqlPredicate
		{
			get => this.sqlPredicate;
		    set => this.sqlPredicate = value;
		}
		
		#endregion

		#region Property  SubSqlSearchCondition
		
		private SqlSearchCondition subSqlSearchCondition;
		
		public SqlSearchCondition SubSqlSearchCondition
		{
			get => this.subSqlSearchCondition;
		    set => this.subSqlSearchCondition = value;
		}
		
		#endregion

		#region Property  OrNext
		
		private bool orNext = false;
		
		public bool OrNext
		{
			get => this.orNext;
		    set => this.orNext = value;
		}
		
		#endregion

		#region Property  NextSqlSearchCondition
		
		private SqlSearchCondition nextSqlSearchCondition;
		
		public SqlSearchCondition NextSqlSearchCondition
		{
			get => this.nextSqlSearchCondition;
		    set => this.nextSqlSearchCondition = value;
		}
		
		#endregion

		public SqlSearchCondition GetSubSqlSearchCondition()
		{
			if (this.subSqlSearchCondition == null)
				this.subSqlSearchCondition = new SqlSearchCondition(this, true) ;
			return this.subSqlSearchCondition;
		}

		public SqlSearchCondition GetNextSqlSearchCondition()
		{
			if (this.nextSqlSearchCondition == null)
			{
				this.nextSqlSearchCondition = new SqlSearchCondition(this) ;
				return this.nextSqlSearchCondition;								
			}
			SqlSearchCondition sqlSearchCondition = this.nextSqlSearchCondition;
			while (sqlSearchCondition.NextSqlSearchCondition != null)
			{
				sqlSearchCondition = sqlSearchCondition.NextSqlSearchCondition;
			}
			sqlSearchCondition = sqlSearchCondition.GetNextSqlSearchCondition();
			return sqlSearchCondition;
		}

		
		public SqlSearchCondition GetCurrentSqlSearchCondition()
		{
			if (this.nextSqlSearchCondition == null)
			{
				this.nextSqlSearchCondition = new SqlSearchCondition(this) ;
				return this.nextSqlSearchCondition;								
			}
			SqlSearchCondition sqlSearchCondition = this.nextSqlSearchCondition;
			while (sqlSearchCondition.NextSqlSearchCondition != null)
			{
				sqlSearchCondition = sqlSearchCondition.NextSqlSearchCondition;
			}
			return sqlSearchCondition;
		}

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			if (this.sqlPredicate != null)
				this.sqlPredicate.Accept(visitor);
			if (this.subSqlSearchCondition != null)
				this.subSqlSearchCondition.Accept(visitor);
			
			visitor.Visited(this);

			//obs!! we have to do it this way to get right order !!
			if (this.nextSqlSearchCondition != null)
				this.nextSqlSearchCondition.Accept(visitor);

		}
	}
}
