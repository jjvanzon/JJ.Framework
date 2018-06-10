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
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for ObjectCloner.
	/// </summary>
	public class ObjectCloner : ContextChild, IObjectCloner
	{
		public ObjectCloner()
		{

		}

		#region Property  ClonedObjects
		
		private IList clonedObjects = new ArrayList() ;
		
		public IList ClonedObjects
		{
			get => this.clonedObjects;
		    set => this.clonedObjects = value;
		}
		
		#endregion

		
		public void BeginEdit()
		{
			if (this.clonedObjects.Count > 0)
				throw new EditException("Edit cache is not empty!");
			
		}

		public void CancelEdit()
		{
			foreach (object obj in this.clonedObjects)
			{
				RestoreFromClone(obj);
			}
			this.clonedObjects.Clear() ;
		}

		public void EndEdit() => this.clonedObjects.Clear();

	    public IObjectClone CloneObject(object obj)
		{
			IObjectManager om = this.Context.ObjectManager ;
			IObjectClone clone = new ObjectClone();

			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );

			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps() )
			{
				if (propertyMap.IsCollection)
				{
                    //TODO: Implement this					
				}
				else
				{
					clone.SetPropertyValue(propertyMap.Name, om.GetPropertyValue(obj, propertyMap.Name) );	
					clone.SetNullValueStatus(propertyMap.Name, om.GetNullValueStatus(obj, propertyMap.Name) );	
					clone.SetUpdatedStatus(propertyMap.Name, om.GetUpdatedStatus(obj, propertyMap.Name) );	

					if (om.HasOriginalValues(obj, propertyMap.Name))
                        clone.SetOriginalPropertyValue(propertyMap.Name, om.GetOriginalPropertyValue(obj, propertyMap.Name));

				}
			}

			clone.SetObjectStatus(om.GetObjectStatus(obj) );

            IIdentityHelper identityHelper = obj as IIdentityHelper;
            if (identityHelper != null)
            {
                clone.SetIdentity(identityHelper.GetIdentity());

                if (identityHelper.HasIdentityKeyParts())
                    foreach (object keyPart in identityHelper.GetIdentityKeyParts())
                        clone.GetIdentityKeyParts().Add(keyPart);
                if (identityHelper.HasKeyStruct())
                    clone.SetKeyStruct(identityHelper.GetKeyStruct());
            }

			this.clonedObjects.Add(obj);

			return clone;
		}

		public void EnsureIsClonedIfEditing(object obj)
		{
			if (this.Context.IsEditing)
				EnsureIsCloned(obj);
		}


		public void EnsureIsCloned(object obj)
		{
			if (((ICloneHelper) obj).GetObjectClone() == null)
				((ICloneHelper) obj).SetObjectClone(CloneObject(obj)); 
		}

		public void RestoreFromClone(object obj)
		{
			IObjectManager om = this.Context.ObjectManager ;
			IObjectClone clone = ((ICloneHelper) obj).GetObjectClone() ;

			if (clone == null)
				throw new EditException("Object has no cached clone!");

			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );

			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps() )
			{
				if (propertyMap.IsCollection)
				{
					//TODO: Implement this
				}
				else
				{
                    if (clone.HasOriginalValues(propertyMap.Name))
                        om.SetOriginalPropertyValue(obj, propertyMap.Name, clone.GetOriginalPropertyValue(propertyMap.Name));

                    om.SetPropertyValue(obj, propertyMap.Name, clone.GetPropertyValue(propertyMap.Name));
                    om.SetNullValueStatus(obj, propertyMap.Name, clone.GetNullValueStatus(propertyMap.Name));
                    om.SetUpdatedStatus(obj, propertyMap.Name, clone.GetUpdatedStatus(propertyMap.Name));
				}
			}

            IIdentityHelper identityHelper = obj as IIdentityHelper;
            if (identityHelper != null)
            {
                identityHelper.SetIdentity(clone.GetIdentity());

                if (clone.HasIdentityKeyParts())
                {
                    identityHelper.GetIdentityKeyParts().Clear();
                    foreach (object keyPart in clone.GetIdentityKeyParts())
                        identityHelper.GetIdentityKeyParts().Add(keyPart);
                }
                if (clone.HasKeyStruct())
                    identityHelper.SetKeyStruct(clone.GetKeyStruct());
            }

			ObjectStatus objStatus = clone.GetObjectStatus() ;
			om.SetObjectStatus(obj, objStatus);	

			if (objStatus == ObjectStatus.NotRegistered)
			{
				this.Context.IdentityMap.UnRegisterCreatedObject(obj);
			}
		}

		public void DiscardClone(object obj)
		{
			
		}

	}
}
