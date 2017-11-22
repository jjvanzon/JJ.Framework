namespace JJ.Framework.PlatformCompatibility
{
	// TODO: Is the original Tuple type faster as a dictionary key?

	/// <summary>
	/// Net4 substitute
	/// </summary>
	public struct Tuple_PlatformSupport<T1, T2>
	{
		public T1 Item1 { get; }
		public T2 Item2 { get; }

		/// <summary>
		/// Net4 substitute
		/// </summary>
		public Tuple_PlatformSupport(T1 item1, T2 item2)
		{
			Item1 = item1;
			Item2 = item2;
		}
	}
}

