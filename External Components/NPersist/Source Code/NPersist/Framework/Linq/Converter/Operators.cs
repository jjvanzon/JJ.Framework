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
        private string ConvertBinaryExpression(BinaryExpression expression)
        {
            string left = ConvertExpression(expression.Left);
            string right = ConvertExpression(expression.Right);

            if (expression.NodeType == ExpressionType.Equal)
            {
                return string.Format("({0} = {1})", left, right);
            }

            if (expression.NodeType == ExpressionType.NotEqual)
            {
                return string.Format("({0} != {1})", left, right);
            }

            if (expression.NodeType == ExpressionType.GreaterThan)
            {
                return string.Format("({0} > {1})", left, right);
            }

            if (expression.NodeType == ExpressionType.LessThan)
            {
                return string.Format("({0} < {1})", left, right);
            }

            if (expression.NodeType == ExpressionType.GreaterThanOrEqual)
            {
                return string.Format("({0} >= {1})", left, right);
            }

            if (expression.NodeType == ExpressionType.LessThanOrEqual)
            {
                return string.Format("({0} <= {1})", left, right);
            }


            if (expression.NodeType == ExpressionType.AndAlso)
            {
                return string.Format("({0} and {1})", left, right);
            }

            if (expression.NodeType == ExpressionType.OrElse)
            {
                return string.Format("({0} or {1})", left, right);
            }

            throw new Exception(string.Format("The method or operation is not implemented. : {0}", expression.NodeType));
        }

        private string ConvertToInequalityExpression(MethodCallExpression expression)
        {
            string left = ConvertExpression(expression.Arguments[0]);
            string right = ConvertExpression(expression.Arguments[1]);

            return string.Format("{0} != {1}", left, right);
        }

        private string ConvertToEqualityExpression(MethodCallExpression expression)
        {
            string left = ConvertExpression(expression.Arguments[0]);
            string right = ConvertExpression(expression.Arguments[1]);


            return string.Format("{0} = {1}", left, right);
        }
    }
}