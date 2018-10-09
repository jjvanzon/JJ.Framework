using Puzzle.NCore.Framework.Compression;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Remoting.Formatting;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Remoting
{
	/// <summary>
	/// Summary description for IRemotingServer.
	/// </summary>
	public interface IRemotingServer
	{
		IContextFactory ContextFactory { get; set; }

		IFormatter Formatter { get; set; }

		IWebServiceCompressor Compressor { get; set; }

		bool UseCompression { get; set; }

		string GetMap(string domainKey);

		object LoadObject(string type, object identity, string domainKey);

		object LoadObjectByKey(string type, string keyPropertyName, object keyValue, string domainKey);

		object CommitUnitOfWork(object obj, string domainKey);

		object LoadProperty(object obj, string propertyName, string domainKey);

		object LoadObjects(object query, string domainKey);

	}
}
