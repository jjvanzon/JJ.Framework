using System;

namespace Puzzle.NPersist.Samples.Northwind.Domain
{
	/// <summary>
	/// Summary description for OrderMaxTotalExceededException.
	/// </summary>
	public class OrderMaxTotalExceededException : ApplicationException
	{
		public OrderMaxTotalExceededException(string message) : base(message)
		{
		}
	}
}
