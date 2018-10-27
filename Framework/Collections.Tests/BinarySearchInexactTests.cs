//using System;
//using JJ.Framework.Testing;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace JJ.Framework.Collections.Tests
//{
//    [TestClass]
//    public class BinarySearchInexactTests
//    {
//        [TestMethod]
//        public void Test_BinarySearchInexact_JumpsAlignWithIndices_ExactMatch()
//        {
//            var values = new[] { 1, 5, 9, 14, 19, 60, 128, 200 };

//            (int before, int after) = values.BinarySearchInexact(14);

//            AssertHelper.AreEqual(14, () => before);
//            AssertHelper.AreEqual(14, () => after);
//        }

//        [TestMethod]
//        public void Test_BinarySearchInexact_JumpsAlignWithIndices_InexactMatch()
//        {
//            var values = new[] { 1, 5, 9, 14, 19, 60, 128, 200 };

//            (int before, int after) = values.BinarySearchInexact(15);

//            AssertHelper.AreEqual(14, () => before);
//            AssertHelper.AreEqual(19, () => after);
//        }

//        [TestMethod]
//        public void Test_BinarySearchInexact_JumpsNotAlignedWithIndices_ExactMatch()
//        {
//            var values = new[] { 1, 5, 9, 14, 19, 60 };

//            (int before, int after) = values.BinarySearchInexact(5);

//            AssertHelper.AreEqual(5, () => before);
//            AssertHelper.AreEqual(5, () => after);
//        }

//        [TestMethod]
//        public void Test_BinarySearchInexact_JumpsNotAlignedWithIndices_InexactMatch()
//        {
//            var values = new[] { 1, 5, 9, 14, 19, 60 };

//            (int before, int after) = values.BinarySearchInexact(6);

//            AssertHelper.AreEqual(5, () => before);
//            AssertHelper.AreEqual(9, () => after);
//        }

//        [TestMethod]
//        public void Test_BinarySearchInexact_ArbitrarySituation()
//        {
//            var values = new[] { 1, 5, 9, 14, 19, 60 };

//            (int before, int after) = values.BinarySearchInexact(6);

//            AssertHelper.AreEqual(5, () => before);
//            AssertHelper.AreEqual(9, () => after);
//        }

//        // Test the Overloads

//        //[TestMethod]
//        //public void Test_BinarySearchInexact_InCollectionExtensions_WithArray() => throw new NotImplementedException();

//        //[TestMethod]
//        //public void Test_BinarySearchInexact_InCollectionExtensions_WithArray_AndPrecalculatedValues() => throw new NotImplementedException();

//        //[TestMethod]
//        //public void Test_BinarySearchInexact_InCollectionExtensions_WithIEnumerable() => throw new NotImplementedException();

//        //[TestMethod]
//        //public void Test_BinarySearchInexact_InCollectionExtensions_WithIEnumerable_AndPrecalculatedValues() => throw new NotImplementedException();

//        //[TestMethod]
//        //public void Test_BinarySearchInexact_InCollectionHelper_WithTuples() => throw new NotImplementedException();

//        //[TestMethod]
//        //public void Test_BinarySearchInexact_InCollectionHelper_WithTuples_AndPrecalculatedValues() => throw new NotImplementedException();

//        //[TestMethod]
//        //public void Test_BinarySearchInexact_InCollectionHelper_WithOutVariables() => throw new NotImplementedException();

//        //[TestMethod]
//        //public void Test_BinarySearchInexact_InCollectionHelper_WithOutVariables_AndPrecalculatedValues() => throw new NotImplementedException();
//    }
//}
