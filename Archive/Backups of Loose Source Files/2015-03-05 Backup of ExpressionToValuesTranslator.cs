//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;

//namespace JJ.Framework.Reflection
//{
//    internal class ExpressionToValuesTranslator : ExpressionToValueTranslator
//    {
//        private IList<object> _list;

//        public IList<object> GetValues(Expression expression)
//        {
//            _list = new List<object>();

//            object value = GetValue(expression);

//            return _list.Reverse().ToArray();
//        }

//        protected override void VisitMember(MemberExpression node)
//        {
//            base.VisitMember(node);
            
//            _list.Add(_stack.Peek());
//        }
//    }
//}
