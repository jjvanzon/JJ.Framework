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
	public class SqlMathExpression : SqlExpression
	{

		public SqlMathExpression(SqlExpression leftOperand,SqlMathOperatorType sqlMathOperator,SqlExpression rightOperand)
		{
			this.LeftOperand = leftOperand;
			this.RightOperand = rightOperand;
			this.SqlMathOperator = sqlMathOperator;			
		}


		#region Public Property SqlMathOperator
		private SqlMathOperatorType sqlMathOperator;
		public SqlMathOperatorType SqlMathOperator
		{
			get
			{
				return this.sqlMathOperator;
			}
			set
			{
				this.sqlMathOperator = value;
			}
		}
		#endregion

		#region Public Property LeftOperand
		private SqlExpression leftOperand;
		public SqlExpression LeftOperand
		{
			get
			{
				return this.leftOperand;
			}
			set
			{
				this.leftOperand = value;
			}
		}
		#endregion

		#region Public Property RightOperand
		private SqlExpression rightOperand;
		public SqlExpression RightOperand
		{
			get
			{
				return this.rightOperand;
			}
			set
			{
				this.rightOperand = value;
			}
		}
		#endregion

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}
	}
}
