using System;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for ObjectGuiItem.
	/// </summary>
	public interface IObjectGuiItem
	{
		IContext Context
		{
			get ;
			set ;
		}
		
		object Obj
		{
			get;
			set ;
		}
		
		IClassMap ClassMap
		{
			get ;
			set ;
		}
		
		IPropertyMap PropertyMap
		{
			get ;
			set ;
		}

		object ReferencedByObj
		{
			get ;
			set ;
		}
		
		IClassMap ReferencedByClassMap
		{
			get ;
			set ;
		}
		
		IPropertyMap ReferencedByPropertyMap
		{
			get ;
			set ;
		}
		
	}
}
