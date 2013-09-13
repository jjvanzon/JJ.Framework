using System;
using System.Collections;
using System.Data;
using System.Reflection;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Persistence;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Validation
{
	/// <summary>
	/// Summary description for ObjectValidator.
	/// </summary>
	public class ObjectValidator : ContextChild, IObjectValidator
	{
		public ObjectValidator()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool IsValid(object obj)
		{
			IList exceptions = new ArrayList() ;
			ValidateObject(obj, exceptions);
			return exceptions.Count > 0;
		}

		public bool IsValid(object obj, string propertyName)
		{
			IList exceptions = new ArrayList() ;
			ValidateProperty(obj, propertyName, exceptions);
			return exceptions.Count > 0;			
		}

		public void ValidateObject(object obj)
		{
			ValidateObject(obj, null);
		}

		public void ValidateObject(object obj, IList exceptions)
		{
			IObjectManager om = this.Context.ObjectManager;
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());

            ValidationMode objValidationMode = GetValidationMode(classMap);
            if (objValidationMode != ValidationMode.Off)
            {
                CustomValidateObject(obj, classMap, exceptions);
                ObjectStatus objStatus = om.GetObjectStatus(obj);
                foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
                {
                    ValidationMode validationMode = GetValidationMode(classMap, propertyMap);

                    if (validationMode != ValidationMode.Off)
                    {
                        PropertyStatus propStatus = om.GetPropertyStatus(obj, propertyMap.Name);

                        if (validationMode == ValidationMode.ValidateAll && objStatus != ObjectStatus.UpForCreation)
                            this.Context.ObjectManager.EnsurePropertyIsLoaded(obj, propertyMap);

                        if (objStatus == ObjectStatus.UpForCreation || propStatus != PropertyStatus.NotLoaded)
                        {
                            bool ok = false;
                            if (validationMode == ValidationMode.Default || validationMode == ValidationMode.ValidateLoaded || validationMode == ValidationMode.ValidateAll)
                                ok = true;
                            else if (validationMode == ValidationMode.ValidateDirty)
                            {
                                if (propStatus == PropertyStatus.Dirty)
                                    ok = true;
                            }

                            if (ok)
                                DoValidateProperty(obj, propertyMap, exceptions);
                        }
                    }
                }
            }
		}
		
		public void ValidateProperty(object obj, string propertyName)
		{
			ValidateProperty(obj, propertyName, null);
		}

		public void ValidateProperty(object obj, string propertyName, IList exceptions)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			IPropertyMap propertyMap = classMap.MustGetPropertyMap(propertyName);			
			DoValidateProperty(obj, propertyMap, exceptions);
		}

		private void HandleException(object obj, string propertyName, IList exceptions, Exception exception)
		{
			HandleException(obj, propertyName, exceptions, exception, null, null, null);
		}

		private void HandleException(object obj, string propertyName, IList exceptions, Exception exception, object limit, object actual, object value)
		{
			if (exceptions == null)
			{
				throw exception;	
			}
			else
			{
				exceptions.Add(new NPersistValidationException(exception, obj, propertyName, limit, actual, value));		
			}
		}

		private void DoValidateProperty(object obj, IPropertyMap propertyMap, IList exceptions)
		{
            CustomValidateProperty(obj, propertyMap, exceptions);
            ValidateNull(obj, propertyMap, exceptions);
			ValidateMaxLength(obj, propertyMap, exceptions);
			ValidateMinLength(obj, propertyMap, exceptions);
			ValidateMaxValue(obj, propertyMap, exceptions);
			ValidateMinValue(obj, propertyMap, exceptions);
			ValidateDatabaseDateRange(obj, propertyMap, exceptions);
		}

		private void ValidateNull(object obj, IPropertyMap propertyMap, IList exceptions)
		{
			if (propertyMap.GetIsAssignedBySource() == false)
			{
				if (propertyMap.GetIsNullable() == false)
				{
					if (this.Context.ObjectManager.GetNullValueStatus(obj, propertyMap.Name))
					{
						string template = "Validation error in object {0}.{1} , property {2}: " + Environment.NewLine + "Non-nullable property set to null! (NullValueStatus = true)";
						string result = String.Format(
							template, 
							propertyMap.ClassMap.Name, 
							this.Context.ObjectManager.GetObjectKeyOrIdentity(obj),
							propertyMap.Name );

						HandleException(obj, propertyMap.Name, exceptions, new ValidationException(result)) ;
					}
					else
					{
						object value = this.Context.ObjectManager.GetPropertyValue(obj, propertyMap.Name);
						if (value == null)
						{
							string template = "Validation error in object {0}.{1} , property {2}: " + Environment.NewLine + "Non-nullable property set to null!";
							string result = String.Format(
								template, 
								propertyMap.ClassMap.Name, 
								this.Context.ObjectManager.GetObjectKeyOrIdentity(obj),
								propertyMap.Name );
							HandleException(obj, propertyMap.Name, exceptions, new ValidationException(result)) ;					
						}
					}
				}				
			}
		}

		private string GetExceptionMessage(object obj, IPropertyMap propertyMap, string msg, object expected, object actual)
		{
			if (expected == null)
				expected = "<null>";
			if (actual == null)
				actual = "<null>";
			string template = "Validation error in object {0}.{1} , property {2}: " + Environment.NewLine + "{3}, was {4} , expected {5} ";
			string result = String.Format(
				template, 
				propertyMap.ClassMap.Name, 
				this.Context.ObjectManager.GetObjectKeyOrIdentity(obj),
				propertyMap.Name, 
				msg,
				actual.ToString(),
				expected.ToString());
			return result;
		}

		private void ValidateMaxLength(object obj, IPropertyMap propertyMap, IList exceptions)
		{
			int max = propertyMap.GetMaxLength();
			if (max > -1)
			{
				IObjectManager om = this.Context.ObjectManager;
				if (propertyMap.IsCollection)
				{
					IList value = (IList) om.GetPropertyValue(obj, propertyMap.Name);
					if (value != null)
					{
						if (value.Count > max )
						{
							string msg = "Too many elements in list";
							if (propertyMap.IsCollection)

								HandleException(
									obj, 
									propertyMap.Name, 
									exceptions, 
									new ValidationException(GetExceptionMessage(obj, propertyMap, msg, max, value.Count)), 
									max, 
									value.Count, 
									value.Count);
						}								
					}					
				}
				else
				{
					if (propertyMap.ReferenceType == ReferenceType.None)
					{
						if (!(om.GetNullValueStatus(obj, propertyMap.Name)))
						{
							object objValue = om.GetPropertyValue(obj, propertyMap.Name);
							if (objValue != null)
							{
								string value = objValue.ToString();
								if (value.Length > max )
								{
									string msg = "String too long";
									if (propertyMap.IsCollection)

										HandleException(
											obj, 
											propertyMap.Name, 
											exceptions, 
											new ValidationException(GetExceptionMessage(obj, propertyMap, msg, max, value.Length)), 
											max, 
											value.Length, 
											value);
								}								
							}
						}						
					}
				}
			}
		}

		private void ValidateMinLength(object obj, IPropertyMap propertyMap, IList exceptions)
		{
			int min = propertyMap.MinLength;
			if (min > -1)
			{
				IObjectManager om = this.Context.ObjectManager;
				if (propertyMap.IsCollection)
				{
					IList value = (IList) om.GetPropertyValue(obj, propertyMap.Name);
					if (value != null)
					{
						string msg = "Too few elements in list";
						if (value.Count < min )
							HandleException(
								obj, 
								propertyMap.Name, 
								exceptions, 
								new ValidationException(GetExceptionMessage(obj, propertyMap, msg, min, value.Count)), 
								min, 
								value.Count, 
								value.Count) ;					
					}										
				}
				else
				{
                    if (propertyMap.ReferenceType == ReferenceType.None)
                    {
                        if (!(om.GetNullValueStatus(obj, propertyMap.Name)))
                        {
                            object objValue = om.GetPropertyValue(obj, propertyMap.Name).ToString();
							if (objValue != null)
							{
								string value = objValue.ToString();
								string msg = "String too short";
								if (value.Length < min)
									HandleException(
										obj,
										propertyMap.Name,
										exceptions,
										new ValidationException(GetExceptionMessage(obj, propertyMap, msg, min, value.Length)),
										min,
										value.Length,
										value);
							}
                        }
                    }
				}
			}
		}

		private void ValidateMinValue(object obj, IPropertyMap propertyMap, IList exceptions)
		{
			string min = propertyMap.MinValue;
			if (min.Length > 0)
			{
				IObjectManager om = this.Context.ObjectManager;
				if (!(om.GetNullValueStatus(obj, propertyMap.Name)))
				{
					object value = om.GetPropertyValue(obj, propertyMap.Name);
					if (value != null)
					{
						bool ok = true;
						string msg = "Value too low";
						if (value is string)
						{
							if (min.CompareTo((string) value) > 0)
								ok = false;
						}
						else if (value is DateTime)
						{
							if ((DateTime.Parse(min)).CompareTo((DateTime) value) > 0)
								ok = false;
						}
						else if (value is Int16)
						{
							if ((Int16.Parse(min)).CompareTo((Int16) value) > 0)
								ok = false;
						}
						else if (value is Int32)
						{
							if ((Int32.Parse(min)).CompareTo((Int32) value) > 0)
								ok = false;
						}
						else if (value is Int64)
						{
							if ((Int64.Parse(min)).CompareTo((Int64) value) > 0)
								ok = false;
						}
						else if (value is Decimal)
						{
							if ((Decimal.Parse(min)).CompareTo((Decimal) value) > 0)
								ok = false;
						}
						else if (value is Double)
						{
							if ((Double.Parse(min)).CompareTo((Double) value) > 0)
								ok = false;
						}
						else if (value is Single)
						{
							if ((Single.Parse(min)).CompareTo((Single) value) > 0)
								ok = false;
						}
						if (ok == false)
							HandleException(obj, propertyMap.Name, exceptions, new ValidationException(GetExceptionMessage(obj, propertyMap, msg, min, value)), min, value, value) ;							


					}					
				}
			}
		}

		private void ValidateMaxValue(object obj, IPropertyMap propertyMap, IList exceptions)
		{
			string max = propertyMap.MaxValue;
			if (max.Length > 0)
			{
				IObjectManager om = this.Context.ObjectManager;
				if (!(om.GetNullValueStatus(obj, propertyMap.Name)))
				{
					object value = om.GetPropertyValue(obj, propertyMap.Name);
					if (value != null)
					{
						bool ok = true;
						string msg = "Value too high";
						if (value is string)
						{
							if (max.CompareTo((string) value) < 0)
								ok = false;
						}
						else if (value is DateTime)
						{
							if ((DateTime.Parse(max)).CompareTo((DateTime) value) < 0)
								ok = false;
						}
						else if (value is Int16)
						{
							if ((Int16.Parse(max)).CompareTo((Int16) value) < 0)
								ok = false;
						}
						else if (value is Int32)
						{
							if ((Int32.Parse(max)).CompareTo((Int32) value) < 0)
								ok = false;
						}
						else if (value is Int64)
						{
							if ((Int64.Parse(max)).CompareTo((Int64) value) < 0)
								ok = false;
						}
						else if (value is Decimal)
						{
							if ((Decimal.Parse(max)).CompareTo((Decimal) value) < 0)
								ok = false;
						}
						else if (value is Double)
						{
							if ((Double.Parse(max)).CompareTo((Double) value) < 0)
								ok = false;
						}
						else if (value is Single)
						{
							if ((Single.Parse(max)).CompareTo((Single) value) < 0)
								ok = false;
						}
						if (ok == false)
							HandleException(obj, propertyMap.Name, exceptions, new ValidationException(GetExceptionMessage(obj, propertyMap, msg, max, value)), max, value, value) ;							
					}					
				}
			}
		}


		private void ValidateDatabaseDateRange(object obj, IPropertyMap propertyMap, IList exceptions)
		{
			if (propertyMap.Column.Length > 0)
			{
				IObjectManager om = this.Context.ObjectManager;
				IColumnMap columnMap = propertyMap.GetColumnMap() ;
				if (columnMap != null)
				{
					if (columnMap.DataType.Equals(DbType.DateTime) ||  columnMap.DataType.Equals(DbType.Time) || columnMap.DataType.Equals(DbType.Date))
					{
						if (!(om.GetNullValueStatus(obj, propertyMap.Name)))
						{
							ISourceMap sourceMap = propertyMap.GetSourceMap();
							if (sourceMap != null)
							{
                                object rawValue = om.GetPropertyValue(obj, propertyMap.Name);
                                if (rawValue == null )
                                {
                                    //all ok                                    
                                }
                                else
                                {
                                    DateTime value = (DateTime)rawValue;
                                    if (sourceMap.SourceType == SourceType.MSSqlServer)
                                    {
                                        DateTime minDate = new DateTime(1753, 1, 1, 0, 0, 0);
                                        if (value < minDate)
                                        {
                                            string template = "Validation error in object {0}.{1} , property {2}: " + Environment.NewLine + "Sql server can not handle date/time values lower than 1753-01-01 00:00:00";
                                            string result = String.Format(
                                                template,
                                                propertyMap.ClassMap.Name,
                                                this.Context.ObjectManager.GetObjectKeyOrIdentity(obj),
                                                propertyMap.Name);

                                            HandleException(obj, propertyMap.Name, exceptions, new ValidationException(result), minDate, value, value);
                                        }
                                    }
                                }
							}
						}
					}
				}
			}
		}

		private void CustomValidateObject(object obj, IClassMap classMap, IList exceptions)
		{
			if (classMap.ValidateMethod.Length > 0)
			{
				MethodInfo methodInfo = GetMethod(obj, classMap.ValidateMethod);
				if (methodInfo != null)
				{
					if (exceptions == null)
					{
						methodInfo.Invoke(obj, null);						
					}
					else
					{
						try
						{
                            if (methodInfo.ReturnType is IList)
                            {
                                IList customExceptions = (IList) methodInfo.Invoke(obj, null);
                                if (customExceptions != null)
                                    foreach (Exception customException in customExceptions)
                                        exceptions.Add(customException);
                            }
                            else
                                methodInfo.Invoke(obj, null);
						}
						catch (Exception ex)
						{
							HandleException(obj, "", exceptions, ex.InnerException);							
						}
					}
				}				
			}
		}

		private void CustomValidateProperty(object obj, IPropertyMap propertyMap, IList exceptions)
		{
			if (propertyMap.ValidateMethod.Length > 0)
			{
				MethodInfo methodInfo = GetMethod(obj, propertyMap.ValidateMethod);
				if (methodInfo != null)
				{
					if (exceptions == null)
					{
						methodInfo.Invoke(obj, null);						
					}
					else
					{
						try
						{
                            if (methodInfo.ReturnType is IList)
                            {
                                IList customExceptions = (IList) methodInfo.Invoke(obj, null);
                                if (customExceptions != null)
                                    foreach (Exception customException in customExceptions)
                                        exceptions.Add(customException);
                            }
                            else
                                methodInfo.Invoke(obj, null);
                        }
						catch (Exception ex)
						{
							HandleException(obj, propertyMap.Name, exceptions, ex.InnerException);							
						}
					}
				}				
			}
		}
		
		//[DebuggerStepThrough()]
		public virtual MethodInfo GetMethod(object obj, string methodName)
		{
			return GetMethod(obj, obj.GetType(), methodName);
		}

		//[DebuggerStepThrough()]
		public virtual MethodInfo GetMethod(object obj, Type type, string methodName)
		{
			return ReflectionHelper.GetMethodInfo(type,methodName);
		}

        public virtual ValidationMode GetValidationMode(object obj)
        {
            IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
            return GetValidationMode(classMap);
        }

        public virtual ValidationMode GetValidationMode(IClassMap classMap)
        {
            ValidationMode validationMode = classMap.ValidationMode;
            if (validationMode == ValidationMode.Default)
            {
                validationMode = classMap.DomainMap.ValidationMode;
                if (validationMode == ValidationMode.Default)
                {
                    validationMode = this.Context.ValidationMode;
                    if (validationMode == ValidationMode.Default)
                    {
                        validationMode = ValidationMode.ValidateLoaded;
                    }
                }
            }
            return validationMode;
        }

        public virtual ValidationMode GetValidationMode(object obj, string propertyName)
        {
            IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
            IPropertyMap propertyMap = classMap.MustGetPropertyMap(propertyName);
            return GetValidationMode(classMap, propertyMap);
        }

        public virtual ValidationMode GetValidationMode(IClassMap classMap, IPropertyMap propertyMap)
        {
            ValidationMode validationMode = propertyMap.ValidationMode;
            if (validationMode == ValidationMode.Default)
            {
                validationMode = classMap.ValidationMode;
                if (validationMode == ValidationMode.Default)
                {
                    validationMode = classMap.DomainMap.ValidationMode;
                    if (validationMode == ValidationMode.Default)
                    {
                        validationMode = this.Context.ValidationMode;
                        if (validationMode == ValidationMode.Default)
                        {
                            validationMode = ValidationMode.ValidateLoaded;
                        }
                    }
                }
            }
            return validationMode;
        }
	}
}
