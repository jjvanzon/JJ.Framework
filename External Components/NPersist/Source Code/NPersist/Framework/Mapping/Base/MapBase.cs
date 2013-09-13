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
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public abstract class MapBase : IMap
	{
		private ArrayList m_MetaData = new ArrayList();
		private string m_Name = "";
		private Hashtable m_FixedValues;

		public abstract void Accept(IMapVisitor mapVisitor);

		public virtual IMap GetParent()
		{
			return null; 
		} 

		public virtual bool IsInParents(IMap possibleParent)
		{
			if (possibleParent == null)
				return false;

			IMap parent = this.GetParent();

			while (parent != null)
			{
				if (possibleParent == parent)
				{
					return true;
				}
				parent = parent.GetParent();
			}
			return false;			
		}

		public virtual string Name
		{
			get
			{
				return m_Name;
			}
			set
			{
				m_Name = value;
			}
		}

		public virtual string GetKey()
		{
			return this.Name;
		}

		public virtual IMap Clone()
		{
			return null;
		}

		public virtual IMap DeepClone()
		{
			return null;
		}

		public abstract void Copy(IMap mapObject);

		public abstract void DeepCopy(IMap mapObject);

		public abstract void DeepMerge(IMap mapObject);

		public abstract bool Compare(IMap compareTo);

		public abstract bool DeepCompare(IMap compareTo);

		public int CompareTo(object obj)
		{
			string thisName;
			string thatName;
			if (!(obj is IMap))
			{
				throw new MissingInterfaceException("Objects of this type can only be compared to objects implementing the IMap interface!"); // do not localize
			}
			else
			{
				thisName = this.Name;
				thatName = ((IMap) (obj)).Name;
				return thisName.CompareTo(thatName);
			}
		}

		public virtual object GetMetaData(string key)
		{
			foreach (IMetaDataValue mdv in m_MetaData)
			{
				if (mdv.Key == key)
				{
					return mdv.Value;
				}
			}
			return null;
		}

		[XmlArrayItem(typeof (MetaDataValue))]
		public virtual ArrayList MetaData
		{
			get
			{
				return m_MetaData;
			}
			set
			{
				m_MetaData = value;
			}
		}

		public virtual void SetMetaData(string key, object value)
		{
			foreach (IMetaDataValue imdv in m_MetaData)
			{
				if (imdv.Key == key)
				{
					imdv.Value = value;
					return;
				}
			}
			IMetaDataValue mdv;
			mdv = new MetaDataValue();
			mdv.Key = key;
			mdv.Value = value;
			m_MetaData.Add(mdv);
		}

		public virtual bool HasMetaData(string key)
		{
			foreach (IMetaDataValue mdv in m_MetaData)
			{
				if (mdv.Key == key)
				{
					return true;
				}
			}
			return false;
		}

		public virtual void RemoveMetaData(string key)
		{
			foreach (IMetaDataValue mdv in m_MetaData)
			{
				if (mdv.Key == key)
				{
					m_MetaData.Remove(mdv);
					return;
				}
			}
		}

		protected virtual bool CompareArrayLists(ArrayList arrayList1, ArrayList arrayList2)
		{
			foreach (object val in arrayList1)
			{
				if (!(arrayList2.Contains(val)))
				{
					return false;
				}
			}
			foreach (object val in arrayList2)
			{
				if (!(arrayList1.Contains(val)))
				{
					return false;
				}
			}
			return true;
		}

		public virtual void Fixate()
		{
			if (m_FixedValues == null)
			{
				m_FixedValues = new Hashtable();
			}
		}

		public virtual void UnFixate()
		{
			m_FixedValues = null;
		}

		//[DebuggerStepThrough()]
		public virtual bool IsFixed()
		{
			if (m_FixedValues == null)
			{
				return false;
			}
			return true;
		}

		
		//[DebuggerStepThrough()]
		public virtual bool IsFixed(string memberName)
		{
			if (m_FixedValues == null)
			{
				return false;
			}
			return m_FixedValues.ContainsKey(memberName);
		}

		//[DebuggerStepThrough()]
		public virtual object GetFixedValue(string memberName)
		{
			if (m_FixedValues != null)
			{
                object res = m_FixedValues[memberName];
                return res;
			}
			return null;
		}

		//[DebuggerStepThrough()]
		public virtual void SetFixedValue(string memberName, object value)
		{
			if (m_FixedValues == null)
			{
				return;
			}
			m_FixedValues[memberName] = value;
		}

		public static bool IsReservedName(string name)
		{
			if (IsReservedCSharp(name))
			{
				return true;
			}
			if (IsReservedVBNet(name))
			{
				return true;
			}
			if (IsReservedDelphi(name))
			{
				return true;
			}
			return false;
		}

		public static bool IsReservedCSharp(string name)
		{
			bool isReserved = false;
			string[] reserved = new string[]
				{
					"abstract", "as",
					"bool", "break", "base", "byte",
					"continue", "const", "case", "char", "checked", "catch", "class",
					"decimal", "do", "double", "delegate", "default",
					"event", "explicit", "enum", "else", "extern",
					"float", "fixed", "finally", "false", "for", "foreach",
					"goto",
					"int", "is", "interface", "in", "internal", "implicit", "if",
					"lock", "long",
					"new", "null", "namespace",
					"this", "try",
					"operator", "out", "object", "override",
					"params", "private", "protected", "public",
					"readonly", "return", "ref",
					"string", "stackalloc", "switch", "static", "short", "sizeof", "struct", "sealed", "sbyte",
					"typeof", "throw", "true",
					"ulong", "using", "uint", "unchecked", "unsafe", "ushort",
					"while", "volatile", "virtual", "void"
				};

			isReserved = (Array.IndexOf(reserved, name) >= 0);
			return isReserved;
		}

		public static bool IsReservedVBNet(string name)
		{
			bool isReserved = false;
			string lowName = name.ToLower(CultureInfo.InvariantCulture);
			string[] reserved = new string[]
				{
					"addhandler", "addressof", "alias", "and", "andalso", "ansi", "as", "assembly", "auto",
					"boolean", "byref", "byte", "byval",
					"call", "case", "catch", "cbool", "cbyte", "cchar", "cdate", "cdec", "cdbl", "char", "cint", "class", "clng",
					"cobj", "const", "cshort", "csng", "cstr", "ctype", "date", "decimal",
					"declare", "default", "delegate", "dim", "directcast", "do", "double",
					"each", "else", "elseif", "end", "enum", "erase", "error", "event", "exit",
					"false", "finally", "for", "friend", "function",
					"get", "gettype", "gosub", "goto",
					"handles",
					"if", "implements", "imports", "in", "inherits", "integer", "interface", "is",
					"let", "lib", "like", "long", "loop",
					"me", "mod", "module", "mustinherit", "mustoverride", "mybase", "myclass",
					"namespace", "new", "next", "not", "nothing", "notinheritable", "notoverridable",
					"object", "on", "option", "optional", "or", "orelse", "overloads", "overridable", "overrides",
					"paramarray", "preserve", "private", "property", "protected", "public",
					"raiseevent", "readonly", "redim", "rem", "removehandler", "resume", "return",
					"select", "set", "shadows", "shared", "short", "single", "static", "step", "stop", "string",
					"structure", "sub", "synclock",
					"then", "throw", "to", "true", "try", "typeof",
					"unicode", "until",
					"variant", "when", "while", "with", "withevents", "writeonly",
					"xor",
					"#const", "#externalsource", "#region"
				};

			isReserved = (Array.IndexOf(reserved, lowName) >= 0);
			return isReserved;
		}

		public static bool IsReservedDelphi(string name)
		{
			bool isReserved = false;
			string lowName = name.ToLower(CultureInfo.InvariantCulture);
			string[] reserved = new string[]
				{
					"and", "array", "as", "asm", "absolute", "abstract", "assembler", "automated",
					"begin",
					"case", "class", "const", "constructor", "cdecl", "contains",
					"destructor", "dispinterface", "div", "do", "downto", "default", "dispid", "dynamic",
					"else", "end", "except", "exports", "export", "external",
					"file", "finalization", "finally", "for", "function", "far", "forward",
					"goto",
					"if", "implementation", "in", "inherited", "initialization", "inline", "interface", "is", "index",
					"label", "library",
					"mod", "message",
					"nil", "not", "name", "near", "nodefault",
					"object", "of", "or", "out", "override",
					"packed", "procedure", "program", "property", "pascal", "private", "protected", "public", "published", "package",
					"raise", "record", "repeat", "resourcestring", "read", "readonly", "register", "resident", "requires",
					"set", "shl", "shr", "string", "stringresource", "safecall", "stdcall", "stored", "static",
					"then", "threadvar", "to", "try", "type", "virtual", "write", "writeonly",
					"unit", "until", "uses",
					"var", "while", "with",
					"xor"
				};

			isReserved = (Array.IndexOf(reserved, lowName) >= 0);
			return isReserved;
		}
	}
}