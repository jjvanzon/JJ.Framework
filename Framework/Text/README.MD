# JJ.Framework.Text

Basic helpers for working with text.

* String extensions for trimming and cutting.
* Case formatting
* `String.Split` overloads
* `SplitWithQuotation`
* `StringBuilderWithIndentation`

## String Extensions

* `Left` /  `Right`
	* Returns the left or right part of a string. Throws an exception if the string has less characters than the length provided.
* `FromTill`
	* Takes the middle of a string by specifying the zero-based start index and the end index. Throws an exception if the string has less characters than the length provided.
* `TakeStart` / `TakeEnd`
	* Returns the left or right part of a string. Can return less characters than the length provided, if string is shorter.
* `TakeStartUntil` / `TakeEndUntil`
	* Takes the part of a string until the specified delimiter. Excludes the delimiter itself.
* `TrimStart` / `TrimEnd`
	* Will trim off repetitions of the same value from the given string. These are variations of the standard .NET methods that instead of just taking `char[]` can take a string or a length.
* `TrimStartUntil` / `TrimEndUntil`
	* Cuts off the part of a string until the specified delimiter and returns what remains including the delimiter itself.
* `TrimFirst` / `TrimLast`
	* Will trim off at most one occurrence of a value from the given string.
* `RemoveExcessiveWhiteSpace`
	* Trims and replaces sequences of two or more white space characters by a single space.
* `Repeat`
	* Repeat a string a number of times, returning a single string.
* `Replace`
	* Variation on `String.Replace` with the ability to ignore case.

## String Extensions for Case Formatting

* `StartWithCap`
	* Turns the first character into a capital letter.
* `StartWithLowerCase`
	* Turns the first character into a lower-case letter.
* `ToCamelCase`
	* Converts e.g. *"This is a sentence."* to *"thisIsASentence"* so it can be used in code.

## SplitWithQuotation

Allows you to parse CSV-like lines including quotation for the ability to include the separator character in the values themselves.

## String Split Variations

The notoriously missing `String.Split` overloads, like:

	myString.Split("].");

## StringBuilderWithIndentation

You would think `StringBuilder` might have an `Indent` and an `Unindent` method. It doesn't. Here's one that does:

    var sb = new StringBuilderWithIndentation();

    sb.AppendLine($"public class {generatedClassName}");
    sb.AppendLine("{");
    sb.Indent();
    {
        sb.AppendLine("public void MyMethod()");
        sb.AppendLine("{");
        sb.Indent();
        {
            sb.AppendLine(methodBody);
            sb.Unindent();
        }
        sb.AppendLine("}");
        sb.Unindent();
    }
    sb.AppendLine("}");

## StringHelper.Join

A variation on `String.Join`, but thakes `char` as the separator instead of `String`.
