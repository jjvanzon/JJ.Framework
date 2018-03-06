using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
		/// <inheritdoc />
		public class NullException : SimpleExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is null.";

			/// <inheritdoc />
			public NullException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NullException(string name) : base(MESSAGE_TEMPLATE, name) { }
		}

		/// <inheritdoc />
		public class CollectionEmptyException : SimpleExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} collection is empty.";

			/// <inheritdoc />
			public CollectionEmptyException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public CollectionEmptyException(string name) : base(MESSAGE_TEMPLATE, name) { }
		}

		/// <inheritdoc />
		public class CollectionNotEmptyException : SimpleExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} collection should be empty.";

			/// <inheritdoc />
			public CollectionNotEmptyException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public CollectionNotEmptyException(string name) : base(MESSAGE_TEMPLATE, name) { }
		}

		/// <inheritdoc />
		public class HasNullsException : SimpleExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} contains nulls.";

			/// <inheritdoc />
			public HasNullsException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public HasNullsException(string name) : base(MESSAGE_TEMPLATE, name) { }
		}

		/// <inheritdoc />
		public class InfinityException : SimpleExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is Infinity.";

			/// <inheritdoc />
			public InfinityException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public InfinityException(string name) : base(MESSAGE_TEMPLATE, name) { }
		}

		/// <inheritdoc />
		public class NaNException : SimpleExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is NaN.";

			/// <inheritdoc />
			public NaNException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NaNException(string name) : base(MESSAGE_TEMPLATE, name) { }
		}

		/// <inheritdoc />
		public class NotHasValueException : SimpleExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} has no value.";

			/// <inheritdoc />
			public NotHasValueException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NotHasValueException(string name) : base(MESSAGE_TEMPLATE, name) { }
		}

		/// <inheritdoc />
		public class NullOrEmptyException : SimpleExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is null or empty.";

			/// <inheritdoc />
			public NullOrEmptyException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NullOrEmptyException(string name) : base(MESSAGE_TEMPLATE, name) { }
		}

		/// <inheritdoc />
		public class NullOrWhiteSpaceException : SimpleExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is null or white space.";

			/// <inheritdoc />
			public NullOrWhiteSpaceException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public NullOrWhiteSpaceException(string name) : base(MESSAGE_TEMPLATE, name) { }
		}

		/// <inheritdoc />
		public class ZeroException : SimpleExceptionBase
		{
			private const string MESSAGE_TEMPLATE = "{0} is 0.";

			/// <inheritdoc />
			public ZeroException(Expression<Func<object>> expression) : base(MESSAGE_TEMPLATE, expression) { }

			/// <inheritdoc />
			public ZeroException(string name) : base(MESSAGE_TEMPLATE, name) { }
		}


}
