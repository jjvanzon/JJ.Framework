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
using System.Globalization;
using Puzzle.NPath.Framework.CodeDom;

namespace Puzzle.NPath.Framework
{
	public class NPathParser
	{
		private Tokenizer tokenizer; //code tokenizer
		private ArrayList parameterQueue;
		private Stack queries;


		private NPathSelectQuery CurrentQuery
		{
            get
            {
                if (queries.Count == 0)
                    return null;

                return queries.Peek() as NPathSelectQuery;
            }
		}

		public NPathParser()
		{
		}

		public NPathSelectQuery ParseSelectQuery(string code)
		{
			return ParseSelectQuery(code, new ArrayList());
		}

		public NPathSelectQuery ParseSelectQuery(string code, IList parameters)
		{
			parameterQueue = new ArrayList(parameters);
			queries = new Stack();
			return InternalParseSelectQuery(code, parameters);
		}

		private NPathSelectQuery InternalParseSelectQuery(string code, IList parameters)
		{
			tokenizer = new Tokenizer();
			tokenizer.Tokenize(code);
			return Begin();
		}

		private NPathSelectQuery Begin()
		{
			NPathSelectQuery query = ParseSelectQuery();


			if (tokenizer.GetCurrentToken().Text != "")
			{
				throw new UnexpectedTokenException(string.Format("Unexpected token '{0}' found at end of expression", tokenizer.GetCurrentToken().Text)); // do not localize
			}

			queries.Pop();
			return query;
		}

		private NPathSelectQuery ParseSelectQuery()
		{
			NPathSelectQuery query = new NPathSelectQuery();
			queries.Push(query);

			tokenizer.GetCurrentToken("select", "Select");

			NPathSelectClause selectClause = new NPathSelectClause();
			ParseSelectClause(selectClause);
			query.Select = selectClause;

			tokenizer.GetCurrentToken("from", "From");
			NPathFromClause fromClause = new NPathFromClause();
			ParseFromClause(fromClause);
			query.From = fromClause;

			if (tokenizer.GetCurrentToken().IsType("where"))
			{
				NPathWhereClause whereClause = new NPathWhereClause();
                query.Where = whereClause;
				ParseWhereClause(whereClause);
				
			}

			if (tokenizer.GetCurrentToken().IsType("order by")) // do not localize
			{
				NPathOrderByClause orderByClause = new NPathOrderByClause();
				ParseOrderByClause(orderByClause);
				query.OrderBy = orderByClause;
			}

			return query;
		}

		private void ParseSelectClause(NPathSelectClause selectClause)
		{
			if (tokenizer.GetNextToken().IsType("distinct"))
			{
				selectClause.Distinct = true;
				tokenizer.MoveNext();
			}

			if (tokenizer.GetNextToken().IsType("top"))
			{
				selectClause.HasTop = true;
				tokenizer.MoveNext();
				double top = double.Parse(tokenizer.GetNextToken("decimal", "Decimal value").Text); // do not localize
				selectClause.Top = (int) top;
				tokenizer.MoveNext();

				if (tokenizer.GetNextToken().IsType("percent"))
				{
					selectClause.Percent = true;
					tokenizer.MoveNext();
				}
				if (tokenizer.GetNextToken().IsType("with ties")) // do not localize
				{
					selectClause.WithTies = true;
					tokenizer.MoveNext();
				}
			}


			do
			{
				tokenizer.MoveNext();
				{
					IValue expression = ParseExpression();
					NPathSelectField field = new NPathSelectField();
					field.Expression = expression;
					field.Alias = null;
					selectClause.SelectFields.Add(field);

				}

				if (tokenizer.GetCurrentToken().IsType("as"))
				{
					NPathSelectField field = selectClause.SelectFields[selectClause.SelectFields.Count - 1] as NPathSelectField;
					tokenizer.MoveNext();
					field.Alias = tokenizer.GetCurrentToken().Text;
					tokenizer.MoveNext();
				}


			} while (tokenizer.GetCurrentToken().IsType("comma"));
		}

        public IValue ParseFilter(string code)
        {
            parameterQueue = new ArrayList();
            queries = new Stack();
            tokenizer = new Tokenizer();
            tokenizer.Tokenize(code);

            IValue expression = ParseBooleanExpression();
            return expression;
        }

		private void ParseWhereClause(NPathWhereClause whereClause)
		{
			tokenizer.MoveNext();
			whereClause.Expression = ParseBooleanExpression();
		}

//		private IValue ParseBooleanExpression()
//		{
//			IValue expression = ParseExpression();
//
		////			do
////			{
////				if (tokenizer.GetCurrentToken().IsType("boolop"))
////				{
////					expression = ParseBooleanOperator (expression);
////				}
////			}while (tokenizer.GetCurrentToken().IsType("boolop"));
//			return expression;
//		}
		private IValue ParseBooleanExpression()
		{
			IValue expression = ParseExpression();

			do
			{
				if (tokenizer.GetCurrentToken().IsType("boolop"))
				{
					expression = ParseOperator(expression);
				}
			} while (tokenizer.GetCurrentToken().IsType("boolop"));
			return expression;
		}

		private void ParseFromClause(NPathFromClause fromClause)
		{
			do
			{
				tokenizer.MoveNext();
				Token classToken = tokenizer.GetCurrentToken("identifier", "Class name"); // do not localize
				NPathClassName className = new NPathClassName();
				className.Name = classToken.Text;
				fromClause.Classes.Add(className);
				tokenizer.MoveNext();
			} while (tokenizer.GetCurrentToken().IsType("comma"));
		}


		private void ParseOrderByClause(NPathOrderByClause orderByClause)
		{
			do
			{
				tokenizer.MoveNext();
				//Token propertyToken = tokenizer.GetCurrentToken("property path","Property path"); // do not localize
				IValue expression = ParseExpression();

				SortProperty sortProperty = new SortProperty();
				//	sortProperty.Path = propertyToken.Text;
				sortProperty.Expression = expression;

				if (tokenizer.GetCurrentToken().IsType("direction"))
				{
					sortProperty.Direction = (SortDirection) Enum.Parse(typeof (SortDirection), tokenizer.GetCurrentToken().Text, true);
					tokenizer.MoveNext();
				}

				orderByClause.SortProperties.Add(sortProperty);
			} while (tokenizer.GetCurrentToken().IsType("comma"));
		}

		private void ParseParenthesisGroup(NPathParenthesisGroup parenthesisGroup)
		{
            tokenizer.GetCurrentToken("(", "(");
			tokenizer.MoveNext(); //step past (
			if (tokenizer.GetCurrentToken().IsType("select"))
			{
				parenthesisGroup.Expression = ParseSelectQuery();
			}
			else
			{
				parenthesisGroup.Expression = ParseBooleanExpression();
			}
            tokenizer.GetCurrentToken(")", ")");
			tokenizer.MoveNext(); // step past )
		}

		private void ParseBracketGroup(NPathBracketGroup bracketGroup)
		{
            tokenizer.GetCurrentToken("[", "[");
			tokenizer.MoveNext(); //step past [
			bracketGroup.Expression = ParseBooleanExpression();
            tokenizer.GetCurrentToken("]", "]");
			tokenizer.MoveNext(); //step past ]
		}

		private IValue ParseExpression()
		{
			if (tokenizer.GetCurrentToken().IsType("not"))
			{
				tokenizer.MoveNext(); // move past not
				NPathNotExpression not = new NPathNotExpression();
				not.Expression = ParseExpression();
				return not;
			}

			if (CurrentIsValue())
			{
				IValue operand = ParseValue();
				IValue expression = null;

				if (tokenizer.GetCurrentToken().IsType("between"))
				{
					expression = ParseBetweenExpression(operand);
					return expression;
				}

				if (tokenizer.GetCurrentToken().IsType("in"))
				{
					expression = ParseInExpression(operand);
					return expression;
				}

				if (tokenizer.GetCurrentToken().IsType("math") || tokenizer.GetCurrentToken().IsType("compare") /* ||
					tokenizer.GetCurrentToken().IsType("boolop")*/)
				{
					expression = ParseOperator(operand);

					return expression;
				}

				if (tokenizer.GetCurrentToken().IsType(")"))
				{
					expression = operand;
					return expression;
				}

				if (tokenizer.GetCurrentToken().IsType("as"))
				{
					expression = operand;
					return expression;
				}

				if (tokenizer.GetCurrentToken().IsType("]"))
				{
					expression = operand;
					return expression;
				}

				if (tokenizer.GetCurrentToken().IsType("direction"))
				{
					expression = operand;
					return expression;
				}

				return operand;
			}

			throw GetUnknownTokenException();
		}


		private NPathExpression ParseOperator(IValue leftOperand)
		{
			NPathExpression current = null;
			if (tokenizer.GetCurrentToken().IsType("boolop"))
			{
				current = ParseBooleanOperator(leftOperand);
			}

			if (tokenizer.GetCurrentToken().IsType("compare"))
			{
				current = ParseCompareOperator(leftOperand);
			}

			if (tokenizer.GetCurrentToken().IsType("math"))
			{
				current = ParseMathOperator(leftOperand);
			}


			current = SwapNodes(current);


			return current;
		}

		private NPathExpression SwapNodes(NPathExpression current)
		{
			if (current.RightOperand is NPathExpression)
			{
				NPathExpression next = current.RightOperand as NPathExpression;
				int prio1 = current.GetOperatorPriority();
				int prio2 = next.GetOperatorPriority();
				if (prio2 < prio1)
				{
					NPathExpression tmp = current;
					current = next;
					next = tmp;

					IValue nextLeft = next.LeftOperand;
					IValue currentLeft = next.LeftOperand;

					IValue nextRight = next.RightOperand;
					IValue currentRight = next.RightOperand;


					//	(c = (b and (d = (f and (4 div (5 add (2 = (7 or (


					//"c = "   "b and"    "d =" // do not localize
					//"c = b" " and "  "d =" // do not localize

					next.RightOperand = current.LeftOperand;
					next = SwapNodes(next);
					current.LeftOperand = next;


				}
			}
			return current;
		}

		private IValue ParseBetweenExpression(IValue leftOperand)
		{
			NPathBetweenExpression between = new NPathBetweenExpression();
			between.TestExpression = leftOperand;

			tokenizer.GetCurrentToken("between", "Between");
			tokenizer.MoveNext();

			if (CurrentIsValue())
				between.FromExpression = ParseExpression();
			else
				throw GetExpectedTokenException("Value");

			tokenizer.GetCurrentToken("and", "And");
			tokenizer.MoveNext();

			if (CurrentIsValue())
				between.EndExpression = ParseExpression();
			else
				throw GetExpectedTokenException("Value");


			return between;
		}

		private IValue ParseInExpression(IValue leftOperand)
		{
			NPathInExpression inExpression = new NPathInExpression();
			inExpression.TestExpression = leftOperand;

			tokenizer.GetCurrentToken("in", "in");
			tokenizer.MoveNext();

			tokenizer.GetCurrentToken("(", "(");
			do
			{
				tokenizer.MoveNext();
				IValue expression = ParseExpression();
				inExpression.Values.Add(expression);

			} while (tokenizer.GetCurrentToken().IsType("comma"));

			tokenizer.GetCurrentToken(")", ")");
			tokenizer.MoveNext();

			return inExpression;
		}

		private IValue ParseSearchFunctionExpression()
		{
			NPathSearchFunction search = new NPathSearchFunction();

			search.FunctionName = tokenizer.GetCurrentToken().Text;

			tokenizer.MoveNext();
			tokenizer.GetCurrentToken("(", "(");
			tokenizer.MoveNext();
			NPathIdentifier path = new NPathIdentifier();
			path.Path = CurrentPropertyPrefix + tokenizer.GetCurrentToken("property path", "Property path").Text; // do not localize

			path.ReferenceLocation = IsInSelectClause() ? NPathPropertyPathReferenceLocation.SelectClause : NPathPropertyPathReferenceLocation.WhereClause;
			//	CurrentQuery.AddPropertyPathReference(path.Path) ;

			search.PropertyPath = path;
			tokenizer.MoveNext();
			tokenizer.GetCurrentToken("comma", ",");
			tokenizer.MoveNext();
			tokenizer.GetCurrentToken("string", new string[] {"\"", "'"});
			search.SearchString = (NPathStringValue) ParseValue();

			tokenizer.GetCurrentToken(")", ")"); // do not localize
			tokenizer.MoveNext();

			return search;
		}


		private NPathCompareExpression ParseCompareOperator(IValue leftOperand)
		{
			NPathCompareExpression compare = new NPathCompareExpression();
			compare.LeftOperand = leftOperand;

			Token currentToken = tokenizer.GetCurrentToken();

			#region parse operator

			if (currentToken.IsType(">")) // do not localize
				compare.Operator = ">"; // do not localize
			if (currentToken.IsType("<")) // do not localize
				compare.Operator = "<"; // do not localize
			if (currentToken.IsType(">=")) // do not localize
				compare.Operator = ">="; // do not localize
			if (currentToken.IsType("<=")) // do not localize
				compare.Operator = "<="; // do not localize
			if (currentToken.IsType("=")) // do not localize
				compare.Operator = "="; // do not localize
			if (currentToken.IsType("!=")) // do not localize
				compare.Operator = "!="; // do not localize
			if (currentToken.IsType("like")) // do not localize
				compare.Operator = "like"; // do not localize

			#endregion

			tokenizer.MoveNext();

			if (CurrentIsValue())
			{
				compare.RightOperand = ParseExpression();
			}
			else
			{
				//unknown value?
				throw GetExpectedTokenException("Value");
			}

			return compare;
		}


		private bool CurrentIsValue()
		{
			return tokenizer.GetCurrentToken().IsType("value") || (tokenizer.GetCurrentToken().IsType("sign") && tokenizer.GetNextToken().IsType("value") || (tokenizer.GetCurrentToken().IsType("not") && tokenizer.GetNextToken().IsType("value"))); // do not localize
		}

		private NPathMathExpression ParseMathOperator(IValue leftOperand)
		{
			NPathMathExpression math = new NPathMathExpression();
			math.LeftOperand = leftOperand;

			Token currentToken = tokenizer.GetCurrentToken();

			#region parse operator

			if (currentToken.IsType("add"))
				math.Operator = "add";
			if (currentToken.IsType("minus"))
				math.Operator = "minus";
			if (currentToken.IsType("mul"))
				math.Operator = "mul";
			if (currentToken.IsType("div"))
				math.Operator = "div";
			if (currentToken.IsType("xor"))
				math.Operator = "xor";
			if (currentToken.IsType("mod"))
				math.Operator = "mod";
//			if (currentToken.IsType("and"))
//				math.Operator = "and";
//			if (currentToken.IsType("or"))
//				math.Operator = "or";

			#endregion

			tokenizer.MoveNext();

			if (CurrentIsValue())
			{
				math.RightOperand = ParseExpression();
			}
			else
			{
				//unknown value?
				throw GetExpectedTokenException("Value");
			}

			return math;
		}


		private NPathBooleanExpression ParseBooleanOperator(IValue leftOperand)
		{
			NPathBooleanExpression boolean = new NPathBooleanExpression();
			boolean.LeftOperand = leftOperand;

			Token currentToken = tokenizer.GetCurrentToken();

			#region parse operator

			if (currentToken.IsType("and"))
				boolean.Operator = "and";
			if (currentToken.IsType("or"))
				boolean.Operator = "or";

			#endregion

			tokenizer.MoveNext();

			if (CurrentIsValue())
			{
				IValue rightValue = ParseExpression();
				boolean.RightOperand = rightValue;
				return boolean;
			}
			else
			{
				//unknown value?
				throw GetExpectedTokenException("Value");

			}
		}

//		private BooleanExpression ParseBooleanOperator(IValue leftOperand)
//		{
//			BooleanExpression boolean = new BooleanExpression() ;
//			boolean.LeftOperand = leftOperand;
//
//			Token currentToken = tokenizer.GetCurrentToken();
//
//			#region parse operator
//			if (currentToken.IsType("and"))
//				boolean.Operator = "and";
//			if (currentToken.IsType("or"))
//				boolean.Operator = "or";
//			#endregion
//
//			tokenizer.MoveNext();
//
//			if (CurrentIsValue())
//			{
//				IValue rightValue = ParseExpression ();
//				
//				if (tokenizer.GetCurrentToken().IsType("and"))
//				{
//					boolean.RightOperand = ParseBooleanOperator (rightValue);
//				}
//				else
//				{
//					boolean.RightOperand = rightValue;
//				}
//			}
//			else
//			{
//				//unknown value?
//				throw new Exception("blaa") ;
//			}
//			
//			return boolean;
//		}

		private string CurrentPropertyPrefix = "";

		private IValue ParseValue()
		{
			IValue operand = null;

			bool isNegative = false;
			if (tokenizer.GetCurrentToken().IsType("sign"))
			{
				if (tokenizer.GetCurrentToken().IsType("minus"))
					isNegative = true;

				tokenizer.MoveNext();
			}

			Token currentToken = tokenizer.GetCurrentToken();

			#region parse value

			if (currentToken.IsType("null"))
			{
				NPathNullValue nullOperand = new NPathNullValue();
				operand = nullOperand;
				tokenizer.MoveNext();
			}
			else if (currentToken.IsType("parameter"))
			{
				NPathParameter parameterOperand = new NPathParameter();
				parameterOperand.Value = parameterQueue[0];
				parameterQueue.RemoveAt(0);
				operand = parameterOperand;
				tokenizer.MoveNext();
			}
			else if (tokenizer.GetCurrentToken().IsType("textsearch"))
			{
				return ParseSearchFunctionExpression();
			}
            else if (currentToken.IsType("function") && IsInSelectClause() || currentToken.IsType("isnull") || currentToken.IsType("soundex"))
            {
                NPathFunction functionOperand = new NPathFunction();

                if (currentToken.IsType("soundex"))
                    functionOperand = new NPathSoundexStatement();
                if (currentToken.IsType("sum"))
                    functionOperand = new NPathSumStatement();
                if (currentToken.IsType("isnull"))
                    functionOperand = new NPathIsNullStatement();
                if (currentToken.IsType("count"))
                    functionOperand = new NPathCountStatement();
                if (currentToken.IsType("avg"))
                    functionOperand = new NPathAvgStatement();
                if (currentToken.IsType("min"))
                    functionOperand = new NPathMinStatement();
                if (currentToken.IsType("max"))
                    functionOperand = new NPathMaxStatement();

                tokenizer.MoveNext();
                tokenizer.GetCurrentToken("(", "(");
                tokenizer.MoveNext();
                if (tokenizer.GetCurrentToken().IsType("distinct"))
                {
                    functionOperand.Distinct = true;
                    tokenizer.MoveNext();
                }

                functionOperand.Expression = ParseBooleanExpression();
                tokenizer.GetCurrentToken(")", ")");
                tokenizer.MoveNext();

                operand = functionOperand;
            }
            else if (currentToken.IsType("date"))
            {
                NPathDateTimeValue dateOperand = new NPathDateTimeValue();
                dateOperand.Value = DateTime.Parse(currentToken.Text);
                operand = dateOperand;
                tokenizer.MoveNext();
            }
            else if (currentToken.IsType("decimal"))
            {
                NPathDecimalValue decimalOperand = new NPathDecimalValue();
                decimalOperand.Value = double.Parse(currentToken.Text, NumberFormatInfo.InvariantInfo);
                decimalOperand.IsNegative = isNegative;
                operand = decimalOperand;
                tokenizer.MoveNext();
            }
            else if (currentToken.IsType("string"))
            {
                NPathStringValue stringOperand = new NPathStringValue();
                string text = currentToken.Text;
                text = text.Substring(1, text.Length - 2);

                if (currentToken.IsType("string '")) // do not localize
                    text = text.Replace("''", "'");
                else if (currentToken.IsType("string \""))
                    text = text.Replace("\"\"", "\""); // do not localize

                stringOperand.Value = text;
                operand = stringOperand;
                tokenizer.MoveNext();
            }
            else if (currentToken.IsType("boolean"))
            {
                NPathBooleanValue booleanOperand = new NPathBooleanValue();
                booleanOperand.Value = bool.Parse(currentToken.Text);
                operand = booleanOperand;
                tokenizer.MoveNext();
            }
            else if (currentToken.IsType("guid"))
            {
                NPathGuidValue guidOperand = new NPathGuidValue();
                guidOperand.Value = currentToken.Text;
                operand = guidOperand;
                tokenizer.MoveNext();
            }
            else if (currentToken.IsType("property path")) // do not localize
            {
                if (tokenizer.GetNextToken().IsType("("))
                {
                    string fullPath = currentToken.Text;
                    string propertyPath = "";
                    string methodName = "";
                    int lastIndexOfDot = fullPath.LastIndexOf(".");
                    if (lastIndexOfDot > 0)
                    {
                        propertyPath = fullPath.Substring(0, lastIndexOfDot);
                        methodName = fullPath.Substring(lastIndexOfDot + 1);
                    }
                    else
                    {
                        methodName = fullPath;
                    }

                    NPathMethodCall call = new NPathMethodCall();
                    call.MethodName = methodName;

                    call.PropertyPath = new NPathIdentifier();
                    call.PropertyPath.Path = propertyPath;
                    call.PropertyPath.IsNegative = isNegative;

                    //TODO:add method support here
                    tokenizer.MoveNext(); //move past "("
                    tokenizer.MoveNext();
                    while (!tokenizer.GetCurrentToken().IsType(")"))
                    {
                        IValue param = ParseExpression();
                        call.Parameters.Add(param);
                        if (tokenizer.GetCurrentToken().IsType("comma"))
                        {
                            tokenizer.MoveNext();
                        }
                        else
                        {
                            tokenizer.GetCurrentToken(")", ")");
                        }

                    }
                    tokenizer.MoveNext();
                    operand = call;
                }
                else if (tokenizer.GetNextToken().IsType("["))
                {
                    CurrentPropertyPrefix = currentToken.Text + ".";
                    NPathBracketGroup bracketGroup = new NPathBracketGroup();
                    tokenizer.MoveNext();
                    ParseBracketGroup(bracketGroup);
                    CurrentPropertyPrefix = "";
                    NPathParenthesisGroup parens = new NPathParenthesisGroup();
                    parens.Expression = bracketGroup.Expression;
                    operand = parens;
                }
                else
                {
                    NPathIdentifier propertyOperand = new NPathIdentifier();
                    propertyOperand.Path = CurrentPropertyPrefix + currentToken.Text;

                    propertyOperand.ReferenceLocation = IsInSelectClause() ? NPathPropertyPathReferenceLocation.SelectClause : NPathPropertyPathReferenceLocation.WhereClause;

                    //CurrentQuery.AddPropertyPathReference(propertyOperand.Path) ;

                    propertyOperand.IsNegative = isNegative;
                    operand = propertyOperand;
                    tokenizer.MoveNext();
                }
            }
            else if (currentToken.IsType("("))
            {
                NPathParenthesisGroup parenthesisOperand = new NPathParenthesisGroup();
                ParseParenthesisGroup(parenthesisOperand);
                parenthesisOperand.IsNegative = isNegative;
                operand = parenthesisOperand;
            }
            else
            {
                //unknown value?
                throw GetUnknownTokenException();
            }

			#endregion

			return operand;
		}

		private bool IsInSelectClause()
		{
            if (CurrentQuery == null)
                return false;

			return CurrentQuery.Where == null;
		}

		private Exception GetUnknownTokenException()
		{
			Token currentToken = tokenizer.GetCurrentToken();
			Token previousToken = tokenizer.GetPreviousToken();

			return new UnknownTokenException(currentToken.Text, currentToken.Index, previousToken.Text);
		}

		private Exception GetExpectedTokenException(string expected)
		{
			Token currentToken = tokenizer.GetCurrentToken();
			Token previousToken = tokenizer.GetPreviousToken();

			return new UnexpectedTokenException(currentToken.Text, currentToken.Index, previousToken.Text, expected);
		}
	}
}