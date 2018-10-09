using System;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace ConsoleApplication1
{
	public class TraceWriter : IAroundInterceptor
	{
public object HandleCall(MethodInvocation call)
{
	Console.WriteLine("Innan anrop : " + call.ValueSignature);
	try
	{
		//anropa nästa steg i kedjan
		object res = call.Proceed();

		Console.WriteLine("Efter anrop : " + call.ValueSignature);

		Console.WriteLine("Returnerar resultat : {0}", res);
		return res;
	}
	catch
	{
		Console.WriteLine ("Ett fel inträffade vid anrop av : " + call.ValueSignature);
		throw;
	}
}
	}
}