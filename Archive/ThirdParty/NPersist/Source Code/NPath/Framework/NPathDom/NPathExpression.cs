// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPath.Framework.CodeDom
{
	public class NPathExpression : IValue
	{
		#region Property LEFTOPERAND

		private IValue leftOperand;

		public virtual IValue LeftOperand
		{
			get => leftOperand;
		    set => leftOperand = value;
		}

		#endregion

		#region Property RIGHTOPERAND

		private IValue rightOperand;

		public virtual IValue RightOperand
		{
			get => rightOperand;
		    set => rightOperand = value;
		}

		#endregion

		#region Property OPERATOR

		private string _operator;

		public virtual string Operator
		{
			get => _operator;
		    set => _operator = value;
		}

		#endregion

		public virtual int GetOperatorPriority()
		{
			switch (Operator)
			{
				case "or":
					return 0;
				case "and":
					return 1;
				case "=":
				case "!=":
				case ">=":
				case ">":
				case "<":
				case "<=":
					return 2;
				case "mul":
				case "div":
					return 4;
				case "minus":
				case "add":
				case "like":
					return 3;
				default:
					return -1;
			}
		}
	}
}