using System;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;
using System.Threading;
using System.Collections;

namespace Puzzle.NAspect.Framework
{
	public class TypeExtender : ITypeExtender
	{


        #region Property Members
        private ArrayList members = new ArrayList();
        public IList Members => members;

	    #endregion

		private bool IsDirty = false;
        public Type Extend(Type baseType)
        {
            string typeName = baseType.Name + "ExtenderProxy";
            string moduleName = "Puzzle.NAspect.Runtime.ExtenderProxy";

            AssemblyBuilder assemblyBuilder = GetAssemblyBuilder();            
            TypeBuilder typeBuilder = GetTypeBuilder(assemblyBuilder, moduleName, typeName, baseType);
            BuildConstructors(baseType, typeBuilder);

            foreach (ExtendedMember member in members)
            {
                member.Extend(baseType, typeBuilder);
            }

            Type proxyType = typeBuilder.CreateType();

            if (members.Count > 0)
                this.IsDirty = true;
           
			if (IsDirty)
				return proxyType;
			else
				return baseType;            
        }

        private AssemblyBuilder GetAssemblyBuilder()
        {
            AppDomain domain = Thread.GetDomain();
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = Guid.NewGuid().ToString();
            assemblyName.Version = new Version(1, 0, 0, 0);
            AssemblyBuilder assemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            return assemblyBuilder;
        }



        private static TypeBuilder GetTypeBuilder(AssemblyBuilder assemblyBuilder, string moduleName, string typeName,Type baseType)
        {
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(moduleName);
            TypeAttributes typeAttributes = TypeAttributes.Class | TypeAttributes.Public;
            return moduleBuilder.DefineType(typeName, typeAttributes, baseType);
        }


        private void BuildConstructors(Type baseType, TypeBuilder typeBuilder)
        {
            ConstructorInfo[] constructors = baseType.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                BuildConstructor(constructor, typeBuilder);
            }
            if (constructors.Length == 0)
            {
                constructors = typeof(object).GetConstructors();
                foreach (ConstructorInfo constructor in constructors)
                {
                    BuildConstructor(constructor, typeBuilder);
                }
            }
        }

        private void BuildConstructor(ConstructorInfo constructor, TypeBuilder typeBuilder)
        {            
            ParameterInfo[] parameterInfos = constructor.GetParameters();
            Type[] parameterTypes = new Type[parameterInfos.Length ];

            //copy super ctor param types
            for (int i = 0; i < parameterInfos.Length; i++)
            {
                parameterTypes[i] = parameterInfos[i].ParameterType;
            }

            ConstructorBuilder proxyConstructor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);
            ILGenerator il = proxyConstructor.GetILGenerator();
            for (int i = 0; i < parameterTypes.Length + 1 /* also load "this" */; i++)
            {
                il.Emit(OpCodes.Ldarg, i);
            }
            il.Emit(OpCodes.Callvirt, constructor);

            il.Emit(OpCodes.Ret);
        }
    }
}
