// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using Puzzle.NCore.Framework.Text.PatternMatchers;
using Puzzle.NCore.Framework.Text.Tokenizer;

namespace Puzzle.NCore.Framework.Text
{
    public class TokenTreeNode
    {
        public bool IsEnd = false;
        public char Char = char.MinValue;
        public long Count = 0;
        public TokenTreeNode NextSibling = null;
        public object Tag = null;
        public bool NeedSeparators = false;
        public bool CaseSensitive = true;
        public bool ContainsCaseInsensitiveData = false;
        public TokenTreeNode[] ChildNodes = null;
        public PatternMatchReference FirstExpression = null;

        public TokenTreeNode() => ChildNodes = new TokenTreeNode[256];

        public override string ToString()
        {
            if (Tag != null)
                return Tag.ToString();

            return "TokenTreeNode " + Char; // do not localize
        }

        public void AddExpression(string text, bool caseSensitive, bool needSeparators, IPatternMatcher matcher,
                                  object tag)
        {
            if (StringUtils.IsNullOrEmpty(text))
                throw new ArgumentException("text may not be empty", "text"); // do not localize


            Char = text[0];


            if (!caseSensitive)
                ContainsCaseInsensitiveData = true;

            if (text.Length == 1)
            {
                PatternMatchReference patternMatcherReference = new PatternMatchReference(matcher);
                patternMatcherReference.NextSibling = FirstExpression;
                patternMatcherReference.Tag = tag;
                FirstExpression = patternMatcherReference;
            }
            else
            {
                string leftovers = text.Substring(1);
                char childChar = leftovers[0];
                int childIndex = (int) childChar & 0xff; //make a lookupindex

                TokenTreeNode node = ChildNodes[childIndex];
                if (node == null)
                {
                    TokenTreeNode child = new TokenTreeNode();
                    ChildNodes[childIndex] = child;
                    child.AddExpression(leftovers, caseSensitive, needSeparators, matcher, tag);

                    if (child.Char == ' ')
                    {
                        // if the node contains " " (whitespace)
                        // then add the node as a childnode of itself.
                        // thus allowing it to parse things like
                        // "end         sub" even if the pattern is "end sub" // do not localize
                        child.ChildNodes[(int) ' '] = child;
                    }
                }
                else
                {
                    while (node.NextSibling != null && node.Char != childChar)
                    {
                        node = node.NextSibling;
                    }

                    if (node.Char != childChar)
                    {
                        TokenTreeNode child = new TokenTreeNode();
                        node.NextSibling = child;
                        child.AddExpression(leftovers, caseSensitive, needSeparators, matcher, tag);
                    }
                    else
                    {
                        node.AddExpression(leftovers, caseSensitive, needSeparators, matcher, tag);
                    }
                }
            }
        }


        public void AddToken(string text, bool caseSensitive, bool needSeparators, object tag)
        {
            Char = text[0];


            if (!caseSensitive)
                ContainsCaseInsensitiveData = true;

            if (text.Length == 1)
            {
                IsEnd = true;
                Tag = tag;
                NeedSeparators = needSeparators;
                CaseSensitive = caseSensitive;
            }
            else
            {
                string leftovers = text.Substring(1);
                char childChar = leftovers[0];
                int childIndex = (int) childChar & 0xff;
                    //make a lookupindex (dont mind if unicode chars end up as siblings as ascii)

                TokenTreeNode node = ChildNodes[childIndex];
                if (node == null)
                {
                    TokenTreeNode child = new TokenTreeNode();
                    ChildNodes[childIndex] = child;
                    child.AddToken(leftovers, caseSensitive, needSeparators, tag);

                    if (child.Char == ' ')
                    {
                        // if the node contains " " (whitespace)
                        // then add the node as a childnode of itself.
                        // thus allowing it to parse things like
                        // "end         sub" even if the pattern is "end sub" // do not localize
                        child.ChildNodes[(int) ' '] = child;
                    }
                }
                else
                {
                    while (node.NextSibling != null && node.Char != childChar)
                    {
                        node = node.NextSibling;
                    }

                    if (node.Char != childChar)
                    {
                        TokenTreeNode child = new TokenTreeNode();
                        node.NextSibling = child;
                        child.AddToken(leftovers, caseSensitive, needSeparators, tag);
                    }
                    else
                    {
                        node.AddToken(leftovers, caseSensitive, needSeparators, tag);
                    }
                }
            }
        }
    }
}