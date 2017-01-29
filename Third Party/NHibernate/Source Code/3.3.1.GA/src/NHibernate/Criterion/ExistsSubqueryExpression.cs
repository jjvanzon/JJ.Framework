using System;
using NHibernate.SqlCommand;

namespace NHibernate.Criterion
{
	[Serializable]
	public class ExistsSubqueryExpression : SubqueryExpression
	{
		protected override SqlString ToLeftSqlString(ICriteria criteria, ICriteriaQuery outerQuery)
		{
			return SqlString.Empty;
		}

		internal ExistsSubqueryExpression(string quantifier, DetachedCriteria dc) : base(null, quantifier, dc)
		{
		}
	}
}