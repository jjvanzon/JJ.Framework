using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.NCore.Runtime.Serialization;
using NCoreMain.Data;
using System.Reflection;

namespace NCoreMain.Serialization
{
    [TestClass]
    public class XmlSerializerTest
    {
        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion

        [TestMethod]
        public void DeserializeValueObject()
        {
            ValueObject obj = GetIntegerValueObject(123456);

            int res = (int) obj.GetValue();

            Assert.AreEqual(123456, res);
        }

        private static ValueObject GetIntegerValueObject(int value)
        {
            ValueObject obj = new ValueObject();
            obj.ID = 0;
            obj.Type = typeof (int);
            obj.Value = value.ToString();
            return obj;
        }

        [TestMethod]
        public void Deserialize_1D_ArrayObject()
        {
            ArrayObject arr = GetIntegerArrayObject();

            int[] res = (int[]) arr.GetValue();

            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(i, res[i]);
            }
        }

        [TestMethod]
        public void Deserialize_2D_ArrayObject()
        {
            int z = 0;

            ArrayObject arr = new ArrayObject();
            arr.ID = 0;
            arr.Type = typeof (int[,]);

            ObjectBase[,] items = new ObjectBase[4,4];

            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                    items[x, y] = GetIntegerValueObject(z++);

            arr.Items = items;

            int[,] res = (int[,]) arr.GetValue();

            z = 0;
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                {
                    Assert.AreEqual(z, res[x, y]);
                    z++;
                }
        }

        [TestMethod]
        public void Deserialize_Jagged_ArrayObject()
        {
            ArrayObject arr = new ArrayObject();
            arr.ID = 0;
            arr.Type = typeof (int[][]);

            ArrayObject[] arrObjects = new ArrayObject[4];
            arrObjects[0] = GetIntegerArrayObject();
            arrObjects[1] = GetIntegerArrayObject();
            arrObjects[2] = GetIntegerArrayObject();
            arrObjects[3] = GetIntegerArrayObject();

            arr.Items = new ObjectBase[4] {arrObjects[0], arrObjects[1], arrObjects[2], arrObjects[3]};


            int[][] res = (int[][]) arr.GetValue();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(j, res[i][j]);
                }
            }
        }

        private static ArrayObject GetIntegerArrayObject()
        {
            ArrayObject arr = new ArrayObject();
            arr.ID = 0;
            arr.Type = typeof (int[]);

            int[] ints = new int[4];
            for (int i = 0; i < 4; i++)
                ints[i] = i;

            arr.Items =
                new ObjectBase[4]
                    {
                        GetIntegerValueObject(0), GetIntegerValueObject(1), GetIntegerValueObject(2),
                        GetIntegerValueObject(3)
                    };

            return arr;
        }
        
        [TestMethod]
        public void DeserializeSimpleObject()
        { 
            ReferenceObject robj = new ReferenceObject();
            robj.ID = 0;
            robj.Type = typeof (SomeClass);
            
            
            Field nameField = new Field();
            Field ageField = new Field();
            Field parentField = new Field();
            
            nameField.Name = "name";
            ageField.Name = "age";
            parentField.Name = "parent";

            nameField.Value = NullObject.Default;
            parentField.Value = NullObject.Default;
            ageField.Value = GetIntegerValueObject(55);
                
            robj.Fields.Add(nameField);
            robj.Fields.Add(ageField);
            robj.Fields.Add(parentField);

            SomeClass res = (SomeClass)robj.GetValue();
            
            Assert.AreEqual(res.Name,null);
            Assert.AreEqual(res.Parent,null);
            Assert.AreEqual(res.Age, 55);
        }

        [TestMethod]
        public void DeserializeSelfRefObject()
        {
            ReferenceObject robj = new ReferenceObject();
            robj.ID = 0;
            robj.Type = typeof(SomeClass);

            Field nameField = new Field();
            Field ageField = new Field();
            Field parentField = new Field();

            nameField.Name = "name";
            ageField.Name = "age";
            parentField.Name = "parent";

            nameField.Value = NullObject.Default;
            parentField.Value = robj;
            ageField.Value = GetIntegerValueObject(55);

            robj.Fields.Add(nameField);
            robj.Fields.Add(ageField);
            robj.Fields.Add(parentField);

            SomeClass res = (SomeClass)robj.GetValue();

            Assert.AreEqual(res.Name, null);
            Assert.AreEqual(res.Parent, res);
            Assert.AreEqual(res.Age, 55);
        }   
        
        [TestMethod]
        public void DeserializeEnum()
        {
            ValueObject vobj = new ValueObject();
            vobj.ID = 0;
            vobj.Type = typeof (BindingFlags);

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(BindingFlags));


            vobj.Value = tc.ConvertToString(BindingFlags.ExactBinding | BindingFlags.IgnoreCase);

            BindingFlags res = (BindingFlags)vobj.GetValue();

            Assert.AreEqual(res, BindingFlags.ExactBinding | BindingFlags.IgnoreCase);
            
        }
    }
}