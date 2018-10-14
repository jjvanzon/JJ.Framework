using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;
using System.Collections.ObjectModel;
using KumoUnitTests;

namespace TestProject1.Aspects
{
    public class CustomAspectOnGenericType : GenericAspectBase
    {
        public override bool IsMatch(Type type)
        {
            return (type == typeof (SomeGenericClass<string>));
        }
    }
}
