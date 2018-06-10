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
using System.Reflection;
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Aop.Mixins;
using Puzzle.NCore.Framework.Collections;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for CloneObject.
	/// </summary>
	public class ObjectClone : IObjectClone
	{
		public ObjectClone()
		{
		}

		#region Property  NullValueHelperMixin
		
		private NullValueHelperMixin nullValueHelperMixin = new NullValueHelperMixin() ;
		
		public NullValueHelperMixin NullValueHelperMixin
		{
			get => this.nullValueHelperMixin;
		    set => this.nullValueHelperMixin = value;
		}
		
		#endregion

		#region Property  IdentityHelperMixin
		
		private IdentityHelperMixin identityHelperMixin = new IdentityHelperMixin() ;
		
		public IdentityHelperMixin IdentityHelperMixin
		{
			get => this.identityHelperMixin;
		    set => this.identityHelperMixin = value;
		}
		
		#endregion

		#region Property  OriginalValueHelperMixin
		
		private OriginalValueHelperMixin originalValueHelperMixin = new OriginalValueHelperMixin() ;
		
		public OriginalValueHelperMixin OriginalValueHelperMixin
		{
			get => this.originalValueHelperMixin;
		    set => this.originalValueHelperMixin = value;
		}
		
		#endregion

		#region Property  UpdatedPropertyTrackerMixin
		
		private UpdatedPropertyTrackerMixin updatedPropertyTrackerMixin = new UpdatedPropertyTrackerMixin() ;
		
		public UpdatedPropertyTrackerMixin UpdatedPropertyTrackerMixin
		{
			get => this.updatedPropertyTrackerMixin;
		    set => this.updatedPropertyTrackerMixin = value;
		}
		
		#endregion

		#region Property  ObjectStatusHelperMixin 
		
		private ObjectStatusHelperMixin objectStatusHelperMixin = new ObjectStatusHelperMixin() ;
		
		public ObjectStatusHelperMixin ObjectStatusHelperMixin 
		{
			get => this.objectStatusHelperMixin;
		    set => this.objectStatusHelperMixin  = value;
		}
		
		#endregion
	
		#region Property  ValueHelperMixin
		
		private ValueHelperMixin valueHelperMixin = new ValueHelperMixin() ;
		
		public ValueHelperMixin ValueHelperMixin
		{
			get => this.valueHelperMixin;
		    set => this.valueHelperMixin = value;
		}
		
		#endregion

		public ObjectStatus GetObjectStatus() => this.objectStatusHelperMixin.GetObjectStatus();

	    public bool GetUpdatedStatus(string propertyName) => this.updatedPropertyTrackerMixin.GetUpdatedStatus(propertyName);

	    public void SetUpdatedStatus(string propertyName, bool value) => this.updatedPropertyTrackerMixin.SetUpdatedStatus(propertyName, value);

	    public bool GetNullValueStatus(string propertyName) => this.nullValueHelperMixin.GetNullValueStatus(propertyName);

	    public void SetNullValueStatus(string propertyName, bool value) => this.nullValueHelperMixin.SetNullValueStatus(propertyName, value);

	    public object GetOriginalPropertyValue(string propertyName) => this.originalValueHelperMixin.GetOriginalPropertyValue(propertyName);

	    public void SetOriginalPropertyValue(string propertyName, object value) => this.originalValueHelperMixin.SetOriginalPropertyValue(propertyName, value);

	    public void RemoveOriginalValues(string propertyName) => this.originalValueHelperMixin.RemoveOriginalValues(propertyName);

	    public bool HasOriginalValues() => this.originalValueHelperMixin.HasOriginalValues();

	    public object GetPropertyValue(string propertyName) => this.valueHelperMixin.GetPropertyValue(propertyName);

	    public void SetPropertyValue(string propertyName, object value) => this.valueHelperMixin.SetPropertyValue(propertyName, value);

	    public void RemovePropertyValues(string propertyName) => this.valueHelperMixin.RemovePropertyValues(propertyName);

	    public bool HasPropertyValues() => this.valueHelperMixin.HasPropertyValues();

	    public void Restore(object obj) => throw new IAmOpenSourcePleaseImplementMeException();

	    public bool HasPropertyValues(string propertyName) => this.valueHelperMixin.HasPropertyValues(propertyName);

	    public bool HasOriginalValues(string propertyName) => this.originalValueHelperMixin.HasOriginalValues(propertyName);

	    public void SetNullValueStatus(bool value) => this.nullValueHelperMixin.SetNullValueStatus(value);

	    public void ClearUpdatedStatuses() => this.updatedPropertyTrackerMixin.ClearUpdatedStatuses();

	    public void SetObjectStatus(ObjectStatus value) => this.objectStatusHelperMixin.SetObjectStatus(value);

	    public string GetIdentity() => identityHelperMixin.GetIdentity();

	    public void SetIdentity(string identity) => identityHelperMixin.SetIdentity(identity);

	    public bool HasIdentityKeyParts() => identityHelperMixin.HasIdentityKeyParts();

	    public IList GetIdentityKeyParts() => identityHelperMixin.GetIdentityKeyParts();

	    public bool HasKeyStruct() => identityHelperMixin.HasKeyStruct();

	    public KeyStruct GetKeyStruct() => identityHelperMixin.GetKeyStruct();

	    public void SetKeyStruct(KeyStruct keyStruct) => identityHelperMixin.SetKeyStruct(keyStruct);

	    public void Reset() => identityHelperMixin.Reset();

	    public Guid GetTransactionGuid() => identityHelperMixin.GetTransactionGuid();

	    public void SetTransactionGuid(Guid value) => identityHelperMixin.SetTransactionGuid(value);
	}
}
