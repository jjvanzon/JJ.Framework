

```
cf9ecb39-ad86-4a29-84c4-c0f79b9c59fa
{426f51a9186b4115af98cca1131b8dd4}
{07c75275-0150-4414-bbca-0081b021a0ea}
9390B28866D94C7BA32BFD2B12CA0AA7
155FEB11-A3F4-486A-AE7A-CF2F8961DB10
{3F0EC22422DE4921A7A963C1FD222B33}
{B5F8F331-66B0-47F7-861D-9D849C7776C2}


cf9ecb39-ad86-4a29-84c4-c0f79b9c59fa
{426f51a9186b4115af98cca1131b8dd4}
{07c75275-0150-4414-bbca-0081b021a0ea}
9390B28866D94C7BA32BFD2B12CA0AA7
155FEB11-A3F4-486A-AE7A-CF2F8961DB10
{3F0EC22422DE4921A7A963C1FD222B33}
{B5F8F331-66B0-47F7-861D-9D849C7776C2}
```


```cs

    [TestMethod]
    public void Test_StringHelperCore_WithShortGuids()
    {
        AreEqual("61E6FA - Hello there", "61E6FA88-AE55-453F-8973-E3BB27763720 - Hello there".WithShortGuids(6));
        AreEqual("{61E6FA} - Hello there", "{61E6FA88-AE55-453F-8973-E3BB27763720} - Hello there".WithShortGuids(6));
    }


```

```
            // Works for { } recognition, but \b seems in the wrong place.
            //var guidPattern = new Regex(@"\{?\b[a-fA-F0-9]{4,32}(-?[a-fA-F0-9]{4,32}){0,7}\b\}?", IgnoreCase);
            // Does not work, but \b seems in the right place
            //var guidPattern = new Regex(@"\b\{?[a-fA-F0-9]{4,32}(-?[a-fA-F0-9]{4,32}){0,7}\}?\b", IgnoreCase);
            // Try or op:
            //@"(\b|\{)([a-fA-F0-9]{4,32}(-?[a-fA-F0-9]{4,32}){0,7})(\}|\b)"

                //var boundedLength = Min(length, guid.Length);
                //return guid.Substring(0, boundedLength);
```

```cs

        private static readonly char[] _guidChars = 
        [
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 
            'a', 'b', 'c', 'd', 'e', 'f', 
            'A', 'B', 'C', 'D', 'E', 'F'
        ];

            char[] allowedChars = _guidChars;

                // TODO: Range check is even faster chr > '0' && chr < '9' etc.

                if (!allowedChars.Contains(chr))
                    continue;


```

```

            // TODO: Check char code instead of char[].
            //char[] decimalDigits = [ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' ];
            //if (input.Contains(decimalDigits)) return false;
           
            //double percentIsDigit = input.Count(x => x >= '0' && c <= '9') / input.Length;
            //if (percentIsDigit

            //double consonantCount = guid.Count(x => !hexVowels.Contains(x));
            //double vowelFraction = vowelCount / consonantCount;
```

Before replacing with "dashes anywhere":

```
private static readonly Regex _guidyRegex = new (@"(""?)(\{|\b)([a-fA-F0-9]{4,32}(-?[a-fA-F0-9]{4,32}){0,7})(\}|\b)(""?)", ExplicitCapture | Compiled);
```