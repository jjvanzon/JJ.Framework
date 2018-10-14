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
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NCore.Framework.Collections;

namespace Puzzle.NPersist.Framework.Interfaces
{
	public interface IIdentityHelper
	{
		string GetIdentity();

		void SetIdentity(string identity);

        bool HasIdentityKeyParts();

        IList GetIdentityKeyParts();

        bool HasKeyStruct();

        KeyStruct GetKeyStruct();

        void SetKeyStruct(KeyStruct keyStruct);

		Guid GetTransactionGuid();

		void SetTransactionGuid(Guid value);

		void Reset();
	}
}