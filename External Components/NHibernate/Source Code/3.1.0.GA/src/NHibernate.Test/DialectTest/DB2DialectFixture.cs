using System;
using NHibernate.Dialect;
using NHibernate.SqlCommand;
using NUnit.Framework;

namespace NHibernate.Test.DialectTest
{
	[TestFixture]
	public class DB2DialectFixture
	{
		[Test]
		public void GetLimitString()
		{
			DB2Dialect dialect = new DB2Dialect();
			SqlString sql = new SqlString(
				new object[]
					{
						"select a, b, c ",
						"from d",
						" where X = ",
						Parameter.Placeholder,
						" and Z = ",
						Parameter.Placeholder,
						" order by a, x"
					});

			SqlString limited = dialect.GetLimitString(sql, 1, 2, -1, -2);
			Assert.AreEqual(
				"select * from (select rownumber() over(order by a, x) as rownum, a, b, c from d where X = ? and Z = ? order by a, x) as tempresult where rownum between ?+1 and ?",
				limited.ToString());
			Assert.AreEqual(4, limited.GetParameterCount());
		}
	}
}