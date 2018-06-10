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
using System.Text;
using Puzzle.NPath.Framework.CodeDom;

namespace Puzzle.NPath.Framework
{
	public class TestEmitter
	{
		private StringBuilder code;

		public virtual string EmitQuery(NPathSelectQuery query)
		{
			code = new StringBuilder();
			EmitSelect(query);
			EmitFrom(query);
			EmitWhere(query);
			EmitOrderBy(query);
			return code.ToString();
		}

		protected virtual void EmitOrderBy(NPathSelectQuery query)
		{
			if (query.OrderBy != null)
			{
				Write("order by "); // do not localize
				foreach (SortProperty property in query.OrderBy.SortProperties)
				{
					EmitExpression(property.Expression);
					Write(" ");
					Write(property.Direction);

					if (property != query.OrderBy.SortProperties[query.OrderBy.SortProperties.Count - 1])
						Write(",");
				}
				WriteLine();
			}
		}

		protected virtual void EmitWhere(NPathSelectQuery query)
		{
			if (query.Where == null)
				return;

			Write("where "); // do not localize
			EmitExpression(query.Where.Expression);
			WriteLine();
		}

		protected virtual void EmitExpression(IValue expression)
		{
			if (expression is NPathNotExpression)
			{
				NPathNotExpression value = (NPathNotExpression) expression;
				EmitNot(value);
			}
			if (expression is NPathFunction)
			{
				NPathFunction value = (NPathFunction) expression;
				EmitFunction(value);
			}
			if (expression is NPathParameter)
			{
				NPathParameter value = (NPathParameter) expression;
				EmitParameter(value);
			}
			if (expression is NPathNullValue)
			{
				NPathNullValue value = (NPathNullValue) expression;
				EmitNullValue(value);
			}
			if (expression is NPathBetweenExpression)
			{
				NPathBetweenExpression value = (NPathBetweenExpression) expression;
				EmitBetween(value);
			}
			if (expression is NPathBooleanValue)
			{
				NPathBooleanValue value = (NPathBooleanValue) expression;
				EmitBooleanValue(value);
			}
			if (expression is NPathDecimalValue)
			{
				NPathDecimalValue value = (NPathDecimalValue) expression;
				EmitDecimalValue(value);
			}
			if (expression is NPathDateTimeValue)
			{
				NPathDateTimeValue value = (NPathDateTimeValue) expression;
				EmitDateTimeValue(value);
			}
			if (expression is NPathGuidValue)
			{
				NPathGuidValue value = (NPathGuidValue) expression;
				EmitGuidValue(value);
			}
			if (expression is NPathStringValue)
			{
				NPathStringValue value = (NPathStringValue) expression;
				EmitStringValue(value);
			}
			if (expression is NPathIdentifier)
			{
				NPathIdentifier propertyPath = (NPathIdentifier) expression;
				EmitPropertyPath(propertyPath);
			}
			if (expression is NPathPropertyFilter)
			{
				NPathPropertyFilter propertyFilter = (NPathPropertyFilter) expression;
				EmitPropertyFilter(propertyFilter);
			}
			if (expression is NPathParenthesisGroup)
			{
				NPathParenthesisGroup parenthesisGroup = (NPathParenthesisGroup) expression;
				EmitParenthesisGroup(parenthesisGroup);
			}
			if (expression is NPathMathExpression)
			{
				NPathMathExpression mathExpression = (NPathMathExpression) expression;
				EmitMathExpression(mathExpression);
			}
			if (expression is NPathCompareExpression)
			{
				NPathCompareExpression compareExpression = (NPathCompareExpression) expression;
				EmitCompareExpression(compareExpression);
			}

			if (expression is NPathBooleanExpression)
			{
				NPathBooleanExpression boolExpression = (NPathBooleanExpression) expression;
				EmitBooleanExpression(boolExpression);
			}
			if (expression is NPathInExpression)
			{
				NPathInExpression value = (NPathInExpression) expression;
				EmitIn(value);
			}
			if (expression is NPathSearchFunction)
			{
				NPathSearchFunction value = (NPathSearchFunction) expression;
				EmitSearchFunction(value);
			}
		}

		protected virtual void EmitNot(NPathNotExpression notExpression)
		{
			Write("(not "); // do not localize
			EmitExpression(notExpression.Expression);
			Write(")");
		}

		protected virtual void EmitNullValue(NPathNullValue nullValue) => Write("null");

	    protected virtual void EmitFunction(NPathFunction function)
		{
			if (function is NPathSumStatement)
				Write("sum");
			if (function is NPathCountStatement)
				Write("count");
			if (function is NPathAvgStatement)
				Write("avg");
			if (function is NPathMinStatement)
				Write("min");
			if (function is NPathMaxStatement)
				Write("max");
			if (function is NPathIsNullStatement)
				Write("isnull");

			Write("(");
			EmitExpression(function.Expression);
			Write(")");
		}

		protected virtual void EmitParameter(NPathParameter parameter) => Write("?");

	    protected virtual void EmitBetween(NPathBetweenExpression betweenExpression)
		{
			EmitExpression(betweenExpression.TestExpression);
			Write(" between "); // do not localize
			EmitExpression(betweenExpression.FromExpression);
			Write(" and "); // do not localize
			EmitExpression(betweenExpression.EndExpression);
		}

		protected virtual void EmitIn(NPathInExpression inExpression)
		{
			EmitExpression(inExpression.TestExpression);
			Write(" in ( "); // do not localize

			foreach (IValue expression in inExpression.Values)
			{
				EmitExpression(expression);
				if (expression != inExpression.Values[inExpression.Values.Count - 1])
					Write(",");
			}
			Write(" ) ");
		}

		protected virtual void EmitBooleanExpression(NPathBooleanExpression booleanExpression)
		{
			Write("(");
			EmitExpression(booleanExpression.LeftOperand);
			Write(" " + booleanExpression.Operator + " ");
			EmitExpression(booleanExpression.RightOperand);
			Write(")");
		}

		protected virtual void EmitCompareExpression(NPathCompareExpression compareExpression)
		{
			Write("(");
			EmitExpression(compareExpression.LeftOperand);
			Write(" " + compareExpression.Operator + " ");
			EmitExpression(compareExpression.RightOperand);
			Write(")");
		}

		protected virtual void EmitMathExpression(NPathMathExpression mathExpression)
		{
			Write("(");
			EmitExpression(mathExpression.LeftOperand);
			Write(" " + mathExpression.Operator + " ");
			EmitExpression(mathExpression.RightOperand);
			Write(")");
		}

		protected virtual void EmitParenthesisGroup(NPathParenthesisGroup parenthesisGroup)
		{
			if (parenthesisGroup.IsNegative)
				Write("-");

			Write("(");
			EmitExpression(parenthesisGroup.Expression);
			Write(")");
		}

		protected virtual void EmitPropertyFilter(NPathPropertyFilter propertyFilter)
		{
			Write(propertyFilter.Path);
			Write("[");
			EmitExpression(propertyFilter.Filter.Expression);
			Write("]");
		}

		protected virtual void EmitPropertyPath(NPathIdentifier propertyPath)
		{
			if (propertyPath.IsNegative)
				Write("-");
			Write(propertyPath.Path);
		}

		protected virtual void EmitStringValue(NPathStringValue value)
		{
			Write("'");
			Write(value.Value);
			Write("'");
		}

		protected virtual void EmitGuidValue(NPathGuidValue value)
		{
			Write("'");
			Write(value.Value);
			Write("'");
		}

		protected virtual void EmitDateTimeValue(NPathDateTimeValue value)
		{
			Write("'");
			Write(value.Value);
			Write("'");
		}

		protected virtual void EmitDecimalValue(NPathDecimalValue value)
		{
			if (value.IsNegative)
				Write("-");
			Write(value.Value);
		}

		protected virtual void EmitBooleanValue(NPathBooleanValue value) => Write(value.Value);

	    protected virtual void EmitFrom(NPathSelectQuery query)
		{
			Write("from "); // do not localize
			foreach (NPathClassName className in query.From.Classes)
			{
				Write(className.Name);
				if (className != query.From.Classes[query.From.Classes.Count - 1])
					Write(",");
			}
			WriteLine();
		}

		protected virtual void EmitSearchFunction(NPathSearchFunction searchFunction)
		{
			Write(" {0} ( {1},", searchFunction.FunctionName, searchFunction.PropertyPath); // do not localize
			EmitStringValue(searchFunction.SearchString);
			Write(")");
		}

		protected virtual void EmitSelect(NPathSelectQuery query)
		{
			NPathSelectClause select = query.Select;
			Write("select "); // do not localize

			if (query.Select.HasTop)
			{
				Write("top {0}", query.Select.Top); // do not localize
				if (query.Select.Percent)
					Write("% ");
			}
			int i = 0;
			foreach (NPathSelectField field in select.SelectFields)
			{
				if (field.Expression is NPathIdentifier)
				{
					NPathIdentifier path = field.Expression as NPathIdentifier;
					Write(path.Path);

				}
				if (field.Expression is NPathFunction)
				{
					NPathFunction function = field.Expression as NPathFunction;
					EmitFunction(function);
				}
				if (field.Expression is NPathExpression)
				{
					NPathExpression expression = field.Expression as NPathExpression;
					EmitExpression(expression);
				}

				if (field.Alias != null && field.Alias != "")
				{
					WriteLine(" as [{0}]", field.Alias); // do not localize
				}

				if (i < select.SelectFields.Count - 1)
					Write(",");
				i++;
			}
			WriteLine();
		}

		protected virtual void Write(string text) => code.Append(text);

	    protected virtual void Write(object value) => code.Append(value.ToString());

	    protected virtual void Write(string text, params object[] args) => code.AppendFormat(text, args);

	    protected virtual void WriteLine(string text)
		{
			code.Append(text);
			code.Append(Environment.NewLine);
		}

		protected virtual void WriteLine(object value)
		{
			code.Append(value.ToString());
			code.Append(Environment.NewLine);
		}

		protected virtual void WriteLine(string text, params object[] args)
		{
			code.AppendFormat(text, args);
			code.Append(Environment.NewLine);
		}

		protected virtual void WriteLine() => code.Append(Environment.NewLine);
	}
}