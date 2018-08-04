using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace JJ.Framework.Text
{
    public class StringBuilderWithIndentation
    {
		public StringBuilderWithIndentation(string tabString = "\t") => _tabString = tabString;

	    private readonly string _tabString;
		private readonly StringBuilder _sb = new StringBuilder();

		public override string ToString() => _sb.ToString();
		public void Indent() => IndentLevel++;
		public void Unindent() => IndentLevel--;
		public void AppendLine() => _sb.AppendLine();
		public void Append(object x) => _sb.Append(x);

		public void AppendLine(string value)
		{
			AppendTabs();

			_sb.Append(value);

			_sb.Append(Environment.NewLine);
		}

		public void AppendFormat(string format, params object[] args) => _sb.AppendFormat(format, args);

	    private int _indentLevel;
		public int IndentLevel
		{
			get => _indentLevel;
			set
			{
				if (value < 0) throw new Exception("value cannot be less than 0.");
				_indentLevel = value;
			}
		}

		public void AppendTabs()
		{
			string tabs = GetTabs();
			_sb.Append(tabs);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string GetTabs()
		{
			string tabs = _tabString?.Repeat(_indentLevel);
			return tabs;
		}
	}
}
