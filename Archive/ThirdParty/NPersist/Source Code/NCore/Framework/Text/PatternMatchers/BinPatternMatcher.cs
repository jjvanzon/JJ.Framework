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
    /// Pattern matcher that matches binary tokens
    /// </summary>
    public class BinPatternMatcher : PatternMatcherBase
    {
        //perform the match
        public override int Match(string textToMatch, int matchAtIndex)
        {
            int currentIndex = matchAtIndex;
            do
            {
                char currentChar = textToMatch[currentIndex];
                if (currentChar == '0' || currentChar == '1')
                {
                    //current char is hexchar
                }
                else
                {
                    break;
                }
                currentIndex++;
            } while (currentIndex < textToMatch.Length);

            return currentIndex - matchAtIndex;
        }

        //patterns that trigger this matcher
        public override string[] DefaultPrefixes => new string[] {"0", "1"};
    }
}