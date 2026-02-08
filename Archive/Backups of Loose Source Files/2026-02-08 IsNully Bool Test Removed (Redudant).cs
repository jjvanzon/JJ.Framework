    [TestMethod]
    public void Test_Bool_IsNully()
    {
        IsFalse(IsNully (true));
        IsTrue (IsNully (false));
        IsFalse(IsNully (True));
        IsTrue (IsNully (False));
        IsFalse(IsNully (NullyTrue));
        IsTrue (IsNully (NullyFalse));
        IsTrue (IsNully (NullBool));

        IsFalse(true.IsNully ());
        IsTrue (false.IsNully ());
        IsFalse(True.IsNully ());
        IsTrue (False.IsNully ());
        IsFalse(NullyTrue.IsNully ());
        IsTrue (NullyFalse.IsNully ());
        IsTrue (NullBool.IsNully ());
    }
