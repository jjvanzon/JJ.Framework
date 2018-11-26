
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using NHibernate.Criterion;

using Expression = System.Linq.Expressions.Expression;

namespace NHibernate.Impl
{

	/// <summary>
	/// Subquery type enumeration
	/// </summary>
	public enum LambdaSubqueryType
	{
		/// <summary>exact</summary>
		Exact = 1,
		/// <summary>all</summary>
		All = 2,
		/// <summary>some</summary>
		Some = 3,
	}

	/// <summary>
	/// Converts lambda expressions to NHibernate criterion/order
	/// </summary>
	public static class ExpressionProcessor
	{

		private readonly static IDictionary<ExpressionType, Func<string, object, ICriterion>> _simpleExpressionCreators = null;
		private readonly static IDictionary<ExpressionType, Func<string, string, ICriterion>> _propertyExpressionCreators = null;
		private readonly static IDictionary<LambdaSubqueryType, IDictionary<ExpressionType, Func<string, DetachedCriteria, AbstractCriterion>>> _subqueryExpressionCreatorTypes = null;
		private readonly static IDictionary<string, Func<MethodCallExpression, ICriterion>> _customMethodCallProcessors = null;

		static ExpressionProcessor()
		{
			_simpleExpressionCreators = new Dictionary<ExpressionType, Func<string, object, ICriterion>>();
			_simpleExpressionCreators[ExpressionType.Equal] = Eq;
			_simpleExpressionCreators[ExpressionType.NotEqual] = Ne;
			_simpleExpressionCreators[ExpressionType.GreaterThan] = Gt;
			_simpleExpressionCreators[ExpressionType.GreaterThanOrEqual] = Ge;
			_simpleExpressionCreators[ExpressionType.LessThan] = Lt;
			_simpleExpressionCreators[ExpressionType.LessThanOrEqual] = Le;

			_propertyExpressionCreators = new Dictionary<ExpressionType, Func<string, string, ICriterion>>();
			_propertyExpressionCreators[ExpressionType.Equal] = Restrictions.EqProperty;
			_propertyExpressionCreators[ExpressionType.NotEqual] = Restrictions.NotEqProperty;
			_propertyExpressionCreators[ExpressionType.GreaterThan] = Restrictions.GtProperty;
			_propertyExpressionCreators[ExpressionType.GreaterThanOrEqual] = Restrictions.GeProperty;
			_propertyExpressionCreators[ExpressionType.LessThan] = Restrictions.LtProperty;
			_propertyExpressionCreators[ExpressionType.LessThanOrEqual] = Restrictions.LeProperty;

			_subqueryExpressionCreatorTypes = new Dictionary<LambdaSubqueryType, IDictionary<ExpressionType, Func<string, DetachedCriteria, AbstractCriterion>>>();
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.Exact] = new Dictionary<ExpressionType, Func<string, DetachedCriteria, AbstractCriterion>>();
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.All] = new Dictionary<ExpressionType, Func<string, DetachedCriteria, AbstractCriterion>>();
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.Some] = new Dictionary<ExpressionType, Func<string, DetachedCriteria, AbstractCriterion>>();

			_subqueryExpressionCreatorTypes[LambdaSubqueryType.Exact][ExpressionType.Equal] = Subqueries.PropertyEq;
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.Exact][ExpressionType.NotEqual] = Subqueries.PropertyNe;
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.Exact][ExpressionType.GreaterThan] = Subqueries.PropertyGt;
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.Exact][ExpressionType.GreaterThanOrEqual] = Subqueries.PropertyGe;
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.Exact][ExpressionType.LessThan] = Subqueries.PropertyLt;
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.Exact][ExpressionType.LessThanOrEqual] = Subqueries.PropertyLe;

			_subqueryExpressionCreatorTypes[LambdaSubqueryType.All][ExpressionType.Equal] = Subqueries.PropertyEqAll;
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.All][ExpressionType.GreaterThan] = Subqueries.PropertyGtAll;
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.All][ExpressionType.GreaterThanOrEqual] = Subqueries.PropertyGeAll;
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.All][ExpressionType.LessThan] = Subqueries.PropertyLtAll;
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.All][ExpressionType.LessThanOrEqual] = Subqueries.PropertyLeAll;

			_subqueryExpressionCreatorTypes[LambdaSubqueryType.Some][ExpressionType.GreaterThan] = Subqueries.PropertyGtSome;
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.Some][ExpressionType.GreaterThanOrEqual] = Subqueries.PropertyGeSome;
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.Some][ExpressionType.LessThan] = Subqueries.PropertyLtSome;
			_subqueryExpressionCreatorTypes[LambdaSubqueryType.Some][ExpressionType.LessThanOrEqual] = Subqueries.PropertyLeSome;

			_customMethodCallProcessors = new Dictionary<string, Func<MethodCallExpression, ICriterion>>();
			RegisterCustomMethodCall(() => RestrictionExtensions.IsLike("", ""), RestrictionExtensions.ProcessIsLike);
			RegisterCustomMethodCall(() => RestrictionExtensions.IsLike("", "", null), RestrictionExtensions.ProcessIsLikeMatchMode);
			RegisterCustomMethodCall(() => RestrictionExtensions.IsLike("", "", null, null), RestrictionExtensions.ProcessIsLikeMatchModeEscapeChar);
			RegisterCustomMethodCall(() => RestrictionExtensions.IsInsensitiveLike("", ""), RestrictionExtensions.ProcessIsInsensitiveLike);
			RegisterCustomMethodCall(() => RestrictionExtensions.IsInsensitiveLike("", "", null), RestrictionExtensions.ProcessIsInsensitiveLikeMatchMode);
			RegisterCustomMethodCall(() => RestrictionExtensions.IsIn(null, new object[0]), RestrictionExtensions.ProcessIsInArray);
			RegisterCustomMethodCall(() => RestrictionExtensions.IsIn(null, new List<object>()), RestrictionExtensions.ProcessIsInCollection);
			RegisterCustomMethodCall(() => RestrictionExtensions.IsBetween(null, null).And(null), RestrictionExtensions.ProcessIsBetween);
		}

		private static ICriterion Eq(string propertyName, object value)
		{
			return Restrictions.Eq(propertyName, value);
		}

		private static ICriterion Ne(string propertyName, object value)
		{
			return
				NHibernate.Criterion.Restrictions.Not(
					NHibernate.Criterion.Restrictions.Eq(propertyName, value));
		}

		private static ICriterion Gt(string propertyName, object value)
		{
			return NHibernate.Criterion.Restrictions.Gt(propertyName, value);
		}

		private static ICriterion Ge(string propertyName, object value)
		{
			return NHibernate.Criterion.Restrictions.Ge(propertyName, value);
		}

		private static ICriterion Lt(string propertyName, object value)
		{
			return NHibernate.Criterion.Restrictions.Lt(propertyName, value);
		}

		private static ICriterion Le(string propertyName, object value)
		{
			return NHibernate.Criterion.Restrictions.Le(propertyName, value);
		}

		/// <summary>
		/// Invoke the expression to extract its runtime value
		/// </summary>
		public static object FindValue(Expression expression)
		{
			var valueExpression = Expression.Lambda(expression).Compile();
			object value = valueExpression.DynamicInvoke();
			return value;
		}

		/// <summary>
		/// Retrieves the name of the property from a member expression
		/// </summary>
		/// <param name="expression">An expression tree that can contain either a member, or a conversion from a member.
		/// If the member is referenced from a null valued object, then the container is treated as an alias.</param>
		/// <returns>The name of the member property</returns>
		public static string FindMemberExpression(Expression expression)
		{
			if (expression is MemberExpression)
			{
				MemberExpression memberExpression = (MemberExpression)expression;

				if (memberExpression.Expression.NodeType == ExpressionType.MemberAccess
					|| memberExpression.Expression.NodeType == ExpressionType.Call)
				{
					if (IsNullableOfT(memberExpression.Member.DeclaringType))
					{
						// it's a Nullable<T>, so ignore any .Value
						if (memberExpression.Member.Name == "Value")
							return FindMemberExpression(memberExpression.Expression);
					}

					return FindMemberExpression(memberExpression.Expression) + "." + memberExpression.Member.Name;
				}
				else
				{
					return memberExpression.Member.Name;
				}
			}

			if (expression is UnaryExpression)
			{
				UnaryExpression unaryExpression = (UnaryExpression)expression;

				if (unaryExpression.NodeType != ExpressionType.Convert)
					throw new Exception("Cannot interpret member from " + expression.ToString());

				return FindMemberExpression(unaryExpression.Operand);
			}

			if (expression is MethodCallExpression)
			{
				MethodCallExpression methodCallExpression = (MethodCallExpression)expression;

				if (methodCallExpression.Method.Name == "GetType")
					return ClassMember(methodCallExpression.Object);

				if (methodCallExpression.Method.Name == "get_Item")
					return FindMemberExpression(methodCallExpression.Object);

				if (methodCallExpression.Method.Name == "First")
					return FindMemberExpression(methodCallExpression.Arguments[0]);

				throw new Exception("Unrecognised method call in epression " + expression.ToString());
			}

			throw new Exception("Could not determine member from " + expression.ToString());
		}

		/// <summary>
		/// Retrieves the name of the property from a member expression (without leading member access)
		/// </summary>
		public static string FindPropertyExpression(Expression expression)
		{
			string memberExpression = FindMemberExpression(expression);
			int periodPosition = memberExpression.LastIndexOf('.') + 1;
			string property = (periodPosition <= 0) ? memberExpression : memberExpression.Substring(periodPosition);
			return property;
		}

		/// <summary>
		/// Retrieves a detached criteria from an appropriate lambda expression
		/// </summary>
		/// <param name="expression">Expresson for detached criteria using .As&lt;>() extension"/></param>
		/// <returns>Evaluated detached criteria</returns>
		public static DetachedCriteria FindDetachedCriteria(Expression expression)
		{
			MethodCallExpression methodCallExpression = expression as MethodCallExpression;

			if (methodCallExpression == null)
				throw new Exception("right operand should be detachedQueryInstance.As<T>() - " + expression.ToString());

			var criteriaExpression = Expression.Lambda(methodCallExpression.Object).Compile();
			QueryOver detachedQuery = (QueryOver)criteriaExpression.DynamicInvoke();
			return detachedQuery.DetachedCriteria;
		}

		private static bool EvaluatesToNull(Expression expression)
		{
			var valueExpression = Expression.Lambda(expression).Compile();
			object value = valueExpression.DynamicInvoke();
			return (value == null);
		}

		private static System.Type FindMemberType(Expression expression)
		{
			if (expression is MemberExpression)
			{
				MemberExpression memberExpression = (MemberExpression)expression;

				return memberExpression.Type;
			}

			if (expression is UnaryExpression)
			{
				UnaryExpression unaryExpression = (UnaryExpression)expression;

				if (unaryExpression.NodeType != ExpressionType.Convert)
					throw new Exception("Cannot interpret member from " + expression.ToString());

				return FindMemberType(unaryExpression.Operand);
			}

			if (expression is MethodCallExpression)
			{
				return typeof(System.Type);
			}

			throw new Exception("Could not determine member type from " + expression.ToString());
		}

		private static bool IsMemberExpression(Expression expression)
		{
			if (expression is MemberExpression)
			{
				MemberExpression memberExpression = (MemberExpression)expression;

				if (memberExpression.Expression == null)
					return false;  // it's a member of a static class

				if (memberExpression.Expression.NodeType == ExpressionType.Parameter)
					return true;

				if (memberExpression.Expression.NodeType == ExpressionType.MemberAccess)
				{
					// if the member has a null value, it was an alias
					if (EvaluatesToNull(memberExpression.Expression))
						return true;
				}
			}

			if (expression is UnaryExpression)
			{
				UnaryExpression unaryExpression = (UnaryExpression)expression;

				if (unaryExpression.NodeType != ExpressionType.Convert)
					throw new Exception("Cannot interpret member from " + expression.ToString());

				return IsMemberExpression(unaryExpression.Operand);
			}

			return false;
		}

		private static object ConvertType(object value, System.Type type)
		{
			if (value == null)
				return null;

			if (type.IsAssignableFrom(value.GetType()))
				return value;

			if (IsNullableOfT(type))
				type = Nullable.GetUnderlyingType(type);

			if (type.IsEnum)
				return Enum.ToObject(type, value);

			if (type.IsPrimitive)
				return Convert.ChangeType(value, type);

			throw new Exception("Cannot convert '" + value.ToString() + "' to " + type.ToString());
		}

		private static bool IsNullableOfT(System.Type type)
		{
			return type.IsGenericType
				&& type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
		}

		private static ICriterion ProcessSimpleExpression(BinaryExpression be)
		{
			if (be.Left.NodeType == ExpressionType.Call && ((MethodCallExpression)be.Left).Method.Name == "CompareString")
				return ProcessVisualBasicStringComparison(be);

			return ProcessSimpleExpression(be.Left, be.Right, be.NodeType);
		}

		private static ICriterion ProcessSimpleExpression(Expression left, Expression right, ExpressionType nodeType)
		{
			string property = FindMemberExpression(left);
			System.Type propertyType = FindMemberType(left);

			object value = FindValue(right);
			value = ConvertType(value, propertyType);

			if (value == null)
				return ProcessSimpleNullExpression(property, nodeType);

			if (!_simpleExpressionCreators.ContainsKey(nodeType))
				throw new Exception("Unhandled simple expression type: " + nodeType);

			Func<string, object, ICriterion> simpleExpressionCreator = _simpleExpressionCreators[nodeType];
			ICriterion criterion = simpleExpressionCreator(property, value);
			return criterion;
		}

		private static ICriterion ProcessVisualBasicStringComparison(BinaryExpression be)
		{
			var methodCall = (MethodCallExpression)be.Left;

			if (IsMemberExpression(methodCall.Arguments[1]))
				return ProcessMemberExpression(methodCall.Arguments[0], methodCall.Arguments[1], be.NodeType);
			else
				return ProcessSimpleExpression(methodCall.Arguments[0], methodCall.Arguments[1], be.NodeType);
		}

		private static ICriterion ProcessSimpleNullExpression(string property, ExpressionType expressionType)
		{
			if (expressionType == ExpressionType.Equal)
				return Restrictions.IsNull(property);

			if (expressionType == ExpressionType.NotEqual)
				return Restrictions.Not(
					Restrictions.IsNull(property));

			throw new Exception("Cannot supply null value to operator " + expressionType);
		}

		private static ICriterion ProcessMemberExpression(BinaryExpression be)
		{
			return ProcessMemberExpression(be.Left, be.Right, be.NodeType);
		}

		private static ICriterion ProcessMemberExpression(Expression left, Expression right, ExpressionType nodeType)
		{
			string leftProperty = FindMemberExpression(left);
			string rightProperty = FindMemberExpression(right);

			if (!_propertyExpressionCreators.ContainsKey(nodeType))
				throw new Exception("Unhandled property expression type: " + nodeType);

			Func<string, string, ICriterion> propertyExpressionCreator = _propertyExpressionCreators[nodeType];
			ICriterion criterion = propertyExpressionCreator(leftProperty, rightProperty);
			return criterion;
		}

		private static ICriterion ProcessAndExpression(BinaryExpression expression)
		{
			return
				NHibernate.Criterion.Restrictions.And(
					ProcessExpression(expression.Left),
					ProcessExpression(expression.Right));
		}

		private static ICriterion ProcessOrExpression(BinaryExpression expression)
		{
			return
				NHibernate.Criterion.Restrictions.Or(
					ProcessExpression(expression.Left),
					ProcessExpression(expression.Right));
		}

		private static ICriterion ProcessBinaryExpression(BinaryExpression expression)
		{
			switch (expression.NodeType)
			{
				case ExpressionType.AndAlso:
					return ProcessAndExpression(expression);

				case ExpressionType.OrElse:
					return ProcessOrExpression(expression);

				case ExpressionType.Equal:
				case ExpressionType.NotEqual:
				case ExpressionType.GreaterThan:
				case ExpressionType.GreaterThanOrEqual:
				case ExpressionType.LessThan:
				case ExpressionType.LessThanOrEqual:
					if (IsMemberExpression(expression.Right))
						return ProcessMemberExpression(expression);
					else
						return ProcessSimpleExpression(expression);

				default:
					throw new Exception("Unhandled binary expression: " + expression.NodeType + ", " + expression.ToString());
			}
		}

		private static ICriterion ProcessBooleanExpression(Expression expression)
		{
			if (expression is MemberExpression)
			{
				return Restrictions.Eq(FindMemberExpression(expression), true);
			}

			if (expression is UnaryExpression)
			{
				UnaryExpression unaryExpression = (UnaryExpression)expression;

				if (unaryExpression.NodeType != ExpressionType.Not)
					throw new Exception("Cannot interpret member from " + expression.ToString());

				if (IsMemberExpression(unaryExpression.Operand))
					return Restrictions.Eq(FindMemberExpression(unaryExpression.Operand), false);
				else
					return Restrictions.Not(ProcessExpression(unaryExpression.Operand));
			}

			if (expression is MethodCallExpression)
			{
				MethodCallExpression methodCallExpression = (MethodCallExpression)expression;
				return ProcessCustomMethodCall(methodCallExpression);
			}

			if (expression is TypeBinaryExpression)
			{
				TypeBinaryExpression typeBinaryExpression = (TypeBinaryExpression)expression;
				return Restrictions.Eq(ClassMember(typeBinaryExpression.Expression), typeBinaryExpression.TypeOperand.FullName);
			}

			throw new Exception("Could not determine member type from " + expression.NodeType + ", " + expression.ToString() + ", " + expression.GetType());
		}

		private static string ClassMember(Expression expression)
		{
			if (expression.NodeType == ExpressionType.MemberAccess)
				return FindMemberExpression(expression) + ".class";
			else
				return "class";
		}

		private static string Signature(MethodInfo methodInfo)
		{
			return methodInfo.DeclaringType.FullName
				+ ":" + methodInfo.ToString();
		}

		private static ICriterion ProcessCustomMethodCall(MethodCallExpression methodCallExpression)
		{
			string signature = Signature(methodCallExpression.Method);

			if (!_customMethodCallProcessors.ContainsKey(signature))
				throw new Exception("Unrecognised method call: " + signature);

			Func<MethodCallExpression, ICriterion> customMethodCallProcessor = _customMethodCallProcessors[signature];
			ICriterion criterion = customMethodCallProcessor(methodCallExpression);
			return criterion;
		}

		private static ICriterion ProcessExpression(Expression expression)
		{
			if (expression is BinaryExpression)
				return ProcessBinaryExpression((BinaryExpression)expression);
			else
				return ProcessBooleanExpression((Expression)expression);
		}

		private static ICriterion ProcessLambdaExpression(LambdaExpression expression)
		{
			return ProcessExpression(expression.Body);
		}

		/// <summary>
		/// Convert a lambda expression to NHibernate ICriterion
		/// </summary>
		/// <typeparam name="T">The type of the lambda expression</typeparam>
		/// <param name="expression">The lambda expression to convert</param>
		/// <returns>NHibernate ICriterion</returns>
		public static ICriterion ProcessExpression<T>(Expression<Func<T, bool>> expression)
		{
			return ProcessLambdaExpression(expression);
		}

		/// <summary>
		/// Convert a lambda expression to NHibernate ICriterion
		/// </summary>
		/// <param name="expression">The lambda expression to convert</param>
		/// <returns>NHibernate ICriterion</returns>
		public static ICriterion ProcessExpression(Expression<Func<bool>> expression)
		{
			return ProcessLambdaExpression(expression);
		}

		/// <summary>
		/// Convert a lambda expression to NHibernate Order
		/// </summary>
		/// <typeparam name="T">The type of the lambda expression</typeparam>
		/// <param name="expression">The lambda expression to convert</param>
		/// <param name="orderDelegate">The appropriate order delegate (order direction)</param>
		/// <returns>NHibernate Order</returns>
		public static Order ProcessOrder<T>(Expression<Func<T, object>> expression,
											Func<string, Order> orderDelegate)
		{
			string property = FindMemberExpression(expression.Body);
			Order order = orderDelegate(property);
			return order;
		}

		/// <summary>
		/// Convert a lambda expression to NHibernate Order
		/// </summary>
		/// <param name="expression">The lambda expression to convert</param>
		/// <param name="orderDelegate">The appropriate order delegate (order direction)</param>
		/// <returns>NHibernate Order</returns>
		public static Order ProcessOrder(Expression<Func<object>> expression,
											Func<string, Order> orderDelegate)
		{
			string property = FindMemberExpression(expression.Body);
			Order order = orderDelegate(property);
			return order;
		}

		/// <summary>
		/// Convert a lambda expression to NHibernate Order
		/// </summary>
		/// <param name="expression">The lambda expression to convert</param>
		/// <param name="orderDelegate">The appropriate order delegate (order direction)</param>
		/// <param name="isAlias">Indicates if the path is an aliased projection</param>
		/// <returns>NHibernate Order</returns>
		public static Order ProcessOrder(	LambdaExpression expression,
											Func<string, Order> orderDelegate,
											bool isAlias)
		{
			string property = isAlias ? FindPropertyExpression(expression.Body) : FindMemberExpression(expression.Body);
			Order order = orderDelegate(property);
			return order;
		}

		private static AbstractCriterion ProcessSubqueryExpression(LambdaSubqueryType subqueryType,
																	BinaryExpression be)
		{
			string property = FindMemberExpression(be.Left);
			DetachedCriteria detachedCriteria = FindDetachedCriteria(be.Right);

			var subqueryExpressionCreators = _subqueryExpressionCreatorTypes[subqueryType];

			if (!subqueryExpressionCreators.ContainsKey(be.NodeType))
				throw new Exception("Unhandled subquery expression type: " + subqueryType + "," + be.NodeType);

			Func<string, DetachedCriteria, AbstractCriterion> subqueryExpressionCreator = subqueryExpressionCreators[be.NodeType];
			return subqueryExpressionCreator(property, detachedCriteria);
		}

		/// <summary>
		/// Convert a lambda expression to NHibernate subquery AbstractCriterion
		/// </summary>
		/// <typeparam name="T">type of member expression</typeparam>
		/// <param name="subqueryType">type of subquery</param>
		/// <param name="expression">lambda expression to convert</param>
		/// <returns>NHibernate.ICriterion.AbstractCriterion</returns>
		public static AbstractCriterion ProcessSubquery<T>(LambdaSubqueryType subqueryType,
															Expression<Func<T, bool>> expression)
		{
			BinaryExpression be = (BinaryExpression)expression.Body;
			AbstractCriterion criterion = ProcessSubqueryExpression(subqueryType, be);
			return criterion;
		}

		/// <summary>
		/// Convert a lambda expression to NHibernate subquery AbstractCriterion
		/// </summary>
		/// <param name="subqueryType">type of subquery</param>
		/// <param name="expression">lambda expression to convert</param>
		/// <returns>NHibernate.ICriterion.AbstractCriterion</returns>
		public static AbstractCriterion ProcessSubquery(LambdaSubqueryType subqueryType,
														Expression<Func<bool>> expression)
		{
			BinaryExpression be = (BinaryExpression)expression.Body;
			AbstractCriterion criterion = ProcessSubqueryExpression(subqueryType, be);
			return criterion;
		}

		/// <summary>
		/// Register a custom method for use in a QueryOver expression
		/// </summary>
		/// <param name="function">Lambda expression demonstrating call of custom method</param>
		/// <param name="functionProcessor">function to convert MethodCallExpression to ICriterion</param>
		public static void RegisterCustomMethodCall(Expression<Func<bool>> function, Func<MethodCallExpression, ICriterion> functionProcessor)
		{
			MethodCallExpression functionExpression = (MethodCallExpression)function.Body;
			string signature = Signature(functionExpression.Method);
			_customMethodCallProcessors.Add(signature, functionProcessor);
		}

	}

}

