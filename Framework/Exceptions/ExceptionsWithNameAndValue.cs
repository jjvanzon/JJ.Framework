using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
		/// <inheritdoc />
		public class HasValueException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} should not have a value.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} should not have a value.";

			/// <inheritdoc />
			public HasValueException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public HasValueException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class InvalidReferenceException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} not found in list.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} not found in list.";

			/// <inheritdoc />
			public InvalidReferenceException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public InvalidReferenceException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class IsDateTimeException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} should not be a DateTime.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} should not be a DateTime.";

			/// <inheritdoc />
			public IsDateTimeException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public IsDateTimeException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class IsDecimalException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} should not be a Decimal.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} should not be a Decimal.";

			/// <inheritdoc />
			public IsDecimalException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public IsDecimalException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class IsDoubleException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} should not be a double precision floating point number.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} should not be a double precision floating point number.";

			/// <inheritdoc />
			public IsDoubleException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public IsDoubleException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class IsIntegerException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} should not be an integer number.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} should not be an integer number.";

			/// <inheritdoc />
			public IsIntegerException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public IsIntegerException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class NotDateTimeException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} is not a DateTime.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} is not a DateTime.";

			/// <inheritdoc />
			public NotDateTimeException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public NotDateTimeException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class NotDecimalException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} is not a Decimal.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} is not a Decimal.";

			/// <inheritdoc />
			public NotDecimalException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public NotDecimalException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class NotDoubleException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} is not a double precision floating point number.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} is not a double precision floating point number.";

			/// <inheritdoc />
			public NotDoubleException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public NotDoubleException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class NotInfinityException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} should be Infinity.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} should be Infinity.";

			/// <inheritdoc />
			public NotInfinityException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public NotInfinityException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class NotIntegerException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} is not an integer number.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} is not an integer number.";

			/// <inheritdoc />
			public NotIntegerException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public NotIntegerException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class NotNaNException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} should be NaN.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} should be NaN.";

			/// <inheritdoc />
			public NotNaNException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public NotNaNException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class NotNullException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} should be null.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} should be null.";

			/// <inheritdoc />
			public NotNullException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public NotNullException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class NotNullOrEmptyException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} should be null or empty.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} should be null or empty.";

			/// <inheritdoc />
			public NotNullOrEmptyException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public NotNullOrEmptyException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}

		/// <inheritdoc />
		public class NotNullOrWhiteSpaceException : ExceptionWithNameAndValueBase
		{
			private const string MESSAGE_TEMPLATE_WITH_NAME = "{0} should be null or white space.";
			private const string MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE = "{0} of {1} should be null or white space.";

			/// <inheritdoc />
			public NotNullOrWhiteSpaceException(Expression<Func<object>> expression) 
				: base(MESSAGE_TEMPLATE_WITH_NAME, MESSAGE_TEMPLATE_WITH_NAME_AND_VALUE, expression) { }

			/// <inheritdoc />
			public NotNullOrWhiteSpaceException(string name) : base(MESSAGE_TEMPLATE_WITH_NAME, name) { }
		}


}
