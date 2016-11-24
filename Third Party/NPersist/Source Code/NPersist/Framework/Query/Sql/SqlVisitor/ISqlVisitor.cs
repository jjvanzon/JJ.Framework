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
	/// Summary description for ISqlVisitor.
	/// </summary>
	public interface ISqlVisitor
	{
		#region Visiting

		void Visiting(SqlParenthesisGroup parenthesisGroup);

		void Visiting(SqlMathExpression mathExpression);

		void Visiting(SqlSelectStatement selectStatement);

		void Visiting(SqlSelectClause selectClause);

		void Visiting(SqlIntoClause intoClause);
	
		void Visiting(SqlFromClause fromClause);
	
		void Visiting(SqlWhereClause whereClause);
	
		void Visiting(SqlGroupByClause groupByClause);
	
		void Visiting(SqlHavingClause havingClause);
	
		void Visiting(SqlDatabase database);

		void Visiting(SqlTable table);

		void Visiting(SqlColumn column);
	
		void Visiting(SqlTableAlias tableAlias);

		void Visiting(SqlColumnAlias columnAlias);

		void Visiting(SqlExpressionAlias expressionAlias);

		void Visiting(SqlOrderByClause orderByClause);

		void Visiting(SqlAllColumnsSelectListItem allColumnsSelectListItem);

		void Visiting(SqlAllColumnsInTableSelectListItem allColumnsInTableSelectListItem);

		void Visiting(SqlAliasSelectListItem aliasSelectListItem);

		void Visiting(SqlExpressionSelectListItem expressionSelectListItem);

		void Visiting(SqlColumnAliasReference columnAliasReference);
		
		void Visiting(SqlTableAliasReference tableAliasReference);

		void Visiting(SqlExpressionAliasReference expressionAliasReference);

		void Visiting(SqlAliasTableSource aliasTableSource);

		void Visiting(SqlJoinTableSource joinTableSource);

		void Visiting(SqlWhereClauseItem whereClauseItem);

		void Visiting(SqlComparePredicate comparePredicate);

		void Visiting(SqlLikePredicate likePredicate);

		void Visiting(SqlBetweenPredicate betweenPredicate);

		void Visiting(SqlIsNullPredicate isNullPredicate);

		void Visiting(SqlContainsPredicate containsPredicate);

		void Visiting(SqlFreeTextPredicate freeTextPredicate);

		void Visiting(SqlInPredicate inPredicate);

		void Visiting(SqlAllPredicate allPredicate);

		void Visiting(SqlExistsPredicate existsPredicate);

		void Visiting(SqlInPredicateItem inPredicateItem);

		void Visiting(SqlBooleanLiteral booleanLiteral);

		void Visiting(SqlNumericLiteral numericLiteral);

		void Visiting(SqlStringLiteral stringLiteral);

		void Visiting(SqlDateTimeLiteral dateTimeLiteral);

		void Visiting(SqlCompareOperator compareOperator);

		void Visiting(SqlSearchCondition searchCondition);

		void Visiting(SqlAllFullTextColumnsInTable allFullTextColumnsInTable);

		void Visiting(SqlOrderByItem orderByItem);

		void Visiting(SqlParameter parameter);

		void Visiting(SqlDistinctFunction distinctFunction);

		void Visiting(SqlCountFunction countFunction);

		void Visiting(SqlAvgFunction avgFunction);

		void Visiting(SqlMinFunction minFunction);

		void Visiting(SqlMaxFunction maxFunction);

		void Visiting(SqlSumFunction sumFunction);

        void Visiting(SqlSoundexFunction sumFunction);

		void Visiting(SqlDeleteStatement deleteStatement);

		void Visiting(SqlDeleteClause deleteClause);

		void Visiting(SqlInsertStatement insertStatement);

		void Visiting(SqlInsertClause insertClause);

		void Visiting(SqlNullValue nullValue);

		void Visiting(SqlDefaultValue defaultValue);

		void Visiting(SqlUpdateStatement updateStatement);

		void Visiting(SqlUpdateClause updateClause);

		#endregion

		#region Visited

		void Visited(SqlParenthesisGroup parenthesisGroup);

		void Visited(SqlMathExpression mathExpression);

		void Visited(SqlSelectStatement selectStatement);

		void Visited(SqlSelectClause selectClause);

		void Visited(SqlIntoClause intoClause);
	
		void Visited(SqlFromClause fromClause);
	
		void Visited(SqlWhereClause whereClause);
	
		void Visited(SqlGroupByClause groupByClause);
	
		void Visited(SqlHavingClause havingClause);
	
		void Visited(SqlDatabase database);

		void Visited(SqlTable table);

		void Visited(SqlColumn column);
	
		void Visited(SqlTableAlias tableAlias);

		void Visited(SqlColumnAlias columnAlias);

		void Visited(SqlExpressionAlias expressionAlias);

		void Visited(SqlOrderByClause orderByClause);

		void Visited(SqlAllColumnsSelectListItem allColumnsSelectListItem);

		void Visited(SqlAllColumnsInTableSelectListItem allColumnsInTableSelectListItem);

		void Visited(SqlAliasSelectListItem aliasSelectListItem);

		void Visited(SqlExpressionSelectListItem expressionSelectListItem);

		void Visited(SqlColumnAliasReference columnAliasReference);

		void Visited(SqlTableAliasReference tableAliasReference);

		void Visited(SqlExpressionAliasReference expressionAliasReference);

		void Visited(SqlAliasTableSource aliasTableSource);

		void Visited(SqlJoinTableSource sqlJoinTableSource);

		void Visited(SqlWhereClauseItem whereClauseItem);

		void Visited(SqlComparePredicate comparePredicate);

		void Visited(SqlLikePredicate likePredicate);

		void Visited(SqlBetweenPredicate betweenPredicate);

		void Visited(SqlIsNullPredicate isNullPredicate);

		void Visited(SqlContainsPredicate containsPredicate);

		void Visited(SqlFreeTextPredicate freeTextPredicate);

		void Visited(SqlInPredicate inPredicate);

		void Visited(SqlInPredicateItem inPredicateItem);

		void Visited(SqlAllPredicate allPredicate);

		void Visited(SqlExistsPredicate existsPredicate);

		void Visited(SqlBooleanLiteral booleanLiteral);

		void Visited(SqlNumericLiteral numericLiteral);

		void Visited(SqlStringLiteral stringLiteral);

		void Visited(SqlDateTimeLiteral dateTimeLiteral);

		void Visited(SqlCompareOperator compareOperator);

		void Visited(SqlSearchCondition searchCondition);

		void Visited(SqlAllFullTextColumnsInTable allFullTextColumnsInTable);

		void Visited(SqlOrderByItem orderByItem);

		void Visited(SqlParameter parameter);

		void Visited(SqlDistinctFunction distinctFunction);

		void Visited(SqlCountFunction countFunction);

		void Visited(SqlAvgFunction avgFunction);

		void Visited(SqlMinFunction minFunction);

		void Visited(SqlMaxFunction maxFunction);

		void Visited(SqlSumFunction sumFunction);

        void Visited(SqlSoundexFunction sumFunction);

		void Visited(SqlDeleteStatement deleteStatement);

		void Visited(SqlDeleteClause deleteClause);

		void Visited(SqlInsertStatement insertStatement);

		void Visited(SqlInsertClause insertClause);

		void Visited(SqlNullValue nullValue);

		void Visited(SqlDefaultValue defaultValue);

		void Visited(SqlUpdateStatement updateStatement);

		void Visited(SqlUpdateClause updateClause);

		#endregion

		string Sql { get; }

		#region Template

		string LeftEncapsulator { get; set; }
		
		string RightEncapsulator { get; set; }

		string ColumnAliasKeyword { get; set; }

		string TableAliasKeyword { get; set; }

		#endregion
	}
}
