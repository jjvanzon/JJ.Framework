//using System;
//using System.Linq;
//using System.Reflection;
//using JJ.Framework.Common;
//using JJ.Framework.PlatformCompatibility;

//namespace JJ.Framework.Reflection
//{
//    public static class MethodBaseExtensions
//    {
//        public static bool IsProperty(this MethodBase method)
//        {
//            if (method == null) throw new ArgumentNullException(nameof(method));

//            bool isProperty = method.Name.StartsWith("get_") ||
//                              method.Name.StartsWith("set_");
//            return isProperty;
//        }

//        public static bool IsIndexer(this MethodBase method)
//        {
//            if (!method.IsSpecialName)
//            {
//                return false;
//            }

//            if (!method.Name.StartsWith("get_") &&
//                !method.Name.StartsWith("set_"))
//            {
//                return false;
//            }

//            string propertyName = method.Name.TrimStart("get_").TrimStart("set_");

//            Type type = method.DeclaringType;
//            var defaultMemberAttribute = (DefaultMemberAttribute)type.GetCustomAttributes(typeof(DefaultMemberAttribute), inherit: true).SingleOrDefault();
//            if (defaultMemberAttribute == null)
//            {
//                return false;
//            }

//            if (defaultMemberAttribute.MemberName == propertyName)
//            {
//                return true;
//            }

//            return false;
//        }

//        public static bool IsStatic(this MemberInfo member)
//        {
//            if (member == null) throw new ArgumentNullException(nameof(member));

//            MemberTypes_PlatformSafe memberType = member.MemberType_PlatformSafe();

//            switch (memberType)
//            {
//                case MemberTypes_PlatformSafe.Field:
//                    var field = (FieldInfo)member;
//                    return field.IsStatic;

//                case MemberTypes_PlatformSafe.Method:
//                    var method = (MethodInfo)member;
//                    return method.IsStatic;

//                case MemberTypes_PlatformSafe.Property:
//                    var property = (PropertyInfo)member;
//                    // TODO: Check if this will work for public members.
//                    MethodInfo getterOrSetter = property.GetGetMethod(nonPublic: true) ?? property.GetSetMethod(nonPublic: true);
//                    return getterOrSetter.IsStatic;

//                default:
//                    throw new Exception($"IsStatic cannot be obtained from member of type '{member.GetType()}'.");
//            }
//        }
//    }
//}
