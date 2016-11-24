// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	/// <summary>
	/// Summary description for CodeMap.
	/// </summary>
	public class CodeMap : MapBase, ICodeMap
	{
		public CodeMap()
		{
		}

		public override void Accept(IMapVisitor mapVisitor)
		{
			mapVisitor.Visit(this);
		}

		#region Property  Code
		
		private string code = "";
		
		public string Code
		{
			get { return this.code; }
			set { this.code = value; }
		}
		
		#endregion

		#region Property  CodeLanguage
		
		private CodeLanguage codeLanguage = CodeLanguage.CSharp ;
		
		public CodeLanguage CodeLanguage
		{
			get { return this.codeLanguage; }
			set { this.codeLanguage = value; }
		}
		
		#endregion

		#region Cloning

		public override IMap Clone()
		{
			ICodeMap codeMap = new CodeMap();
			Copy(codeMap);
			return codeMap;
		}

		public override IMap DeepClone()
		{
			ICodeMap codeMap = new CodeMap();
			DeepCopy(codeMap);
			return codeMap;
		}

		protected virtual void DoDeepCopy(ICodeMap codeMap)
		{
		}

		public override void DeepCopy(IMap mapObject)
		{
			ICodeMap codeMap = (ICodeMap) mapObject;
			Copy(codeMap);
			DoDeepCopy(codeMap);
		}

		public override bool DeepCompare(IMap compareTo)
		{
			if (!(Compare(compareTo)))
			{
				return false;
			}
			return true;
		}

		public override void DeepMerge(IMap mapObject)
		{
			Copy(mapObject);
		}

		public override void Copy(IMap mapObject)
		{
			ICodeMap codeMap = (ICodeMap) mapObject;
			codeMap.Code  = this.Code;
			codeMap.CodeLanguage = this.CodeLanguage;
		}

		public override bool Compare(IMap compareTo)
		{
			if (compareTo == null)
			{
				return false;
			}
			ICodeMap codeMap = (ICodeMap) compareTo;
			if (!(codeMap.Code == this.Code))
			{
				return false;
			}
			if (!(codeMap.CodeLanguage == this.CodeLanguage))
			{
				return false;
			}
			return true;
		}

		#endregion
	}
}
