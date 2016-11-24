using System;
using System.Diagnostics;
using Puzzle.NAspect.Framework;

namespace CacheSample
{
    internal class Program
    {
        private static void Main()
        {
            IEngine e = ApplicationContext.Configure();

            //create an instance of "SomeAopTarget" through the aop container

            SomeAopTarget myObj = e.CreateProxy<SomeAopTarget>();

            myObj.PerfromSomeReallyHeavyCalculation(1);
            myObj.NonAopVersion(1);

            //for (int i = 0; i < 4; i++)
            //{
            //    DateTime start = DateTime.Now;
            //    Console.WriteLine("starting to do some heavy calculation");
            //    double res = myObj.PerfromSomeReallyHeavyCalculation(50); //<-- just a normal call to our method
            //    Console.WriteLine(res);
            //    Console.WriteLine("heavy calculation done");
            //    DateTime end = DateTime.Now;
            //    Console.WriteLine("time to complete work: {0}", end.Subtract(start));
            //}

            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 1000000; i++)
            {
                double res = myObj.PerfromSomeReallyHeavyCalculation(1);
            }
            timer.Stop();
            Console.WriteLine("Time elapsed on non aop version {0}", timer.ElapsedMilliseconds);

            timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 1000000; i++)
            {
                double res = myObj.NonAopVersion(1);
            }
            timer.Stop();
            Console.WriteLine("Time elapsed on non aop version {0}", timer.ElapsedMilliseconds);

            Console.WriteLine("press any key to continue");
            Console.ReadLine();
        }
    }
}