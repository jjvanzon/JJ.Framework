namespace JJ.Framework.Testing.Core.Tests;

[TestClass]
public class TestingCoreRegressionTests
{
            
    [TestMethod]
    public void Test_CaseCollection_Initialization_RegressionCase()
    {
        // This used to fail before FilledInHelper overloads with HashSet<T> and IList<T> were added.
        // Before, the hope was that HashSet<T> would invoke an overload with ICollection<T>,
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
    
    static CaseCollection<Case> CreateCasesInit { get; } = Cases.Add
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
    
    [TestMethod]
    public void Case_FromTemplate_ChangesNullPropsToZeroes_Regression()
    {
        {
            var caseProp = new CaseProp<int> { Nully = null, Coalesced = 4 };
            AreEqual("?4", caseProp.Descriptor);
        }
        {
            var cases = new CaseCollection<Case2>();
            var template = new Case2 { Name = "Template", MainProp = { Nully = null, Coalesced = 4 } };
            AreEqual("?4", template.MainProp.Descriptor);
            
            var subCases = cases.FromTemplate(template, new Case2 { Name = "Derived" });
            var subCase = subCases.GetAll().Single();
            //AreEqual("0?4", subCase.MainProp.Descriptor);
            AreEqual("?4", subCase.MainProp.Descriptor); // Solved! Did it!
        }
    }
    
    private class Case2 : CaseBase<int> { }
}
