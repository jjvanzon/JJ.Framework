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
        private string ConvertSumExpression(MethodCallExpression expression)
        {

            LambdaExpression sumLambda = expression.Arguments[1] as LambdaExpression;
            string sum = ConvertExpression(sumLambda.Body);
            string from = ConvertExpression(expression.Arguments[0]);
            return string.Format("(select sum({0}) from {1})", sum, from);
        }

        private string ConvertAvgExpression(MethodCallExpression expression)
        {

            LambdaExpression sumLambda = expression.Arguments[1] as LambdaExpression;
            string sum = ConvertExpression(sumLambda.Body);
            string from = ConvertExpression(expression.Arguments[0]);
            return string.Format("(select avg({0}) from {1})", sum, from);
        }

        private string ConvertMinExpression(MethodCallExpression expression)
        {

            LambdaExpression sumLambda = expression.Arguments[1] as LambdaExpression;
            string sum = ConvertExpression(sumLambda.Body);
            string from = ConvertExpression(expression.Arguments[0]);
            return string.Format("(select min({0}) from {1})", sum, from);
        }


        private string ConvertMaxExpression(MethodCallExpression expression)
        {

            LambdaExpression sumLambda = expression.Arguments[1] as LambdaExpression;
            string sum = ConvertExpression(sumLambda.Body);
            string from = ConvertExpression(expression.Arguments[0]);
            return string.Format("(select max({0}) from {1})", sum, from);
        }
    }
}