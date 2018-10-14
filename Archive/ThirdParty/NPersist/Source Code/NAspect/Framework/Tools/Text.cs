// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Text.RegularExpressions;

namespace Puzzle.NAspect.Framework.Tools
{
    /// <summary>
    /// Util class for strings
    /// </summary>
    public class Text
    {
        #region IsMatch

        /// <summary>
        /// Matches wildcard patterns in strings.
        /// </summary>
        /// <param name="text">string to match.</param>
        /// <param name="pattern">matching pattern.</param>
        /// <returns>true if match, otherwise false.</returns>
        public static bool IsMatch(string text, string pattern)
        {
            string regexpattern = "";
            foreach (char c in pattern)
            {
                if (c == '*')
                    regexpattern += @"\w*";
                else if (c == '?')
                    regexpattern += @"\w";
                else
                    regexpattern += Regex.Escape(c.ToString());
            }
            return Regex.IsMatch(text, regexpattern);
        }

        #endregion
    }
}