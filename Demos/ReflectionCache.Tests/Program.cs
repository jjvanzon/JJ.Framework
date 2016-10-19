using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace JJ.Demos.ReflectionCache.Tests
{
    public class Program
    {
        // Console app, because Microsoft Visual C# 2010 Express does not support unit test projects.

        public static void Main(string[] args)
        {
            HisTests.Execute();
            MyTests.Execute();

            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
    }
}
