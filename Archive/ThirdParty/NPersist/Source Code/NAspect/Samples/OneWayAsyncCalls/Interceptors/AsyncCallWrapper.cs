using System;
using System.Threading;
using Puzzle.NAspect.Framework;

namespace OneWayAsyncCalls.Interceptors
{	public class AsyncCallWrapper
	{
		private MethodInvocation call;
		public AsyncCallWrapper(MethodInvocation call)
		{
			this.call = call;
			
		}

		public void CallAsync()
		{
			Thread thread = new Thread(new ThreadStart(StartThread) );
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.Lowest;
			thread.Start() ;
		}

		private void StartThread()
		{
			call.Proceed();
		}
	}
}
