using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using JJ.Framework.Common;

namespace JJ.Framework.Reflection.Exceptions
{
    public class InvalidIndexException : Exception
    {
        /// <summary>
        /// Example: "outletViewModel.Keys.OutletListIndex 1 is an invalid index for op.Outlets with count 0."
        /// </summary>
        private const string MESSAGE = "{0} {1} is an invalid index for {2} with count {3}.";

        public InvalidIndexException(Expression<Func<object>> indexNumberExpression, Expression<Func<object>> countExpression)
            : base(String.Format(
                MESSAGE, 
                ExpressionHelper.GetText(indexNumberExpression), 
                ExpressionHelper.GetValue(indexNumberExpression), 
                ExpressionHelper.GetText(countExpression).CutLeft('.').TrimEnd('.'), 
                ExpressionHelper.GetValue(countExpression)))
        {  }
    }
}
