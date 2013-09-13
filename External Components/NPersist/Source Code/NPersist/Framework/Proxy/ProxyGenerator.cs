using System;
namespace MatsSoft.NPersist.Framework.Proxy
{
	public class ProxyGenerator
	{
		private ProxyCompiler compiler = new ProxyCompiler();

		public Type GetProxyType(Type baseType)
		{
			string code = ProxyGeneratorHelper.GetClassCode(baseType);
			return ProxyCompiler.Compile(code);
		}
	}
}
