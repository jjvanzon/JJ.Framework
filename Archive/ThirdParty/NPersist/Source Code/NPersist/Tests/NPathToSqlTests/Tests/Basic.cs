using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Samples.Northwind.Domain;
using Puzzle.NPersist.Tests.NPathToSql;

namespace Puzzle.NPersist.Tests.Main
{
	[TestFixture()]
	public class Basic : TestBase
	{

		[Test()]
		public void ParseSubQuery()
		{
			using (IContext context = GetContext())
			{
				//,(select count(*) from Products) as Blah
				string npath = "select CategoryName,(1+3-(5*Id)) as Häst from Category";
				string sql = new NPathQuery(npath,typeof(Category),context).ToSql() ;

				Console.WriteLine(sql) ;
			}
		}

		[Test()]
		public void NullValueStatusTest()
		{
			using (IContext context = new Context(@"C:\Project\ComponaSite\Compona.Web.SiteServiceLayer\bin\Debug\DM.npersist"))
			{
				Compona.Web.SiteDM.User user = (Compona.Web.SiteDM.User)context.GetObject(730,typeof(Compona.Web.SiteDM.User));
				Assert.IsFalse(context.GetNullValueStatus(user,"Email") ) ;
			}
		}
	}
	
}
