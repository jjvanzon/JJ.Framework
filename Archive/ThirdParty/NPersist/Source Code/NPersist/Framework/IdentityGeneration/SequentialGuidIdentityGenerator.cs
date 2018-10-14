// * 
// * Copyright (C) 2005 Sebastian Smith
// * 
// * This library is free software; you can redistribute it and/or modify it 
// * under the terms of the GNU Lesser General Public License 2.1 or later, as 
// * published by the Free Software Foundation. See the included license.txt 
// * or  http://www.gnu.org/copyleft/lesser.html for details. 
// * 
// * 
using Puzzle.NPersist.Framework.Interfaces; 

namespace Puzzle.NPersist.Framework.IdentityGeneration 
{ 
	class SequentialGuidIdentityGenerator : IIdentityGenerator 
	{ 
		private const int BASE_YEAR = 2000; 
		private const int BASE_MONTH = 1; 
		private const int BASE_DAY = 1; 
		private const double LIMITING_DIVISOR = 3.333333; 

		public SequentialGuidIdentityGenerator() {;} 

		public object GenerateIdentity() 
		{ 
			System.DateTime baseDate = new System.DateTime(BASE_YEAR, BASE_MONTH, BASE_DAY); 
			System.DateTime now = System.DateTime.Now; 

			// Get the days and milliseconds which will be used to build the byte array 
			System.TimeSpan days = new System.TimeSpan(now.Ticks - baseDate.Ticks); 
			System.TimeSpan msecs = new System.TimeSpan(now.Ticks - (new System.DateTime(now.Year, now.Month, now.Day).Ticks)); 

			// Convert TimeSpans to a byte array 
			byte[] daysArray = System.BitConverter.GetBytes(days.Days); 
			byte[] msecsArray = System.BitConverter.GetBytes((long)(msecs.TotalMilliseconds / LIMITING_DIVISOR)); 

			// Reverse the bytes to match big-endian ordering 
			// Used by certain DB engines (i.e. MS-SQL) for indexing 
			System.Array.Reverse(daysArray); 
			System.Array.Reverse(msecsArray); 

			// Generate a real guid for the unique portion of sequential guid and put it in a byte array 
			byte[] guidArray = System.Guid.NewGuid().ToByteArray(); 

			// Copy the bytes into the guid to make the sequential guid 
			System.Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2); 
			System.Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4); 

			return new System.Guid(guidArray); 
		} 

		public static System.DateTime GetDateFromSequentialGuid(System.Guid guid) 
		{ 
			System.DateTime baseDate = new System.DateTime(BASE_YEAR, BASE_MONTH, BASE_DAY); 
			byte[] daysArray = new byte[4]; 
			byte[] msecsArray = new byte[4]; 
			byte[] guidArray = guid.ToByteArray(); 

			// Copy the date parts of the guid to the respective byte arrays 
			System.Array.Copy(guidArray, guidArray.Length - 6, daysArray, 2, 2); 
			System.Array.Copy(guidArray, guidArray.Length - 4, msecsArray, 0, 4); 

			// Reverse the arrays to put them into the original order 
			System.Array.Reverse(daysArray); 
			System.Array.Reverse(msecsArray); 

			// Convert the bytes to ints 
			int days = System.BitConverter.ToInt32(daysArray, 0); 
			int msecs = System.BitConverter.ToInt32(msecsArray, 0); 

			System.DateTime date = baseDate.AddDays(days); 
			date = date.AddMilliseconds(msecs * LIMITING_DIVISOR); 

			return date; 
		} 
	} 
} 
