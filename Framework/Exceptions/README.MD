# JJ.Framework.Exceptions

Contains many exception classes for common basic errors, for instance:

* Null errors, null or white space errors, collection contains nulls, etc.
* Parsing errors, type casting errors
* Not found, not unique errors
* Greater than or equal errors and the like
* Files not found, folder already exists, etc.

There are several advantages over using these exception types.

* Error messages are clear.
* Concise syntax, without sacrificing performance.
* You can pass an expression, whose text becomes part of the message.
* Lose no time typing and trying to come up with a good message.

For example:

	throw new NullException(() => myParent.MyChildren[0].MyProperty);

Will produce an exception message:

	"myParent.MyChildren[0].MyProperty is null."

This is where it surpasses the possibilities of the C#6 nameof operator, which can only mention a name, not a whole expression.

Another example:

	throw new NotFoundException<Customer>(new { customerNumber, customerType });

will produce an exception message:

	"Customer with key { customerNumber = 1234, customerType = Subscriber } not found."

As such it is fit for use with any composite key you might have.
			
Some more examples:
			
	throw new NotUniqueException<Product>(productNumber);
	throw new ValueNotSupportedException(myCountryEnumValue);
	throw new FileAlreadyExistsException("text.txt");
	throw new NullOrWhiteSpaceException(() => myParam.MyProp);

Those produce the exception messages:
			
	Product with key A123 not unique.
	Country value 'Undefined' is not supported.
	File 'test.txt' already exists.
	myParam.MyProp is null or white space.

Here is an example with the value check in it:

	if (height < 0) throw new LessThanException(nameof(height), 0);

This produces the exception message:
				
	height is less than 0.