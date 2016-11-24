// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using Puzzle.NCore.Framework.Text;
using Puzzle.NCore.Framework.Text.PatternMatchers;

namespace Puzzle.NPath.Framework
{
	public class Tokenizer
	{
		private static TokenTree tokenTree = Setup();

		#region Setup keywords

		private static TokenTree Setup()
		{
			TokenTree tree = new TokenTree();
			tree.AddToken("select", false, true, "select");
			tree.AddToken("contains", false, true, new string[] {"value", "textsearch", "contains"});
			tree.AddToken("freetext", false, true, new string[] {"value", "textsearch", "freetext"});

			tree.AddToken("as", false, true, "as");


			tree.AddToken("top", false, true, "top");
			tree.AddToken("distinct", false, true, "distinct");
			tree.AddToken("percent", false, true, "percent");
			tree.AddToken("with ties", false, true, "with ties"); // do not localize

			tree.AddToken(",", false, false, "comma");
			tree.AddToken("from", false, true, "from");
			tree.AddToken("where", false, true, "where");
			tree.AddToken("order by", false, true, "order by"); // do not localize


			tree.AddToken("min", false, true, new string[] {"function", "value", "min"});
			tree.AddToken("max", false, true, new string[] {"function", "value", "max"});
			tree.AddToken("avg", false, true, new string[] {"function", "value", "avg"});
			tree.AddToken("sum", false, true, new string[] {"function", "value", "sum"});
            tree.AddToken("soundex", false, true, new string[] { "function", "value", "soundex" });
			tree.AddToken("count", false, true, new string[] {"function", "value", "count"});
			tree.AddToken("isnull", false, true, new string[] {"function", "value", "isnull"});

			tree.AddToken("in", false, true, new string[] {"compare", "in"});
			tree.AddToken("like", false, true, new string[] {"compare", "like"});
			tree.AddToken(">", false, false, new string[] {"compare", ">"});
			tree.AddToken("<", false, false, new string[] {"compare", "<"});
			tree.AddToken("<=", false, false, new string[] {"compare", "<="});
			tree.AddToken(">=", false, false, new string[] {"compare", ">="});
			tree.AddToken("=<", false, false, new string[] {"compare", "<="});
			tree.AddToken("=>", false, false, new string[] {"compare", ">="});
			tree.AddToken("!=", false, false, new string[] {"compare", "!="});
			tree.AddToken("<>", false, false, new string[] {"compare", "!="});
			tree.AddToken("=", false, false, new string[] {"compare", "="});
			tree.AddToken("is", false, true, new string[] {"compare", "="});

			tree.AddToken("(", false, false, new string[] {"(", "value"});
			tree.AddToken(")", false, false, ")");
			tree.AddToken("[", false, false, "[");
			tree.AddToken("]", false, false, "]");


			tree.AddToken("+", false, false, new string[] {"math", "add", "sign"});
			tree.AddToken("-", false, false, new string[] {"math", "minus", "sign"});
			tree.AddToken("/", false, false, new string[] {"math", "div"});
			tree.AddToken("^", false, false, new string[] {"math", "xor"});
			tree.AddToken("%", false, false, new string[] {"math", "mod"});

			tree.AddToken("*", false, false, new string[] {"identifier", "property path", "value", "math", "mul"}); // do not localize
			tree.AddToken("¤", false, true, new string[] {"identifier", "property path", "value"}); // do not localize

			tree.AddToken("and", false, true, new string[] {"boolop", "and"});
			tree.AddToken("or", false, true, new string[] {"boolop", "or"});
			tree.AddToken("&&", false, false, new string[] {"boolop", "and"});
			tree.AddToken("||", false, false, new string[] {"boolop", "or"});

			tree.AddToken("not", false, true, new string[] {"math", "not"});
			tree.AddToken("!", false, false, new string[] {"math", "not"});


			tree.AddToken("asc", false, true, "direction");
			tree.AddToken("desc", false, true, "direction");

			tree.AddToken("true", false, true, new string[] {"value", "boolean", "true"});
			tree.AddToken("false", false, true, new string[] {"value", "boolean", "false"});
			tree.AddToken("between", false, true, new string[] {"between"});


			tree.AddToken("null", false, true, new string[] {"value", "null"});

			tree.AddToken("?", false, false, new string[] {"value", "?", "parameter"});
			tree.AddExpression(false, true, new RangePatternMatcher('\"', '\"', '\"'), new string[] {"value", "string", "string \""}); // do not localize
			tree.AddExpression(false, true, new RangePatternMatcher('\'', '\'', '\''), new string[] {"value", "string", "string '"}); // do not localize
			tree.AddExpression(false, true, new RangePatternMatcher('#'), new string[] {"value", "date"});
			tree.AddExpression(false, true, new RangePatternMatcher('{', '}'), new string[] {"value", "guid"});
			tree.AddExpression(false, true, new DecPatternMatcher(), new string[] {"value", "decimal"});

			//		tree.AddExpression(false, true, new RegexPatternMatcher(@"(\@?[a-zA-Z]{1}(\w*)\.?)*"), new string[] {"property path","value"}); // do not localize
			//tree.AddExpression(false, true, new RegexPatternMatcher(@"(\@?[a-zA-Z]{1}(\w*))"),new string[] {"identifier","property path","value"}); // do not localize
			//tree.AddExpression(false, true, new RegexPatternMatcher(@"(\@?[a-zA-Z]{1}(\w*)\.{1})*(([a-zA-Z]{1}(\w*))|\*|\¤)"),new string[] {"identifier","property path","value"}); // do not localize
			tree.AddExpression(false, true, new PropertyPathPatterhMatcher(), new string[] {"identifier", "property path", "value"}); // do not localize

			return tree;
		}

		#endregion

		private int currentIndex = 0;
		private IList tokens = null;

		public void Tokenize(string code)
		{
			tokens = GetTokens(code);
		}

		public Token GetPreviousToken()
		{
			return this[currentIndex - 1];
		}

		public Token GetCurrentToken()
		{
			return this[currentIndex];
		}

		public Token GetNextToken()
		{
			return this[currentIndex + 1];
		}

		public Token GetCurrentToken(string ensureType, string expected)
		{
			Token tokenFound = GetCurrentToken();
			Token tokenNear = GetPreviousToken();
			EnsureType(tokenFound, ensureType, tokenNear.Text, expected);
			return tokenFound;
		}

		public Token GetNextToken(string ensureType, string expected)
		{
			Token tokenFound = GetNextToken();
			Token tokenNear = GetCurrentToken();
			EnsureType(tokenFound, ensureType, tokenNear.Text, expected);
			return tokenFound;
		}

		public Token GetCurrentToken(string ensureType, string[] expected)
		{
			Token tokenFound = GetCurrentToken();
			Token tokenNear = GetNextToken();
			EnsureType(tokenFound, ensureType, tokenNear.Text, expected);
			return tokenFound;
		}

		public Token GetNextToken(string ensureType, string[] expected)
		{
			Token tokenFound = GetNextToken();
			Token tokenNear = this[currentIndex + 2];
			EnsureType(tokenFound, ensureType, tokenNear.Text, expected);
			return tokenFound;
		}

		private void EnsureType(Token token, string type, string near)
		{
			if (!token.IsType(type))
				throw new UnexpectedTokenException(token.Text, token.Index, near);
		}

		private void EnsureType(Token token, string type, string near, params string[] expected)
		{
			if (!token.IsType(type))
				throw new UnexpectedTokenException(token.Text, token.Index, near, expected);
		}

		private void EnsureType(Token token, string type, string near, string expected)
		{
			if (!token.IsType(type))
				throw new UnexpectedTokenException(token.Text, token.Index, near, expected);
		}

		public bool MoveNext()
		{
			currentIndex ++;
			return true;
		}

		public bool MovePrevious()
		{
			currentIndex --;
			return true;
		}

		public bool EOF
		{
			get { return currentIndex >= tokens.Count; }
		}

		public bool BOF
		{
			get { return currentIndex <= 0; }
		}

		public Token this[int index]
		{
			get
			{
				if (index < 0)
					return Token.Empty;

				if (index >= tokens.Count)
					return Token.Empty;

				return (Token) tokens[index];
			}
		}

		public int Count
		{
			get { return tokens.Count; }
		}

		private IList GetTokens(string code)
		{
			ArrayList tokens = new ArrayList();
			MatchResult match;
			int currentIndex = 0;

			while (true)
			{
				match = tokenTree.Match(code, currentIndex);
				Token token = new Token();

				if (match.Found)
				{
					//get the test from the end of the last match , to the begining of the new match
					//if
					string dumbText = code.Substring(currentIndex, match.Index - currentIndex);
					ThrowUnknownTokenException(dumbText, tokens, currentIndex);
				}
				else
				{
					string dumbText = code.Substring(currentIndex);
					ThrowUnknownTokenException(dumbText, tokens, currentIndex);
				}

				token.Index = match.Index;
				token.Text = match.GetText();
				if (match.Tag is string)
				{
					token.Types = new string[] {(string) match.Tag};
				}
				else if (match.Tag is string[])
				{
					token.Types = (string[]) match.Tag;
				}

				tokens.Add(token);


				currentIndex = match.Index + match.Length;


				if (!match.Found)
					break;
			}
			return tokens;
		}

		private static void ThrowUnknownTokenException(string dumbText, ArrayList tokens, int currentIndex)
		{
			dumbText = dumbText.Replace("\n", "");
			dumbText = dumbText.Replace("\r", "");
			dumbText = dumbText.Replace("\t", " ");
			dumbText = dumbText.Trim();

			if (dumbText != "")
			{
				if (tokens.Count > 0)
				{
					Token previousToken = (Token) tokens[tokens.Count - 1];
					throw new UnknownTokenException(dumbText, currentIndex, previousToken.Text);
				}
				else
				{
					throw new UnknownTokenException(dumbText, currentIndex, "");
				}
			}
		}
	}
}