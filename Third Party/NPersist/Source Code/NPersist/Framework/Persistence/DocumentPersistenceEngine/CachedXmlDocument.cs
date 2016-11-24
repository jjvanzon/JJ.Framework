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
using System.IO;
using System.Text;
using System.Xml;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for CachedXmlDocument.
	/// </summary>
	public class CachedXmlDocument
	{
		private XmlDocument xmlDocument;
		private string fileName;
		private DateTime lastUpdated;
		private bool newFile = false;

		public CachedXmlDocument(XmlDocument xmlDocument, string fileName, DateTime lastUpdated)
		{
			this.xmlDocument = xmlDocument;
			this.fileName = fileName;
			this.lastUpdated = lastUpdated;
		}

		public CachedXmlDocument(XmlDocument xmlDocument, string fileName)
		{
			this.xmlDocument = xmlDocument;
			this.fileName = fileName;
			this.lastUpdated = DateTime.MinValue;
			newFile = true;
		}

		public XmlDocument XmlDocument
		{
			get { return this.xmlDocument; }
			set { this.xmlDocument = value; }
		}

		public string FileName
		{
			get { return this.fileName; }
			set { this.fileName = value; }
		}

		public DateTime LastUpdated
		{
			get { return this.lastUpdated; }
			set { this.lastUpdated = value; }
		}

		public bool NewFile
		{
			get { return this.newFile; }
			set { this.newFile = value; }
		}

	}
}
