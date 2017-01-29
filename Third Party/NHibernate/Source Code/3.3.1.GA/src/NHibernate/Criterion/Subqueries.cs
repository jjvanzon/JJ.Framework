using System;
using System.Linq.Expressions;

using NHibernate.Criterion.Lambda;
using NHibernate.Impl;

namespace NHibernate.Criterion
{
	/// <summary>
	/// Factory class for AbstractCriterion instances that represent 
	/// involving subqueries.
	/// <c>Expression</c>
	/// <c>Projection</c>
	/// <c>AbstractCriterion</c>
	/// </summary>
	public class Subqueries
	{
		public static AbstractCriterion Exists(DetachedCriteria dc)
		{
			return new ExistsSubqueryExpression("exists", dc);
		}

		public static AbstractCriterion NotExists(DetachedCriteria dc)
		{
			return new ExistsSubqueryExpression("not exists", dc);
		}

		public static AbstractCriterion PropertyEqAll(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, "=", "all", dc);
		}

		public static AbstractCriterion PropertyIn(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, "in", null, dc);
		}

		public static AbstractCriterion PropertyNotIn(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, "not in", null, dc);
		}

		public static AbstractCriterion PropertyEq(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, "=", null, dc);
		}

		public static AbstractCriterion PropertyNe(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, "<>", null, dc);
		}

		public static AbstractCriterion PropertyGt(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, ">", null, dc);
		}

		public static AbstractCriterion PropertyLt(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, "<", null, dc);
		}

		public static AbstractCriterion PropertyGe(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, ">=", null, dc);
		}

		public static AbstractCriterion PropertyLe(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, "<=", null, dc);
		}

		public static AbstractCriterion PropertyGtAll(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, ">", "all", dc);
		}

		public static AbstractCriterion PropertyLtAll(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, "<", "all", dc);
		}

		public static AbstractCriterion PropertyGeAll(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, ">=", "all", dc);
		}

		public static AbstractCriterion PropertyLeAll(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, "<=", "all", dc);
		}

		public static AbstractCriterion PropertyGtSome(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, ">", "some", dc);
		}

		public static AbstractCriterion PropertyLtSome(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, "<", "some", dc);
		}

		public static AbstractCriterion PropertyGeSome(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, ">=", "some", dc);
		}

		public static AbstractCriterion PropertyLeSome(string propertyName, DetachedCriteria dc)
		{
			return new PropertySubqueryExpression(propertyName, "<=", "some", dc);
		}

		public static AbstractCriterion EqAll(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, "=", "all", dc);
		}

		public static AbstractCriterion In(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, "in", null, dc);
		}

		public static AbstractCriterion NotIn(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, "not in", null, dc);
		}

		public static AbstractCriterion Eq(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, "=", null, dc);
		}

		public static AbstractCriterion Gt(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, ">", null, dc);
		}

		public static AbstractCriterion Lt(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, "<", null, dc);
		}

		public static AbstractCriterion Ge(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, ">=", null, dc);
		}

		public static AbstractCriterion Le(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, "<=", null, dc);
		}

		public static AbstractCriterion Ne(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, "<>", null, dc);
		}

		public static AbstractCriterion GtAll(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, ">", "all", dc);
		}

		public static AbstractCriterion LtAll(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, "<", "all", dc);
		}

		public static AbstractCriterion GeAll(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, ">=", "all", dc);
		}

		public static AbstractCriterion LeAll(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, "<=", "all", dc);
		}

		public static AbstractCriterion GtSome(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, ">", "some", dc);
		}

		public static AbstractCriterion LtSome(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, "<", "some", dc);
		}

		public static AbstractCriterion GeSome(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, ">=", "some", dc);
		}

		public static AbstractCriterion LeSome(object value, DetachedCriteria dc)
		{
			return new SimpleSubqueryExpression(value, "<=", "some", dc);
		}

		public static AbstractCriterion Select(DetachedCriteria detachedCriteria)
		{
			return new SelectSubqueryExpression(detachedCriteria);
		}

		/// <summary>
		/// Create a ICriterion for the specified property subquery expression
		/// </summary>
		/// <typeparam name="T">generic type</typeparam>
		/// <param name="expression">lambda expression</param>
		/// <returns>returns LambdaSubqueryBuilder</returns>
		public static LambdaSubqueryBuilder WhereProperty<T>(Expression<Func<T, object>> expression)
		{
			string property = ExpressionProcessor.FindMemberExpression(expression.Body);
			return new LambdaSubqueryBuilder(property, null);
		}

		/// <summary>
		/// Create a ICriterion for the specified property subquery expression
		/// </summary>
		/// <param name="expression">lambda expression</param>
		/// <returns>returns LambdaSubqueryBuilder</returns>
		public static LambdaSubqueryBuilder WhereProperty(Expression<Func<object>> expression)
		{
			string property = ExpressionProcessor.FindMemberExpression(expression.Body);
			return new LambdaSubqueryBuilder(property, null);
		}

		/// <summary>
		/// Create a ICriterion for the specified value subquery expression
		/// </summary>
		/// <param name="value">value</param>
		/// <returns>returns LambdaSubqueryBuilder</returns>
		public static LambdaSubqueryBuilder WhereValue(object value)
		{
			return new LambdaSubqueryBuilder(null, value);
		}

		/// <summary>
		/// Create ICriterion for subquery expression using lambda syntax
		/// </summary>
		/// <typeparam name="T">type of property</typeparam>
		/// <param name="expression">lambda expression</param>
		/// <returns>NHibernate.ICriterion.AbstractCriterion</returns>
		public static AbstractCriterion Where<T>(Expression<Func<T, bool>> expression)
		{
			AbstractCriterion criterion = ExpressionProcessor.ProcessSubquery<T>(LambdaSubqueryType.Exact, expression);
			return criterion;
		}

		/// <summary>
		/// Create ICriterion for (exact) subquery expression using lambda syntax
		/// </summary>
		/// <param name="expression">lambda expression</param>
		/// <returns>NHibernate.ICriterion.AbstractCriterion</returns>
		public static AbstractCriterion Where(Expression<Func<bool>> expression)
		{
			AbstractCriterion criterion = ExpressionProcessor.ProcessSubquery(LambdaSubqueryType.Exact, expression);
			return criterion;
		}

		/// <summary>
		/// Create ICriterion for (all) subquery expression using lambda syntax
		/// </summary>
		/// <typeparam name="T">type of property</typeparam>
		/// <param name="expression">lambda expression</param>
		/// <returns>NHibernate.ICriterion.AbstractCriterion</returns>
		public static AbstractCriterion WhereAll<T>(Expression<Func<T, bool>> expression)
		{
			AbstractCriterion criterion = ExpressionProcessor.ProcessSubquery<T>(LambdaSubqueryType.All, expression);
			return criterion;
		}

		/// <summary>
		/// Create ICriterion for (all) subquery expression using lambda syntax
		/// </summary>
		/// <param name="expression">lambda expression</param>
		/// <returns>NHibernate.ICriterion.AbstractCriterion</returns>
		public static AbstractCriterion WhereAll(Expression<Func<bool>> expression)
		{
			AbstractCriterion criterion = ExpressionProcessor.ProcessSubquery(LambdaSubqueryType.All, expression);
			return criterion;
		}

		/// <summary>
		/// Create ICriterion for (some) subquery expression using lambda syntax
		/// </summary>
		/// <typeparam name="T">type of property</typeparam>
		/// <param name="expression">lambda expression</param>
		/// <returns>NHibernate.ICriterion.AbstractCriterion</returns>
		public static AbstractCriterion WhereSome<T>(Expression<Func<T, bool>> expression)
		{
			AbstractCriterion criterion = ExpressionProcessor.ProcessSubquery<T>(LambdaSubqueryType.Some, expression);
			return criterion;
		}

		/// <summary>
		/// Create ICriterion for (some) subquery expression using lambda syntax
		/// </summary>
		/// <param name="expression">lambda expression</param>
		/// <returns>NHibernate.ICriterion.AbstractCriterion</returns>
		public static AbstractCriterion WhereSome(Expression<Func<bool>> expression)
		{
			AbstractCriterion criterion = ExpressionProcessor.ProcessSubquery(LambdaSubqueryType.Some, expression);
			return criterion;
		}

		/// <summary>
		/// Add an Exists subquery criterion
		/// </summary>
		public static AbstractCriterion WhereExists<U>(QueryOver<U> detachedQuery)
		{
			 return Subqueries.Exists(detachedQuery.DetachedCriteria);
		}

		/// <summary>
		/// Add a NotExists subquery criterion
		/// </summary>
		public static AbstractCriterion WhereNotExists<U>(QueryOver<U> detachedQuery)
		{
			return Subqueries.NotExists(detachedQuery.DetachedCriteria);
		}

        public static AbstractCriterion IsNull(DetachedCriteria dc)
        {
            return new NullSubqueryExpression("IS NULL", dc);
        }

        public static AbstractCriterion IsNotNull(DetachedCriteria dc)
        {
            return new NullSubqueryExpression("IS NOT NULL", dc);
        }
	}
}
