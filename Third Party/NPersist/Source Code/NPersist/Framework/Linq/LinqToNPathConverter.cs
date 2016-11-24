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
using System.Linq;
using Puzzle.NPath.Framework.CodeDom;
using System.Collections;
using Puzzle.NPersist.Framework.Linq.Strings;
using System.Linq.Expressions;
using System.Globalization;

namespace Puzzle.NPersist.Framework.Linq
{
    public partial class LinqToNPathConverter
    {
        public List<object> Parameters = new List<object>();

        public string ConvertToString<T>(Expression<T> expression)
        {
            return ConvertExpression(expression);
        }

        public string ConvertExpression<T>(Expression<T> expression)
        {
            return ConvertExpression(expression.Body);
           
        }

        public string ConvertExpression(Expression expression)
        {
            if (expression is MethodCallExpression)
            {
                return ConvertMethodCallExpression((MethodCallExpression) expression);
            }
            if (expression is MemberExpression)
            {
                return ConvertMemberExpression((MemberExpression) expression);
            }
            if (expression is ParameterExpression)
            {
                return ConvertParameterExpression((ParameterExpression) expression);
            }
            if (expression is ConstantExpression)
            {
                return ConvertConstantExpression((ConstantExpression) expression);
            }
            if (expression is BinaryExpression)
            {
                return ConvertBinaryExpression((BinaryExpression) expression);
            }
            if (expression is UnaryExpression)
            {
                return ConvertUnaryExpression((UnaryExpression) expression);
            }
            if (expression is NewExpression)
            {
                return ConvertNewExpression((NewExpression)expression);
            }
            if (expression is TypeBinaryExpression)
            {
                return ConvertIsExpression((TypeBinaryExpression)expression);
            }
            
            throw new Exception("The method or operation is not implemented.");
        }

        private string ConvertIsExpression(TypeBinaryExpression expression)
        {
            string path = ConvertExpression(expression.Expression);
            string type = expression.TypeOperand.Name;
            return string.Format("({0} is {1})", path, type);
        }

        private string ConvertNewExpression(NewExpression expression)
        {
            if (expression.Constructor.DeclaringType == typeof(DateTime))
            {
                //HACK: make it typed - Roger
                string year = expression.Arguments[0].ToString().PadLeft (4,'0');
                string month = expression.Arguments[1].ToString().PadLeft(2, '0');
                string day = expression.Arguments[1].ToString().PadLeft(2, '0');
                return string.Format("#{0}-{1}-{2}#",year,month,day);
            }

            throw new NotImplementedException();
        }

        private string ConvertUnaryExpression(UnaryExpression expression)
        {
            if (expression.NodeType == ExpressionType.Not)
            {
                string operand = ConvertExpression(expression.Operand);
                return string.Format ("not ({0})",operand);
            }
            else if (expression.NodeType == ExpressionType.Quote)
            {
                
                LambdaExpression lambda = expression.Operand as LambdaExpression;
                return ConvertExpression(lambda.Body);    
            }
            else
            {
                string operand = ConvertExpression(expression.Operand);
                return operand;
            }
        }



        private string ConvertParameterExpression(ParameterExpression expression)
        {
            return expression.Type.Name;
            //return "";
          //  return expression.Name;
        }

        private string ConvertMemberExpression(MemberExpression expression)
        {
            string suffix = expression.Member.Name;

            if (expression.Expression.NodeType == ExpressionType.Constant)
            {
                string prefix = ConvertExpression(expression.Expression);
                return prefix;
            }

            if (expression.Expression is UnaryExpression && suffix == "Count")
            {
                return ConvertSubquery((UnaryExpression)expression.Expression);
            }
            else
            {

                string prefix = ConvertExpression (expression.Expression);


                if (suffix == "Count" && typeof(IList).IsAssignableFrom (expression.Member.ReflectedType))
                {
                    suffix += "()";
                }
                else if (suffix == "Count" && expression is MemberExpression)
                {
                    return string.Format("(select count(*) from {0})", prefix);
                }

                if (prefix != "")
                    return string.Format ("{0}.{1}",prefix,suffix);
                else
                    return suffix;
            }
        }



        private string ConvertSubquery(UnaryExpression expression)
        {
            if (expression.Operand is MethodCallExpression && ((MethodCallExpression)expression.Operand).Method.Name == "Where")
            {
                MethodCallExpression methodCall = (MethodCallExpression)expression.Operand;
                
                
                
                string propPath = ConvertExpression (methodCall.Arguments[0]);                
                string whereClause = ConvertExpression(methodCall.Arguments[1]);

                return string.Format ("(select count(*) from {0} where {1})",propPath,whereClause);
            }

            throw new Exception("The method or operation is not implemented.");        
        }

        private string ConvertMethodCallExpression(MethodCallExpression expression)
        {
            if (expression.Method.Name == "Select")
            {
                throw new NotSupportedException("Projections in subqueries are not supported");
            }
            if (expression.Method.Name == "Any")
            {
                return ConvertAnyExpression(expression);
            }
            if (expression.Method.Name == "All")
            {
                return ConvertAllExpression(expression);
            }
            if (expression.Method.Name == "Contains")
            {
                return ConvertContainsExpression(expression);
            }
            if (expression.Method.Name == "Sum")
            {
                return ConvertSumExpression(expression);
            }
            if (expression.Method.Name == "Average")
            {
                return ConvertAvgExpression(expression);
            }
            if (expression.Method.Name == "Min")
            {
                return ConvertMinExpression(expression);
            }
            if (expression.Method.Name == "Max")
            {
                return ConvertMaxExpression(expression);
            }
            if (expression.Method.Name == "Where")
            {
                return ConvertSubWhereExpression(expression);
            }
            if (expression.Method.Name == "op_Equality")
            {
                return ConvertToEqualityExpression(expression);
            }
            if (expression.Method.Name == "op_Inequality")
            {
                return ConvertToInequalityExpression(expression);
            }
            if (expression.Method.Name == "Like" && expression.Method.ReflectedType == typeof(StringExtensions))
            {
                return ConvertLikeExpression(expression);
            }
            if (expression.Method.Name == "Soundex" && expression.Method.ReflectedType == typeof(StringExtensions))
            {
                return ConvertSoundexExpression(expression);
            }


            throw new Exception(string.Format("The method or operation is not implemented. : {0}", expression.Method.Name));
        }

        



        private string ConvertSubWhereExpression(MethodCallExpression expression)
        {            
            string from = ConvertExpression(expression.Arguments[0]);
            string predicate = ConvertUnaryExpression((UnaryExpression)expression.Arguments[1]);

            return string.Format("{0} where {1}", from, predicate);
        }


        


        

        //public static void CreateLoadspan<T>(NewExpression expression,LinqQuery<T> query)
        //{
        //    NewArrayExpression newArray = (NewArrayExpression)expression.Arguments[0];

        //    query.SelectClause = "select ";
        //    int i = 0;
        //    foreach (Expression arg in newArray.Expressions)
        //    {
        //        string path = ConvertExpression(arg);
        //        query.SelectClause += path;

        //        i++;
        //        if (i<newArray.Expressions.Count)
        //            query.SelectClause += ",";
        //    }
        //}

        //public static void CreateLoadspan<T>(MemberInitExpression expression,LinqQuery<T> query)
        //{

        //    query.SelectClause = "select ";
        //    int i = 0;
        //    foreach (MemberAssignment binding in expression.Bindings)
        //    {
        //        string path = ConvertExpression(binding.Expression);
        //        query.SelectClause += path;

        //        i++;
        //        if (i<expression.Bindings.Count)
        //            query.SelectClause += ",";
        //    }
        //}
    }
}
