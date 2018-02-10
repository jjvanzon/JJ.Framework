using System;

namespace JJ.Framework.Common
{
	public class EventArgs<T> : EventArgs
	{
		public T Value { get; }

		public EventArgs(T value) => Value = value;
	}
}
