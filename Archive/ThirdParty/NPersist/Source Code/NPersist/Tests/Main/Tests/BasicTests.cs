using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;

namespace Puzzle.NPersist.Tests.Main.Tests
{
	/// <summary>
	/// Summary description for BasicTests.
	/// </summary>
	[TestFixture]
	public class BasicTests : TestBase
	{
		[Test]
		public void CanInstantiateObject()
		{
			using (IContext context = GetContext())
			{
				Book book = (Book) context.CreateObject(typeof(Book));
			}
		}
	}
}
