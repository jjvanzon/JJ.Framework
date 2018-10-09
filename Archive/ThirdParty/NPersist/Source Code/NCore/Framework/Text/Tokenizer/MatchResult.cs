// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NCore.Framework.Text
{
    public struct MatchResult
    {
        public bool Found;
        public object Tag;
        public int Index;
        public int Length;
        public string Text;

        public static MatchResult NoMatch
        {
            get
            {
                MatchResult result = new MatchResult();
                result.Found = false;
                return result;
            }
        }

        public override string ToString()
        {
            if (Found == false)
                return "no match"; // do not localize
            else if (Tag != null)
                return Tag.ToString() + "  " + Index.ToString() + "  " + Length.ToString();
            else
                return "MatchResult";
        }

        public string GetText()
        {
            if (Text != null)
                return Text.Substring(Index, Length);
            else
                return "";
        }
    }
}