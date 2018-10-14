// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NCore.Framework.Text.PatternMatchers
{
    public class RangePatternMatcher : PatternMatcherBase
    {
        public override string[] DefaultPrefixes => new string[] {StartChar.ToString()};

        #region Property STARTCHAR

        private char startChar;

        public virtual char StartChar
        {
            get => startChar;
            set => startChar = value;
        }

        #endregion

        #region Property ENDCHAR

        private char endChar;

        public virtual char EndChar
        {
            get => endChar;
            set => endChar = value;
        }

        #endregion

        #region Property ESCAPECHAR

        private char escapeChar;

        public virtual char EscapeChar
        {
            get => escapeChar;
            set => escapeChar = value;
        }

        #endregion

        public RangePatternMatcher(char quote)
        {
            StartChar = quote;
            EndChar = quote;
        }

        public RangePatternMatcher(char start, char end)
        {
            StartChar = start;
            EndChar = end;
        }

        public RangePatternMatcher(char start, char end, char escape)
        {
            StartChar = start;
            EndChar = end;
            EscapeChar = escape;
        }


        public override int Match(string textToMatch, int matchAtIndex)
        {
            int length = 0;
            int textLength = textToMatch.Length;

            while (matchAtIndex + length != textLength)
            {
                if (textToMatch[matchAtIndex + length] == EndChar &&
                    (matchAtIndex + length < textLength - 1 && textToMatch[matchAtIndex + length + 1] == EndChar))
                {
                    length++;
                }
                else if (textToMatch[matchAtIndex + length] == EndChar &&
                         (matchAtIndex + length == textLength - 1 || textToMatch[matchAtIndex + length + 1] != EndChar))
                    return length + 1;

                length++;
            }


            return 0;
        }
    }
}