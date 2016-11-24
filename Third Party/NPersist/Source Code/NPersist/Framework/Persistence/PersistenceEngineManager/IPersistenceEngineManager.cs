// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *
using Puzzle.NPersist.Framework.Enumerations ;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for IPersistenceEngineManager.
	/// </summary>
	public interface IPersistenceEngineManager : IPersistenceEngine
	{
		IPersistenceEngine GetPersistenceEngine(PersistenceType persistenceType);

		IPersistenceEngine GetPersistenceEngine(ISourceMap sourceMap);

		void SetPersistenceEngine(ISourceMap sourceMap, IPersistenceEngine persistenceEngine);

		IPersistenceEngine DefaultPersistenceEngine { get; set; }

		IPersistenceEngine ObjectRelationalPersistenceEngine { get; set; }

		IPersistenceEngine ObjectDocumentPersistenceEngine { get; set; }

		IPersistenceEngine ObjectServicePersistenceEngine { get; set; }

		IPersistenceEngine ObjectObjectPersistenceEngine { get; set; }
    }
}
