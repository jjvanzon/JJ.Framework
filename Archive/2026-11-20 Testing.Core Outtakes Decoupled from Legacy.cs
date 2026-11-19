    <!--<ProjectReference Include="..\JJ.Framework.Testing\JJ.Framework.Testing.Legacy.csproj" />-->

//global using JJ.Framework.Testing.Legacy;

    public static void ThrowsExceptionOnOtherThread(Func<object?> statement)
        => AssertHelper.ThrowsExceptionOnOtherThread(() => statement());

        ThrowsExceptionOnOtherThread(ThrowingFunc);
        Throws(() => ThrowsExceptionOnOtherThread(() => ""), expectedMsgPart);

