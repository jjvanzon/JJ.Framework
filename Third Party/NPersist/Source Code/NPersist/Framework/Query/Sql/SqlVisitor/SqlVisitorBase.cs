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
using System.Text;
using Puzzle.NPersist.Framework.Sql.Dom;
using Puzzle.NPersist.Framework.Sql.Visitor;
using Puzzle.NPersist.Framework.Exceptions;

namespace Puzzle.NPersist.Framework.Sql.Visitor
{
	/// <summary>
	/// Summary description for SqlVisitorBase.
	/// </summary>
	public class SqlVisitorBase : ISqlVisitor
	{
		public SqlVisitorBase()
		{
		}

		#region Property  Sql
		
		private StringBuilder sqlBuilder = new StringBuilder() ;
		
		public string Sql => this.sqlBuilder.ToString();

	    #endregion

		public StringBuilder SqlBuilder
		{
			get => this.sqlBuilder;
		    set => this.sqlBuilder = value;
		}

		#region Template

		#region Property  LeftEncapsulator
		
		private string leftEncapsulator = "[";
		
		public virtual string LeftEncapsulator
		{
			get => this.leftEncapsulator;
		    set => this.leftEncapsulator = value;
		}
		
		#endregion

		#region Property  RightEncapsulator
		
		private string rightEncapsulator = "]";
		
		public virtual string RightEncapsulator
		{
			get => this.rightEncapsulator;
		    set => this.rightEncapsulator = value;
		}
		
		#endregion

		#region Property  ColumnAliasKeyword
		
		private string columnAliasKeyword = "As ";
		
		public virtual string ColumnAliasKeyword
		{
			get => this.columnAliasKeyword;
		    set => this.columnAliasKeyword = value;
		}
		
		#endregion

		#region Property  TableAliasKeyword
		
		private string tableAliasKeyword = "As ";
		
		public virtual string TableAliasKeyword
		{
			get => this.tableAliasKeyword;
		    set => this.tableAliasKeyword = value;
		}
		
		#endregion


		#endregion

		#region Visiting

		public virtual void Visiting(SqlParenthesisGroup parenthesisGroup)
		{
			if (parenthesisGroup.IsNegative)
				sqlBuilder.Append("-");

			sqlBuilder.Append("(");
			parenthesisGroup.Expression.Accept(this) ; 
			sqlBuilder.Append(")");
		}

		public virtual void Visiting(SqlMathExpression mathExpression)
		{
			mathExpression.LeftOperand.Accept(this) ;

			switch(mathExpression.SqlMathOperator)
			{
				case SqlMathOperatorType.Add:
				{
					sqlBuilder.Append("+");
					break;
				}
				case SqlMathOperatorType.Divide:
				{
					sqlBuilder.Append("/");
					break;
				}
				case SqlMathOperatorType.Multiply:
				{
					sqlBuilder.Append("*");
					break;
				}
				case SqlMathOperatorType.Subtract:
				{
					sqlBuilder.Append("-");
					break;
				}

			}
			mathExpression.RightOperand.Accept(this) ;
		}

		public virtual void Visiting(SqlSelectStatement selectStatement)
		{
			sqlBuilder.Append("Select ");
			if (selectStatement.Distinct)
				sqlBuilder.Append("Distinct ");

			if (selectStatement.Top > -1)
			{
				sqlBuilder.Append("Top " + selectStatement.Top.ToString() + " ");
				if (selectStatement.Percent)
					sqlBuilder.Append("Percent ");
				if (selectStatement.WithTies)
					sqlBuilder.Append("With Ties ");
				
			} 
		}

		public virtual void Visiting(SqlSelectClause selectClause)
		{
		}

		public virtual void Visiting(SqlIntoClause intoClause)
		{
			if (intoClause.NewTableName.Length > 0)
				sqlBuilder.Append(" Into " + EncapsulateTable(intoClause.NewTableName));
		}

		public virtual void Visiting(SqlFromClause fromClause)
		{
			if (fromClause.SqlTableSources.Count > 0)
				sqlBuilder.Append(" From ");
			int i = 0;
			foreach(SqlTableSource sqlTableSource in fromClause.SqlTableSources)
			{
				sqlTableSource.Accept(this);
				if (i < fromClause.SqlTableSources.Count - 1)
					if (fromClause.SqlTableSources[i + 1] is SqlAliasTableSource)
						sqlBuilder.Append(", ");				
				i++;
			}
		}

		public virtual void Visiting(SqlWhereClause whereClause)
		{
			if (whereClause.HasChild())
				sqlBuilder.Append(" Where ");
		}

		public virtual void Visiting(SqlGroupByClause groupByClause)
		{
			//sqlBuilder.Append("GroupBy ");
		}

		public virtual void Visiting(SqlHavingClause havingClause)
		{
			//sqlBuilder.Append("Having ");
		}

		public virtual void Visiting(SqlOrderByClause orderByClause)
		{
			if (orderByClause.SqlOrderByItems.Count > 0)
				sqlBuilder.Append(" Order By ");
		}

		public virtual void Visiting(SqlDatabase database)
		{
			//
		}

		public virtual void Visiting(SqlTable table)
		{
			//
		}

		public virtual void Visiting(SqlColumn column)
		{
			sqlBuilder.Append(EncapsulateTable(column.SqlTable.Name) + ".");
			string columnName = column.Name;
			sqlBuilder.Append(Encapsulate(columnName));
		}

		public virtual void Visiting(SqlTableAlias tableAlias)
		{
			string tableName = tableAlias.SqlTable.Name;
			string alias = tableAlias.Alias;
			sqlBuilder.Append(EncapsulateTable(tableName));
			if (tableName != alias)
				sqlBuilder.Append(" " + this.TableAliasKeyword + EncapsulateTable(alias));
		}

		public virtual void Visiting(SqlColumnAlias columnAlias)
		{
			sqlBuilder.Append(EncapsulateTable(columnAlias.SqlTableAlias.Alias) + ".");
			string columnName = columnAlias.SqlColumn.Name;
			string alias = columnAlias.Alias;
			sqlBuilder.Append(Encapsulate(columnName));
			if (alias.Length > 0)
				if (columnName != alias)
					sqlBuilder.Append(" " + this.ColumnAliasKeyword + Encapsulate(alias));
		}

		public virtual void Visiting(SqlExpressionAlias expressionAlias)
		{
            if (expressionAlias.SqlExpression is SqlSelectStatement)
                sqlBuilder.Append("(");

			expressionAlias.SqlExpression.Accept(this);

            if (expressionAlias.SqlExpression is SqlSelectStatement)
                sqlBuilder.Append(")");

            string alias = expressionAlias.Alias;
			if (alias.Length > 0)
				sqlBuilder.Append(" " + this.ColumnAliasKeyword + Encapsulate(alias));
		}

		public virtual void Visiting(SqlAllColumnsSelectListItem allColumnsSelectListItem) => sqlBuilder.Append("*");

	    public virtual void Visiting(SqlAllColumnsInTableSelectListItem allColumnsInTableSelectListItem)
		{
		}

		public virtual void Visiting(SqlAliasSelectListItem aliasSelectListItem)
		{
			//
		}

		public virtual void Visiting(SqlExpressionSelectListItem expressionSelectListItem)
		{
			//
		}

		public virtual void Visiting(SqlColumnAliasReference columnAliasReference)
		{
			SqlColumnAlias columnAlias = columnAliasReference.SqlColumnAlias;
			SqlTableAlias tableAlias = columnAlias.SqlTableAlias;
			//string alias = columnAlias.Alias;
			string alias = columnAlias.SqlColumn.Name ; // weird, but that's how Sql Server likes it...(possibly this should be moved to Sql Server subclass, dunno what is standard...)
			string tblAlias = tableAlias.Alias;
			sqlBuilder.Append(EncapsulateTable(tblAlias));
			sqlBuilder.Append(".");
			sqlBuilder.Append(Encapsulate(alias));
		}

		public virtual void Visiting(SqlTableAliasReference tableAliasReference) => sqlBuilder.Append(EncapsulateTable(tableAliasReference.SqlTableAlias.Alias));

	    public virtual void Visiting(SqlExpressionAliasReference expressionAliasReference) => sqlBuilder.Append(Encapsulate(expressionAliasReference.SqlExpressionAlias.Alias));

	    public virtual void Visiting(SqlAliasTableSource aliasTableSource)
		{
			//
		}

		public virtual void Visiting(SqlWhereClauseItem whereClauseItem)
		{
			//
		}

		public virtual void Visiting(SqlComparePredicate comparePredicate)
		{
			//
		}

		public virtual void Visiting(SqlLikePredicate likePredicate)
		{
			likePredicate.LeftExpression.Accept(this);
			if (likePredicate.Negative)
				sqlBuilder.Append(" Not");									
			sqlBuilder.Append(" Like ");
			likePredicate.RightExpression.Accept(this);				
			if (likePredicate.EscapeCharacter.Length > 0)
				sqlBuilder.Append(" Escape " + EncapsulateString(FormatString(likePredicate.EscapeCharacter)));									
		}

		public virtual void Visiting(SqlBetweenPredicate betweenPredicate)
		{
			betweenPredicate.LeftExpression.Accept(this);
			if (betweenPredicate.Negative)
				sqlBuilder.Append(" Not");									
			sqlBuilder.Append(" Between ");									
			betweenPredicate.MiddleExpression.Accept(this);
			sqlBuilder.Append(" And ");									
			betweenPredicate.RightExpression.Accept(this);			
		}

		public virtual void Visiting(SqlIsNullPredicate isNullPredicate)
		{
			isNullPredicate.LeftExpression.Accept(this);
			sqlBuilder.Append(" Is");									
			if (isNullPredicate.Negative)
				sqlBuilder.Append(" Not");									
			sqlBuilder.Append(" Null");												
		}

		public virtual void Visiting(SqlContainsPredicate containsPredicate)
		{
			sqlBuilder.Append("Contains(");									
			containsPredicate.LeftExpression.Accept(this);							
			sqlBuilder.Append(", ");									
			containsPredicate.RightExpression.Accept(this);				
			sqlBuilder.Append(")");									
		}

		public virtual void Visiting(SqlFreeTextPredicate freeTextPredicate)
		{
			sqlBuilder.Append("FreeText(");									
			freeTextPredicate.LeftExpression.Accept(this);							
			sqlBuilder.Append(", ");									
			freeTextPredicate.RightExpression.Accept(this);				
			sqlBuilder.Append(")");				
		}

		public virtual void Visiting(SqlInPredicate inPredicate)
		{
			inPredicate.LeftExpression.Accept(this);
			if (inPredicate.Negative)
				sqlBuilder.Append(" Not");									
			sqlBuilder.Append(" In");									
			sqlBuilder.Append(" (");					
			foreach (SqlInPredicateItem sqlInPredicateItem in inPredicate.SqlInPredicateItems)
			{
				sqlInPredicateItem.Accept(this);
				sqlBuilder.Append(", ");								
			}
			if (inPredicate.SqlInPredicateItems.Count > 0)
				sqlBuilder.Length -= 2;

			sqlBuilder.Append(")");					
		}

		public virtual void Visiting(SqlAllPredicate allPredicate)
		{
			allPredicate.LeftExpression.Accept(this); 
			allPredicate.SqlCompareOperator.Accept(this);
			switch (allPredicate.SqlAllPredicateType)
			{
				case SqlAllPredicateType.All :
					sqlBuilder.Append(" All ");
					break;
				case SqlAllPredicateType.Any :
					sqlBuilder.Append(" Any ");
					break;
				case SqlAllPredicateType.Some :
					sqlBuilder.Append(" Some ");
					break;
				default :
					break;
			}
			sqlBuilder.Append("(");
			allPredicate.SqlSelectStatement.Accept(this);				
			sqlBuilder.Append(")");
		}

		public virtual void Visiting(SqlExistsPredicate existsPredicate)
		{
			sqlBuilder.Append("Exists (");
			existsPredicate.SqlSelectStatement.Accept(this);				
			sqlBuilder.Append(")");			
		}

		public virtual void Visiting(SqlInPredicateItem inPredicateItem)
		{
			if (inPredicateItem.SqlExpression != null)
				inPredicateItem.SqlExpression.Accept(this); 
			else if (inPredicateItem.SqlSelectStatement != null)
				inPredicateItem.SqlSelectStatement.Accept(this); 
		}

		public virtual void Visiting(SqlBooleanLiteral booleanLiteral) => sqlBuilder.Append(EncapsulateBoolean(FormatBoolean(booleanLiteral.BooleanValue)));

	    public virtual void Visiting(SqlNumericLiteral numericLiteral) => sqlBuilder.Append(EncapsulateNumeric(FormatNumeric(numericLiteral.DecimalValue)));

	    public virtual void Visiting(SqlStringLiteral stringLiteral) => sqlBuilder.Append(EncapsulateString(FormatString(stringLiteral.StringValue)));

	    public virtual void Visiting(SqlDateTimeLiteral dateTimeLiteral) => sqlBuilder.Append(EncapsulateDateTime(FormatDateTime(dateTimeLiteral.DateTimeValue)));

	    public virtual void Visiting(SqlCompareOperator compareOperator)
		{
			switch (compareOperator.SqlCompareOperatorType)
			{
				case SqlCompareOperatorType.Equals :
					sqlBuilder.Append(" = ");
					break;
				case SqlCompareOperatorType.GreaterThan  :
					sqlBuilder.Append(" > ");
					break;
				case SqlCompareOperatorType.GreaterThanOrEqual  :
					sqlBuilder.Append(" >= ");
					break;
				case SqlCompareOperatorType.Like   :
					sqlBuilder.Append(" Like ");
					break;
				case SqlCompareOperatorType.NotEquals   :
					sqlBuilder.Append(" != ");
					break;
				case SqlCompareOperatorType.NotGreaterThan   :
					sqlBuilder.Append(" !> ");
					break;
				case SqlCompareOperatorType.NotSmallerThan   :
					sqlBuilder.Append(" !< ");
					break;
				case SqlCompareOperatorType.SmallerOrGreaterThan   :
					sqlBuilder.Append(" <> ");
					break;
				case SqlCompareOperatorType.SmallerThan   :
					sqlBuilder.Append(" < ");
					break;
				case SqlCompareOperatorType.SmallerThanOrEqual   :
					sqlBuilder.Append(" <= ");
					break;
				default :
					break;
			}			
			
		}

		public virtual void Visiting(SqlSearchCondition searchCondition)
		{
			if (searchCondition.Negative)
				sqlBuilder.Append("Not ");

			if (searchCondition.PrevSqlSearchCondition == null)
				sqlBuilder.Append("(");
		}

		public virtual void Visiting(SqlAllFullTextColumnsInTable allFullTextColumnsInTable)
		{
			allFullTextColumnsInTable.SqlTableAliasReference.Accept(this);
			sqlBuilder.Append(".*");			
		}

		public virtual void Visiting(SqlOrderByItem orderByItem)
		{
			orderByItem.SqlExpression.Accept(this);
			if (orderByItem.Descending)
				sqlBuilder.Append(" Desc");
			sqlBuilder.Append(", ");
		}

		public virtual void Visiting(SqlParameter parameter) => sqlBuilder.Append(parameter.GetName());

	    public void Visiting(SqlDistinctFunction distinctFunction)
		{
			if (distinctFunction.SqlExpression != null)
			{
				sqlBuilder.Append("Distinct(");			
				distinctFunction.SqlExpression.Accept(this);
				sqlBuilder.Append(")");			
			}
		}

		public virtual void Visiting(SqlCountFunction countFunction)
		{
			if (countFunction.SqlExpression != null)
			{
				sqlBuilder.Append("Count(");			
				if (countFunction.Distinct)
					sqlBuilder.Append("Distinct ");			
				countFunction.SqlExpression.Accept(this);
				sqlBuilder.Append(")");			
			}
			else
				sqlBuilder.Append("Count(*)");			
		}

		public void Visiting(SqlAvgFunction avgFunction)
		{
			if (avgFunction.SqlExpression != null)
			{
				sqlBuilder.Append("Avg(");			
				if (avgFunction.Distinct)
					sqlBuilder.Append("Distinct ");			
				avgFunction.SqlExpression.Accept(this);
				sqlBuilder.Append(")");			
			}
			else
				sqlBuilder.Append("Avg(*)");						
		}

		public void Visiting(SqlMinFunction minFunction)
		{
			if (minFunction.SqlExpression != null)
			{
				sqlBuilder.Append("Min(");			
				if (minFunction.Distinct)
					sqlBuilder.Append("Distinct ");			
				minFunction.SqlExpression.Accept(this);
				sqlBuilder.Append(")");			
			}
			else
				sqlBuilder.Append("Min(*)");		
		}

		public void Visiting(SqlMaxFunction maxFunction)
		{
			if (maxFunction.SqlExpression != null)
			{
				sqlBuilder.Append("Max(");			
				if (maxFunction.Distinct)
					sqlBuilder.Append("Distinct ");			
				maxFunction.SqlExpression.Accept(this);
				sqlBuilder.Append(")");			
			}
			else
				sqlBuilder.Append("Max(*)");				
		}

		public void Visiting(SqlSumFunction sumFunction)
		{
			if (sumFunction.SqlExpression != null)
			{
				sqlBuilder.Append("Sum(");			
				if (sumFunction.Distinct)
					sqlBuilder.Append("Distinct ");			
				sumFunction.SqlExpression.Accept(this);
				sqlBuilder.Append(")");			
			}
			else
				sqlBuilder.Append("Sum(*)");							
		}

        public void Visiting(SqlSoundexFunction soundexFunction)
        {
            if (soundexFunction.SqlExpression != null)
            {
                sqlBuilder.Append("Soundex(");
                soundexFunction.SqlExpression.Accept(this);
                sqlBuilder.Append(")");
            }
            else
                throw new NPersistException("Soundex must take a parameter");
        }

		public virtual void Visiting(SqlDeleteStatement deleteStatement)
		{
			
		}

		public virtual void Visiting(SqlDeleteClause deleteClause) => sqlBuilder.Append("Delete");

	    public virtual void Visiting(SqlInsertStatement insertStatement)
		{
			insertStatement.SqlInsertClause.Accept(this);
			if (insertStatement.DefaultValues)
				sqlBuilder.Append(" Default Values");				
			else
			{
				if (insertStatement.SqlColumnList.Count > 0)
				{
					sqlBuilder.Append(" (");				
					foreach (SqlColumn sqlColumn in insertStatement.SqlColumnList)
					{
						sqlColumn.Accept(this);
						sqlBuilder.Append(", ");									
					}
				
					sqlBuilder.Length -= 2;
					sqlBuilder.Append(") Values (");				
					foreach (SqlExpression sqlExpression in insertStatement.ValueList)
					{
						sqlExpression.Accept(this);
						sqlBuilder.Append(", ");									
					}
					sqlBuilder.Length -= 2;
					sqlBuilder.Append(")");					
				}
			}
		}

		public virtual void Visiting(SqlInsertClause insertClause) => sqlBuilder.Append("Insert Into " + EncapsulateTable(insertClause.SqlTable.Name));

	    public virtual void Visiting(SqlNullValue nullValue) => sqlBuilder.Append("Null");

	    public virtual void Visiting(SqlDefaultValue defaultValue) => sqlBuilder.Append("Default");

	    public virtual void Visiting(SqlUpdateStatement updateStatement)
		{
			updateStatement.SqlUpdateClause.Accept(this);
			sqlBuilder.Append(" Set ");
			
			int i = 0;
			foreach (SqlColumn sqlColumn in updateStatement.SqlColumnList)
			{
				SqlExpression sqlExpression = (SqlExpression) updateStatement.ValueList[i];
				sqlColumn.Accept(this);
				sqlBuilder.Append(" = ");									
				sqlExpression.Accept(this);
				sqlBuilder.Append(", ");									
				i++;
			}
			sqlBuilder.Length -= 2;
			updateStatement.SqlFromClause.Accept(this);			
			updateStatement.SqlWhereClause.Accept(this);			
		}

		public virtual void Visiting(SqlUpdateClause updateClause) => sqlBuilder.Append("Update " + EncapsulateTable(updateClause.SqlTable.Name));

	    public virtual void Visiting(SqlJoinTableSource sqlJoinTableSource)
		{
			switch (sqlJoinTableSource.SqlJoinType)
			{
				case SqlJoinType.Inner :
					sqlBuilder.Append(" Inner Join ");
					break;
				case SqlJoinType.LeftOuter :
					sqlBuilder.Append(" Left Outer Join ");
					break;
				case SqlJoinType.RightOuter :
					sqlBuilder.Append(" Right Outer Join ");
					break;
				case SqlJoinType.FullOuter :
					sqlBuilder.Append(" Full Outer Join ");
					break;
				default :
					break;
			}
			sqlBuilder.Append(" ");
			if (sqlJoinTableSource.LeftSqlTableAlias != null)
				sqlJoinTableSource.LeftSqlTableAlias.Accept(this);
//			if (sqlJoinTableSource.RightTableAlias != null)
//				sqlJoinTableSource.RightTableAlias.Accept(this);
			sqlBuilder.Append(" On ");
			if (sqlJoinTableSource.SqlSearchCondition != null)
				sqlJoinTableSource.SqlSearchCondition.Accept(this);
		}

		#endregion

		#region Visited

		public virtual void Visited(SqlParenthesisGroup parenthesisGroup)
		{
		}

		public virtual void Visited(SqlMathExpression mathExpression)
		{
		}

		public virtual void Visited(SqlSelectStatement selectStatement)
		{
		}

		public virtual void Visited(SqlSelectClause selectClause)
		{
			if (selectClause.SqlSelectListItems.Count > 0)
			{
				sqlBuilder.Length -= 2;
			}
		}

		public virtual void Visited(SqlIntoClause intoClause)
		{
			//
		}

		public virtual void Visited(SqlFromClause fromClause)
		{
//			if (fromClause.SqlTableSources.Count > 0)
//				sqlBuilder.Length -= 2;
		}

		public virtual void Visited(SqlWhereClause whereClause)
		{

		}

		public virtual void Visited(SqlGroupByClause groupByClause)
		{
			//
		}

		public virtual void Visited(SqlHavingClause havingClause)
		{
			//
		}

		public virtual void Visited(SqlOrderByClause orderByClause)
		{
			if (orderByClause.SqlOrderByItems.Count > 0)
			{
				sqlBuilder.Length -= 2;
			}
		}

		public virtual void Visited(SqlDatabase database)
		{
			//
		}

		public virtual void Visited(SqlTable table)
		{
			//
		}

		public virtual void Visited(SqlColumn column)
		{
			//
		}

		public virtual void Visited(SqlTableAlias tableAlias)
		{
		}

		public virtual void Visited(SqlColumnAlias columnAlias)
		{
		}

		public virtual void Visited(SqlExpressionAlias expressionAlias)
		{
			
		}

		public virtual void Visited(SqlAllColumnsSelectListItem allColumnsSelectListItem) => sqlBuilder.Append(", ");

	    public virtual void Visited(SqlAllColumnsInTableSelectListItem allColumnsInTableSelectListItem) => sqlBuilder.Append(".*, ");

	    public virtual void Visited(SqlAliasSelectListItem aliasSelectListItem) => sqlBuilder.Append(", ");

	    public virtual void Visited(SqlExpressionSelectListItem expressionSelectListItem) => sqlBuilder.Append(", ");

	    public virtual void Visited(SqlColumnAliasReference columnAliasReference)
		{
			//
		}

		public virtual void Visited(SqlTableAliasReference tableAliasReference)
		{

		}

		public virtual void Visited(SqlExpressionAliasReference expressionAliasReference)
		{
			
		}

		public virtual void Visited(SqlAliasTableSource aliasTableSource)
		{
			//sqlBuilder.Append(", ");
		}

		public virtual void Visited(SqlJoinTableSource sqlJoinTableSource)
		{
			//sqlBuilder.Append(", ");
		}

		public virtual void Visited(SqlWhereClauseItem whereClauseItem)
		{
			//
		}

		public virtual void Visited(SqlComparePredicate comparePredicate)
		{
			//
		}

		public virtual void Visited(SqlLikePredicate likePredicate)
		{
			
		}

		public virtual void Visited(SqlBetweenPredicate betweenPredicate)
		{
			
		}

		public virtual void Visited(SqlIsNullPredicate isNullPredicate)
		{

		}

		public virtual void Visited(SqlContainsPredicate containsPredicate)
		{
			
		}

		public virtual void Visited(SqlFreeTextPredicate freeTextPredicate)
		{
			
		}

		public virtual void Visited(SqlInPredicate inPredicate)
		{
			
		}

		public virtual void Visited(SqlInPredicateItem inPredicateItem)
		{
			
		}

		public virtual void Visited(SqlAllPredicate allPredicate)
		{
			
		}

		public virtual void Visited(SqlExistsPredicate existsPredicate)
		{
			
		}

		public virtual void Visited(SqlBooleanLiteral booleanLiteral)
		{
			
		}

		public virtual void Visited(SqlNumericLiteral numericLiteral)
		{
			
		}

		public virtual void Visited(SqlStringLiteral stringLiteral)
		{

		}

		public virtual void Visited(SqlDateTimeLiteral dateTimeLiteral)
		{
			
		}

		public virtual void Visited(SqlCompareOperator compareOperator)
		{
		}

		public virtual void Visited(SqlSearchCondition searchCondition)
		{
			if (searchCondition.NextSqlSearchCondition != null)
			{								
				if (searchCondition.SqlPredicate != null || searchCondition.SubSqlSearchCondition != null )
				{
					if (searchCondition.OrNext)
						sqlBuilder.Append(" Or ");
					else
						sqlBuilder.Append(" And ");									
				}
			}
			else
				sqlBuilder.Append(")");			
		}

		public virtual void Visited(SqlAllFullTextColumnsInTable allFullTextColumnsInTable)
		{
			
		}

		public virtual void Visited(SqlOrderByItem orderByItem)
		{
			
		}

		public virtual void Visited(SqlParameter parameter)
		{
			
		}

		public void Visited(SqlDistinctFunction distinctFunction)
		{
			
		}

		public virtual void Visited(SqlCountFunction countFunction)
		{
			
		}

		public void Visited(SqlAvgFunction avgFunction)
		{
			
		}

		public void Visited(SqlMinFunction minFunction)
		{
			
		}

		public void Visited(SqlMaxFunction maxFunction)
		{
			
		}

		public void Visited(SqlSumFunction sumFunction)
		{
			
		}

        public void Visited(SqlSoundexFunction soundexFunction)
        {

        }

		public virtual void Visited(SqlDeleteStatement deleteStatement)
		{
			
		}

		public virtual void Visited(SqlDeleteClause deleteClause)
		{
			
		}

		public virtual void Visited(SqlInsertStatement insertStatement)
		{
			
		}

		public virtual void Visited(SqlInsertClause insertClause)
		{
			
		}

		public virtual void Visited(SqlNullValue nullValue)
		{
			
		}

		public virtual void Visited(SqlDefaultValue defaultValue)
		{
			
		}

		public virtual void Visited(SqlUpdateStatement updateStatement)
		{
			
		}

		public virtual void Visited(SqlUpdateClause updateClause)
		{
			
		}

		#endregion

		protected virtual string Encapsulate(string content) => this.LeftEncapsulator + content + this.RightEncapsulator;

	    protected virtual string EncapsulateTable(string content)
        {
            string[] parts = content.Split(".".ToCharArray());
            StringBuilder result = new StringBuilder();
            foreach (string part in parts)
                result.Append(this.LeftEncapsulator + part + this.RightEncapsulator + ".");
            result.Length--;
            return result.ToString();
        }

		protected virtual string EncapsulateString(string content) => "'" + content + "'";

	    protected virtual string EncapsulateDateTime(string content) => "'" + content + "'";

	    protected virtual string EncapsulateBoolean(string content) => content;

	    protected virtual string EncapsulateNumeric(string content) => content;

	    protected virtual string FormatString(string content) => content.Replace("'", "''");

	    protected virtual string FormatDateTime(DateTime content) => content.ToString("yyyy-MM-dd HH:mm:ss");

	    protected virtual string FormatBoolean(bool content) => content.ToString(System.Globalization.CultureInfo.InvariantCulture);

	    protected virtual string FormatNumeric(decimal content) => content.ToString(System.Globalization.CultureInfo.InvariantCulture);
	}
}
