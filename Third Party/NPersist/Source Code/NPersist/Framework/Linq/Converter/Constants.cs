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
using System.Reflection;

namespace Puzzle.NPersist.Framework.Linq
{
    public partial class LinqToNPathConverter
    {
        private string ConvertConstantExpression(ConstantExpression expression)
        {
            //TODO: escape string
            if (expression.Value is string)
                return ConvertString(expression);

            if (expression.Value  is int)
                return ConvertInt(expression);

            if (expression.Value is double)
                return ConvertDouble(expression);

            if (expression.Value.GetType().IsNested && expression.Value.GetType().IsSealed)
            {
                
                return ConvertEntityRef(expression);
            }

            throw new Exception("The method or operation is not implemented.");
        }

        private string ConvertEntityRef(ConstantExpression expression)
        {
            FieldInfo field = expression.Value.GetType().GetFields().First();
            object value = field.GetValue(expression.Value);
            this.Parameters.Add(value);
            return "?";
        }

        private string ConvertDouble(ConstantExpression expression) => string.Format(NumberFormatInfo.InvariantInfo, "{0}", expression.Value);

        private string ConvertInt(ConstantExpression expression) => string.Format(NumberFormatInfo.InvariantInfo, "{0}", expression.Value);

        private string ConvertString(ConstantExpression expression) => string.Format("\"{0}\"", expression.Value);
    }
}