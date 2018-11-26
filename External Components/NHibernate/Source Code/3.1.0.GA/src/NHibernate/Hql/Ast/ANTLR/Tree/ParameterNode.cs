using System;
using Antlr.Runtime;
using NHibernate.Engine;
using NHibernate.Param;
using NHibernate.SqlCommand;
using NHibernate.Type;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	/// <summary>
	/// Implementation of ParameterNode.
	/// Author: Steve Ebersole
	/// Ported by: Steve Strong
	/// </summary>
	[CLSCompliant(false)]
	public class ParameterNode : HqlSqlWalkerNode, IDisplayableNode, IExpectedTypeAwareNode
	{
		private IParameterSpecification _parameterSpecification;

		public ParameterNode(IToken token) : base(token)
		{
		}

		public IParameterSpecification HqlParameterSpecification
		{
			get { return _parameterSpecification; }
			set { _parameterSpecification = value; }
		}

		public string GetDisplayText()
		{
			return "{" + (_parameterSpecification == null ? "???" : _parameterSpecification.RenderDisplayInfo()) + "}";
		}

		public IType ExpectedType
		{
			get
			{
				return HqlParameterSpecification == null ? null : HqlParameterSpecification.ExpectedType;
			}

			set
			{
				HqlParameterSpecification.ExpectedType = value;
				DataType = value;
			}
		}

		public override SqlString RenderText(ISessionFactoryImplementor sessionFactory)
		{
			int count;
			if (ExpectedType != null && (count = ExpectedType.GetColumnSpan(sessionFactory)) > 1)
			{
				SqlStringBuilder buffer = new SqlStringBuilder();
				buffer.Add("(");
				buffer.AddParameter();
				for (int i = 1; i < count; i++)
				{
					buffer.Add(",");
					buffer.AddParameter();
				}
				buffer.Add(")");
				return buffer.ToSqlString();
			}
			else
			{
				return new SqlString(Parameter.Placeholder);
			}
		}
	}
}
