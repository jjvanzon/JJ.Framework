```cs
    //private readonly AccessorCore _accessor 
    //    = new("JJ.Framework.Common.Core.CommonStringExtensionsCore, " +
    //          "JJ.Framework.Common.Core");


            // Old

            //Exception[] exceptions = ex.SelfAndAncestors(x => x.InnerException)
            //                           //.OfType(exceptionType)
            //                           .ToArray();
            //
            //foreach (Exception exception in exceptions)
            //{
            //    //if (exception.GetType() == exceptionType)
            //    {
            //        foreach (string expectedText in expectedTexts)
            //        {
            //            if (exception.Message.Contains(expectedText, caseMatters: false))
            //            {
            //                return ex;
            //            }
            //        }
            //    }
            //}

            // Older

            //foreach (string expectedText in expectedTexts)
            //{
            //    Contains(expectedText, ex.Message);
            //}
            //
            //return ex;


            // Old

            //Exception[] exceptions = ex.SelfAndAncestors(x => x.InnerException)
            //                           .OfType(exceptionType)
            //                           .ToArray();
            //
            //foreach (Exception exception in exceptions)
            //{
            //    if (exception.GetType() == exceptionType)
            //    {
            //        foreach (string expectedText in expectedTexts)
            //        {
            //            if (exception.Message.Contains(expectedText, caseMatters: false))
            //            {
            //                return ex;
            //            }
            //        }
            //    }
            //}

            // Older

            //AreEqual(exceptionType, ex.GetType());
            //
            //foreach (string expectedText in expectedTexts)
            //{
            //    Contains(expectedText, ex.Message);
            //}
            //
            //return ex;


```


```log
System.Exception: An exception should have been thrown with message containing: "AreEqual failed". Actual exception: System.Exception: An exception of type System.NullReferenceException should have been thrown. Actual exception: System.InvalidOperationException: boom

System.Exception: An exception should have been thrown with message containing: "AreEqual failed". Actual exception: System.Exception: An exception of type NullReferenceException should have been thrown. Actual exception: System.InvalidOperationException: boom


An exception should have been thrown with message containing: "AreEqual failed". Actual exception: System.Exception: NullReferenceException should have been thrown. Actual exception: System.InvalidOperationException: boom

System.Exception: Exception should have been thrown with message containing: "AreEqual failed". Actual exception: System.Exception: NullReference should have been thrown. Actual: System.InvalidOperationException: boom
```