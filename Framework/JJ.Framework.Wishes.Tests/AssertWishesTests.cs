using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Wishes.Testing;
using static System.Array;
using static JJ.Framework.Testing.AssertHelper;
using static JJ.Framework.Wishes.Testing.AssertWishes;
using static JJ.Framework.Wishes.Testing.DeltaDirectionEnum;

namespace JJ.Framework.Wishes.Tests
{
    [TestClass]
    public class AssertWishesTests
    {
        // DeltaDirection with Ints

        [TestMethod]
        public void Test_AssertWishes_AreEqual_OfInt_DeltaDirection_Down()
        {
                                  AreEqual(10, () =>  8, delta: -2, Down);
                                  AreEqual(10, () =>  9, delta: -2, Down); 
                                  AreEqual(10, () => 10, delta: -2, Down); 
            ThrowsException(() => AreEqual(10, () => 11, delta: -2, Down));
            ThrowsException(() => AreEqual(10, () => 12, delta: -2, Down));
        
            ThrowsException(() => AreEqual(10, () =>  8, delta: -1, Down));
                                  AreEqual(10, () =>  9, delta: -1, Down); 
                                  AreEqual(10, () => 10, delta: -1, Down); 
            ThrowsException(() => AreEqual(10, () => 11, delta: -1, Down));
            ThrowsException(() => AreEqual(10, () => 12, delta: -1, Down));
        
            ThrowsException(() => AreEqual(10, () =>  8, delta: 0, Down));
            ThrowsException(() => AreEqual(10, () =>  9, delta: 0, Down)); 
                                  AreEqual(10, () => 10, delta: 0, Down); 
            ThrowsException(() => AreEqual(10, () => 11, delta: 0, Down));
            ThrowsException(() => AreEqual(10, () => 12, delta: 0, Down));
        
            ThrowsException(() => AreEqual(10, () =>  8, delta: 1, Down));
                                  AreEqual(10, () =>  9, delta: 1, Down); 
                                  AreEqual(10, () => 10, delta: 1, Down); 
            ThrowsException(() => AreEqual(10, () => 11, delta: 1, Down));
            ThrowsException(() => AreEqual(10, () => 12, delta: 1, Down));
        
                                  AreEqual(10, () =>  8, delta: 2, Down);
                                  AreEqual(10, () =>  9, delta: 2, Down); 
                                  AreEqual(10, () => 10, delta: 2, Down); 
            ThrowsException(() => AreEqual(10, () => 11, delta: 2, Down));
            ThrowsException(() => AreEqual(10, () => 12, delta: 2, Down));
        }

        [TestMethod]
        public void Test_AssertWishes_AreEqual_OfInt_DeltaDirection_Up()
        {
            ThrowsException(() => AreEqual(10, () =>  8, delta: -2, Up));
            ThrowsException(() => AreEqual(10, () =>  9, delta: -2, Up)); 
            ThrowsException(() => AreEqual(10, () => 10, delta: -2, Up)); 
            ThrowsException(() => AreEqual(10, () => 11, delta: -2, Up));
            ThrowsException(() => AreEqual(10, () => 12, delta: -2, Up));

            ThrowsException(() => AreEqual(10, () =>  8, delta: -1, Up));
            ThrowsException(() => AreEqual(10, () =>  9, delta: -1, Up)); 
            ThrowsException(() => AreEqual(10, () => 10, delta: -1, Up)); 
            ThrowsException(() => AreEqual(10, () => 11, delta: -1, Up));
            ThrowsException(() => AreEqual(10, () => 12, delta: -1, Up));

            ThrowsException(() => AreEqual(10, () =>  8, delta: 0, Up));
            ThrowsException(() => AreEqual(10, () =>  9, delta: 0, Up)); 
                                  AreEqual(10, () => 10, delta: 0, Up); 
            ThrowsException(() => AreEqual(10, () => 11, delta: 0, Up));
            ThrowsException(() => AreEqual(10, () => 12, delta: 0, Up));

            ThrowsException(() => AreEqual(10, () =>  8, delta: 1, Up));
            ThrowsException(() => AreEqual(10, () =>  9, delta: 1, Up)); 
                                  AreEqual(10, () => 10, delta: 1, Up); 
                                  AreEqual(10, () => 11, delta: 1, Up);
            ThrowsException(() => AreEqual(10, () => 12, delta: 1, Up));

            ThrowsException(() => AreEqual(10, () =>  8, delta: 2, Up));
            ThrowsException(() => AreEqual(10, () =>  9, delta: 2, Up)); 
                                  AreEqual(10, () => 10, delta: 2, Up); 
                                  AreEqual(10, () => 11, delta: 2, Up);
                                  AreEqual(10, () => 12, delta: 2, Up);
        }
        
        [TestMethod]
        public void Test_AssertWishes_AreEqual_OfInt_DeltaDirection_Unspecified()
        {
            ThrowsException(() => AreEqual(10, () =>  8, delta: -2));
            ThrowsException(() => AreEqual(10, () =>  9, delta: -2)); 
            ThrowsException(() => AreEqual(10, () => 10, delta: -2)); 
            ThrowsException(() => AreEqual(10, () => 11, delta: -2));
            ThrowsException(() => AreEqual(10, () => 12, delta: -2));

            ThrowsException(() => AreEqual(10, () =>  8, delta: -1));
            ThrowsException(() => AreEqual(10, () =>  9, delta: -1)); 
            ThrowsException(() => AreEqual(10, () => 10, delta: -1)); 
            ThrowsException(() => AreEqual(10, () => 11, delta: -1));
            ThrowsException(() => AreEqual(10, () => 12, delta: -1));

            ThrowsException(() => AreEqual(10, () =>  8, delta: 0));
            ThrowsException(() => AreEqual(10, () =>  9, delta: 0)); 
                                  AreEqual(10, () => 10, delta: 0); 
            ThrowsException(() => AreEqual(10, () => 11, delta: 0));
            ThrowsException(() => AreEqual(10, () => 12, delta: 0));

            ThrowsException(() => AreEqual(10, () =>  8, delta: 1));
                                  AreEqual(10, () =>  9, delta: 1); 
                                  AreEqual(10, () => 10, delta: 1); 
                                  AreEqual(10, () => 11, delta: 1);
            ThrowsException(() => AreEqual(10, () => 12, delta: 1));

                                  AreEqual(10, () =>  8, delta: 2);
                                  AreEqual(10, () =>  9, delta: 2); 
                                  AreEqual(10, () => 10, delta: 2); 
                                  AreEqual(10, () => 11, delta: 2);
                                  AreEqual(10, () => 12, delta: 2);
        }

        // With Doubles

        [TestMethod]
        public void Test_AssertWishes_AreEqual_OfDouble_DeltaDirection_Down()
        {
                                  AreEqual(10.1, () =>  9.1, delta: -1.5, Down);
                                  AreEqual(10.1, () =>  9.6, delta: -1.5, Down); 
                                  AreEqual(10.1, () => 10.1, delta: -1.5, Down); 
            ThrowsException(() => AreEqual(10.1, () => 10.6, delta: -1.5, Down));
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: -1.5, Down));

            ThrowsException(() => AreEqual(10.1, () =>  9.1, delta: -0.5, Down));
                                  AreEqual(10.1, () =>  9.6, delta: -0.5, Down); 
                                  AreEqual(10.1, () => 10.1, delta: -0.5, Down); 
            ThrowsException(() => AreEqual(10.1, () => 10.6, delta: -0.5, Down));
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: -0.5, Down));

            ThrowsException(() => AreEqual(10.1, () =>  9.1, delta: 0.0, Down));
            ThrowsException(() => AreEqual(10.1, () =>  9.6, delta: 0.0, Down)); 
                                  AreEqual(10.1, () => 10.1, delta: 0.0, Down); 
            ThrowsException(() => AreEqual(10.1, () => 10.6, delta: 0.0, Down));
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: 0.0, Down));

            ThrowsException(() => AreEqual(10.1, () =>  9.1, delta: 0.5, Down));
                                  AreEqual(10.1, () =>  9.6, delta: 0.5, Down); 
                                  AreEqual(10.1, () => 10.1, delta: 0.5, Down); 
            ThrowsException(() => AreEqual(10.1, () => 10.6, delta: 0.5, Down));
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: 0.5, Down));

                                  AreEqual(10.1, () =>  9.1, delta: 1.5, Down);
                                  AreEqual(10.1, () =>  9.6, delta: 1.5, Down); 
                                  AreEqual(10.1, () => 10.1, delta: 1.5, Down); 
            ThrowsException(() => AreEqual(10.1, () => 10.6, delta: 1.5, Down));
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: 1.5, Down));
        }

        [TestMethod]
        public void Test_AssertWishes_AreEqual_OfDouble_DeltaDirection_Up()
        {
            ThrowsException(() => AreEqual(10.1, () =>  9.1, delta: -1.5, Up));
            ThrowsException(() => AreEqual(10.1, () =>  9.6, delta: -1.5, Up)); 
            ThrowsException(() => AreEqual(10.1, () => 10.1, delta: -1.5, Up)); 
            ThrowsException(() => AreEqual(10.1, () => 10.6, delta: -1.5, Up));
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: -1.5, Up));

            ThrowsException(() => AreEqual(10.1, () =>  9.1, delta: -0.5, Up));
            ThrowsException(() => AreEqual(10.1, () =>  9.6, delta: -0.5, Up)); 
            ThrowsException(() => AreEqual(10.1, () => 10.1, delta: -0.5, Up)); 
            ThrowsException(() => AreEqual(10.1, () => 10.6, delta: -0.5, Up));
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: -0.5, Up));

            ThrowsException(() => AreEqual(10.1, () =>  9.1, delta: 0, Up));
            ThrowsException(() => AreEqual(10.1, () =>  9.6, delta: 0, Up)); 
                                  AreEqual(10.1, () => 10.1, delta: 0, Up); 
            ThrowsException(() => AreEqual(10.1, () => 10.6, delta: 0, Up));
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: 0, Up));

            ThrowsException(() => AreEqual(10.1, () =>  9.1, delta: 0.5, Up));
            ThrowsException(() => AreEqual(10.1, () =>  9.6, delta: 0.5, Up)); 
                                  AreEqual(10.1, () => 10.1, delta: 0.5, Up); 
                                  AreEqual(10.1, () => 10.6, delta: 0.5, Up);
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: 0.5, Up));

            ThrowsException(() => AreEqual(10.1, () =>  9.1, delta: 1.5, Up));
            ThrowsException(() => AreEqual(10.1, () =>  9.6, delta: 1.5, Up)); 
                                  AreEqual(10.1, () => 10.1, delta: 1.5, Up); 
                                  AreEqual(10.1, () => 10.6, delta: 1.5, Up);
                                  AreEqual(10.1, () => 11.1, delta: 1.5, Up);
        }
        
        [TestMethod]
        public void Test_AssertWishes_AreEqual_OfDouble_DeltaDirection_Unspecified()
        {
            ThrowsException(() => AreEqual(10.1, () =>  9.1, delta: -1.5));
            ThrowsException(() => AreEqual(10.1, () =>  9.6, delta: -1.5)); 
            ThrowsException(() => AreEqual(10.1, () => 10.1, delta: -1.5)); 
            ThrowsException(() => AreEqual(10.1, () => 10.6, delta: -1.5));
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: -1.5));

            ThrowsException(() => AreEqual(10.1, () =>  9.1, delta: -0.5));
            ThrowsException(() => AreEqual(10.1, () =>  9.6, delta: -0.5)); 
            ThrowsException(() => AreEqual(10.1, () => 10.1, delta: -0.5)); 
            ThrowsException(() => AreEqual(10.1, () => 10.6, delta: -0.5));
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: -0.5));

            ThrowsException(() => AreEqual(10.1, () =>  9.1, delta: 0));
            ThrowsException(() => AreEqual(10.1, () =>  9.6, delta: 0)); 
                                  AreEqual(10.1, () => 10.1, delta: 0); 
            ThrowsException(() => AreEqual(10.1, () => 10.6, delta: 0));
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: 0));

            ThrowsException(() => AreEqual(10.1, () =>  9.1, delta: 0.5));
                                  AreEqual(10.1, () =>  9.6, delta: 0.5); 
                                  AreEqual(10.1, () => 10.1, delta: 0.5); 
                                  AreEqual(10.1, () => 10.6, delta: 0.5);
            ThrowsException(() => AreEqual(10.1, () => 11.1, delta: 0.5));

                                  AreEqual(10.1, () =>  9.1, delta: 1.5);
                                  AreEqual(10.1, () =>  9.6, delta: 1.5); 
                                  AreEqual(10.1, () => 10.1, delta: 1.5); 
                                  AreEqual(10.1, () => 10.6, delta: 1.5);
                                  AreEqual(10.1, () => 11.1, delta: 1.5);
        }

        // DeltaDirection Edge-Cases
        
        [TestMethod]
        public void Test_AssertWishes_AreEqual_DeltaDirection_EdgeCase()
        {
            ThrowsException(
                () => AreEqual(10, () => 7, delta: 3, (DeltaDirectionEnum)(-1)), 
                "JJ.Framework.Wishes.Testing.DeltaDirectionEnum value: '-1' is not supported." );

            ThrowsException(
                () => AreEqual(10.1, () => 7, delta: 3, (DeltaDirectionEnum)(-1)), 
                "JJ.Framework.Wishes.Testing.DeltaDirectionEnum value: '-1' is not supported." );
        }
    }
}
