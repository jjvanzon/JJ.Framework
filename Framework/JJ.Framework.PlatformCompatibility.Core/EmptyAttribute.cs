// ReSharper disable UnusedParameter.Local

using System;

namespace JJ.Framework.PlatformCompatibility.Core;

public class EmptyAttribute : Attribute 
{
    public EmptyAttribute() { }
    
    public EmptyAttribute(params object[] args) { }
}

