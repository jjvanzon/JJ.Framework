using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions.Basic
{
	/// <inheritdoc />
	public class NullException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is null.";

			/// <inheritdoc />
			public NullException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NullException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class CollectionEmptyException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} collection is empty.";

			/// <inheritdoc />
			public CollectionEmptyException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public CollectionEmptyException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class CollectionNotEmptyException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} collection should be empty.";

			/// <inheritdoc />
			public CollectionNotEmptyException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public CollectionNotEmptyException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class HasNullsException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} contains nulls.";

			/// <inheritdoc />
			public HasNullsException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public HasNullsException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class HasValueException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} should not have a value.";

			/// <inheritdoc />
			public HasValueException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public HasValueException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class InfinityException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is Infinity.";

			/// <inheritdoc />
			public InfinityException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public InfinityException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class InvalidReferenceException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} not found in list.";

			/// <inheritdoc />
			public InvalidReferenceException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public InvalidReferenceException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class IsDateTimeException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} should not be a DateTime.";

			/// <inheritdoc />
			public IsDateTimeException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public IsDateTimeException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class IsDecimalException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} should not be a Decimal.";

			/// <inheritdoc />
			public IsDecimalException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public IsDecimalException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class IsDoubleException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} should not be a double precision floating point number.";

			/// <inheritdoc />
			public IsDoubleException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public IsDoubleException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class IsIntegerException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} should not be an integer number.";

			/// <inheritdoc />
			public IsIntegerException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public IsIntegerException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NaNException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is NaN.";

			/// <inheritdoc />
			public NaNException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NaNException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NotDateTimeException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is not a DateTime.";

			/// <inheritdoc />
			public NotDateTimeException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NotDateTimeException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NotDecimalException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is not a Decimal.";

			/// <inheritdoc />
			public NotDecimalException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NotDecimalException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NotDoubleException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is not a double precision floating point number.";

			/// <inheritdoc />
			public NotDoubleException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NotDoubleException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NotHasValueException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} has no value.";

			/// <inheritdoc />
			public NotHasValueException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NotHasValueException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NotInfinityException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} should be Infinity.";

			/// <inheritdoc />
			public NotInfinityException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NotInfinityException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NotIntegerException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is not an integer number.";

			/// <inheritdoc />
			public NotIntegerException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NotIntegerException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NotNaNException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} should be NaN.";

			/// <inheritdoc />
			public NotNaNException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NotNaNException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NotNullException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} should be null.";

			/// <inheritdoc />
			public NotNullException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NotNullException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NotNullOrEmptyException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} should be null or empty.";

			/// <inheritdoc />
			public NotNullOrEmptyException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NotNullOrEmptyException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NotNullOrWhiteSpaceException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} should be null or white space.";

			/// <inheritdoc />
			public NotNullOrWhiteSpaceException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NotNullOrWhiteSpaceException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NullOrEmptyException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is null or empty.";

			/// <inheritdoc />
			public NullOrEmptyException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NullOrEmptyException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class NullOrWhiteSpaceException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is null or white space.";

			/// <inheritdoc />
			public NullOrWhiteSpaceException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NullOrWhiteSpaceException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}

		/// <inheritdoc />
		public class ZeroException : BasicExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is 0.";

			/// <inheritdoc />
			public ZeroException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public ZeroException(object indicator) : base(MESSAGE_TEMPLATE, indicator) { }
		}


}
