using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Wishes.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Wishes.Tests
{
    [TestClass]
    public class TestWishes_Regression_Tests
    {
                
        [TestMethod]
        public void Test_CaseCollection_Initialization_RegressionCase()
        {
            // This used to fail before FilledInWishes overloads with HashSet<T> and IList<T> were added.
            // Before the hope was that HashSet<T> would invoke an overload with ICollection<T>,
            // but instead fell back to overloads that take T,
            // disrupting the intention of checking a collection for null or empty.
            CaseCollection<Case> cases = CreateCasesInit;
        }

        private static int? _ = null;

        private class Case : CaseBase<(int? channels, int? channel)>
        {
            public Case(int? channels, int? channel) : base((channels, channel)) { }

            public Case((int?, int?) init, (int?, int?) val) : base(init, val) { }

            public Case(((int?, int?) nully, (int?, int?) coalesce) init, ( int?, int?) val) : base(init, val) { }
            public Case(( int?, int?) init, ((int?, int?) nully, (int?, int?) coalesce) val ) : base(init, val) { }

            public Case(((int?, int?) nully, (int?, int?) coalesce) init,
                        ((int?, int?) nully, (int?, int?) coalesce) val ) : base(init, val) { }
        }

        static CaseCollection<Case> Cases { get; } = new CaseCollection<Case>();
        
        static CaseCollection<Case> CreateCasesInit => Cases.Add
        (
            // Stereo configurations
            new Case(2,0),
            new Case(2,1),
            new Case(2,_),

            // Mono: channel ignored (defaults to CenterChannel)
            new Case ( (1,_), (1,0) ),
            new Case   (1,0),
            new Case ( (1,1), (1,0) ),
            
            // All Mono: null / 0 Channels => defaults to Mono => ignores the channel.
            new Case ( (_,_) , (1,0) ),
            new Case ( (0,_) , (1,0) ), 
            new Case ( (_,0) , (1,0) ), 
            new Case ( (0,0) , (1,0) ), 
            new Case ( (_,1) , (1,0) ), 
            new Case ( (0,1) , (1,0) ) 
        );

    }
}
