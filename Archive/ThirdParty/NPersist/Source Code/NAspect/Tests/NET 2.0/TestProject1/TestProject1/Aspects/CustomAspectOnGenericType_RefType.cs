using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;
using KumoUnitTests;

namespace TestProject1.Aspects
{
    public class CustomAspectOnGenericType_RefType : GenericAspectBase
    {
        public override bool IsMatch(Type type)
        {            
            if (type.GetGenericTypeDefinition () == typeof(SomeGenericClass<>))
            {
                Type genericType = type.GetGenericArguments () [0];
                if (genericType.IsClass)
                    return true;
            }

            return false;
        }
    }
}
