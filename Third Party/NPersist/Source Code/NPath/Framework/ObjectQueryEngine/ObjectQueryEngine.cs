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
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using Puzzle.NCore.Framework.Collections;
using Puzzle.NPath.Framework.CodeDom;

namespace Puzzle.NPath.Framework
{
	/// <summary>
	/// Summary description for ObjectQueryEngine.
	/// </summary>
	public class ObjectQueryEngine : IObjectQueryEngine
	{
		#region Public Property ObjectQueryEngineHelper

		private IObjectQueryEngineHelper objectQueryEngineHelper;

		public IObjectQueryEngineHelper ObjectQueryEngineHelper
		{
			get { return this.objectQueryEngineHelper; }
			set { this.objectQueryEngineHelper = value; }
		}

		#endregion

		public virtual IList GetObjectsByNPath(string npathQuery, IList sourceList)
		{
			return GetObjectsByNPath(npathQuery, sourceList, new ArrayList());
		}

		public virtual DataTable GetDataTableByNPath(string npathQuery, IList sourceList)
		{
			return GetDataTableByNPath(npathQuery, sourceList, new ArrayList());
		}

		public virtual IList GetObjectsByNPath(string npathQuery, IList sourceList, IList parameters)
		{
			NPathSelectQuery query = Parse(npathQuery, parameters);
			return GetObjects(query, sourceList);
		}

		public virtual DataTable GetDataTableByNPath(string npathQuery, IList sourceList, IList parameters)
		{
			NPathSelectQuery query = Parse(npathQuery, parameters);
			return GetDataTable(query, sourceList);
		}

		//transforms all * fields into real property path fields
		private void FixQuery(NPathSelectQuery query)
		{
			ObjectQueryEngineHelper.ExpandWildcards(query);


		}

		public virtual DataTable GetDataTable(NPathSelectQuery query, IList sourceList)
		{
			FixQuery(query);
			DataTable resultTable = new DataTable();
			resultTable.BeginInit();

			#region build columns

			int id = 0;
			foreach (NPathSelectField field in query.Select.SelectFields)
			{
				string fieldName = field.Alias;
				NPathIdentifier path = field.Expression as NPathIdentifier;
				if (path != null)
				{
					if (path.IsWildcard)
					{
						throw new Exception("this can not happen"); // do not localize
					}
					else
					{
						if (fieldName == null)
							fieldName = path.Path;

						resultTable.Columns.Add(path.Path, typeof (object));
					}
				}
				else
				{
					if (fieldName == null)
					{
						fieldName = "col" + id.ToString();
						id++;
					}
					resultTable.Columns.Add(fieldName, typeof (object));
				}
			}

			#endregion

			resultTable.EndInit();

			resultTable.BeginLoadData();

			IList resultList = InternalGetTable(query, sourceList);

			foreach (object[] values in resultList)
			{
				resultTable.Rows.Add(values);
			}

			resultTable.EndLoadData();

			return resultTable;
		}

		protected virtual ArrayList InternalGetTable(NPathSelectQuery query, IList sourceList)
		{
			ArrayList result = new ArrayList();

			IList resultList = GetObjects(query, sourceList);

			if (query.IsAggregate)
			{
				#region build rows

				object[] values = new object[query.Select.SelectFields.Count];
				for (int i = 0; i < query.Select.SelectFields.Count; i++)
				{
					NPathSelectField selectField = (NPathSelectField) query.Select.SelectFields[i];
					object res = EvalAggregate(resultList, selectField.Expression);
					values[i] = res;

				}
				result.Add(values);

				#endregion
			}
			else
			{
				#region build rows

				foreach (object item in resultList)
				{
					object[] values = new object[query.Select.SelectFields.Count];
					for (int i = 0; i < query.Select.SelectFields.Count; i++)
					{
						NPathSelectField selectField = (NPathSelectField) query.Select.SelectFields[i];
						object res = EvalValue(item, selectField.Expression);
						values[i] = res;
					}
					result.Add(values);
				}

				#endregion
			}
			return result;
		}


		protected virtual object EvalAggregate(IList resultList, IValue expression)
		{
			if (expression is NPathCountStatement)
			{
				return resultList.Count;
			}

			if (expression is NPathSumStatement)
			{
				return EvalSumStatement(resultList, expression as NPathSumStatement);
			}

			if (expression is NPathAvgStatement)
			{
				return EvalAvgStatement(resultList, expression as NPathSumStatement);
			}

			if (expression is NPathMaxStatement)
			{
				return EvalMaxStatement(resultList, expression as NPathSumStatement);
			}

			if (expression is NPathMinStatement)
			{
				return EvalMinStatement(resultList, expression as NPathSumStatement);
			}


			throw new NotImplementedException();
		}

		protected virtual object EvalSumStatement(IList resultList, NPathSumStatement sumStatement)
		{
			double sum = 0;
			foreach (object item in resultList)
			{
				object value = EvalValue(item, sumStatement.Expression);
				if (value is double)
					sum += (double) value;
				else if (value == null)
				{
					//ignore null
				}
				else
				{
					throw new Exception("tough shit"); // do not localize
				}
			}
			return sum;
		}

		protected virtual object EvalAvgStatement(IList resultList, NPathSumStatement sumStatement)
		{
			if (resultList.Count == 0)
				return 0;

			double sum = 0;
			foreach (object item in resultList)
			{
				object value = EvalValue(item, sumStatement.Expression);
				if (value is double)
					sum += (double) value;
				else if (value == null)
				{
					//ignore null
				}
				else
				{
					throw new Exception("tough shit"); // do not localize
				}
			}

			double avg = sum/resultList.Count;
			return avg;
		}

		protected virtual object EvalMaxStatement(IList resultList, NPathSumStatement sumStatement)
		{
			if (resultList.Count == 0)
				return null;

			object max = null;
			foreach (object item in resultList)
			{
				object value = EvalValue(item, sumStatement.Expression);
				int res = Comparer.Default.Compare(max, value);
				if (res > 0)
					max = value;
			}

			return max;
		}

		protected virtual object EvalMinStatement(IList resultList, NPathSumStatement sumStatement)
		{
			if (resultList.Count == 0)
				return null;

			object min = null;
			foreach (object item in resultList)
			{
				object value = EvalValue(item, sumStatement.Expression);
				int res = Comparer.Default.Compare(min, value);
				if (res < 0)
					min = value;
			}

			return min;
		}

		protected virtual NPathSelectQuery Parse(string npathQuery)
		{
			NPathParser parser = new NPathParser();
			return parser.ParseSelectQuery(npathQuery, new ArrayList());
		}

		protected virtual NPathSelectQuery Parse(string npathQuery, IList parameters)
		{
			NPathParser parser = new NPathParser();
			return parser.ParseSelectQuery(npathQuery, parameters);
		}

		public virtual IList GetObjects(NPathSelectQuery query, IList sourceList)
		{
			//sort the source list according to the orderby clause
			IList sortedSourceList = SortSourceList(sourceList, query);

			//fill result list with matches of the where clause
			ArrayList destList = PopulateResult(sortedSourceList, query);

			//apply top statement
			ApplyTop(query, ref destList);

			return destList;
		}

		protected virtual ArrayList PopulateResult(IList sortedSourceList, NPathSelectQuery query)
		{
			ArrayList destList = new ArrayList(sortedSourceList.Count);
			Hashtable distinctLookup = new Hashtable();
			foreach (object o in sortedSourceList)
			{
				if (IsMatch(o, query))
				{
					if (query.Select.Distinct)
					{
						#region distinct add

						//add if not present
						if (!distinctLookup.ContainsKey(o))
						{
							//flag precense
							distinctLookup.Add(o, o);
							destList.Add(o);
						}

						#endregion
					}
					else
					{
						#region normal add

						destList.Add(o);

						#endregion
					}
				}
			}
			return destList;
		}

		protected virtual IList SortSourceList(IList sourceList, NPathSelectQuery query)
		{
			if (query.OrderBy == null)
				return sourceList;

			ArrayList sortedSourceList = new ArrayList(sourceList);


			sortedSourceList.Sort(new SortOrderComparer(query.OrderBy, this));
			return sortedSourceList;
		}

		protected virtual void ApplyTop(NPathSelectQuery query, ref ArrayList destList)
		{
			//apply "top"
			if (query.Select.HasTop)
			{
				int count = 0;
				if (query.Select.Percent)
				{
					double percent = ((double) query.Select.Top)/100;
					count = (int) ((double) destList.Count*percent);
				}
				else
				{
					count = (int) query.Select.Top;
				}
				ArrayList tmp = new ArrayList(count);

				if (destList.Count < count)
					count = destList.Count;

				tmp.AddRange(destList.GetRange(0, count));
				destList = tmp;
			}
		}

		public virtual bool IsMatch(object item, NPathSelectQuery query)
		{
			if (query.Where == null)
				return true;

			return EvalExpression(item, query.Where.Expression);
		}

		protected virtual bool EvalExpression(object item, object expression)
		{
			if (expression is NPathBooleanExpression)
			{
				return EvalBooleanExpression(item, expression as NPathBooleanExpression);
			}

			if (expression is NPathCompareExpression)
			{
				return EvalCompareExpression(item, expression as NPathCompareExpression);
			}

			if (expression is NPathParenthesisGroup)
			{
				return EvalParenthesisExpression(item, expression as NPathParenthesisGroup);
			}

			if (expression is NPathNotExpression)
			{
				return EvalNotExpression(item, expression as NPathNotExpression);
			}

			if (expression is NPathBetweenExpression)
			{
				return EvalBetweenExpression(item, expression as NPathBetweenExpression);
			}

			if (expression is NPathInExpression)
			{
				return EvalInExpression(item, expression as NPathInExpression);
			}
			throw new Exception("unknown expression"); // do not localize
		}

		protected virtual bool EvalInExpression(object item, NPathInExpression inExpression)
		{
			object testValue = EvalValue(item, inExpression.TestExpression);
			foreach (object expression in inExpression.Values)
			{
				object value = EvalValue(item, expression);
				int res = Comparer.Default.Compare(testValue, value);
				if (res == 0)
					return true;
			}
			return false;
		}

		protected virtual bool EvalBetweenExpression(object item, NPathBetweenExpression betweenExpression)
		{
			object fromValue = EvalValue(item, betweenExpression.FromExpression);
			object endValue = EvalValue(item, betweenExpression.EndExpression);
			object testValue = EvalValue(item, betweenExpression.TestExpression);

			if (fromValue is string)
				fromValue = fromValue.ToString().ToLower();

			if (endValue is string)
				endValue = endValue.ToString().ToLower();

			if (testValue is string)
				testValue = testValue.ToString().ToLower();


			int res1 = Comparer.DefaultInvariant.Compare(testValue, fromValue);
			if (res1 < 0)
				return false;

			int res2 = Comparer.DefaultInvariant.Compare(testValue, endValue);

			if (res2 > 0)
				return false;

			return true;
		}

		protected virtual bool EvalNotExpression(object item, NPathNotExpression notExpression)
		{
			return !EvalExpression(item, notExpression.Expression);
		}

		protected virtual bool EvalParenthesisExpression(object item, NPathParenthesisGroup parenthesisGroup)
		{
			return EvalExpression(item, parenthesisGroup.Expression);
		}

		protected virtual object EvalMathExpression(object item, NPathMathExpression mathExpression)
		{
			object leftValue = EvalValue(item, mathExpression.LeftOperand);
			object rightValue = EvalValue(item, mathExpression.RightOperand);

			if (leftValue is double && rightValue is double)
			{
				double leftDouble = (double) leftValue;
				double rightDouble = (double) rightValue;
				switch (mathExpression.Operator)
				{
					case "add":
						{
							return leftDouble + rightDouble;
						}
					case "minus":
						{
							return leftDouble - rightDouble;
						}
					case "mul":
						{
							return leftDouble*rightDouble;
						}
					case "div":
						{
							return leftDouble/rightDouble;
						}
					default:
						throw new Exception("unknown expression"); // do not localize
				}
			}
			else if (IsStringOrNull(leftValue) && IsStringOrNull(rightValue))
			{
				string leftString = (string) leftValue;
				string rightString = (string) rightValue;

				switch (mathExpression.Operator)
				{
					case "add":
						{
							//is this how it behaves in SQL ????
							if (leftString == null && rightString == null)
							{
								return null;
							}
							else if (leftString != null && rightString == null)
							{
								return leftString;
							}
							else if (leftString == null && rightString != null)
							{
								return rightString;
							}
							else
							{
								return leftString + rightString;
							}
						}
					default:
						throw new Exception("unknown expression"); // do not localize
				}
			}

			throw new Exception("unknown expression"); // do not localize
		}

		protected virtual bool IsStringOrNull(object value)
		{
			return (value is string || value == null);
		}

		protected virtual bool EvalCompareExpression(object item, NPathCompareExpression compareExpression)
		{
			object leftValue = null; //EvalValue(item, compareExpression.LeftOperand);
			object rightValue = null; // EvalValue(item, compareExpression.RightOperand);

			if (compareExpression.LeftOperand is NPathIdentifier && compareExpression.RightOperand is NPathIdentifier)
			{
				NPathIdentifier leftIdent = (NPathIdentifier)compareExpression.LeftOperand;
				NPathIdentifier rightIdent = (NPathIdentifier)compareExpression.RightOperand ;

				bool rightIsEnum = false;
				if (rightIdent.Path.IndexOf(".") == -1)
				{
					if (item.GetType().GetProperty(rightIdent.Path) == null)
						rightIsEnum = true;
				}

				bool leftIsEnum = false;
				if (leftIdent.Path.IndexOf(".") == -1)
				{
					if (item.GetType().GetProperty(leftIdent.Path) == null)
						leftIsEnum = true;
				}

				if (leftIsEnum && rightIsEnum)
					throw new Exception(string.Format("Property not found '{0}'",leftIdent.Path) );

				if (leftIsEnum)
				{
					string enumName = leftIdent.Path;
					rightValue = EvalValue(item,rightIdent);
					if (rightValue == null)
						return false;

					Type enumType = rightValue.GetType();
					if (!enumType.IsEnum)
						throw new Exception(string.Format("Property '{0}' is not an enum",rightIdent.Path) );
					
	
					leftValue = Enum.Parse(enumType,enumName);
				}

				if (rightIsEnum)
				{
					string enumName = rightIdent.Path;
					leftValue = EvalValue(item,leftIdent);
					if (leftValue == null)
						return false;

					Type enumType = leftValue.GetType();
					if (!enumType.IsEnum)
						throw new Exception(string.Format("Property '{0}' is not an enum",leftIdent.Path) );
					
	
					rightValue = Enum.Parse(enumType,enumName);
				}
			}
			else
			{
				leftValue = EvalValue(item, compareExpression.LeftOperand);
				rightValue = EvalValue(item, compareExpression.RightOperand);
			}


			if (  (leftValue is IComparable || rightValue is IComparable)  ||  (leftValue == null || rightValue == null)  )
			{
				int res = Comparer.DefaultInvariant.Compare(leftValue, rightValue);

				switch (compareExpression.Operator)
				{
					case "=":
						{
							return res == 0;
						}
					case "!=":
						{
							return res != 0;
						}
					case ">=":
						{
							return res >= 0;
						}
					case "<=":
						{
							return res <= 0;
						}
					case ">":
						{
							return res > 0;
						}
					case "<":
						{
							return res < 0;
						}
					case "like":
						{
							if (leftValue == null || rightValue == null)
								return false;

							bool isLike = Like(leftValue.ToString(), rightValue.ToString());
							return isLike;
						}
					default:
						break;
				}
			}
			else
			{
				switch (compareExpression.Operator)
				{
					case "=":
						{
							return leftValue == rightValue;
						}
					case "!=":
						{
							return leftValue != rightValue;
						}
					default:
						break;
				}
			}

			throw new Exception(string.Format("unknown compare expression '{0}'", compareExpression.Operator)); // do not localize
		}

		public virtual object EvalValue(object item, object expression)
		{
			if (expression is NPathIdentifier)
			{
				return EvalPropertyPath(item, expression as NPathIdentifier);
			}

			if (expression is NPathDateTimeValue)
			{
				return ((NPathDateTimeValue) expression).Value;
			}

			if (expression is NPathStringValue)
			{
				return ((NPathStringValue) expression).Value;
			}

			if (expression is NPathDecimalValue)
			{
				NPathDecimalValue dv = expression as NPathDecimalValue;
				double d = dv.Value;

				//negate value
				if (dv.IsNegative)
					d = -d;

				return d;
			}

			if (expression is NPathBooleanValue)
			{
				NPathBooleanValue bv = expression as NPathBooleanValue;
				return bv.Value;
			}

			if (expression is NPathMathExpression)
			{
				return EvalMathExpression(item, expression as NPathMathExpression);
			}

			if (expression is NPathParenthesisGroup)
			{
				return EvalParenthesisValue(item, expression as NPathParenthesisGroup);
			}

			if (expression is NPathSelectQuery)
			{
				return EvalQuery(item, expression as NPathSelectQuery);
			}

			if (expression is NPathParameter)
			{
				return ObjectQueryEngineHelper.EvalParameter(item, expression as NPathParameter);
			}

			if (expression is NPathMethodCall)
			{
				return EvalMethodCall(item, expression as NPathMethodCall);
			}

            if (expression is NPathNullValue)
            {
                return null;
            }


			throw new Exception(string.Format("unknown value {0}", expression.ToString())); // do not localize
		}

//		private object EvalParameter(object item, NPathParameter parameter)
//		{
//			IQueryParameter value = parameter.Value as IQueryParameter;
//			object res = value.Value;
//
//			if (IsNumber(res))
//				res = double.Parse(res.ToString());
//
//			return res;
//		}

		protected virtual object EvalMethodCall(object item, NPathMethodCall call)
		{
			ArrayList parameters = new ArrayList();
			foreach (IValue parameterExpression in call.Parameters)
			{
				object parameterValue = this.EvalValue(item, parameterExpression);



				parameters.Add(parameterValue);
			}

			object target = item;
			if (call.PropertyPath.Path != "")
				target = EvalPropertyPath(item, call.PropertyPath);

			if (target == null)
				return null;

			string methodName = call.MethodName;

			if (target is IList)
			{
				if (methodName == "Count")
					methodName = "get_Count";
			}


			MethodInfo[] methods = target.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);
			foreach (MethodInfo method in methods)
			{
				if (methodName == method.Name && method.GetParameters().Length == parameters.Count)
				{
					object[] methodParams = new object[parameters.Count];
                    ParameterInfo[] paramInfo = method.GetParameters ();
					for (int i=0;i<parameters.Count;i++)
                    {
                        object value = Convert.ChangeType (parameters[i],paramInfo[i].ParameterType);
                        methodParams[i] = value;
                    }                   

					object result = method.Invoke(target, methodParams);


					if (IsNumber(result))
					{
						result = Convert.ToDouble(result);
					}

					if (call.PropertyPath.IsNegative)
					{
						result = NegateValue(result);
					}


					return result;
				}
			}


			throw new Exception("Error");
		}

		protected virtual object EvalQuery(object item, NPathSelectQuery query)
		{
			NPathClassName className = (NPathClassName) query.From.Classes[0];
			string propertyPath = className.Name;
			IList childList = (IList) EvalStringPropertyPath(item, propertyPath);
			ArrayList result = InternalGetTable(query, childList);

			object[] resultList = new object[result.Count];
			int i = 0;
			foreach (object[] values in result)
			{
				object scalarRes = values[0];
				if (IsNumber(scalarRes))
					scalarRes = double.Parse(scalarRes.ToString());
				resultList[i] = scalarRes;
				i++;
			}

			if (query.IsAggregate)
			{
				return resultList[0];
			}
			else
			{
				return resultList;
			}
		}

		protected virtual object EvalParenthesisValue(object item, NPathParenthesisGroup parenthesis)
		{
			object res = EvalValue(item, parenthesis.Expression);
			if (parenthesis.IsNegative)
			{
				//negate result

				return NegateValue(res);
			}
			else
				return res;
		}


		private MultiHashtable propertyLookup = new MultiHashtable();

		private IPropertyAccessor GetProperty(object item, string propertyName)
		{
			IPropertyAccessor propertyAccessor = (IPropertyAccessor) propertyLookup[item.GetType(), propertyName];
			if (propertyAccessor == null)
			{
				propertyAccessor = new PropertyAccessor(item.GetType(), propertyName);
				propertyLookup[item.GetType(), propertyName] = propertyAccessor;
			}
			return propertyAccessor;
		}

		public object EvalStringPropertyPath(object item, string propertyPath)
		{
			//split property path into parts
			string[] parts = propertyPath.Split('.');

			object current = item;
			//fetch each value from the path
			int i = 0;
			foreach (string part in parts)
			{
				IPropertyAccessor pi = GetProperty(current, part);
				current = pi.Get(current);

				//bail out if null parent found
				if (current == null)
					return null;

				//check null value status for last property only
				if (i == parts.Length - 1)
					if (ObjectQueryEngineHelper.GetNullValueStatus(item, part))
						return null;
				//if (ObjectQueryEngineHelper.GetNullValueStatus(current, part))


				i++;
			}
			//current is now the value of the last part
			return current;
		}


		public object EvalPropertyPath(object item, NPathIdentifier propertyPath)
		{
			if (propertyPath.Path == "")
			{
				throw new Exception("Can not evaluate propertypath ''");
			}

			if (propertyPath.IsWildcard)
				throw new Exception("Can not evaluate a wildcard path"); // do not localize

			object current = EvalStringPropertyPath(item, propertyPath.Path);
			//idiot conversion is due to roundoff errors when using convert.todouble
			if (IsNumber(current))
				current = double.Parse(current.ToString());

			//negate expression
			if (propertyPath.IsNegative)
			{
				return NegateValue(current);
			}

			return current;
		}

		private static object NegateValue(object current)
		{
			if (current is double)
			{
				return -(double) current;
			}
			else if (current == null)
			{
				throw new Exception(string.Format("Can not negate NULL")); // do not localize
			}
			else
			{
				throw new Exception(string.Format("Can not negate values of type {0}", current.GetType().ToString())); // do not localize
			}
		}

		private static bool IsNumber(object value)
		{
			if (value is Byte)
				return true;

			if (value is Int16)
				return true;

			if (value is Int32)
				return true;

			if (value is Int64)
				return true;

			if (value is UInt16)
				return true;

			if (value is UInt32)
				return true;

			if (value is UInt64)
				return true;

			if (value is Single)
				return true;

			if (value is Double)
				return true;

			if (value is Decimal)
				return true;

			return false;
		}

		protected virtual bool EvalBooleanExpression(object item, NPathBooleanExpression booleanExpression)
		{
			//get left operand
			bool leftExpression = EvalExpression(item, booleanExpression.LeftOperand);

			//short circuit "AND"... bailout if leftexpression is "false"
			if (booleanExpression.Operator == "and" && leftExpression == false)
			{
				return false;
			}
			//short circuit "OR"... bailout if leftexpression is "true"
			if (booleanExpression.Operator == "or" && leftExpression == true)
			{
				return true;
			}

			//get right operand
			bool rightExpression = EvalExpression(item, booleanExpression.RightOperand);

			//"and" left and right operand
			if (booleanExpression.Operator == "and")
			{
				return leftExpression && rightExpression;
			}
			//"or" left and right operand
			if (booleanExpression.Operator == "or")
			{
				return leftExpression || rightExpression;
			}

			throw new Exception(string.Format("unknown boolean expression {0}", booleanExpression.Operator)); // do not localize
		}

		#region Like

		private static bool Like(string text, string pattern)
		{
            //string regexpattern = "^";
            //foreach (char c in pattern)
            //{
            //    if (c == '%')
            //        regexpattern += @"\w*";
            //    else if (c == '?')
            //        regexpattern += @"\w";
            //    else if (c == '@')
            //        regexpattern += @"\@";
            //    else
            //        regexpattern += Regex.Escape(c.ToString());
            //}
            //return Regex.IsMatch(text, regexpattern, RegexOptions.IgnoreCase);

            text = text.ToLower();
            pattern = pattern.ToLower();

            int cp=0, mp=0;
            
            int i=0;
            int j=0;
            while ((i<text.Length) && (pattern[j] != '%')) 
            {
                if ((pattern[j] != text[i]) && (pattern[j] != '?')) 
                {
                    return false;
                }
                i++;
                j++;
            }
            
            while (i<text.Length) 
            {
                if (j<pattern.Length && pattern[j] == '%') 
                {
                    if ((j++)>=pattern.Length) 
                    {
                        return true;
                    }
                    mp = j;
                    cp = i+1;
                } 
                else if (j<pattern.Length && (pattern[j] == text[i] || pattern[j] == '?')) 
                {
                    j++;
                    i++;
                } 
                else 
                {
                    j = mp;
                    i = cp++;
                }
            }
            
            while (j<pattern.Length && pattern[j] == '%') 
            {
                j++;
            }
            return j>=pattern.Length;
        }
		#endregion
	}
}