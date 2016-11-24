using System;
using System.Collections;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Interception;

namespace CacheSample
{
    [MayBreakFlow]
    [Throws(typeof(Exception))]
    public class CacheInterceptor : IAroundInterceptor
    {

        public object HandleCall(MethodInvocation call)
        {
            return call.Proceed();


            //ICacheHolder cacheHolder = call.Target as ICacheHolder;
            //if (cacheHolder != null)
            //{
            //    Hashtable cache = cacheHolder.Cache;
            //    string key = string.Format("PerfromSomeReallyHeavyCalculationWoAop ({0})", 1.1);
            //    //string key = call.ValueSignature;
            //    if (!cache.ContainsKey(key))
            //    {
            //        cache[key] = call.Proceed();
            //        //   Console.WriteLine("adding result to cache");
            //    }
            //    else
            //    {
            //        //    Console.WriteLine("result fetched from cache");
            //    }

            //    return cache[key];
            //}
            //else
            //{
            //    return call.Proceed();
            //}
        }
    }
}