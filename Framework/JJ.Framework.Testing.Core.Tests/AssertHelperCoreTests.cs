using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Array;
using static JJ.Framework.Testing.AssertHelper;
using static JJ.Framework.Testing.Core.AssertHelperCore;
using static JJ.Framework.Testing.Core.DeltaDirectionEnum;

namespace JJ.Framework.Testing.Core.Tests
{
    [TestClass]
    public class AssertHelperCoreTests
    {
        // With Ints

        [TestMethod]
        public void AreEqual_WithInts_DeltaDirection_Down()
        {
            AssertDeltaDirection(Down, 10, -2, new[] { 8, 9, 10 }, new[] { 11, 12 });
            AssertDeltaDirection(Down, 10, -1, new[] { 9, 10 }, new[] { 8, 11 });
            AssertDeltaDirection(Down, 10,  0, new[] { 10 }, new[] { 9, 11 });
            AssertDeltaDirection(Down, 10,  1, new[] { 9, 10 }, new[] { 8, 11 });
            AssertDeltaDirection(Down, 10,  2, new[] { 8, 9, 10 }, new[] { 11, 12 });
        }

        [TestMethod]
        public void AreEqual_WithInts_DeltaDirection_Up()
        {
            AssertDeltaDirection(Up, 10, -2, Empty<int>(), new[] { 8, 9, 11, 12 });
            AssertDeltaDirection(Up, 10, -1, Empty<int>(), new[] { 8, 9, 11, 12 });
            AssertDeltaDirection(Up, 10,  0, new[] { 10 }, new[] { 8, 9, 11, 12 });
            AssertDeltaDirection(Up, 10,  1, new[] { 10, 11 }, new[] { 8, 9, 12 });
            AssertDeltaDirection(Up, 10,  2, new[] { 10, 11, 12 }, new[] { 8, 9 });
        }

        [TestMethod]
        public void AreEqual_WithInts_DeltaDirection_None()
        {
            // Negative delta = tolerance downward 
            AssertDeltaDirection(None, 10, -2, new[] { 8, 9, 10 }, new[] { 11, 12 });
            AssertDeltaDirection(None, 10, -1, new[] { 9, 10 }, new[] { 8, 11, 12 });
            
            AssertDeltaDirection(None, 10,  0, new[] { 10 }, new[] { 8, 9, 11, 12 });
            AssertDeltaDirection(None, 10,  1, new[] { 9, 10, 11 }, new[] { 8, 12 });
            AssertDeltaDirection(None, 10,  2, new[] { 8, 9, 10, 11, 12 }, new[] { 7, 13 });
        }

        // With Doubles

        [TestMethod]
        public void AreEqual_WithDoubles_DeltaDirection_Down()
        {
            AssertDeltaDirection(Down, 10.1, -1.5, new[] { 9.1, 9.6, 10.1 }, new[] { 10.6, 11.1 });
            AssertDeltaDirection(Down, 10.1, -0.5, new[] { 9.6, 10.1 }, new[] { 9.1, 10.6, 11.1 });
            AssertDeltaDirection(Down, 10.1,  0.0, new[] { 10.1 }, new[] { 9.1, 9.6, 10.6, 11.1 });
            AssertDeltaDirection(Down, 10.1,  0.5, new[] { 9.6, 10.1 }, new[] { 9.1, 10.6, 11.1 });
            AssertDeltaDirection(Down, 10.1,  1.5, new[] { 9.1, 9.6, 10.1 }, new[] { 10.6, 11.1 });
        }

        [TestMethod]
        public void AreEqual_WithDoubles_DeltaDirection_Up()
        {
            AssertDeltaDirection(Up, 10.1, -1.5, Empty<double>(), new[] { 9.1, 9.6, 10.1, 10.6, 11.1 });
            AssertDeltaDirection(Up, 10.1, -0.5, Empty<double>(), new[] { 9.1, 9.6, 10.1, 10.6, 11.1 });
            AssertDeltaDirection(Up, 10.1,  0.0, new[] { 10.1 }, new[] { 9.1, 9.6, 10.6, 11.1 });
            AssertDeltaDirection(Up, 10.1,  0.5, new[] { 10.1, 10.6 }, new[] { 9.1, 9.6, 11.1 });
            AssertDeltaDirection(Up, 10.1,  1.5, new[] { 10.1, 10.6, 11.1 }, new[] { 9.1, 9.6 });
        }
        
        [TestMethod]
        public void AreEqual_WithDoubles_DeltaDirection_None()
        {
            // Negative delta = tolerance downward 
            AssertDeltaDirection(default, 10.1, -1.5, new[] { 8.6, 9.1, 9.6, 10.1}, new[] { 8.1, 10.6, 11.1 });
            AssertDeltaDirection(default, 10.1, -0.5, new[] { 9.6, 10.1 }, new[] { 9.1, 10.6, 11.1 });
            
            AssertDeltaDirection(default, 10.1,  0.0, new[] { 10.1 }, new[] { 9.1, 9.6, 10.6, 11.1 });
            AssertDeltaDirection(default, 10.1,  0.5, new[] { 9.6, 10.1, 10.6 }, new[] { 9.1, 11.1 });
            AssertDeltaDirection(default, 10.1,  1.5, new[] { 9.1, 9.6, 10.1, 10.6, 11.1 }, Empty<double>());
        }
        
        [TestMethod]
        public void AreEqual_DeltaDirection_WithNegatives()
        {
            // Negative expected
            AssertDeltaDirection(None, -10, 2, new[] { -12, -11, -10, -9, -8 }, new[] { -13, -7 });
            AssertDeltaDirection(Down, -10, 2, new[] { -12, -11, -10 }, new[] { -9, -8 });
            AssertDeltaDirection(Up  , -10, 2, new[] { -10, -9, -8 }, new[] { -12, -11 });

            // Crossing zero
            AssertDeltaDirection(None,  0, 2, new[] { -2, -1, 0, 1, 2 }, new[] { -3, 3 });
            AssertDeltaDirection(Down, -1, 2, new[] { -3, -2, -1 }, new[] { 0, 1 });
            AssertDeltaDirection(Up  ,  1, 2, new[] { 1, 2, 3 }, new[] { -1, 0 });

            // Negative doubles precision
            AssertDeltaDirection(None, -10.5, 1.5, new[] { -12.0, -11.5, -10.5, -10.0, -9.5, -9.0 }, new[] { -12.5, -8.5 });
            AssertDeltaDirection(Down, -10.5, 1.5, new[] { -12.0, -11.5, -10.5 }, new[] { -12.5, -10.0, -9.5 });
            AssertDeltaDirection(Up  , -10.5, 1.5, new[] { -10.5, -10.0, -9.5, -9.0 }, new[] { -12.0, -11.5, -11.0, -8.5, -8.0 });
        }

        // Edge-Cases
        
        [TestMethod]
        public void AreEqual_DeltaDirection_EdgeCases()
        {
            ThrowsException(
                () => AreEqual(10, () => 7, delta: 3, (DeltaDirectionEnum)(-1)), 
                "DeltaDirectionEnum value: '-1' is not supported." );

            ThrowsException(
                () => AreEqual(10.1, () => 7, delta: 3, (DeltaDirectionEnum)(-1)), 
                "DeltaDirectionEnum value: '-1' is not supported." );
        }
        
        // Helpers
        
        private void AssertDeltaDirection(DeltaDirectionEnum direction, int expected, int delta, int[] passingCases, int[] failingCases)
        {
            passingCases.ForEach(value =>                       AreEqual(expected, () => value, delta, direction));
            failingCases.ForEach(value => ThrowsException(() => AreEqual(expected, () => value, delta, direction)));
        }

        private void AssertDeltaDirection(DeltaDirectionEnum direction, double expected, double delta, double[] passingCases, double[] failingCases)
        {
            passingCases.ForEach(value =>                       AreEqual(expected, () => value, delta, direction));
            failingCases.ForEach(value => ThrowsException(() => AreEqual(expected, () => value, delta, direction)));
        }
    }
}
