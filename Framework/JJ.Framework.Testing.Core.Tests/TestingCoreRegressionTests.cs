namespace JJ.Framework.Testing.Core.Tests;

[TestClass]
public class TestingCore_Case_FromTemplate_ChangesNullPropsToZeroes_Regression_Tests
{
    [TestMethod]
    public void Test_CaseCollection_Initialization_Regression()
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

[TestClass]
public class TestingCore_DifferentNullies_OmittedInCaseKeys_CausedDuplicateKeyError_Tests()
{
    // Copied from JJ.Synthesizer repo tests, where the error occurred.
    
    internal class Case : CaseBase<int>
    {
        public CaseProp<int> SamplingRate { get; set; } = new();
        public CaseProp<int> Hz           { get => SamplingRate; set => SamplingRate = value; }
        
        public Case(
            int?    frameCount     = null,
            int?    samplingRate   = null)
        {
            if (frameCount     != null) From = To      = frameCount.Value;
            if (samplingRate   != null) SamplingRate   = samplingRate.Value;
        }
        
        public Case() { }
        public Case(int frameCount) : base(frameCount) { }
        public Case(int from, int to) : base(from, to) { }
    }
    
    [TestMethod]
    public void Test_DifferentNullies_OmittedInCaseKeys_CausedDuplicateKeyError()
    {
        return;
        
        // Duplicate case key:
        // NullyHz ~ 480 f ( ?48000 => 48000 Hz + 3 , 0.01 s
        
        CaseCollection<Case> rootCaseColl = new CaseCollection<Case>();
        
        /*CaseCollection<Case> nullyHzCases2 = */rootCaseColl.FromTemplate(new Case
            
            { Name = "NullyHz" },
            //{ Name = "NullyHz", AudioLength = 0.01, CourtesyFrames = 3 },
          //new Case (480)     { Hz = { From = (null,48000), To = 48000        } },
            new Case (480)     { Hz = { From = (0,48000)   , To = 48000        } }
        );        
        
        /*CaseCollection<Case> nullyHzCases1 = */rootCaseColl.FromTemplate(new Case
            
            { Name = "NullyHz" },
            //{ Name = "NullyHz", AudioLength = 0.01, CourtesyFrames = 3 },
            
                
            new Case (480)     { Hz = { From = (null,48000), To = 48000        } }//,
          //new Case (480)     { Hz = { From = (0,48000)   , To = 48000        } }
        );
    }
    
    [TestMethod]
    public void ZeroAndNull_SameInCaseKeys_LooseCases_NotDuplicate()
    {
        // Keys of loose cases are not same. Hypothesis: It's in the templating.
        var caseWithZero = new Case(480) { Hz = { From = (0,    48000), To = 48000 } };
        var caseWithNull = new Case(480) { Hz = { From = (null, 48000), To = 48000 } };
        string key1 = caseWithZero.ToString();
        string key2 = caseWithNull.ToString();
        NotEqual(key1, key2);
    }
    
    [TestMethod]
    public void ZeroAndNull_SameInCaseKeys_TemplatedCases_WereDuplicate()
    {

        Case caseWith0;
        {
            var rootColl = new CaseCollection<Case>();
            var template = new Case { Name = "NullyHz" };
            var coll = rootColl.FromTemplate(template, new Case(480) { Hz = { From = (0,    48000), To = 48000 } });
            caseWith0 = coll.GetAll().Single();
        }
        Case caseWithNull;
        {
            var rootColl = new CaseCollection<Case>();
            var template = new Case { Name = "NullyHz" };
            var coll = rootColl.FromTemplate(template, new Case(480) { Hz = { From = (null, 48000), To = 48000 } });
            caseWithNull = coll.GetAll().Single();
        }

        string keyWith0 = caseWith0.ToString();
        string keyWithNull = caseWithNull.ToString();
        NotEqual(keyWith0, keyWithNull);
    }
}