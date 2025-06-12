
namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    /// <inheritdoc cref="_complementparametertypes" />
    public static ICollection<Type> ComplementArgTypes(ICollection<Type?> argTypes, ICollection<object?> args)
    {
        if (argTypes.Count > args.Count) throw new Exception("More argTypes than args.");
        Type?[] argTypesArr = argTypes.ToArray();
        Resize(ref argTypesArr, args.Count); // Lenience for missing argTypes array elements.
        Type[] argTypesFromObjects = TypesFromObjects(args);
        Type[] resolvedArgTypes = argTypesArr.Zip(argTypesFromObjects, (x, y) => x ?? y).ToArray();
        return resolvedArgTypes;
    }

}