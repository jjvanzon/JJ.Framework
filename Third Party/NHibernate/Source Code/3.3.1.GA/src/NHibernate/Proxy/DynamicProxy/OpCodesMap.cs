using System.Collections.Generic;
using System.Reflection.Emit;

namespace NHibernate.Proxy.DynamicProxy
{
	public static class OpCodesMap
	{
		private static readonly Dictionary<System.Type, OpCode> LdindMap = new Dictionary<System.Type, OpCode>
		                                                                   {
		                                                                   	{typeof (bool), OpCodes.Ldind_I1},
		                                                                   	{typeof (sbyte), OpCodes.Ldind_I1},
		                                                                   	{typeof (byte), OpCodes.Ldind_U1},
		                                                                   	{typeof (char), OpCodes.Ldind_I2},
		                                                                   	{typeof (short), OpCodes.Ldind_I2},
		                                                                   	{typeof (int), OpCodes.Ldind_I4},
		                                                                   	{typeof (long), OpCodes.Ldind_I8},
		                                                                   	{typeof (ushort), OpCodes.Ldind_U2},
		                                                                   	{typeof (uint), OpCodes.Ldind_U4},
		                                                                   	{typeof (ulong), OpCodes.Ldind_I8},
		                                                                   	{typeof (float), OpCodes.Ldind_R4},
		                                                                   	{typeof (double), OpCodes.Ldind_R8},
		                                                                   };
		private static readonly Dictionary<System.Type, OpCode> StindMap = new Dictionary<System.Type, OpCode>
		                                                                   {
		                                                                   	{typeof (bool), OpCodes.Stind_I1},
		                                                                   	{typeof (sbyte), OpCodes.Stind_I1},
		                                                                   	{typeof (byte), OpCodes.Stind_I1},
		                                                                   	{typeof (char), OpCodes.Stind_I2},
		                                                                   	{typeof (short), OpCodes.Stind_I2},
		                                                                   	{typeof (int), OpCodes.Stind_I4},
		                                                                   	{typeof (long), OpCodes.Stind_I8},
		                                                                   	{typeof (ushort), OpCodes.Stind_I2},
		                                                                   	{typeof (uint), OpCodes.Stind_I4},
		                                                                   	{typeof (ulong), OpCodes.Stind_I8},
		                                                                   	{typeof (float), OpCodes.Stind_R4},
		                                                                   	{typeof (double), OpCodes.Stind_R8},
		                                                                   };
		
		public static bool TryGetLdindOpCode(System.Type valueType, out OpCode opCode)
		{
			return LdindMap.TryGetValue(valueType, out opCode);
		}

		public static bool TryGetStindOpCode(System.Type valueType, out OpCode opCode)
		{
			return StindMap.TryGetValue(valueType, out opCode);
		}
	}
}