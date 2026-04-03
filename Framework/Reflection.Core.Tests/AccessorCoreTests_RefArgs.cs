using static System.TimeSpan;

#pragma warning disable CS0219 // Variable is assigned but its value is never used

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public partial class AccessorCoreTests_RefArgs
{
    // Test Methods
    
    // 1 Parameter Tests
    
    [TestMethod]
    public void AccessorCore_1Out()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            int  arg;
            bool ret = accessor.MyMethod(out arg);
            
            AreEqual(1, () => arg);
            IsTrue(() => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_1Out_String()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            string arg;
            bool   ret = accessor.MyMethod(out arg);
            
            AreEqual("1", () => arg);
            IsTrue(() => ret);
        }
    }
    
    // 2 Parameters Tests
    
    [TestMethod]
    public void AccessorCore_RefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            float  arg1 = 2;
            double arg2 = 4;
            
            long ret = accessor.MyMethod(ref arg1, arg2);
            
            AreEqual(3, () => arg1);
            AreEqual(4, () => arg2);
            AreEqual(5, () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefValString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            float  arg1 = 2;
            string arg2 = "4";
            
            long ret = accessor.MyMethod(ref arg1, arg2);
            
            AreEqual(3,   () => arg1);
            AreEqual("4", () => arg2);
            AreEqual(5,   () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            TimeSpan arg1 = FromSeconds(06);
            char     arg2;
            
            DateTime ret = accessor.MyMethod(arg1, out arg2);
            
            AreEqual(FromSeconds(6), () => arg1);
            AreEqual((char)7,        () => arg2);
            AreEqual(FromYear(8),    () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            TimeSpan arg1 = FromSeconds(06);
            string   arg2;
            
            DateTime ret = accessor.MyMethod(arg1, out arg2);
            
            AreEqual(FromSeconds(06), () => arg1);
            AreEqual("7",             () => arg2);
            AreEqual(FromYear(8),     () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            string   arg1 = "9";
            TimeSpan arg2;
            
            Guid ret = accessor.MyMethod(ref arg1, out arg2);
            
            AreEqual("10",            () => arg1);
            AreEqual(FromSeconds(11), () => arg2);
            AreEqual(ToGuid(12),      () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            string   arg1 = "9";
            string   arg2;
            
            Guid ret = accessor.MyMethod(ref arg1, out arg2);
            
            AreEqual("10",       () => arg1);
            AreEqual("11",       () => arg2);
            AreEqual(ToGuid(12), () => ret);
        }
    }
    
    // 3 Parameter Tests
    
    [TestMethod]
    public void AccessorCore_RefValVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            double arg1 = 13;
            float  arg2 = 15;
            long   arg3 = 16;
            
            DateTime ret = accessor.MyMethod(ref arg1, arg2, arg3);
            
            AreEqual(14,           () => arg1);
            AreEqual(15,           () => arg2);
            AreEqual(16,           () => arg3);
            AreEqual(FromYear(17), () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefValValString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            double arg1 = 13;
            float  arg2 = 15;
            string arg3 = "16";
            
            DateTime ret = accessor.MyMethod(ref arg1, arg2, arg3);
            
            AreEqual(14,           () => arg1);
            AreEqual(15,           () => arg2);
            AreEqual("16",         () => arg3);
            AreEqual(FromYear(17), () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            bool arg1 = true;
            long arg3 = 19;
            
            int ret = accessor.MyMethod(arg1, out int arg2, arg3);
            
            AreEqual(true, () => arg1);
            AreEqual(18,   () => arg2);
            AreEqual(19,   () => arg3);
            AreEqual(20,   () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefValString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            bool arg1 = true;
            string arg3 = "19";
            
            int ret = accessor.MyMethod(arg1, out int arg2, arg3);
            
            AreEqual(true, () => arg1);
            AreEqual(18,   () => arg2);
            AreEqual("19", () => arg3);
            AreEqual(20,   () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            double   arg1 = 21;
            TimeSpan arg3 = FromSeconds(24);
            
            float ret = accessor.MyMethod(ref arg1, out DateTime arg2, arg3);
            
            AreEqual(22,              () => arg1);
            AreEqual(FromYear(23),    () => arg2);
            AreEqual(FromSeconds(24), () => arg3);
            AreEqual(25,              () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefValString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            double arg1 = 21;
            string arg3 = "24";
            
            float ret = accessor.MyMethod(ref arg1, out DateTime arg2, arg3);
            
            AreEqual(22,           () => arg1);
            AreEqual(FromYear(23), () => arg2);
            AreEqual("24",         () => arg3);
            AreEqual(25,           () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            Guid     arg1 = ToGuid(26);
            string   arg2 = "27";
            TimeSpan arg3 = FromSeconds(28);
            
            string ret = accessor.MyMethod(arg1, arg2, ref arg3);
            
            AreEqual(ToGuid(26),      () => arg1);
            AreEqual("27",            () => arg2);
            AreEqual(FromSeconds(29), () => arg3);
            AreEqual("30",            () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValValRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            Guid   arg1 = ToGuid(26);
            string arg2 = "27";
            string arg3 = "28";
            
            string ret = accessor.MyMethod(arg1, arg2, ref arg3);
            
            AreEqual(ToGuid(26), () => arg1);
            AreEqual("27",       () => arg2);
            AreEqual("29",       () => arg3);
            AreEqual("30",       () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            float arg2 = 32;
            long  arg3 = 33;
            
            DateTime ret = accessor.MyMethod(out double arg1, arg2, ref arg3);
            
            AreEqual(31,           () => arg1);
            AreEqual(32,           () => arg2);
            AreEqual(34,           () => arg3);
            AreEqual(FromYear(35), () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefValRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            float  arg2 = 32;
            string arg3 = "33";
            
            DateTime ret = accessor.MyMethod(out double arg1, arg2, ref arg3);
            
            AreEqual(31,           () => arg1);
            AreEqual(32,           () => arg2);
            AreEqual("34",         () => arg3);
            AreEqual(FromYear(35), () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            bool arg1 = true;
            long arg3 = 37;
            
            int ret = accessor.MyMethod(arg1, out int arg2, ref arg3);
            
            AreEqual(true, () => arg1);
            AreEqual(36,   () => arg2);
            AreEqual(38,   () => arg3);
            AreEqual(39,   () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            bool   arg1 = true;
            string arg3 = "37";
            
            int ret = accessor.MyMethod(arg1, out int arg2, ref arg3);
            
            AreEqual(true, () => arg1);
            AreEqual(36,   () => arg2);
            AreEqual("38", () => arg3);
            AreEqual(39,   () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            DateTime arg2 = FromYear(41);
            TimeSpan arg3;
            
            float ret = accessor.MyMethod(out double arg1, ref arg2, out arg3);
            
            AreEqual(40,              () => arg1);
            AreEqual(FromYear(42),    () => arg2);
            AreEqual(FromSeconds(43), () => arg3);
            AreEqual(44,              () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            DateTime arg2 = FromYear(41);
            string   arg3;
            
            float ret = accessor.MyMethod(out double arg1, ref arg2, out arg3);
            
            AreEqual(40,           () => arg1);
            AreEqual(FromYear(42), () => arg2);
            AreEqual("43",         () => arg3);
            AreEqual(44,           () => ret);
        }
    }
    
    // 4 Parameter Tests
    
    [TestMethod]
    public void AccessorCore_RefValValVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = 45;
            var arg2 = 47;
            var arg3 = 48;
            var arg4 = 49;
            var ret  = accessor.MyMethod(ref arg1, arg2, arg3, arg4);
            
            AreEqual(46, () => arg1);
            AreEqual(47, () => arg2);
            AreEqual(48, () => arg3);
            AreEqual(49, () => arg4);
            AreEqual(50, () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefValValValString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = 45;
            var arg2 = 47;
            var arg3 = 48;
            var arg4 = "49";
            var ret  = accessor.MyMethod(ref arg1, arg2, arg3, arg4);
            
            AreEqual(46, () => arg1);
            AreEqual(47, () => arg2);
            AreEqual(48, () => arg3);
            AreEqual("49", () => arg4);
            AreEqual(50, () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefValVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = true;
            var arg2 = "";
            var arg3 = FromYear(52);
            var arg4 = FromSeconds(53);
            var ret  = accessor.MyMethod(arg1, out arg2, arg3, arg4);
            
            AreEqual("51", () => arg2);
            AreEqual(54,   () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefValValString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = true;
            var arg2 = "";
            var arg3 = FromYear(52);
            var arg4 = "53";
            var ret  = accessor.MyMethod(arg1, out arg2, arg3, arg4);
            
            AreEqual("51", () => arg2);
            AreEqual(54,   () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefValVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = (byte)55;
            var arg2 = 56;
            var arg3 = 58;
            var arg4 = 59;
            var ret  = accessor.MyMethod(ref arg1, out arg2, arg3, arg4);
            
            AreEqual(57,         () => arg2);
            AreEqual(ToGuid(60), () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefValValString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = (byte)55;
            var arg2 = 56;
            var arg3 = 58;
            var arg4 = "59";
            var ret  = accessor.MyMethod(ref arg1, out arg2, arg3, arg4);
            
            AreEqual(57,         () => arg2);
            AreEqual(ToGuid(60), () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValValRefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = 61;
            var arg2 = true;
            var arg3 = "62";
            var arg4 = FromYear(64);
            var ret  = accessor.MyMethod(arg1, arg2, ref arg3, arg4);
            
            AreEqual("63", () => arg3);
            AreEqual(65,   () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValValRefValString_2StringsLast_RequireExplicitName()
{
        var arg1 = 61;
        var arg2 = true;
        var arg3 = "62";
        var arg4 = "64";

        var accessor = new MyAccessor();
        var accessorByName = new MyAccessorByName();

        ThrowsException(() => accessor.MyMethod(arg1, arg2, ref arg3, arg4));
        
        var ret = accessorByName.MyMethod(arg1, arg2, ref arg3, arg4);
        AreEqual("63", () => arg3);
        AreEqual(65,   () => ret);
    }
    
    [TestMethod]
    public void AccessorCore_RefValRefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = ToGuid(0);
            var arg2 = (byte)67;
            var arg3 = 68;
            var arg4 = 70;
            var ret  = accessor.MyMethod(out arg1, arg2, ref arg3, arg4);
            
            AreEqual(ToGuid(66),      () => arg1);
            AreEqual(69,              () => arg3);
            AreEqual(FromSeconds(71), () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefValRefValString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = ToGuid(0);
            var arg2 = (byte)67;
            var arg3 = 68;
            var arg4 = "70";
            var ret  = accessor.MyMethod(out arg1, arg2, ref arg3, arg4);
            
            AreEqual(ToGuid(66),      () => arg1);
            AreEqual(69,              () => arg3);
            AreEqual(FromSeconds(71), () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefRefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = 72;
            var arg2 = (decimal)0;
            var arg3 = true;
            var arg4 = (char)74;
            var ret  = accessor.MyMethod(arg1, out arg2, ref arg3, arg4);
            
            AreEqual(73,    () => arg2);
            AreEqual(false, () => arg3);
            AreEqual(75,    () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefRefValString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = 72;
            var arg2 = (decimal)0;
            var arg3 = true;
            var arg4 = "74";
            var ret  = accessor.MyMethod(arg1, out arg2, ref arg3, arg4);
            
            AreEqual(73,    () => arg2);
            AreEqual(false, () => arg3);
            AreEqual(75,    () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefRefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = FromSeconds(0);
            var arg2 = ToGuid(77);
            var arg3 = (byte)0;
            var arg4 = 80;
            var ret  = accessor.MyMethod(out arg1, ref arg2, out arg3, arg4);
            
            AreEqual(FromSeconds(76), () => arg1);
            AreEqual(ToGuid(78),      () => arg2);
            AreEqual(79,              () => arg3);
            AreEqual(FromYear(81),    () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefRefValString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = FromSeconds(0);
            var arg2 = ToGuid(77);
            var arg3 = (byte)0;
            var arg4 = "80";
            var ret  = accessor.MyMethod(out arg1, ref arg2, out arg3, arg4);
            
            AreEqual(FromSeconds(76), () => arg1);
            AreEqual(ToGuid(78),      () => arg2);
            AreEqual(79,              () => arg3);
            AreEqual(FromYear(81),    () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValValValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = 82;
            var arg2 = 83;
            var arg3 = 84;
            var arg4 = true;
            var ret  = accessor.MyMethod(arg1, arg2, arg3, ref arg4);
            
            AreEqual(false, () => arg4);
            AreEqual(85,    () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValValValRefString_2StringsLast_DistinguishedByRefness()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = 82;
            var arg2 = 83;
            var arg3 = 84;
            var arg4 = "true";
                
            var ret = accessor.MyMethod(arg1, arg2, arg3, ref arg4);
        
            AreEqual("false", () => arg4);
            AreEqual(85,   () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefValValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = default(DateTime);
            var arg2 = FromSeconds(87);
            var arg3 = ToGuid(88);
            var arg4 = (byte)89;
            var ret  = accessor.MyMethod(out arg1, arg2, arg3, ref arg4);
            
            AreEqual(FromYear(86), () => arg1);
            AreEqual(90,           () => arg4);
            AreEqual("91",         () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefValValRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = default(DateTime);
            var arg2 = FromSeconds(87);
            var arg3 = ToGuid(88);
            var arg4 = "89";
            var ret  = accessor.MyMethod(out arg1, arg2, arg3, ref arg4);
            
            AreEqual(FromYear(86), () => arg1);
            AreEqual("90",         () => arg4);
            AreEqual("91",         () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = 92;
            var arg2 = (float)0;
            var arg3 = 94;
            var arg4 = (decimal)95;
            var ret  = accessor.MyMethod(arg1, out arg2, arg3, ref arg4);
            
            AreEqual(93, () => arg2);
            AreEqual(96, () => arg4);
            AreEqual(97, () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefValRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = 92;
            var arg2 = (float)0;
            var arg3 = 94;
            var arg4 = "95";
            var ret  = accessor.MyMethod(arg1, out arg2, arg3, ref arg4);
            
            AreEqual(93,   () => arg2);
            AreEqual("96", () => arg4);
            AreEqual(97,   () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = "";
            var arg2 = FromYear(99);
            var arg3 = FromSeconds(101);
            var arg4 = ToGuid(0);
            var ret  = accessor.MyMethod(out arg1, ref arg2, arg3, out arg4);
            
            AreEqual("98",          () => arg1);
            AreEqual(FromYear(100), () => arg2);
            AreEqual(ToGuid(102),   () => arg4);
            AreEqual(true,          () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefValRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = "";
            var arg2 = FromYear(99);
            var arg3 = FromSeconds(101);
            var arg4 = "";
            var ret  = accessor.MyMethod(out arg1, ref arg2, arg3, out arg4);
            
            AreEqual("98",          () => arg1);
            AreEqual(FromYear(100), () => arg2);
            AreEqual("102",         () => arg4);
            AreEqual(true,          () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValValRefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = 103;
            var arg2 = 104;
            var arg3 = (float)105;
            var arg4 = (double)0;
            var ret  = accessor.MyMethod(arg1, arg2, ref arg3, out arg4);
            
            AreEqual(106, () => arg3);
            AreEqual(107, () => arg4);
            AreEqual(108, () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValValRefRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = 103;
            var arg2 = 104;
            var arg3 = (float)105;
            var arg4 = "0";
            var ret  = accessor.MyMethod(arg1, arg2, ref arg3, out arg4);
            
            AreEqual(106,   () => arg3);
            AreEqual("107", () => arg4);
            AreEqual(108,   () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefValRefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = true;
            var arg2 = "109";
            var arg3 = default(DateTime);
            var arg4 = FromSeconds(111);
            var ret  = accessor.MyMethod(ref arg1, arg2, out arg3, ref arg4);
            
            AreEqual(false,            () => arg1);
            AreEqual(FromYear(110),    () => arg3);
            AreEqual(FromSeconds(112), () => arg4);
            AreEqual(113,              () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefValRefRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = true;
            var arg2 = "109";
            var arg3 = default(DateTime);
            var arg4 = "111";
            var ret  = accessor.MyMethod(ref arg1, arg2, out arg3, ref arg4);
            
            AreEqual(false,         () => arg1);
            AreEqual(FromYear(110), () => arg3);
            AreEqual("112",         () => arg4);
            AreEqual(113,           () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefRefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = (byte)114;
            var arg2 = (int)0;
            var arg3 = (long)116;
            var arg4 = (float)0;
            var ret  = accessor.MyMethod(arg1, out arg2, ref arg3, out arg4);
            
            AreEqual(115,         () => arg2);
            AreEqual(117,         () => arg3);
            AreEqual(118,         () => arg4);
            AreEqual(ToGuid(119), () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefRefRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = (byte)114;
            var arg2 = (int)0;
            var arg3 = (long)116;
            var arg4 = "";
            var ret  = accessor.MyMethod(arg1, out arg2, ref arg3, out arg4);
            
            AreEqual(115,         () => arg2);
            AreEqual(117,         () => arg3);
            AreEqual("118",       () => arg4);
            AreEqual(ToGuid(119), () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefRefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = (decimal)120;
            var arg2 = default(bool);
            var arg3 = "122";
            var arg4 = default(DateTime);
            var ret  = accessor.MyMethod(ref arg1, out arg2, ref arg3, out arg4);
            
            AreEqual(121,           () => arg1);
            AreEqual(true,          () => arg2);
            AreEqual("123",         () => arg3);
            AreEqual(FromYear(124), () => arg4);
            AreEqual(125,           () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_RefRefRefRefString()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            var arg1 = (decimal)120;
            var arg2 = default(bool);
            var arg3 = "122";
            var arg4 = "";
            var ret  = accessor.MyMethod(ref arg1, out arg2, ref arg3, out arg4);
            
            AreEqual(121,   () => arg1);
            AreEqual(true,  () => arg2);
            AreEqual("123", () => arg3);
            AreEqual("124", () => arg4);
            AreEqual(125,   () => ret);
        }
    }
}