using System;
using System.Collections;
using System.IO;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using NUnit.Framework ;

namespace ODMappingTests
{
	[TestFixture()]
	public class TestDogOwner
	{
		public TestDogOwner()
		{
		}

		[Test()]
		public void TestCreateDogOwnerAndDogs()
		{
			IContext context = ContextFactory.GetContext(this, "DogOwner");
			DogOwner dogOwner = (DogOwner) context.CreateObject(System.Guid.NewGuid() , typeof(DogOwner));

			dogOwner.Name = "Mats Helander";

			Dog dog1 = (Dog) context.CreateObject(System.Guid.NewGuid() , typeof(Dog));
			dog1.Name = "Karo";
			dogOwner.Dogs.Add(dog1);

			Dog dog2 = (Dog) context.CreateObject(System.Guid.NewGuid() , typeof(Dog));
			dog2.Name = "Fido";
			dogOwner.Dogs.Add(dog2);

			context.PersistAll() ;

			context.Dispose();
		}


		[Test()]
		public void TestCreateAndFetchDogOwnerAndDogs()
		{

			System.Guid dogOwnerId = System.Guid.NewGuid();
			System.Guid dog1Id = System.Guid.NewGuid();
			System.Guid dog2Id = System.Guid.NewGuid();
			System.Guid profileId = System.Guid.NewGuid();
			System.Guid number1Id = System.Guid.NewGuid();
			System.Guid number2Id = System.Guid.NewGuid();

			IContext context = ContextFactory.GetContext(this, "DogOwner");

			DogOwner dogOwner = (DogOwner) context.CreateObject(dogOwnerId , typeof(DogOwner));
			dogOwner.Name = "Mats Helander";

			Profile profile = (Profile) context.CreateObject(profileId , typeof(Profile));
			profile.Email = "mats@Puzzle.com";
			dogOwner.Profile = profile;

			PhoneNumber number1 = (PhoneNumber) context.CreateObject(number1Id , typeof(PhoneNumber));
			number1.Number = "555-1234";
			profile.PhoneNumbers.Add(number1);

			PhoneNumber number2 = (PhoneNumber) context.CreateObject(number2Id , typeof(PhoneNumber));
			number2.Number = "555-4321";
			profile.PhoneNumbers.Add(number2);

			Dog dog1 = (Dog) context.CreateObject(dog1Id , typeof(Dog));
			dog1.Name = "Karo";
			dogOwner.Dogs.Add(dog1);

			Dog dog2 = (Dog) context.CreateObject(dog2Id , typeof(Dog));
			dog2.Name = "Fido";
			dogOwner.Dogs.Add(dog2);

			Assert.IsTrue(dog1.DogOwner == dogOwner) ;
			
			context.PersistAll() ;

			context.Dispose();

			IContext context2 = ContextFactory.GetContext(this, "DogOwner");
			DogOwner dogOwner2 = (DogOwner) context2.GetObject(dogOwnerId , typeof(DogOwner));

			Dog dog12 = (Dog) context2.GetObject(dog1Id , typeof(Dog));
			Dog dog22 = (Dog) context2.GetObject(dog2Id , typeof(Dog));

			Assert.IsTrue(dog12.DogOwner == dogOwner2) ;
			Assert.IsTrue(dog22.DogOwner == dogOwner2) ;

			Assert.IsTrue(dogOwner2.Dogs.Contains(dog12)) ;
			Assert.IsTrue(dogOwner2.Dogs.Contains(dog22)) ;

			context2.Dispose();
		}

	
		[Test()]
		public void TestCreateAndFetchDogOwnerAndDogsWithLazyDogOwner()
		{

			System.Guid dogOwnerId = System.Guid.NewGuid();
			System.Guid dog1Id = System.Guid.NewGuid();
			System.Guid dog2Id = System.Guid.NewGuid();

			IContext context = ContextFactory.GetContext(this, "DogOwner");
			DogOwner dogOwner = (DogOwner) context.CreateObject(dogOwnerId , typeof(DogOwner));

			dogOwner.Name = "Mats Helander";

			Dog dog1 = (Dog) context.CreateObject(dog1Id , typeof(Dog));
			dog1.Name = "Karo";
			dogOwner.Dogs.Add(dog1);

			Dog dog2 = (Dog) context.CreateObject(dog2Id , typeof(Dog));
			dog2.Name = "Fido";
			dogOwner.Dogs.Add(dog2);

			context.PersistAll() ;

			context.Dispose();

			IContext context2 = ContextFactory.GetContext(this, "DogOwner");

			Dog dog12 = (Dog) context2.GetObject(dog1Id , typeof(Dog));
			Dog dog22 = (Dog) context2.GetObject(dog2Id , typeof(Dog));

			Assert.IsTrue(context2.GetPropertyStatus(dog12, "DogOwner") == PropertyStatus.Clean);
			Assert.IsTrue(context2.GetPropertyStatus(dog22, "DogOwner") == PropertyStatus.Clean);

			Assert.IsTrue(context2.GetPropertyStatus(dog12.DogOwner, "Id") == PropertyStatus.Clean);
			Assert.IsTrue(context2.GetPropertyStatus(dog22.DogOwner, "Id") == PropertyStatus.Clean);

			Assert.IsTrue(dog12.DogOwner.Id == dogOwnerId) ;
			Assert.IsTrue(dog22.DogOwner.Id == dogOwnerId) ;

			Assert.IsTrue(dog12.DogOwner.Name == "Mats Helander") ;

			context2.Dispose();
		}

		[Test()]
		public void TestCreateAndFetchAllDogOwnerAndDogs()
		{
			string dir = @"C:\Test\Xml\ODMappingTests.Dog";
			if (Directory.Exists(dir))
				Directory.Delete(dir, true);

			dir = @"C:\Test\Xml\ODMappingTests.DogOwner";
			if (Directory.Exists(dir))
				Directory.Delete(dir, true);

			dir = @"C:\Test\Xml\ODMappingTests.PhoneNumber";
			if (Directory.Exists(dir))
				Directory.Delete(dir, true);

			System.Guid dogOwnerId = System.Guid.NewGuid();
			System.Guid dog1Id = System.Guid.NewGuid();
			System.Guid dog2Id = System.Guid.NewGuid();
			System.Guid profileId = System.Guid.NewGuid();
			System.Guid number1Id = System.Guid.NewGuid();
			System.Guid number2Id = System.Guid.NewGuid();

			IContext context = ContextFactory.GetContext(this, "DogOwner");

			DogOwner dogOwner = (DogOwner) context.CreateObject(dogOwnerId , typeof(DogOwner));
			dogOwner.Name = "Mats Helander";

			Profile profile = (Profile) context.CreateObject(profileId , typeof(Profile));
			profile.Email = "mats@Puzzle.com";
			dogOwner.Profile = profile;

			PhoneNumber number1 = (PhoneNumber) context.CreateObject(number1Id , typeof(PhoneNumber));
			number1.Number = "555-1234";
			profile.PhoneNumbers.Add(number1);

			PhoneNumber number2 = (PhoneNumber) context.CreateObject(number2Id , typeof(PhoneNumber));
			number2.Number = "555-4321";
			profile.PhoneNumbers.Add(number2);

			Dog dog1 = (Dog) context.CreateObject(dog1Id , typeof(Dog));
			dog1.Name = "Karo";
			dogOwner.Dogs.Add(dog1);

			Dog dog2 = (Dog) context.CreateObject(dog2Id , typeof(Dog));
			dog2.Name = "Fido";
			dogOwner.Dogs.Add(dog2);

			Assert.IsTrue(dog1.DogOwner == dogOwner) ;
			
			context.PersistAll() ;

			context.Dispose();

			IContext context2 = ContextFactory.GetContext(this, "DogOwner");

			IList dogOwners = context2.GetObjects(typeof(DogOwner));
			IList dogs = context2.GetObjects(typeof(Dog));

			Assert.AreEqual(1, dogOwners.Count);
			Assert.AreEqual(2, dogs.Count);

			DogOwner dogOwner2 = (DogOwner) dogOwners[0];

			Dog dog12 = (Dog) dogs[0];
			Dog dog22 = (Dog) dogs[1];

			Assert.IsTrue(dog12.DogOwner == dogOwner2) ;
			Assert.IsTrue(dog22.DogOwner == dogOwner2) ;

			Assert.IsTrue(dogOwner2.Dogs.Contains(dog12)) ;
			Assert.IsTrue(dogOwner2.Dogs.Contains(dog22)) ;

			context2.Dispose();
		}


		[Test()]
		public void TestCreatePerClass()
		{
			IContext context = ContextFactory.GetContext(this, "DogOwner");

			PerClassX perClassX1 = (PerClassX) context.CreateObject(System.Guid.NewGuid() , typeof(PerClassX));
			perClassX1.Name = "Mats Helander";

			PerClassX perClassX2 = (PerClassX) context.CreateObject(System.Guid.NewGuid() , typeof(PerClassX));
			perClassX2.Name = "Bo Helander";

			context.PersistAll() ;

			context.Dispose();
		}	

		[Test()]
		public void TestCreateAndFetchPerClass()
		{
			System.Guid id1 = System.Guid.NewGuid() ;
			System.Guid id2 = System.Guid.NewGuid() ;

			IContext context = ContextFactory.GetContext(this, "DogOwner");

			PerClassX perClassX1 = (PerClassX) context.CreateObject(id1 , typeof(PerClassX));
			perClassX1.Name = "Mats Helander";

			PerClassX perClassX2 = (PerClassX) context.CreateObject(id2 , typeof(PerClassX));
			perClassX2.Name = "Bo Helander";

			context.PersistAll() ;

			context.Dispose();

			IContext context2 = ContextFactory.GetContext(this, "DogOwner");

			PerClassX perClassX12 = (PerClassX) context2.GetObject(id1 , typeof(PerClassX));
			PerClassX perClassX22 = (PerClassX) context2.GetObject(id2 , typeof(PerClassX));

			Assert.AreEqual(id1, perClassX12.Id);
			Assert.AreEqual(id2, perClassX22.Id);

			Assert.AreEqual("Mats Helander", perClassX12.Name);
			Assert.AreEqual("Bo Helander", perClassX22.Name);

		}

		[Test()]
		public void TestCreateAndFetchAllPerClass()
		{
			string file = @"C:\Test\Xml\ODMappingTests.PerClassX\ODMappingTests.PerClassX.xml";
			if (File.Exists(file))
				File.Delete(file);

			System.Guid id1 = System.Guid.NewGuid() ;
			System.Guid id2 = System.Guid.NewGuid() ;

			IContext context = ContextFactory.GetContext(this, "DogOwner");

			PerClassX perClassX1 = (PerClassX) context.CreateObject(id1 , typeof(PerClassX));
			perClassX1.Name = "Mats Helander";

			PerClassX perClassX2 = (PerClassX) context.CreateObject(id2 , typeof(PerClassX));
			perClassX2.Name = "Bo Helander";

			context.PersistAll() ;

			context.Dispose();

			IContext context2 = ContextFactory.GetContext(this, "DogOwner");

			IList perClassX = context2.GetObjects(typeof(PerClassX));

			Assert.AreEqual(2, perClassX.Count);

			PerClassX perClassX12 = (PerClassX) perClassX[0];
			PerClassX perClassX22 = (PerClassX) perClassX[1];

			Assert.AreEqual(id1, perClassX12.Id);
			Assert.AreEqual(id2, perClassX22.Id);

			Assert.AreEqual("Mats Helander", perClassX12.Name);
			Assert.AreEqual("Bo Helander", perClassX22.Name);

		}

		[Test()]
		public void TestCreatePerDomain()
		{
			IContext context = ContextFactory.GetContext(this, "DogOwner");

			PerDomainA perDomainA1 = (PerDomainA) context.CreateObject(System.Guid.NewGuid() , typeof(PerDomainA));
			perDomainA1.Name = "Mats Helander";

			PerDomainA perDomainA2 = (PerDomainA) context.CreateObject(System.Guid.NewGuid() , typeof(PerDomainA));
			perDomainA2.Name = "Bo Helander";

			PerDomainB perDomainB1 = (PerDomainB) context.CreateObject(System.Guid.NewGuid() , typeof(PerDomainB));
			perDomainB1.Name = "John Doe";

			PerDomainB perDomainB2 = (PerDomainB) context.CreateObject(System.Guid.NewGuid() , typeof(PerDomainB));
			perDomainB2.Name = "Jane Doe";

			context.PersistAll() ;

			context.Dispose();
		}	

		[Test()]
		public void TestCreateAndFetchAndDeletePerDomain()
		{
			System.Guid id1 = System.Guid.NewGuid() ;
			System.Guid id2 = System.Guid.NewGuid() ;
			System.Guid id3 = System.Guid.NewGuid() ;
			System.Guid id4 = System.Guid.NewGuid() ;

			IContext context = ContextFactory.GetContext(this, "DogOwner");

			PerDomainA perDomainA1 = (PerDomainA) context.CreateObject(id1 , typeof(PerDomainA));
			perDomainA1.Name = "Mats Helander";

			PerDomainA perDomainA2 = (PerDomainA) context.CreateObject(id2 , typeof(PerDomainA));
			perDomainA2.Name = "Bo Helander";

			PerDomainB perDomainB1 = (PerDomainB) context.CreateObject(id3 , typeof(PerDomainB));
			perDomainB1.Name = "John Doe";

			PerDomainB perDomainB2 = (PerDomainB) context.CreateObject(id4 , typeof(PerDomainB));
			perDomainB2.Name = "Jane Doe";

			context.PersistAll() ;

			context.Dispose();

			IContext context2 = ContextFactory.GetContext(this, "DogOwner");

			PerDomainA perDomainA12 = (PerDomainA) context2.GetObject(id1 , typeof(PerDomainA));
			PerDomainA perDomainA22 = (PerDomainA) context2.GetObject(id2 , typeof(PerDomainA));
			PerDomainB perDomainB12 = (PerDomainB) context2.GetObject(id3 , typeof(PerDomainB));
			PerDomainB perDomainB22 = (PerDomainB) context2.GetObject(id4 , typeof(PerDomainB));

			perDomainA12.Name = "Mats Helander";
			perDomainA22.Name = "Bo Helander";
			perDomainB12.Name = "John Doe";
			perDomainB22.Name = "Jane Doe";

			Assert.AreEqual(id1, perDomainA12.Id);
			Assert.AreEqual(id2, perDomainA22.Id);
			Assert.AreEqual(id3, perDomainB12.Id);
			Assert.AreEqual(id4, perDomainB22.Id);

			Assert.AreEqual("Mats Helander", perDomainA12.Name);
			Assert.AreEqual("Bo Helander", perDomainA22.Name);
			Assert.AreEqual("John Doe", perDomainB12.Name);
			Assert.AreEqual("Jane Doe", perDomainB22.Name);

			context2.DeleteObject(perDomainA12);
			context2.DeleteObject(perDomainA22);
			context2.DeleteObject(perDomainB12);
			context2.DeleteObject(perDomainB22);
			
			context2.PersistAll() ;

			context2.Dispose();

		}	

	
		[Test()]
		public void TestCreateAndFetchAllAndDeletePerDomain()
		{
			string file = @"C:\Test\Xml\DogOwner.xml";
			if (File.Exists(file))
				File.Delete(file);

			System.Guid id1 = System.Guid.NewGuid() ;
			System.Guid id2 = System.Guid.NewGuid() ;
			System.Guid id3 = System.Guid.NewGuid() ;
			System.Guid id4 = System.Guid.NewGuid() ;

			IContext context = ContextFactory.GetContext(this, "DogOwner");

			PerDomainA perDomainA1 = (PerDomainA) context.CreateObject(id1 , typeof(PerDomainA));
			perDomainA1.Name = "Mats Helander";

			PerDomainA perDomainA2 = (PerDomainA) context.CreateObject(id2 , typeof(PerDomainA));
			perDomainA2.Name = "Bo Helander";

			PerDomainB perDomainB1 = (PerDomainB) context.CreateObject(id3 , typeof(PerDomainB));
			perDomainB1.Name = "John Doe";

			PerDomainB perDomainB2 = (PerDomainB) context.CreateObject(id4 , typeof(PerDomainB));
			perDomainB2.Name = "Jane Doe";

			context.PersistAll() ;

			context.Dispose();

			IContext context2 = ContextFactory.GetContext(this, "DogOwner");

			IList perDomainA = context2.GetObjects(typeof(PerDomainA));
			IList perDomainB = context2.GetObjects(typeof(PerDomainB));

			Assert.AreEqual(2, perDomainA.Count);
			Assert.AreEqual(2, perDomainB.Count);

			PerDomainA perDomainA12 = (PerDomainA) perDomainA[0] ;
			PerDomainA perDomainA22 = (PerDomainA) perDomainA[1];
			PerDomainB perDomainB12 = (PerDomainB) perDomainB[0];
			PerDomainB perDomainB22 = (PerDomainB) perDomainB[1];

			perDomainA12.Name = "Mats Helander";
			perDomainA22.Name = "Bo Helander";
			perDomainB12.Name = "John Doe";
			perDomainB22.Name = "Jane Doe";

			Assert.AreEqual(id1, perDomainA12.Id);
			Assert.AreEqual(id2, perDomainA22.Id);
			Assert.AreEqual(id3, perDomainB12.Id);
			Assert.AreEqual(id4, perDomainB22.Id);

			Assert.AreEqual("Mats Helander", perDomainA12.Name);
			Assert.AreEqual("Bo Helander", perDomainA22.Name);
			Assert.AreEqual("John Doe", perDomainB12.Name);
			Assert.AreEqual("Jane Doe", perDomainB22.Name);

			context2.DeleteObject(perDomainA12);
			context2.DeleteObject(perDomainA22);
			context2.DeleteObject(perDomainB12);
			context2.DeleteObject(perDomainB22);
			
			context2.PersistAll() ;

			context2.Dispose();

		}	

		[Test()]
		public void TestCreateAndFetchByNPathPerDomain()
		{
			string file = @"C:\Test\Xml\DogOwner.xml";
			if (File.Exists(file))
				File.Delete(file);

			System.Guid id1 = System.Guid.NewGuid() ;
			System.Guid id2 = System.Guid.NewGuid() ;
			System.Guid id3 = System.Guid.NewGuid() ;
			System.Guid id4 = System.Guid.NewGuid() ;

			IContext context = ContextFactory.GetContext(this, "DogOwner");

			PerDomainA perDomainA1 = (PerDomainA) context.CreateObject(id1 , typeof(PerDomainA));
			perDomainA1.Name = "Mats Helander";

			PerDomainA perDomainA2 = (PerDomainA) context.CreateObject(id2 , typeof(PerDomainA));
			perDomainA2.Name = "Bo Helander";

			PerDomainB perDomainB1 = (PerDomainB) context.CreateObject(id3 , typeof(PerDomainB));
			perDomainB1.Name = "John Doe";

			PerDomainB perDomainB2 = (PerDomainB) context.CreateObject(id4 , typeof(PerDomainB));
			perDomainB2.Name = "Jane Doe";

			context.PersistAll() ;

			context.Dispose();

			IContext context2 = ContextFactory.GetContext(this, "DogOwner");

			IList result = context2.GetObjectsByNPath("Select * From PerDomainA Where Name Like '%ts He%'", typeof(PerDomainA));

			Assert.AreEqual(1, result.Count);
			Assert.AreEqual("Mats Helander", ((PerDomainA) result[0]).Name);

			context2.Dispose();

		}	

	}
}
