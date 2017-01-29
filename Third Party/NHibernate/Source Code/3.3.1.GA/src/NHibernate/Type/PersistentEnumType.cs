using System;
using System.Collections.Generic;
using System.Data;
using NHibernate.Engine;
using NHibernate.SqlTypes;

namespace NHibernate.Type
{
	using System.Runtime.Serialization;

	/// <summary>
	/// PersistentEnumType
	/// </summary>
	[Serializable]
	public class PersistentEnumType : AbstractEnumType
	{
		#region Converters

		// OLD TODO: ORACLE - An convert is needed because right now everything that Oracle is 
		// sending to NHibernate is a decimal - not the correct underlying type and I don't know why

		public interface IEnumConverter
		{
			object ToObject(System.Type enumClass, object code);
			object ToEnumValue(object value);
			SqlType SqlType { get; }
		}
		[Serializable]
		private abstract class AbstractEnumConverter<T> : IEnumConverter
		{
			public object ToObject(System.Type enumClass, object code)
			{
				return Enum.ToObject(enumClass, Convert(code));
			}

			public object ToEnumValue(object value)
			{
				return Convert(value);
			}

			public abstract T Convert(object input);
			public abstract SqlType SqlType { get; }
		}
		[Serializable]
		private class SystemByteEnumConverter : AbstractEnumConverter<byte>
		{
			public override byte Convert(object input)
			{
				return System.Convert.ToByte(input);
			}

			public override SqlType SqlType
			{
				get { return SqlTypeFactory.Byte; }
			}
		}
		[Serializable]
		private class SystemSByteEnumConverter : AbstractEnumConverter<sbyte>
		{
			public override sbyte Convert(object input)
			{
				return System.Convert.ToSByte(input);
			}

			public override SqlType SqlType
			{
				get { return SqlTypeFactory.SByte; }
			}
		}
		[Serializable]
		private class SystemInt16EnumConverter : AbstractEnumConverter<short>
		{
			public override short Convert(object input)
			{
				return System.Convert.ToInt16(input);
			}

			public override SqlType SqlType
			{
				get { return SqlTypeFactory.Int16; }
			}
		}
		[Serializable]
		private class SystemInt32EnumConverter : AbstractEnumConverter<int>
		{
			public override int Convert(object input)
			{
				return System.Convert.ToInt32(input);
			}

			public override SqlType SqlType
			{
				get { return SqlTypeFactory.Int32; }
			}
		}
		[Serializable]
		private class SystemInt64EnumConverter : AbstractEnumConverter<long>
		{
			public override long Convert(object input)
			{
				return System.Convert.ToInt64(input);
			}

			public override SqlType SqlType
			{
				get { return SqlTypeFactory.Int64; }
			}
		}
		[Serializable]
		private class SystemUInt16EnumConverter : AbstractEnumConverter<ushort>
		{
			public override ushort Convert(object input)
			{
				return System.Convert.ToUInt16(input);
			}

			public override SqlType SqlType
			{
				get { return SqlTypeFactory.UInt16; }
			}
		}
		[Serializable]
		private class SystemUInt32EnumConverter : AbstractEnumConverter<uint>
		{
			public override uint Convert(object input)
			{
				return System.Convert.ToUInt32(input);
			}

			public override SqlType SqlType
			{
				get { return SqlTypeFactory.UInt32; }
			}
		}
		[Serializable]
		private class SystemUInt64EnumConverter : AbstractEnumConverter<ulong>
		{
			public override ulong Convert(object input)
			{
				return System.Convert.ToUInt64(input);
			}

			public override SqlType SqlType
			{
				get { return SqlTypeFactory.UInt64; }
			}
		}

		#endregion

		static PersistentEnumType()
		{
			converters = new Dictionary<System.Type, IEnumConverter>(8);
			converters.Add(typeof (int), new SystemInt32EnumConverter());
			converters.Add(typeof (short), new SystemInt16EnumConverter());
			converters.Add(typeof (long), new SystemInt64EnumConverter());
			converters.Add(typeof (byte), new SystemByteEnumConverter());
			converters.Add(typeof (sbyte), new SystemSByteEnumConverter());
			converters.Add(typeof (ushort), new SystemUInt16EnumConverter());
			converters.Add(typeof (uint), new SystemUInt32EnumConverter());
			converters.Add(typeof (ulong), new SystemUInt64EnumConverter());
		}
		private static readonly Dictionary<System.Type, IEnumConverter> converters;
		private readonly IEnumConverter converter;

		public PersistentEnumType(System.Type enumClass) : base(GetEnumCoverter(enumClass).SqlType,enumClass)
		{
			converter = GetEnumCoverter(enumClass);
		}

		public static IEnumConverter GetEnumCoverter(System.Type enumClass)
		{
			System.Type underlyingType = Enum.GetUnderlyingType(enumClass);
			IEnumConverter result;
			if (!converters.TryGetValue(underlyingType, out result))
			{
				throw new HibernateException("Unknown UnderlyingDbType for Enum; type:" + enumClass.FullName);
			}
			return result;
		}

		public override object Get(IDataReader rs, int index)
		{
			object code = rs[index];
			if (code == DBNull.Value || code == null)
			{
				return null;
			}
			return GetInstance(code);
		}

		/// <summary>
		/// Gets an instance of the Enum
		/// </summary>
		/// <param name="code">The underlying value of an item in the Enum.</param>
		/// <returns>
		/// An instance of the Enum set to the <c>code</c> value.
		/// </returns>
		public virtual object GetInstance(object code)
		{
			try
			{
				return converter.ToObject(this.ReturnedClass, code);
			}
			catch (ArgumentException ae)
			{
				throw new HibernateException("ArgumentException occurred inside Enum.ToObject()", ae);
			}
		}

		/// <summary>
		/// Gets the correct value for the Enum.
		/// </summary>
		/// <param name="code">The value to convert (an enum instance).</param>
		/// <returns>A boxed version of the code, converted to the correct type.</returns>
		/// <remarks>
		/// This handles situations where the DataProvider returns the value of the Enum
		/// from the db in the wrong underlying type.  It uses <see cref="Convert"/> to 
		/// convert it to the correct type.
		/// </remarks>
		public virtual object GetValue(object code)
		{
			return converter.ToEnumValue(code);
		}


		public override void Set(IDbCommand cmd, object value, int index)
		{
			IDataParameter par = (IDataParameter) cmd.Parameters[index];
			par.Value = value != null ? GetValue(value) : DBNull.Value;
		}

		public override object Get(IDataReader rs, string name)
		{
			return Get(rs, rs.GetOrdinal(name));
		}

		public override string Name
		{
			get { return ReturnedClass.FullName; }
		}

		public override string ToString(object value)
		{
			return (value == null) ? null : GetValue(value).ToString();
		}

		public override object FromStringValue(string xml)
		{
			return GetInstance(long.Parse(xml));
		}

		public override object Assemble(object cached, ISessionImplementor session, object owner)
		{
			return cached == null ? null : GetInstance(cached);
		}

		public override object Disassemble(object value, ISessionImplementor session, object owner)
		{
			return (value == null) ? null : GetValue(value);
		}

		public override string ObjectToSQLString(object value, Dialect.Dialect dialect)
		{
			return GetValue(value).ToString();
		}

		public override bool Equals(object obj)
		{
			if (!base.Equals(obj))
			{
				return false;
			}

			return ((PersistentEnumType)obj).ReturnedClass == ReturnedClass;
		}

		public override int GetHashCode()
		{
			return ReturnedClass.GetHashCode();
		}
	}

	[Serializable]
	public class EnumType<T> : PersistentEnumType
	{
		private readonly string typeName;

		public EnumType() : base(typeof (T))
		{
			System.Type type = GetType();
			typeName = type.FullName + ", " + type.Assembly.GetName().Name;
		}

		public override string Name
		{
			get { return typeName; }
		}
	}
}
