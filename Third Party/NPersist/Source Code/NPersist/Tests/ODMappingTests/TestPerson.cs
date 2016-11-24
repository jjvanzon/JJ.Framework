using System;
using Puzzle.NPersist.Framework;
using NUnit.Framework ;

namespace ODMappingTests
{
	[TestFixture()]
	public class TestPerson
	{
		public TestPerson()
		{
		}

		[Test()]
		public void TestCreatePerson()
		{
			IContext context = ContextFactory.GetContext(this, "Person");
			Person person = (Person) context.CreateObject(System.Guid.NewGuid() , typeof(Person));

			person.FirstName = "Mats";
			person.LastName = "Helander";

			context.PersistAll() ;

			context.Dispose();
		}

		[Test()]
		public void TestCreateAndUpdatePerson()
		{
			IContext context = ContextFactory.GetContext(this, "Person");
			Person person = (Person) context.CreateObject(System.Guid.NewGuid() , typeof(Person));

			person.FirstName = "Mats";
			person.LastName = "Helander";

			context.PersistAll() ;

			person.FirstName = "Bo";

			context.PersistAll() ;

			context.Dispose();
		}

		[Test()]
		public void TestCreateAndRemovePerson()
		{
			IContext context = ContextFactory.GetContext(this, "Person");
			Person person = (Person) context.CreateObject(System.Guid.NewGuid() , typeof(Person));

			person.FirstName = "Mats";
			person.LastName = "Helander";

			context.PersistAll() ;

			context.DeleteObject(person);

			context.PersistAll() ;

			context.Dispose();
		}

		[Test()]
		public void TestCreateAndFetchPerson()
		{
			System.Guid id = Guid.NewGuid() ;
			IContext context = ContextFactory.GetContext(this, "Person");
			Person person = (Person) context.CreateObject(id, typeof(Person));

			person.FirstName = "Mats";
			person.LastName = "Helander";

			context.PersistAll() ;

			context.Dispose();

			IContext context2 = ContextFactory.GetContext(this, "Person");
			Person person2 = (Person) context2.GetObject(id, typeof(Person));

			Assert.AreEqual(person2.FirstName, "Mats");
			Assert.AreEqual(person2.LastName, "Helander");

			context2.Dispose();

		}

	}
}
