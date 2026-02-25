    <!--<Content Include="$(SolutionDir)\Resources\jj-icon-64x64-margin4.png" Visible="False">-->
    <!--<Content Include="$(MSBuildThisFileDirectory)\..\Resources\jj-icon-64x64-margin4.png" Visible="False">-->

                            /*
                    if (inQuote && pos + 1 < input.Length && input[pos + 1] == quote.Value)
                    {
                        // Escaped quote: skip the second quote and stay in quote.
                        pos++;
                        continue;
                    }
                    */

I applied a local fix for the FromTill throw snafu. 

Applied locally so that legacy code pulls won't not cause merge hell.

There's still this last bug though that makes CsvReader_HandlesEscapedQuotesInsideQuotedField fail with this error:

```
System.Exception: Assert.AreEqual failed. Expected <He said "hi">, Actual <He said "hi>. Tested: 'reader[0]'.
   at JJ.Framework.Testing.Core.AssertCore.Check[T](T expected, T actual, String message, Func`1 condition, String methodName) in D:\Repositories\JJ.Framework\Framework\JJ.Framework.Testing.Core\AssertCore.Base.cs:line 77
   at JJ.Framework.Testing.Core.AssertCore.AreEqual[T](T expected, T actual, String message) in D:\Repositories\JJ.Framework\Framework\JJ.Framework.Testing.Core\AssertCore.AreEqual.cs:line 11
   at JJ.Framework.IO.Core.Tests.CsvReaderTests.CsvReader_HandlesEscapedQuotesInsideQuotedField() in D:\Repositories\JJ.Framework\Framework\JJ.Framework.IO.Core.Tests\CsvReaderTests.cs:line 49
   at System.Reflection.MethodBaseInvoker.InterpretedInvoke_Method(Object obj, IntPtr* args)
   at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)
```

Using the other AI model you struggled to both make it correct and keep it local and short and flipped back and forth between solutions.

Can you try again solving it with a very local fix within StringExtensions_Split?



            /*
            char q = quote.Value;

            return values.Select(value =>
            {
                string v = (value ?? "").Replace($"{q}{q}", $"{q}");

                if (v.Length >= 2 && v[0] == q && v[v.Length - 1] == q)
                {
                    v = v.Substring(1, v.Length - 2);
                }

                return v;
            }).ToArray();
            */

                    /*
                    // Escaped quote inside quoted field: ""
                    if (inQuote && pos + 1 < input.Length && input[pos + 1] == quote.Value)
                    {
                        pos++; // skip escaped quote
                        continue;
                    }
                    */

