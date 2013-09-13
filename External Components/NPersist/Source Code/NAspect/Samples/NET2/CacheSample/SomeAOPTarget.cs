using System.Collections;
using System.Threading;

namespace CacheSample
{
    //some class that will be the target of our caching interceptor
    public class SomeAopTarget
    {
        public SomeAopTarget()
        {
        }

        //some function that takes ages to complete
        public virtual double PerfromSomeReallyHeavyCalculation(int loopCount)
        {
            //string result = "";
            //for (int i = 0; i < loopCount; i++)
            //{
            //    result += i.ToString();
            //    //simulate some work beeing done
            //    Thread.Sleep(100);
            //}
            
            return 12345.44;
        }

        Hashtable cache = new Hashtable();
        public virtual double NonAopVersion(int loopCount)
        {
            return 12345.44;
            //string key = string.Format("PerfromSomeReallyHeavyCalculationWoAop ({0})", loopCount);
            //if (cache.ContainsKey(key))
            //{
            //    return (double)cache[key];
            //}
            //else
            //{
            //    string result = "";
            //    for (int i = 0; i < loopCount; i++)
            //    {
            //        result += i.ToString();
            //        //simulate some work beeing done
            //        Thread.Sleep(100);
            //    }
            //    double res = 12345.44;
            //    cache[key] = res;
            //    return res;
            //}
        }
        
    }

    public class MyProxy : SomeAopTarget
    {
        public override double NonAopVersion(int loopCount)
        {            
            return base.NonAopVersion(loopCount+1);
        }        
    }
}