using System;
using System.Linq.Expressions;
using JJ.Framework.Common;

namespace JJ.Framework.Reflection.Exceptions
{
    public class InvalidIndexException : Exception
    {
        /// <summary> Example: "outletViewModel.Keys.OutletListIndex 1 is an invalid index for op.Outlets with count 0." </summary>
        private const string MESSAGE = "{0} {1} is an invalid index for {2} with count {3}.";

        public InvalidIndexException(Expression<Func<object>> listIndexExpression, Expression<Func<object>> countExpression)
            : base(String.Format(
                MESSAGE, 
                ExpressionHelper.GetText(listIndexExpression), 
                ExpressionHelper.GetValue(listIndexExpression), 
                ExpressionHelper.GetText(countExpression).CutLeft('.').TrimEnd('.'), 
                ExpressionHelper.GetValue(countExpression)))
        {  }
    }
}
