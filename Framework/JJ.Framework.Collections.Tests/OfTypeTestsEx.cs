// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable MemberCanBeProtected.Local
// ReSharper disable PropertyCanBeMadeInitOnly.Local
namespace JJ.Framework.Collections.Legacy.Tests;

[TestClass]
public class OfTypeTestsEx
{
    private abstract class Animal 
    {
        public string Name { get; set; } = "";
    }

    private class Dog : Animal
    {
        public Dog(string name) => Name = name;
    }

    private class Cat : Animal
    {
        public Cat(string name) => Name = name;
    }

    [TestMethod]
    public void Test_OfType_Generic_Vs_NonGeneric()
    {
        Animal[] animals =
        [
            new Dog("Bert"),
            new Cat("Mewski"),
            new Dog("Bobby"),
            new Cat("Nummy"),
            new Cat("Felix")
        ];

        Dog   [] dogs1 = animals.OfType<Dog>()      .ToArray();
        Animal[] dogs2 = animals.OfType(typeof(Dog)).ToArray();
        
        Cat   [] cats1 = animals.OfType<Cat>()      .ToArray();
        Animal[] cats2 = animals.OfType(typeof(Cat)).ToArray();

        IsNotNull(          animals);
        AreEqual (5,        animals.Length);
        IsNotNull(          animals[0]);
        AreEqual ("Bert",   animals[0].Name);
        IsNotNull(          animals[1]);
        AreEqual ("Mewski", animals[1].Name);
        IsNotNull(          animals[2]);
        AreEqual ("Bobby",  animals[2].Name);
        IsNotNull(          animals[3]);
        AreEqual ("Nummy",  animals[3].Name);
        IsNotNull(          animals[4]);
        AreEqual ("Felix",  animals[4].Name);

        IsNotNull(          dogs1);
        AreEqual (2,        dogs1.Length);
        IsNotNull(          dogs1[0]);
        AreEqual ("Bert",   dogs1[0].Name);
        IsNotNull(          dogs1[1]);
        AreEqual ("Bobby",  dogs1[1].Name);

        IsNotNull(          dogs2);
        AreEqual (2,        dogs2.Length);
        IsNotNull(          dogs2[0]);
        AreEqual ("Bert",   dogs2[0].Name);
        IsNotNull(          dogs2[1]);
        AreEqual ("Bobby",  dogs2[1].Name);

        IsNotNull(          cats1);
        AreEqual (3,        cats1.Length);
        IsNotNull(          cats1[0]);
        AreEqual ("Mewski", cats1[0].Name);
        IsNotNull(          cats1[1]);
        AreEqual ("Nummy",  cats1[1].Name);
        IsNotNull(          cats1[2]);
        AreEqual ("Felix",  cats1[2].Name);

        IsNotNull(          cats2);
        AreEqual (3,        cats2.Length);
        IsNotNull(          cats2[0]);
        AreEqual ("Mewski", cats2[0].Name);
        IsNotNull(          cats2[1]);
        AreEqual ("Nummy",  cats2[1].Name);
        IsNotNull(          cats2[2]);
        AreEqual ("Felix",  cats1[2].Name);
    }

    [TestMethod]
    public void Test_OfType_NonGeneric_NullExceptions()
    {
        Type?     nullType     = null;
        Type      notNullType  = typeof(Cat);
        Animal[]? nullArray    = null;
        Animal[]  notNullArray = [ new Dog("Bert"), new Cat("Mewski") ];

        Throws(() => nullArray!.OfType(notNullType), "source", "null");
        Throws(() => notNullArray.OfType(nullType!), "type", "null");
    }
}