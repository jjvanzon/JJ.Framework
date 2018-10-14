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
    public class TokenTree
    {
        private TokenTreeNode[] nodes;
        private bool[] separatorCharLookup = null;
        private char[] textLookup = null;
        private TokenTreeNode root;

        public TokenTree()
        {
            nodes = new TokenTreeNode[65536];
            Separators = ".,;:<>[](){}!\"#¤%&/=?*+-/\\ \t\n\r";
            textLookup = new char[65536];
            for (int i = 0; i < 65536; i++)
            {
                textLookup[i] = (char) i;
            }
            textLookup[(int) '\t'] = ' ';

            root = new TokenTreeNode();
        }

        #region PUBLIC PROPERTY SEPARATORS

        private string separators;

        public virtual string Separators
        {
            get => separators;
            set
            {
                separators = value;
                separatorCharLookup = new bool[65536]; //initialize all to false
                foreach (char separatorChar in value)
                {
                    separatorCharLookup[(int) separatorChar] = true;
                }
            }
        }

        #endregion //END PUBLIC PROPERTY SEPARATORS

        public void AddExpression(bool caseSensitive, bool needSeparators, IPatternMatcher matcher, object tag)
        {
            if (matcher == null)
                throw new ArgumentNullException("matcher"); // do not localize

            AddExpression(null, caseSensitive, needSeparators, matcher, tag);
        }

        public void AddExpression(string prefix, bool caseSensitive, bool needSeparators, IPatternMatcher matcher,
                                  object tag)
        {
            if (StringUtils.IsNullOrEmpty(prefix))
            {
                AddExpressionWithoutPrefix(matcher, caseSensitive, needSeparators, tag);
            }
            else if (caseSensitive)
            {
                AddExpressionWithCaseSensitivePrefix(prefix, needSeparators, matcher, tag);
            }
            else
            {
                AddExpressionWithCaseInsensitivePrefix(prefix, needSeparators, matcher, tag);
            }
        }

        private void AddExpressionWithCaseInsensitivePrefix(string prefix, bool needSeparators, IPatternMatcher matcher,
                                                            object tag)
        {
            //make a lowercase string and add it as a token
            prefix = prefix.ToLower();
            char startChar = prefix[0];
            int startIndex = (int) startChar;
            if (nodes[startIndex] == null)
                nodes[startIndex] = new TokenTreeNode();

            nodes[startIndex].AddExpression(prefix, false, needSeparators, matcher, tag);

            //make a lowercase string with a uppercase start char and add it as a token
            prefix = char.ToUpper(startChar) + prefix.Substring(1);
            startChar = prefix[0];
            startIndex = (int) startChar;
            if (nodes[startIndex] == null)
                nodes[startIndex] = new TokenTreeNode();

            nodes[startIndex].AddExpression(prefix, false, needSeparators, matcher, tag);
        }

        private void AddExpressionWithCaseSensitivePrefix(string prefix, bool needSeparators, IPatternMatcher matcher,
                                                          object tag)
        {
            char startChar = prefix[0];
            int startIndex = (int) startChar;
            if (nodes[startIndex] == null)
                nodes[startIndex] = new TokenTreeNode();

            nodes[startIndex].AddExpression(prefix, true, needSeparators, matcher, tag);
        }

        private void AddExpressionWithoutPrefix(IPatternMatcher matcher, bool caseSensitive, bool needSeparators,
                                                object tag)
        {
            if (matcher.DefaultPrefixes != null)
            {
                foreach (string defaultPrefix in matcher.DefaultPrefixes)
                {
                    AddExpression(defaultPrefix, caseSensitive, needSeparators, matcher, tag);
                }
            }
            else
            {
                PatternMatchReference patternMatcherReference = new PatternMatchReference(matcher);
                patternMatcherReference.Tag = tag;
                patternMatcherReference.NextSibling = root.FirstExpression;
                root.FirstExpression = patternMatcherReference;
            }
        }

        public void AddToken(string text, object tag)
        {
            if (StringUtils.IsNullOrEmpty(text))
                throw new ArgumentException("text may not be empty", "text"); // do not localize

            AddToken(text, true, false, tag);
        }

        public void AddToken(string text, bool caseSensitive, bool needSeparators, object tag)
        {
            if (StringUtils.IsNullOrEmpty(text))
                throw new ArgumentException("text may not be empty", "text"); // do not localize

            if (caseSensitive)
            {
                AddCaseSensitiveToken(text, needSeparators, tag);
            }
            else
            {
                AddCaseInsensitiveToken(text, needSeparators, tag);
            }
        }

        private void AddCaseInsensitiveToken(string text, bool needSeparators, object tag)
        {
            //make a lowercase string and add it as a token
            text = text.ToLower();
            char startChar = text[0];
            int startIndex = (int) startChar;
            if (nodes[startIndex] == null)
                nodes[startIndex] = new TokenTreeNode();

            nodes[startIndex].AddToken(text, false, needSeparators, tag);

            //make a lowercase string with a uppercase start char and add it as a token
            text = char.ToUpper(startChar) + text.Substring(1);
            startChar = text[0];
            startIndex = (int) startChar;
            if (nodes[startIndex] == null)
                nodes[startIndex] = new TokenTreeNode();

            nodes[startIndex].AddToken(text, false, needSeparators, tag);
        }

        private void AddCaseSensitiveToken(string text, bool needSeparators, object tag)
        {
            char startChar = text[0];
            int startIndex = (int) startChar;
            if (nodes[startIndex] == null)
                nodes[startIndex] = new TokenTreeNode();

            nodes[startIndex].AddToken(text, true, needSeparators, tag);
        }


        //this is wicked fast
        //do not refactor extract methods from this if you want to keep the speed
        public MatchResult Match(string text, int startIndex)
        {
            if (StringUtils.IsNullOrEmpty(text))
                throw new ArgumentException("text may not be empty", "text"); // do not localize

            MatchResult lastMatch = new MatchResult();
            lastMatch.Text = text;
            int textLength = text.Length;

            for (int currentIndex = startIndex; currentIndex < textLength; currentIndex ++)
            {
                //call any prefixless patternmatchers

                #region HasExpressions

                if (root.FirstExpression != null)
                {
                    //begin with the first expression of the _root node_
                    PatternMatchReference patternMatcherReference = root.FirstExpression;
                    while (patternMatcherReference != null)
                    {
                        int expressionMatchIndex = patternMatcherReference.Matcher.Match(text, currentIndex);
                        if (expressionMatchIndex > 0 && expressionMatchIndex > lastMatch.Length)
                        {
                            lastMatch.Index = currentIndex;
                            lastMatch.Length = expressionMatchIndex;
                            lastMatch.Found = true;
                            lastMatch.Tag = patternMatcherReference.Tag;
                        }

                        patternMatcherReference = patternMatcherReference.NextSibling;
                    }
                }

                #endregion

                //lookup the first token tree node
                TokenTreeNode node = nodes[(int) text[currentIndex]];
                if (node == null)
                {
                    if (lastMatch.Found)
                        break;
                    else
                        continue;
                }


                for (int matchIndex = currentIndex + 1; matchIndex <= textLength; matchIndex++)
                {
                    //call patternmatchers for the current prefix

                    #region HasExpressions

                    if (node.FirstExpression != null)
                    {
                        //begin with the first expression of the _current node_
                        PatternMatchReference patternMatcherReference = node.FirstExpression;
                        while (patternMatcherReference != null)
                        {
                            int expressionMatchIndex = patternMatcherReference.Matcher.Match(text, matchIndex);
                            if (expressionMatchIndex > 0 && expressionMatchIndex > lastMatch.Length)
                            {
                                lastMatch.Index = currentIndex;
                                lastMatch.Length = expressionMatchIndex + matchIndex - currentIndex;
                                lastMatch.Found = true;
                                lastMatch.Tag = patternMatcherReference.Tag;
                            }

                            patternMatcherReference = patternMatcherReference.NextSibling;
                        }
                    }

                    #endregion

                    #region IsEndNode

                    if (node.IsEnd && matchIndex - currentIndex >= lastMatch.Length)
                    {
                        bool leftIsSeparator = currentIndex == 0 ? true : separatorCharLookup[text[currentIndex - 1]];
                        bool rightIsSeparator = matchIndex == textLength ? true : separatorCharLookup[text[matchIndex]];

                        if (!node.NeedSeparators || (leftIsSeparator && rightIsSeparator))
                        {
                            //this node does not require separators on the sides
                            lastMatch.Index = currentIndex;
                            lastMatch.Tag = node.Tag;
                            lastMatch.Found = true;
                            lastMatch.Length = matchIndex - currentIndex;
                            //TODO:perform case test here , case sensitive words might be matched even if they have incorrect case
                            if (currentIndex + lastMatch.Length == textLength)
                                break;
                        }
                    }

                    #endregion

                    if (matchIndex >= textLength)
                        break;
                    //try fetch a node at this index
                    node =
                        node.ChildNodes[
                            node.ContainsCaseInsensitiveData
                                ? (int) CharUtils.ToLower(textLookup[(int) text[matchIndex]]) & 0xff
                                : (int) textLookup[(int) text[matchIndex]] & 0xff];


                    //if node is not null then do: if caseinsensitive then do: insensitivelookup else do: casesesnsitivelookup
                    while (node != null
                               ?
                           (node.ContainsCaseInsensitiveData
                                ? (node.Char != CharUtils.ToLower(textLookup[(int) text[matchIndex]]))
                                : (node.Char != textLookup[(int) text[matchIndex]]))
                               : false)
                        node = node.NextSibling;

                    //we found no node on the lookupindex or none of the siblingnodes at that index matched the current char
                    if (node == null)
                        break; // continue with the next character
                }

                //return last match
                if (lastMatch.Found)
                    return lastMatch;
            }

            if (lastMatch.Found)
            {
                return lastMatch;
            }
            else
            {
                //no match was found
                return MatchResult.NoMatch;
            }
        }
    }
}