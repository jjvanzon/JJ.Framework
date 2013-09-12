using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using JJ.Framework.Common;

namespace JJ.Framework.Configuration
{
    internal class XmlExpressionTranslator
    {
        private XmlNode _rootXmlNode;

        private Stack<XmlNode> _stack = new Stack<XmlNode>();

        public XmlExpressionTranslator(XmlNode rootXmlNode)
        {
            if (rootXmlNode == null) throw new ArgumentNullException("rootXmlNode");
            _rootXmlNode = rootXmlNode;
            _stack.Push(_rootXmlNode);
        }

        public string Result
        {
            // TODO: handle nulls.
            get 
            {
                XmlNode xmlNode = _stack.Peek();
                if (xmlNode == null)
                {
                    return null;
                }
                return xmlNode.InnerText;
            }
        }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            Visit((LambdaExpression)expression);
        }

        public void Visit(LambdaExpression expression)
        {
            Visit(expression.Body);
        }

        private void Visit(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.MemberAccess:
                    {
                        var memberExpression = (MemberExpression)node;
                        VisitMember(memberExpression);
                        return;
                    }

                //case ExpressionType.Convert:
                //case ExpressionType.ConvertChecked:
                //    {
                //        var unaryExpression = (UnaryExpression)node;
                //        VisitConvert(unaryExpression);
                //        return;
                //    }

                //case ExpressionType.ArrayLength:
                //    {
                //        var unaryExpression = (UnaryExpression)node;
                //        VisitArrayLength(unaryExpression);
                //        return;
                //    }

                //case ExpressionType.Call:
                //    {
                //        var methodCallExpression = (MethodCallExpression)node;
                //        VisitMethodCall(methodCallExpression);
                //        return;
                //    }

                //case ExpressionType.Constant:
                //    {
                //        var constantExpression = (ConstantExpression)node;
                //        VisitConstant(constantExpression);
                //        return;
                //    }

                //case ExpressionType.ArrayIndex:
                //    {
                //        var binaryExpression = (BinaryExpression)node;
                //        VisitArrayIndex(binaryExpression);
                //        return;
                //    }

                //case ExpressionType.NewArrayInit:
                //    {
                //        var newArrayExpression = (NewArrayExpression)node;
                //        VisitNewArray(newArrayExpression);
                //        return;
                //    }

                case ExpressionType.Parameter:
                    {
                        // Ignore
                        return;
                    }
            }

            throw new ArgumentException(String.Format("Value cannot be obtained from {0}.", node.GetType().Name));
        }

        //private void VisitConstant(ConstantExpression constantExpression)
        //{
        //    _stack.Push(constantExpression.Value);
        //}

        private void VisitMember(MemberExpression node)
        {
            // First process 'parent' node.
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            // Then process 'child' node.
            switch (node.Member.MemberType)
            {
                //case MemberTypes.Field:
                //    VisitField(node);
                //    break;

                case MemberTypes.Property:
                    VisitProperty(node);
                    break;

                default:
                    throw new NotSupportedException(String.Format("MemberType {0} is not supported.", node.Member.MemberType));
            }
        }

        //private void VisitField(MemberExpression node)
        //{
        //    var field = (FieldInfo)node.Member;
        //    object obj = null;
        //    if (!field.IsStatic)
        //    {
        //        obj = _stack.Pop();
        //    }
        //    object value = field.GetValue(obj);

        //    _stack.Push(value);
        //}

        private void VisitProperty(MemberExpression node)
        {
            var property = (PropertyInfo)node.Member;
            XmlNode xmlNode = null;
            // TODO: This check may be overkill.
            MethodInfo getterOrSetter = property.GetGetMethod() ?? property.GetSetMethod();
            if (!getterOrSetter.IsStatic)
            {
                xmlNode = _stack.Pop();
            }

            string name = FormatName(property.Name);
            XmlNode childXmlNode = xmlNode.SelectSingleNode(name);
            // HACK
            if (childXmlNode == null)
            {
                childXmlNode = xmlNode.SelectSingleNode("@" + name);
            }

            if (childXmlNode == null)
            {
                throw new Exception(String.Format("XML node '{0}' not found.", name));
            }

            _stack.Push(childXmlNode);
        }

        private string FormatName(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Left(1).ToLower() + input.CutLeft(1);
        }

        //private void VisitMethodCall(MethodCallExpression node)
        //{
        //    if (!node.Method.IsStatic)
        //    {
        //        Visit(node.Object);
        //    }
        //    else
        //    {
        //        Stack.Push(null);
        //    }

        //    for (int i = 0; i < node.Arguments.Count; i++)
        //    {
        //        Visit(node.Arguments[i]);
        //    }
        //    object[] arguments = new object[node.Arguments.Count];
        //    for (int i = node.Arguments.Count - 1; i >= 0; i--)
        //    {
        //        arguments[i] = Stack.Pop();
        //    }

        //    object obj = Stack.Pop();
        //    object value = node.Method.Invoke(obj, arguments);
        //    Stack.Push(value);
        //}

        //private void VisitConvert(UnaryExpression node)
        //{
        //    switch (node.Operand.NodeType)
        //    {
        //        case ExpressionType.MemberAccess:
        //            var memberExpression = (MemberExpression)node.Operand;
        //            VisitMember(memberExpression);
        //            break;

        //        case ExpressionType.Call:
        //            Visit(node.Operand);
        //            break;

        //        case ExpressionType.ArrayIndex:
        //            var binaryExpression = (BinaryExpression)node.Operand;
        //            VisitArrayIndex(binaryExpression);
        //            break;

        //        case ExpressionType.Constant:
        //            VisitConstant(node);
        //            break;

        //        default:
        //            throw new ArgumentException(String.Format("Value cannot be obtained from NodeType {0}.", node.Operand.NodeType));
        //    }
        //    object obj = Stack.Pop();
        //    if (obj is IConvertible)
        //    {
        //        obj = Convert.ChangeType(obj, node.Type);
        //    }
        //    Stack.Push(obj);
        //}

        //private void VisitArrayLength(UnaryExpression node)
        //{
        //    if (node.Operand.NodeType == ExpressionType.MemberAccess)
        //    {
        //        var memberExpression = (MemberExpression)node.Operand;
        //        VisitMember(memberExpression);
        //        Array array = (Array)Stack.Pop();
        //        Stack.Push(array.Length);
        //        return;
        //    }

        //    throw new ArgumentException(String.Format("Value cannot be obtained from NodeType {0}.", node.Operand.NodeType));
        //}

        //private void VisitArrayIndex(BinaryExpression node)
        //{
        //    var memberExpression = (MemberExpression)node.Left;
        //    VisitMember(memberExpression);
        //    var array = (Array)Stack.Pop();

        //    var constantExpression = (ConstantExpression)node.Right;
        //    int index = (int)constantExpression.Value;
        //    Stack.Push(array.GetValue(index));
        //}

        //private void VisitNewArray(NewArrayExpression node)
        //{
        //    for (int i = 0; i < node.Expressions.Count; i++)
        //    {
        //        Visit(node.Expressions[i]);
        //    }
        //    Array array = (Array)Activator.CreateInstance(node.Type, node.Expressions.Count);
        //    for (int i = node.Expressions.Count - 1; i >= 0; i--)
        //    {
        //        object item = Stack.Pop();
        //        array.SetValue(item, i);
        //    }
        //    Stack.Push(array);
        //}
    }
}
