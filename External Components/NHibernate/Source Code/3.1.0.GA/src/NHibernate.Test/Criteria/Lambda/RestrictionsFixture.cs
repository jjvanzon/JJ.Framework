using System;
using System.Collections;

using NUnit.Framework;

using NHibernate.Criterion;

namespace NHibernate.Test.Criteria.Lambda
{

	[TestFixture]
	public class RestrictionsFixture : LambdaFixtureBase
	{

		[Test]
		public void ArbitraryCriterion()
		{
			ICriteria expected =
				CreateTestCriteria(typeof(Person), "personAlias")
					.Add(Restrictions.Lt("Age", 65))
					.Add(Restrictions.Ge("personAlias.Age", 18))
					.Add(Restrictions.Not(Restrictions.Ge("Age", 65)))
					.Add(Restrictions.Not(Restrictions.Lt("personAlias.Age", 18)));

			Person personAlias = null;
			var actual =
				CreateTestQueryOver<Person>(() => personAlias)
					.Where(Restrictions.Where<Person>(p => p.Age < 65))
					.And(Restrictions.Where(() => personAlias.Age >= 18))
					.And(Restrictions.WhereNot<Person>(p => p.Age >= 65))
					.And(Restrictions.WhereNot(() => personAlias.Age < 18));

			AssertCriteriaAreEqual(expected, actual);
		}

		[Test]
		public void SqlOperators()
		{
			ICriteria expected =
				CreateTestCriteria(typeof(Person), "personAlias")
					.Add(Restrictions.Between("Age", 18, 65))
					.Add(Restrictions.Between("personAlias.Age", 18, 65))
					.Add(Restrictions.Not(Restrictions.Between("personAlias.Age", 10, 20)))
					.Add(!Restrictions.In("Name", new string[] { "name4" }))
					.Add(Restrictions.In("Name", new string[] { "name1", "name2", "name3" }))
					.Add(Restrictions.In("Name", new ArrayList() { "name1", "name2", "name3" }))
					.Add(Restrictions.InG<int>("Age", new int[] { 1, 2, 3 }))
					.Add(Restrictions.InsensitiveLike("Name", "test"))
					.Add(Restrictions.InsensitiveLike("Name", "tEsT", MatchMode.Anywhere))
					.Add(Restrictions.IsEmpty("Children"))
					.Add(Restrictions.Not(Restrictions.IsEmpty("Children")))
					.Add(Restrictions.IsNotEmpty("Children"))
					.Add(Restrictions.IsNotNull("Name"))
					.Add(Restrictions.IsNull("Name"))
					.Add(Restrictions.Like("Name", "%test%"))
					.Add(Restrictions.Like("Name", "test", MatchMode.Anywhere))
					.Add(Restrictions.Like("Name", "test", MatchMode.Anywhere, '?'))
					.Add(Restrictions.NaturalId()
							.Set("Name", "my name")
							.Set("personAlias.Age", 18));

			Person personAlias = null;
			var actual =
				CreateTestQueryOver<Person>(() => personAlias)
					.Where(Restrictions.On<Person>(p => p.Age).IsBetween(18).And(65))
					.And(Restrictions.On(() => personAlias.Age).IsBetween(18).And(65))
					.And(Restrictions.On(() => personAlias.Age).Not.IsBetween(10).And(20))
					.And(!Restrictions.On<Person>(p => p.Name).IsIn(new string[] { "name4" }))
					.And(Restrictions.On<Person>(p => p.Name).IsIn(new string[] { "name1", "name2", "name3" }))
					.And(Restrictions.On<Person>(p => p.Name).IsIn(new ArrayList() { "name1", "name2", "name3" }))
					.And(Restrictions.On<Person>(p => p.Age).IsInG<int>(new int[] { 1, 2, 3 }))
					.And(Restrictions.On<Person>(p => p.Name).IsInsensitiveLike("test"))
					.And(Restrictions.On<Person>(p => p.Name).IsInsensitiveLike("tEsT", MatchMode.Anywhere))
					.And(Restrictions.On<Person>(p => p.Children).IsEmpty)
					.And(Restrictions.On<Person>(p => p.Children).Not.IsEmpty)
					.And(Restrictions.On<Person>(p => p.Children).IsNotEmpty)
					.And(Restrictions.On<Person>(p => p.Name).IsNotNull)
					.And(Restrictions.On<Person>(p => p.Name).IsNull)
					.And(Restrictions.On<Person>(p => p.Name).IsLike("%test%"))
					.And(Restrictions.On<Person>(p => p.Name).IsLike("test", MatchMode.Anywhere))
					.And(Restrictions.On<Person>(p => p.Name).IsLike("test", MatchMode.Anywhere, '?'))
					.And(Restrictions.NaturalId()
							.Set<Person>(p => p.Name).Is("my name")
							.Set(() => personAlias.Age).Is(18));

			AssertCriteriaAreEqual(expected, actual);
		}

		[Test]
		public void Junction()
		{
			ICriteria expected =
				CreateTestCriteria(typeof(Person), "personAlias")
					.Add(Restrictions.Conjunction()
							.Add(Restrictions.Eq("Name", "test"))
							.Add(Restrictions.Eq("personAlias.Name", "test")))
					.Add(Restrictions.Disjunction()
							.Add(Restrictions.Eq("Name", "test"))
							.Add(Restrictions.Eq("personAlias.Name", "test")));

			Person personAlias = null;
			var actual =
				CreateTestQueryOver<Person>(() => personAlias)
					.Where(Restrictions.Conjunction()
							.Add<Person>(p => p.Name == "test")
							.Add(() => personAlias.Name == "test"))
					.And(Restrictions.Disjunction()
							.Add<Person>(p => p.Name == "test")
							.Add(() => personAlias.Name == "test"));

			AssertCriteriaAreEqual(expected, actual);
		}

		[Test]
		public void SqlOperatorsInline()
		{
			ICriteria expected =
				CreateTestCriteria(typeof(Person), "personAlias")
					.Add(Restrictions.Between("Age", 18, 65))
					.Add(Restrictions.Between("personAlias.Age", 18, 65))
					.Add(Restrictions.Not(Restrictions.Between("Age", 18, 65)))
					.Add(Restrictions.In("Name", new string[] { "name1", "name2", "name3" }))
					.Add(Restrictions.In("personAlias.Name", new ArrayList() { "name1", "name2", "name3" }))
					.Add(Restrictions.InG<int>("Age", new int[] { 1, 2, 3 }))
					.Add(Restrictions.InsensitiveLike("Name", "test"))
					.Add(Restrictions.InsensitiveLike("Name", "tEsT", MatchMode.Anywhere))
					.Add(Restrictions.IsEmpty("Children"))
					.Add(Restrictions.IsNotEmpty("Children"))
					.Add(Restrictions.IsNotNull("Name"))
					.Add(Restrictions.IsNull("Name"))
					.Add(Restrictions.Like("Name", "%test%"))
					.Add(Restrictions.Like("Name", "test", MatchMode.Anywhere))
					.Add(Restrictions.Like("Name", "test", MatchMode.Anywhere, '?'))
					.Add(Restrictions.Not(Restrictions.Like("Name", "%test%")));

			Person personAlias = null;
			var actual =
				CreateTestQueryOver<Person>(() => personAlias)
					.WhereRestrictionOn(p => p.Age).IsBetween(18).And(65)
					.WhereRestrictionOn(() => personAlias.Age).IsBetween(18).And(65)
					.WhereRestrictionOn(p => p.Age).Not.IsBetween(18).And(65)
					.AndRestrictionOn(p => p.Name).IsIn(new string[] { "name1", "name2", "name3" })
					.AndRestrictionOn(() => personAlias.Name).IsIn(new ArrayList() { "name1", "name2", "name3" })
					.AndRestrictionOn(p => p.Age).IsInG<int>(new int[] { 1, 2, 3 })
					.AndRestrictionOn(p => p.Name).IsInsensitiveLike("test")
					.AndRestrictionOn(p => p.Name).IsInsensitiveLike("tEsT", MatchMode.Anywhere)
					.AndRestrictionOn(p => p.Children).IsEmpty
					.AndRestrictionOn(p => p.Children).IsNotEmpty
					.AndRestrictionOn(p => p.Name).IsNotNull
					.AndRestrictionOn(p => p.Name).IsNull
					.AndRestrictionOn(p => p.Name).IsLike("%test%")
					.AndRestrictionOn(p => p.Name).IsLike("test", MatchMode.Anywhere)
					.AndRestrictionOn(p => p.Name).IsLike("test", MatchMode.Anywhere, '?')
					.AndRestrictionOn(p => p.Name).Not.IsLike("%test%");

			AssertCriteriaAreEqual(expected, actual);
		}

		[Test]
		public void DetachedRestrictions()
		{
			DetachedCriteria expected =
				DetachedCriteria.For<Person>("personAlias")
					.Add(Restrictions.Between("Age", 18, 65))
					.Add(Restrictions.Between("personAlias.Age", 18, 65))
					.Add(Restrictions.In("Name", new string[] { "name1", "name2", "name3" }))
					.Add(Restrictions.In("personAlias.Name", new ArrayList() { "name1", "name2", "name3" }));

			Person personAlias = null;
			QueryOver<Person> actual =
				QueryOver.Of<Person>(() => personAlias)
					.WhereRestrictionOn(p => p.Age).IsBetween(18).And(65)
					.WhereRestrictionOn(() => personAlias.Age).IsBetween(18).And(65)
					.AndRestrictionOn(p => p.Name).IsIn(new string[] { "name1", "name2", "name3" })
					.AndRestrictionOn(() => personAlias.Name).IsIn(new ArrayList() { "name1", "name2", "name3" });

			AssertCriteriaAreEqual(expected, actual);
		}

		[Test]
		public void NullRestriction()
		{
			ICriteria expected =
				CreateTestCriteria(typeof(Person), "personAlias")
					.Add(Restrictions.IsNull("Name"))
					.Add(Restrictions.IsNull("Name"))
					.Add(Restrictions.IsNull("Name"))
					.Add(Restrictions.IsNull("Father"))
					.Add(Restrictions.IsNull("Father"))
					.Add(Restrictions.IsNull("NullableGender"))
					.Add(Restrictions.IsNull("NullableAge"))
					.Add(Restrictions.IsNull("NullableIsParent"))
					.Add(Restrictions.Not(Restrictions.IsNull("Name")))
					.Add(Restrictions.Not(Restrictions.IsNull("Name")))
					.Add(Restrictions.Not(Restrictions.IsNull("Name")))
					.Add(Restrictions.Not(Restrictions.IsNull("Father")))
					.Add(Restrictions.Not(Restrictions.IsNull("Father")))
					.Add(Restrictions.Not(Restrictions.IsNull("NullableGender")))
					.Add(Restrictions.Not(Restrictions.IsNull("NullableAge")))
					.Add(Restrictions.Not(Restrictions.IsNull("NullableIsParent")))
					.Add(Restrictions.IsNull("personAlias.Name"));

			Person personAlias = null;
			CustomPerson nullPerson = null;
			Person.StaticName = null;
			Person emptyPerson = new Person() { Name = null };
			var actual =
				CreateTestQueryOver<Person>(() => personAlias)
					.Where(p => p.Name == null)
					.Where(p => p.Name == Person.StaticName)
					.Where(p => p.Name == emptyPerson.Name)
					.Where(p => p.Father == null)
					.Where(p => p.Father == nullPerson)
					.Where(p => p.NullableGender == null)
					.Where(p => p.NullableAge == null)
					.Where(p => p.NullableIsParent == null)
					.Where(p => p.Name != null)
					.Where(p => p.Name != Person.StaticName)
					.Where(p => p.Name != emptyPerson.Name)
					.Where(p => p.Father != null)
					.Where(p => p.Father != nullPerson)
					.Where(p => p.NullableGender != null)
					.Where(p => p.NullableAge != null)
					.Where(p => p.NullableIsParent != null)
					.Where(() => personAlias.Name == null);

			AssertCriteriaAreEqual(expected, actual);
		}

		[Test]
		public void RestrictionsExtensions()
		{
			ICriteria expected =
				CreateTestCriteria(typeof(Person))
					.Add(Restrictions.Like("Name", "%test%"))
					.Add(Restrictions.Like("Name", "test", MatchMode.End))
					.Add(Restrictions.Like("Name", "test", MatchMode.Start, '?'))
					.Add(Restrictions.InsensitiveLike("Name", "%test%"))
					.Add(Restrictions.InsensitiveLike("Name", "test", MatchMode.Anywhere))
					.Add(Restrictions.In("Name", new string[] { "name1", "name2" }))
					.Add(Restrictions.In("Name", new ArrayList() { "name3", "name4" }))
					.Add(Restrictions.Between("Age", 10, 20));

			IQueryOver<Person> actual =
				CreateTestQueryOver<Person>()
					.Where(p => p.Name.IsLike("%test%"))
					.And(p => p.Name.IsLike("test", MatchMode.End))
					.And(p => p.Name.IsLike("test", MatchMode.Start, '?'))
					.And(p => p.Name.IsInsensitiveLike("%test%"))
					.And(p => p.Name.IsInsensitiveLike("test", MatchMode.Anywhere))
					.And(p => p.Name.IsIn(new string[] { "name1", "name2" }))
					.And(p => p.Name.IsIn(new ArrayList() { "name3", "name4" }))
					.And(p => p.Age.IsBetween(10).And(20));

			AssertCriteriaAreEqual(expected, actual);
		}

	}

}