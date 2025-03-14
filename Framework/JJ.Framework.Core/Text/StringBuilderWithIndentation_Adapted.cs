using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace JJ.Framework.Core.Text
{
    public class StringBuilderWithIndentation_Adapted
    {
        public StringBuilderWithIndentation_Adapted()
            : this("  ")
        { }
        
        public StringBuilderWithIndentation_Adapted(string tabString)
            : this(tabString, Environment.NewLine)
        { }
        
        public StringBuilderWithIndentation_Adapted(string tabString , string enter)
        {
            _tabString = tabString;
            _enter     = enter;
        }
        
        private readonly string _tabString;
        private readonly string _enter;
        
        private readonly StringBuilder _sb = new StringBuilder();
        
        public override string ToString()       => _sb.ToString();
        public          void   Indent()         => IndentLevel++;
        public          void   Unindent()       => IndentLevel--;
        public          void   AppendEnter()    => Append(_enter);
        public          void   AppendLine()     => AppendLine("");
        public          void   Append(object x) => _sb.Append(x);
        
        public void AppendLine(string value)
        {
            AppendTabs();
            
            _sb.Append(value);
            
            _sb.Append(_enter);
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