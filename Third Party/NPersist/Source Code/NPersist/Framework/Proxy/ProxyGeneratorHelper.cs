// TODO: NotImplemented statement: ICSharpCode.SharpRefactory.Parser.AST.VB.OptionStrictDeclaration
// TODO: NotImplemented statement: ICSharpCode.SharpRefactory.Parser.AST.VB.OptionExplicitDeclaration
using System;
using System.Reflection;
namespace MatsSoft.NPersist.Framework.Proxy
{
	public class ProxyGeneratorHelper
	{

		public static string GetProxyName(Type baseType)
		{
			return baseType.Name + "Proxy";
		}

		public static string GetClassCode(Type baseType)
		{
			string code = GetTemplateText("ClassTemplate.txt");
			code = code.Replace("%%basetype%%", baseType.FullName);
			code = code.Replace("%%name%%", GetProxyName(baseType));
			code = code.Replace("%%constructors%%", GetConstructorsCode(baseType));
			code = code.Replace("%%properties%%", GetPropertiesCode(baseType));
			return code;
		}

		public static string GetConstructorsCode(Type baseType)
		{
			string constructorCode = "";
			ConstructorInfo[] constructors = baseType.GetConstructors();
			foreach (ConstructorInfo constructor in constructors) {
				constructorCode += GetConstructorCode(baseType, constructor);
			}
			return constructorCode;
		}

		public static string GetConstructorCode(Type baseType, ConstructorInfo constructor)
		{
			string paramString = "";
			string callparamString = "";
			ParameterInfo[] parameters = constructor.GetParameters();
			foreach (ParameterInfo param in parameters) {
				paramString += string.Format("{0} {1}", param.ParameterType.FullName, param.Name); // do not localize
				callparamString += param.Name;
				if (!(param == parameters[parameters.Length - 1])) {
					paramString += ",";
					callparamString += ",";
				}
			}
			string code = GetTemplateText("ConstructorTemplate.txt");
			code = code.Replace("%%params%%", paramString);
			code = code.Replace("%%callparams%%", callparamString);
			code = code.Replace("%%type%%", GetProxyName(baseType));
			return code;
		}

		public static string GetGetHelper(Type baseType)
		{
			string getHelperCode = "";
			PropertyInfo[] properties = baseType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo property in properties) {
				MethodInfo getMethod = property.GetGetMethod();
				if (!((getMethod.IsVirtual == false || getMethod.IsFinal == true || getMethod.IsStatic == true))) {
					getHelperCode += string.Format("case \"{0}\":return base.{0};{1}", property.Name, "\n"); // do not localize
				}
			}
			getHelperCode = "switch (propertyName) {" + getHelperCode + "}"; // do not localize
			return getHelperCode;
		}

		public static string GetSetHelper(Type baseType)
		{
			string getHelperCode = "";
			PropertyInfo[] properties = baseType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo property in properties) {
				MethodInfo getMethod = property.GetGetMethod();
				if (!((getMethod.IsVirtual == false || getMethod.IsFinal == true || getMethod.IsStatic == true))) {
					getHelperCode += string.Format("case \"{0}\":base.{0} = ({1})value;return;{2}", property.Name, property.PropertyType.FullName, "\n"); // do not localize
				}
			}
			getHelperCode = "switch (propertyName) {" + getHelperCode + "}"; // do not localize
			return getHelperCode;
		}

		public static string GetPropertiesCode(Type baseType)
		{
			string propertyCode = "";
			PropertyInfo[] properties = baseType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo property in properties) {
				MethodInfo getMethod = property.GetGetMethod();
				if (!((getMethod.IsVirtual == false || getMethod.IsFinal == true || getMethod.IsStatic == true))) {
					propertyCode += GetPropertyCode(baseType, property);
				}
			}
			return propertyCode;
		}

		public static string GetPropertyCode(Type baseType, PropertyInfo property)
		{
			string propertyCode = GetTemplateText("PropertyTemplate.txt");
			string getCode = "";
			string setCode = "";
			propertyCode = propertyCode.Replace("%%type%%", property.PropertyType.FullName);
			propertyCode = propertyCode.Replace("%%name%%", property.Name);
			if ((property.CanRead)) {
				getCode = GetTemplateText("GetPropertyTemplate.txt");
				getCode = getCode.Replace("%%type%%", property.PropertyType.FullName);
				getCode = getCode.Replace("%%name%%", property.Name);
			}
			if ((property.CanWrite)) {
				setCode = GetTemplateText("SetPropertyTemplate.txt");
				setCode = setCode.Replace("%%type%%", property.PropertyType.FullName);
				setCode = setCode.Replace("%%name%%", property.Name);
			}
			propertyCode = propertyCode.Replace("%%get%%", getCode);
			propertyCode = propertyCode.Replace("%%set%%", setCode);
			return propertyCode;
		}

		public static string GetTemplateText(string templateName)
		{
			System.IO.StreamReader textStream = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Proxy.Templates." + templateName));
			string text = textStream.ReadToEnd();
			return text;
		}
	}
}
