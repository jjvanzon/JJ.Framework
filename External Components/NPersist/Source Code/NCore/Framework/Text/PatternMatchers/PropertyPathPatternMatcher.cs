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
    /// <summary>
    /// Pattern matcher that matches a propertypath
    /// </summary>
    public class PropertyPathPatterhMatcher : PatternMatcherBase
    {
        //perform the match
        public override int Match(string textToMatch, int matchAtIndex)
        {
            bool start = true;

            string pattern = "";
            int currentIndex = matchAtIndex;
            do
            {
                char currentChar = textToMatch[currentIndex];
                if (start && IsValidStartChar(currentChar))
                {
                    start = false;
                }
                else if (start && IsWildcard(currentChar))
                {
                    currentIndex++;
                    break;
                }
                else if (!start && IsSeparator(currentChar))
                {
                    start = true;
                }
                else if (!start && IsValidChar(currentChar))
                {
                }
                else
                {
                    break;
                }
                pattern += currentChar;
                currentIndex++;
            } while (currentIndex < textToMatch.Length);

            if (textToMatch.Substring(matchAtIndex, currentIndex - matchAtIndex) == "*")
                return 0;

            return currentIndex - matchAtIndex;
        }


        private bool IsWildcard(char c)
        {
            return c == '*' || c == '¤';
        }

        private bool IsSeparator(char c)
        {
            return c == '.';
        }

        private bool IsValidStartChar(char c)
        {
            if (CharUtils.IsLetter(c))
                return true;

            if ("_@".IndexOf(c) >= 0)
                return true;

            return false;
        }

        private bool IsValidChar(char c)
        {
            if (CharUtils.IsLetterOrDigit(c) || c == '_')
                return true;

            return false;
        }
    }
}