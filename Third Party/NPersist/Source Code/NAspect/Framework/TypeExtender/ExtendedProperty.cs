using System;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

namespace Puzzle.NAspect.Framework
{
	public class ExtendedProperty : ExtendedMember
	{
        #region FieldName
        private string fieldName;
        /// <summary>
        /// Property FieldName (string)
        /// </summary>        
        public string FieldName
        {
            get
            {
                return this.fieldName;
            }
            set
            {
                this.fieldName = value;
            }
        }
        #endregion


        #region Type
        private Type type;
        /// <summary>
        /// Property Type (Type)
        /// </summary>
        public Type Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
        #endregion

        public override void Extend(Type baseType, TypeBuilder typeBuilder)
        {
            //build field
            FieldBuilder field = typeBuilder.DefineField(FieldName, Type, FieldAttributes.Private);

            //define property
            PropertyBuilder property = typeBuilder.DefineProperty(Name, PropertyAttributes.None, Type, null);

            //build setter
            MethodBuilder setter = typeBuilder.DefineMethod("set_" + Name, MethodAttributes.Public | MethodAttributes.Virtual, null, new Type[] { Type }); 
            ILGenerator setterILG = setter.GetILGenerator(); 
            setterILG.Emit(OpCodes.Ldarg_0); 
            setterILG.Emit(OpCodes.Ldarg_1);
            setterILG.Emit(OpCodes.Stfld, field); 
            setterILG.Emit(OpCodes.Ret);
            property.SetSetMethod(setter);


            //build getter
            MethodBuilder getter = typeBuilder.DefineMethod("get_" + Name, MethodAttributes.Public | MethodAttributes.Virtual, Type, Type.EmptyTypes); 
            ILGenerator getterILG = getter.GetILGenerator(); 
            getterILG.Emit(OpCodes.Ldarg_0); 
            getterILG.Emit(OpCodes.Ldfld, field); 
            getterILG.Emit(OpCodes.Ret); 
            property.SetGetMethod(getter);

        }
    }
}
