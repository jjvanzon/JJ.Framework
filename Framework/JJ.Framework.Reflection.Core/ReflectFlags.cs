// ReSharper disable IdentifierTypo
namespace JJ.Framework.Reflection.Core;

[Flags]
public enum ReflectFlags
{
    throws = 1,
    nothrow = 2,
    matchcase = 4
}