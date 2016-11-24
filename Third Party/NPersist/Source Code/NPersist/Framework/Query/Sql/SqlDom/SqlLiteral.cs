// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlLiteral.
	/// </summary>
	public abstract class SqlLiteral : SqlExpression 
	{
		protected SqlLiteral(object value)
		{
			this.value = value;
		}

		protected SqlLiteral(DateTime value)
		{
			this.DateTimeValue = value;
		}

		protected SqlLiteral(bool value)
		{
			this.BooleanValue = value;
		}

		protected SqlLiteral(decimal value)
		{
			this.DecimalValue = value;
		}

		#region Property  Value
		
		private object value;
		
		public object Value
		{
			get { return this.value; }
			set { this.value = value; }
		}
		
		#endregion

		#region Property  DateTimeValue
		
		private DateTime dateTime;
		
		public DateTime DateTimeValue
		{
			get { return this.dateTime; }
			set { this.dateTime = value; }
		}
		
		#endregion

		#region Property  BooleanValue
		
		private bool boolean;
		
		public bool BooleanValue
		{
			get { return this.boolean; }
			set { this.boolean = value; }
		}
		
		#endregion
	
		#region Property  DecimalValue
		
		private decimal decimalValue;
		
		public decimal DecimalValue
		{
			get { return this.decimalValue; }
			set { this.decimalValue = value; }
		}
		
		#endregion
	}
}
