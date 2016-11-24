using System;
using System.Collections.Generic;
using System.Text;

namespace AopDraw.Attributes
{
    [AttributeUsage(AttributeTargets.Class,Inherited=false)]
    public class MovableAttribute : Attribute
    {
    }
}
