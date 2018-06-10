// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.Enumerations;

namespace Puzzle.NPersist.Framework.Mapping.Transformation
{
	/// <summary>
	/// Summary description for ModelToCodeTransformer.
	/// </summary>
	public class ModelToCodeTransformer
	{
		public ModelToCodeTransformer()
		{
		}

		#region ToAssemblyFile

		public void ToAssemblyFile(IDomainMap domainMap, string fileName)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			ToAssemblyFile(domainMap, provider, fileName);
		}

		public void ToAssemblyFile(IDomainMap domainMap, CodeDomProvider provider, string fileName)
		{
			CodeCompileUnit codeCompileUnit = ToCodeCompileUnit(domainMap);
			ToAssemblyFile(codeCompileUnit, provider, fileName) ;
		}

		public void ToAssemblyFile(CodeCompileUnit compileunit, string fileName)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			ToAssemblyFile(compileunit, provider, fileName);
		}

		public void ToAssemblyFile(CodeCompileUnit compileunit, CodeDomProvider provider, string fileName)
		{
#if NET2
            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("System.dll");
            cp.GenerateInMemory = false;
            cp.OutputAssembly = fileName;
            CompilerResults cr = provider.CompileAssemblyFromDom(cp, compileunit);
#else
            ICodeCompiler compiler = provider.CreateCompiler();
			CompilerParameters cp = new CompilerParameters();
			cp.ReferencedAssemblies.Add( "System.dll" );
			cp.GenerateInMemory = false;
			cp.OutputAssembly = fileName;
 			CompilerResults cr = compiler.CompileAssemblyFromDom(cp, compileunit);
#endif

        }

		#endregion

		#region ToAssembly

		public Assembly ToAssembly(IDomainMap domainMap)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			return ToAssembly(domainMap, provider);
		}

		public Assembly ToAssembly(IDomainMap domainMap, CodeDomProvider provider)
		{
			CodeCompileUnit codeCompileUnit = ToCodeCompileUnit(domainMap);
			return ToAssembly(codeCompileUnit, provider, domainMap) ;
		}

		public Assembly ToAssembly(CodeCompileUnit compileunit)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			return ToAssembly(compileunit, provider, null);
		}
		
		public Assembly ToAssembly(CodeCompileUnit compileunit, CodeDomProvider provider, IDomainMap domainMap)
		{
			CompilerResults cr = ToCompilerResults(compileunit, provider, domainMap);
			return cr.CompiledAssembly;
		}

		public CompilerResults ToCompilerResults(IDomainMap domainMap)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			return ToCompilerResults(domainMap, provider);
		}

		public CompilerResults ToCompilerResults(IDomainMap domainMap, CodeDomProvider provider)
		{
			CodeCompileUnit codeCompileUnit = ToCodeCompileUnit(domainMap);
			return ToCompilerResults(codeCompileUnit, provider, domainMap) ;
		}

		public CompilerResults ToCompilerResults(CodeCompileUnit compileunit)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			return ToCompilerResults(compileunit, provider, null);
		}

		public CompilerResults ToCompilerResults(CodeCompileUnit compileunit, CodeDomProvider provider, IDomainMap domainMap)
		{
#if NET2
            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("System.dll");
            cp.GenerateInMemory = true;

            string code = ToCode(compileunit, provider, domainMap);

            return provider.CompileAssemblyFromSource(cp, code);
#else
			ICodeCompiler compiler = provider.CreateCompiler();
			CompilerParameters cp = new CompilerParameters();
			cp.ReferencedAssemblies.Add( "System.dll" );
			cp.GenerateInMemory = true;
 
			string code = ToCode(compileunit, provider, domainMap);

			return compiler.CompileAssemblyFromSource(cp, code);
#endif
		}


		private string InsertCodeMap(string code, IClassMap classMap, ICodeMap codeMap)
		{
			string declaration = GetClassDeclaration(classMap, codeMap);
			int pos = code.IndexOf(declaration);
			if (pos > 0)
			{
				InsertCode(pos, codeMap, ref code);
			}
			return code;
		}

		private string GetDomainCodeMap(IDomainMap domainMap, ICodeMap codeMap)
		{
			if (codeMap.Code.Length > 0)
			{
				if (domainMap.RootNamespace.Length > 0)
				{
					string declaration = GetNamespaceDeclaration(domainMap, codeMap);
					string endDeclaration = GetNamespaceEndDeclaration(codeMap);
					return AddCode(declaration, endDeclaration, codeMap);
				}
			}
			return "";
		}

		private static void InsertCode(int pos, ICodeMap codeMap, ref string code)
		{
			//int pos2 = code.Substring(pos).IndexOf("{");
			int pos2 = code.Substring(pos).IndexOf("\r\n");
			if (pos2 > 0)
			{
				//int breakAt = pos + pos2 + 3;
				int breakAt = pos + pos2;
				string codeLeft = code.Substring(0, breakAt);
				string codeRight = code.Substring(breakAt);
				string codeMiddle = Environment.NewLine + Environment.NewLine + codeMap.Code;
				code = codeLeft + codeMiddle + codeRight;
			}
		}

		private static string AddCode(string declaration, string endDeclaration, ICodeMap codeMap) => declaration + Environment.NewLine + codeMap.Code + Environment.NewLine + endDeclaration + Environment.NewLine;

	    private string GetNamespaceDeclaration(IDomainMap domainMap, ICodeMap codeMap)
		{
			if (codeMap.CodeLanguage == CodeLanguage.CSharp)
				return "namespace " + domainMap.RootNamespace + " {";
			if (codeMap.CodeLanguage == CodeLanguage.VB)
				return "Namespace " + domainMap.RootNamespace;
			throw new IAmOpenSourcePleaseImplementMeException("");
		}

		private string GetNamespaceEndDeclaration(ICodeMap codeMap)
		{
			if (codeMap.CodeLanguage == CodeLanguage.CSharp)
				return "}" ;
			if (codeMap.CodeLanguage == CodeLanguage.VB)
				return "End Namespace";
			throw new IAmOpenSourcePleaseImplementMeException("");
		}

		private string GetClassDeclaration(IClassMap classMap, ICodeMap codeMap)
		{
			if (codeMap.CodeLanguage == CodeLanguage.CSharp)
				return "public class " + classMap.GetName();
			if (codeMap.CodeLanguage == CodeLanguage.VB)
				return "Public Class " + classMap.GetName();
			throw new IAmOpenSourcePleaseImplementMeException("");
		}

		#endregion

		#region ToFile


		public String ToCodeFile(CodeCompileUnit compileunit, CodeDomProvider provider, string fileName)
		{
#if NET2

            String sourceFile;
            if (provider.FileExtension[0] == '.')
                sourceFile = fileName + provider.FileExtension;
            else
                sourceFile = fileName + "." + provider.FileExtension;

            IndentedTextWriter tw = new IndentedTextWriter(
                new StreamWriter(sourceFile, false), "    ");

            provider.GenerateCodeFromCompileUnit(compileunit, tw,
                new CodeGeneratorOptions());

            tw.Close();

            return sourceFile;
#else
			ICodeGenerator gen = provider.CreateGenerator();

			String sourceFile;
			if (provider.FileExtension[0] == '.')
				sourceFile = fileName + provider.FileExtension;
			else 
				sourceFile = fileName + "." + provider.FileExtension;

			IndentedTextWriter tw = new IndentedTextWriter(
				new StreamWriter(sourceFile, false), "    ");
            
			gen.GenerateCodeFromCompileUnit(compileunit, tw, 
				new CodeGeneratorOptions());

			tw.Close();            

			return sourceFile;
#endif
		}


		public String ToCSharpCodeFile(IDomainMap domainMap, string fileName)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			CodeCompileUnit compileunit = ToCodeCompileUnit(domainMap);
			return ToCodeFile(compileunit, provider, fileName);
		}

		public String ToCSharpCodeFile(IClassMap classMap, string fileName)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			CodeCompileUnit compileunit = ToCodeCompileUnit(classMap);
			return ToCodeFile(compileunit, provider, fileName);
		}

		public String ToCSharpCodeFile(CodeCompileUnit compileunit, string fileName)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			return ToCodeFile(compileunit, provider, fileName);
		}

		
		public String ToVisualBasicCodeFile(IDomainMap domainMap, string fileName)
		{
			VBCodeProvider provider = new VBCodeProvider();
			CodeCompileUnit compileunit = ToCodeCompileUnit(domainMap);
			return ToCodeFile(compileunit, provider, fileName);
		}

		public String ToVisualBasicCodeFile(IClassMap classMap, string fileName)
		{
			VBCodeProvider provider = new VBCodeProvider();
			CodeCompileUnit compileunit = ToCodeCompileUnit(classMap);
			return ToCodeFile(compileunit, provider, fileName);
		}

		public String ToVisualBasicCodeFile(CodeCompileUnit compileunit, string fileName)
		{
			VBCodeProvider provider = new VBCodeProvider();
			return ToCodeFile(compileunit, provider, fileName);
		}


		#endregion

		#region ToCode


		public String ToCode(CodeCompileUnit compileunit, CodeDomProvider provider) => ToCode(compileunit, provider);

	    public String ToCode(CodeCompileUnit compileunit, CodeDomProvider provider, IDomainMap domainMap)
		{

			StringBuilder sb = new StringBuilder() ;
			StringWriter sw = new StringWriter(sb);
			IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");

			ICodeGenerator gen = provider.CreateGenerator(tw);

			gen.GenerateCodeFromCompileUnit(compileunit, tw, 
				new CodeGeneratorOptions());

			string code = sb.ToString();
 
			
			if (domainMap != null)
			{
				foreach (ICodeMap codeMap in domainMap.CodeMaps)
				{
					if (provider is CSharpCodeProvider && codeMap.CodeLanguage == CodeLanguage.CSharp)
					{
						code = GetDomainCodeMap(domainMap, codeMap) + code;							
					}
					else if (provider is VBCodeProvider && codeMap.CodeLanguage == CodeLanguage.VB)
					{
						code = GetDomainCodeMap(domainMap, codeMap)  + code;							
					}
					//						if (provider is DelphiCodeProvider && codeMap.CodeLanguage == CodeLanguage.Delphi)
					//						{
					//							code = GetDomainCodeMap(code, classMap, codeMap) + code;							
					//						}
				}

				foreach (IClassMap classMap in domainMap.ClassMaps)
				{
					foreach (ICodeMap codeMap in classMap.CodeMaps)
					{
						if (provider is CSharpCodeProvider && codeMap.CodeLanguage == CodeLanguage.CSharp)
						{
							code = InsertCodeMap(code, classMap, codeMap);							
						}
						else if (provider is VBCodeProvider && codeMap.CodeLanguage == CodeLanguage.VB)
						{
							code = InsertCodeMap(code, classMap, codeMap);							
						}
//						if (provider is DelphiCodeProvider && codeMap.CodeLanguage == CodeLanguage.Delphi)
//						{
//							code = InsertCodeMap(code, classMap, codeMap);							
//						}
					}
				}	
				
			}

			return code; 
		}

		public String ToCode(IDomainMap domainMap) => ToCSharpCode(domainMap);

	    public String ToCode(IClassMap classMap) => ToCSharpCode(classMap);

	    public String ToCode(IDomainMap domainMap, CodeDomProvider provider)
		{
			CodeCompileUnit compileunit = ToCodeCompileUnit(domainMap);
			return ToCode(compileunit, provider, domainMap);
		}

		public String ToCode(IClassMap classMap,  CodeDomProvider provider)
		{
			CodeCompileUnit compileunit = ToCodeCompileUnit(classMap);
			return ToCode(compileunit, provider, classMap.DomainMap);
		}

		public String ToCSharpCode(IDomainMap domainMap)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			CodeCompileUnit compileunit = ToCodeCompileUnit(domainMap);
			return ToCode(compileunit, provider, domainMap);
		}

		public String ToCSharpCode(IClassMap classMap)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			CodeCompileUnit compileunit = ToCodeCompileUnit(classMap);
			return ToCode(compileunit, provider, classMap.DomainMap);
		}

		public String ToCSharpCode(CodeCompileUnit compileunit)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			return ToCode(compileunit, provider);
		}

		
		public String ToVisualBasicCode(IDomainMap domainMap)
		{
			VBCodeProvider provider = new VBCodeProvider();
			CodeCompileUnit compileunit = ToCodeCompileUnit(domainMap);
			return ToCode(compileunit, provider, domainMap);
		}

		public String ToVisualBasicCode(IClassMap classMap)
		{
			VBCodeProvider provider = new VBCodeProvider();
			CodeCompileUnit compileunit = ToCodeCompileUnit(classMap);
			return ToCode(compileunit, provider, classMap.DomainMap);
		}

		public String ToVisualBasicCode(CodeCompileUnit compileunit)
		{
			VBCodeProvider provider = new VBCodeProvider();
			return ToCode(compileunit, provider);
		}


		#endregion

		#region ToCodeCompileUnit

		public CodeCompileUnit ToCodeCompileUnit(IDomainMap domainMap)
		{
			CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

			foreach (IClassMap classMap in domainMap.ClassMaps)
				codeCompileUnit.Namespaces.Add(ClassMapToCodeNamespace(classMap));

			return codeCompileUnit ;
		}

		public CodeCompileUnit ToCodeCompileUnit(IClassMap classMap)
		{
			CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

			codeCompileUnit.Namespaces.Add(ClassMapToCodeNamespace(classMap));
			return codeCompileUnit ;
		}


		
		private CodeNamespace ClassMapToCodeNamespace(IClassMap classMap)
		{
			CodeNamespace domainNamespace = new CodeNamespace(classMap.GetFullNamespace()) ;
			CodeTypeDeclaration classDecl = new CodeTypeDeclaration(classMap.GetName()) ;

			if (classMap.ClassType == ClassType.Default || classMap.ClassType == ClassType.Class)
			{
				classDecl.IsClass = true;

				IClassMap super = classMap.GetInheritedClassMap();

				if (super != null)
				{
					CodeTypeReference superDecl = new CodeTypeReference(super.GetFullName()) ;				
					classDecl.BaseTypes.Add(superDecl);
				}

				foreach (IPropertyMap propertyMap in classMap.PropertyMaps)
				{
					classDecl.Members.Add(PropertyMapToCodeMemberField(propertyMap));					
					classDecl.Members.Add(PropertyMapToCodeMemberProperty(propertyMap));					
				}

			}
			else if (classMap.ClassType == ClassType.Enum)
			{
				classDecl.IsEnum = true;
				
				foreach (IEnumValueMap enumValueMap in classMap.GetEnumValueMaps())
				{
					classDecl.Members.Add(EnumValueMapToCodeMemberField(enumValueMap));					
				}
			}

			domainNamespace.Types.Add(classDecl);

			return domainNamespace;
		}

		private CodeMemberField EnumValueMapToCodeMemberField(IEnumValueMap enumValueMap)
		{
			string fieldName = enumValueMap.Name ;
			CodeMemberField fieldMember = new CodeMemberField("System.Int32", fieldName) ;

			fieldMember.Attributes = MemberAttributes.Static ;

			return fieldMember;
		}

		private CodeMemberField PropertyMapToCodeMemberField(IPropertyMap propertyMap)
		{
			string fieldName = propertyMap.GetFieldName() ;
			CodeMemberField fieldMember = new CodeMemberField(propertyMap.DataType, fieldName) ;

			fieldMember.Attributes = MemberAttributes.Private ;

			return fieldMember;
		}

		private CodeMemberProperty PropertyMapToCodeMemberProperty(IPropertyMap propertyMap)
		{
			CodeMemberProperty propertyMember = new CodeMemberProperty() ;
			propertyMember.Name = propertyMap.Name ;

			CodeTypeReference typeReference = new CodeTypeReference(propertyMap.DataType);
			propertyMember.Type  = typeReference;
			
			propertyMember.Attributes = MemberAttributes.Public;
			string fieldName = propertyMap.GetFieldName() ;

			CodeThisReferenceExpression thisReferenceExpression = new CodeThisReferenceExpression();
			CodeFieldReferenceExpression fieldReferenceExpression = new CodeFieldReferenceExpression(thisReferenceExpression, fieldName) ;

			propertyMember.HasGet = true;
			CodeMethodReturnStatement getMethodReturnStatement = new CodeMethodReturnStatement(fieldReferenceExpression);
			propertyMember.GetStatements.Add(getMethodReturnStatement);

			if (!propertyMap.IsReadOnly)
			{
				propertyMember.HasSet = true;
				CodeVariableReferenceExpression valueReferenceExpression = new CodeVariableReferenceExpression("value");
				CodeAssignStatement setMethodAssignStatement = new CodeAssignStatement(fieldReferenceExpression, valueReferenceExpression);
				propertyMember.SetStatements.Add(setMethodAssignStatement);				
			}

			return propertyMember;
		}

		#endregion

	}
}
