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
using System.Collections;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Mapping.Serialization
{
	public class DefaultMapSerializer : MapSerializerBase
	{
		public DefaultMapSerializer() : base()
		{
		}

		public DefaultMapSerializer(bool bareBones) : base(bareBones)
		{
		}

		public override IDomainMap Deserialize(string xml)
		{
			XmlDocument xmlDoc = new XmlDocument();
			XmlNode xmlDom;
			xmlDoc.LoadXml(xml);
			xmlDom = xmlDoc.SelectSingleNode("domain");
			return DeserializeDomainMap(xmlDom);
		}

		public override string Serialize(IDomainMap domainMap) => SerializeDomainMap(domainMap);

	    protected virtual string SerializeDomainMap(IDomainMap domainMap)
		{
			StringBuilder xml = new StringBuilder();
			xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n"); // do not localize
			xml.Append("<domain name=\"" + domainMap.Name + "\""); // do not localize
			if (domainMap.AssemblyName.Length > 0)
			{
				xml.Append(" assembly=\"" + domainMap.AssemblyName + "\""); // do not localize
			}

			if (!(domainMap.CodeLanguage == CodeLanguage.CSharp))
			{
				xml.Append(" language=\"" + domainMap.CodeLanguage.ToString() + "\""); // do not localize
			}

			if (domainMap.RootNamespace.Length > 0)
			{
				xml.Append(" root=\"" + domainMap.RootNamespace + "\""); // do not localize
			}
			if (domainMap.Source.Length > 0)
			{
				xml.Append(" source=\"" + domainMap.Source + "\""); // do not localize
			}
			if (domainMap.DocSource.Length > 0)
			{
				xml.Append(" doc-source=\"" + domainMap.DocSource + "\""); // do not localize
			}
			if (domainMap.IsReadOnly)
			{
				xml.Append(" read-only=\"true\"");
			}
			if (domainMap.FieldPrefix.Length > 0)
			{
				if (!(domainMap.FieldPrefix == "m_"))
				{
					xml.Append(" field-prefix=\"" + domainMap.FieldPrefix + "\""); // do not localize
				}
			}
			else
			{
				xml.Append(" field-prefix=\"\"");				
			}
			if (!(domainMap.FieldNameStrategy == FieldNameStrategyType.None))
			{
				xml.Append(" field-strategy=\"" + domainMap.FieldNameStrategy.ToString() + "\""); // do not localize
			}
			if (!(domainMap.MergeBehavior == MergeBehaviorType.DefaultBehavior))
			{
				xml.Append(" merge=\"" + domainMap.MergeBehavior.ToString() + "\""); // do not localize
			}
			if (!(domainMap.RefreshBehavior == RefreshBehaviorType.DefaultBehavior))
			{
				xml.Append(" refresh=\"" + domainMap.RefreshBehavior.ToString() + "\""); // do not localize
			}
			if (!(domainMap.ListCountLoadBehavior == LoadBehavior.Default))
			{
				xml.Append(" count=\"" + domainMap.ListCountLoadBehavior.ToString() + "\""); // do not localize
			}
			if (!(domainMap.UpdateOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior))
			{
				xml.Append(" optimistic-update=\"" + domainMap.UpdateOptimisticConcurrencyBehavior.ToString() + "\""); // do not localize
			}
			if (!(domainMap.DeleteOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior))
			{
				xml.Append(" optimistic-delete=\"" + domainMap.DeleteOptimisticConcurrencyBehavior.ToString() + "\""); // do not localize
			}
			if (!(domainMap.ValidationMode == ValidationMode.Default))
			{
				xml.Append(" validation=\"" + domainMap.ValidationMode.ToString() + "\""); // do not localize
			}
			if (!(domainMap.TimeToLive < 0))
			{
				xml.Append(" ttl=\"" + domainMap.TimeToLive.ToString() + "\""); // do not localize
			}
			if (!(domainMap.TimeToLiveBehavior == TimeToLiveBehavior.Default))
			{
				xml.Append(" ttl-behavior=\"" + domainMap.TimeToLiveBehavior.ToString() + "\""); // do not localize
			}
			if (!(domainMap.LoadBehavior == LoadBehavior.Default))
			{
				xml.Append(" load=\"" + domainMap.LoadBehavior.ToString() + "\""); // do not localize
			}
			if (!(BareBones))
			{
				if (domainMap.InheritsTransientClass.Length > 0)
				{
					xml.Append(" base=\"" + domainMap.InheritsTransientClass + "\""); // do not localize
				}
				if (domainMap.ImplementsInterfaces.Count > 0)
				{
					xml.Append(" implements=\"");
					foreach (string str in domainMap.ImplementsInterfaces)
					{
						xml.Append(str + ", "); // do not localize
					}
					xml.Length -= 2;
					xml.Append("\"");
				}
				if (domainMap.ImportsNamespaces.Count > 0)
				{
					xml.Append(" imports=\""); // do not localize
					foreach (string str in domainMap.ImportsNamespaces)
					{
						xml.Append(str + ", ");
					}
					xml.Length -= 2;
					xml.Append("\"");
				}
				if (domainMap.VerifyCSharpReservedWords || domainMap.VerifyVbReservedWords || domainMap.VerifyDelphiReservedWords)
				{
					xml.Append(" target-languages=\""); // do not localize
					if (domainMap.VerifyCSharpReservedWords)
					{
						xml.Append("cs, "); // do not localize
					}
					if (domainMap.VerifyVbReservedWords)
					{
						xml.Append("vb, "); // do not localize
					}
					if (domainMap.VerifyDelphiReservedWords)
					{
						xml.Append("delphi, "); // do not localize
					}
					xml.Length -= 2;
					xml.Append("\"");
				}
				if (!(domainMap.MapSerializer == MapSerializer.DefaultSerializer))
				{
					if (domainMap.MapSerializer == MapSerializer.DotNetSerializer)
					{
						xml.Append(" serializer=\"dotnet\""); // do not localize
					}
					else if (domainMap.MapSerializer == MapSerializer.CustomSerializer)
					{
						xml.Append(" serializer=\"custom\""); // do not localize
					}
				}
			}
            if (!(domainMap.DeadlockStrategy == DeadlockStrategy.Default))
            {
                xml.Append(" deadlock-strategy=\"" + domainMap.DeadlockStrategy.ToString() + "\""); // do not localize
            }

			xml.Append(">\r\n");
			xml.Append(SerializeMetaData(domainMap.MetaData, "  "));
			foreach (IClassMap classMap in domainMap.ClassMaps)
			{
				xml.Append(SerializeClassMap(classMap));
			}
			foreach (ISourceMap sourceMap in domainMap.SourceMaps)
			{
				xml.Append(SerializeSourceMap(sourceMap));
			}
			foreach (ICodeMap codeMap in domainMap.CodeMaps)
			{
				if (codeMap.Code.Length > 0)
				{
					xml.Append(SerializeCodeMap(codeMap));
				}
			}
			xml.Append("</domain>\r\n");
			return xml.ToString();
		}

		protected virtual string SerializeClassMap(IClassMap classMap)
		{
			StringBuilder xml = new StringBuilder();
			xml.Append("  <class name=\"" + classMap.Name + "\""); // do not localize
			if (!(classMap.ClassType == ClassType.Default))
			{
				xml.Append(" type=\"" + classMap.ClassType.ToString() + "\""); // do not localize
			}
			if (classMap.AssemblyName.Length > 0)
			{
				xml.Append(" assembly=\"" + classMap.AssemblyName + "\""); // do not localize
			}
			if (classMap.SourceClass.Length > 0)
			{
				xml.Append(" source-class=\"" + classMap.SourceClass + "\""); // do not localize
			}
			if (classMap.LoadSpan.Length > 0)
			{
				xml.Append(" load-span=\"" + classMap.LoadSpan + "\""); // do not localize
			}
			if (classMap.Source.Length > 0)
			{
				xml.Append(" source=\"" + classMap.Source + "\""); // do not localize
			}
			if (classMap.DocSource.Length > 0)
			{
				xml.Append(" doc-source=\"" + classMap.DocSource + "\""); // do not localize
			}
			if (classMap.Table.Length > 0)
			{
				xml.Append(" table=\"" + classMap.Table + "\""); // do not localize
			}
			if (classMap.DocElement.Length > 0)
			{
				xml.Append(" doc-element=\"" + classMap.DocElement + "\""); // do not localize
			}
			if (classMap.DocRoot.Length > 0)
			{
				xml.Append(" doc-root=\"" + classMap.DocRoot + "\""); // do not localize
			}
			if (classMap.TypeColumn.Length > 0)
			{
				xml.Append(" type-column=\"" + classMap.TypeColumn + "\""); // do not localize
			}
			if (classMap.TypeValue.Length > 0)
			{
				xml.Append(" type-value=\"" + classMap.TypeValue + "\""); // do not localize
			}
			if (classMap.DocClassMapMode == DocClassMapMode.PerDomain)
			{
				xml.Append(" doc-mode=\"PerDomain\"");
			}
			else if (classMap.DocClassMapMode == DocClassMapMode.PerClass)
			{
				xml.Append(" doc-mode=\"PerClass\"");
			}
			else if (classMap.DocClassMapMode == DocClassMapMode.PerObject)
			{
				xml.Append(" doc-mode=\"PerObject\"");
			}
			else if (classMap.DocClassMapMode == DocClassMapMode.None)
			{
				xml.Append(" doc-mode=\"None\"");
			}
			if (classMap.DocParentProperty.Length > 0)
			{
				xml.Append(" doc-parent=\"" + classMap.DocParentProperty + "\""); // do not localize
			}
			if (classMap.IsReadOnly)
			{
				xml.Append(" read-only=\"true\"");
			}
			if (classMap.IsAbstract)
			{
				xml.Append(" abstract=\"true\"");
			}
			if (classMap.InheritsClass.Length > 0)
			{
				xml.Append(" inherits=\"" + classMap.InheritsClass + "\""); // do not localize
			}
			if (classMap.InheritanceType == InheritanceType.SingleTableInheritance)
			{
				xml.Append(" inheritance=\"SingleTableInheritance\"");
			}
			else if (classMap.InheritanceType == InheritanceType.ClassTableInheritance)
			{
				xml.Append(" inheritance=\"ClassTableInheritance\"");
			}
			else if (classMap.InheritanceType == InheritanceType.ConcreteTableInheritance)
			{
				xml.Append(" inheritance=\"ConcreteTableInheritance\"");
			}
			if (classMap.IdentitySeparator.Length > 0)
			{
				xml.Append(" id-separator=\"" + classMap.IdentitySeparator + "\""); // do not localize
			}
			if (classMap.KeySeparator.Length > 0)
			{
				xml.Append(" key-separator=\"" + classMap.KeySeparator + "\""); // do not localize
			}

			if (!(classMap.ValidationMode == ValidationMode.Default))
			{
				xml.Append(" validation=\"" + classMap.ValidationMode.ToString() + "\""); // do not localize
			}
			if (classMap.ValidateMethod.Length > 0)
			{
				xml.Append(" validate=\"" + classMap.ValidateMethod + "\""); // do not localize
			}


			if (!(classMap.MergeBehavior == MergeBehaviorType.DefaultBehavior))
			{
				xml.Append(" merge=\"" + classMap.MergeBehavior.ToString() + "\""); // do not localize
			}

			if (!(classMap.RefreshBehavior == RefreshBehaviorType.DefaultBehavior))
			{
				xml.Append(" refresh=\"" + classMap.RefreshBehavior.ToString() + "\""); // do not localize
			}

			if (!(classMap.ListCountLoadBehavior == LoadBehavior.Default))
			{
				xml.Append(" count=\"" + classMap.ListCountLoadBehavior.ToString() + "\""); // do not localize
			}

			if (classMap.DeleteOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.Disabled)
			{
				xml.Append(" optimistic-delete=\"Disabled\"");
			}
			else if (classMap.DeleteOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.IncludeWhenDirty)
			{
				xml.Append(" optimistic-delete=\"IncludeWhenDirty\"");
			}
			else if (classMap.DeleteOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.IncludeWhenLoaded)
			{
				xml.Append(" optimistic-delete=\"IncludeWhenLoaded\"");
			}
			if (classMap.UpdateOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.Disabled)
			{
				xml.Append(" optimistic-update=\"Disabled\"");
			}
			else if (classMap.UpdateOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.IncludeWhenDirty)
			{
				xml.Append(" optimistic-update=\"IncludeWhenDirty\"");
			}
			else if (classMap.UpdateOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.IncludeWhenLoaded)
			{
				xml.Append(" optimistic-update=\"IncludeWhenLoaded\"");
			}

			if (!(classMap.TimeToLive < 0))
			{
				xml.Append(" ttl=\"" + classMap.TimeToLive.ToString() + "\""); // do not localize
			}
			if (!(classMap.TimeToLiveBehavior == TimeToLiveBehavior.Default))
			{
				xml.Append(" ttl-behavior=\"" + classMap.TimeToLiveBehavior.ToString() + "\""); // do not localize
			}
			if (!(classMap.LoadBehavior == LoadBehavior.Default))
			{
				xml.Append(" load=\"" + classMap.LoadBehavior.ToString() + "\""); // do not localize
			}
			if (classMap.CommitRegions.Length > 0)
			{
				xml.Append(" commit-regions=\"" + classMap.CommitRegions + "\""); // do not localize
			}

			if (!(BareBones))
			{
				if (classMap.InheritsTransientClass.Length > 0)
				{
					xml.Append(" base=\"" + classMap.InheritsTransientClass + "\""); // do not localize
				}
				if (classMap.ImplementsInterfaces.Count > 0)
				{
					xml.Append(" implements=\"");
					foreach (string str in classMap.ImplementsInterfaces)
					{
						xml.Append(str + ", "); // do not localize
					}
					xml.Length -= 2;
					xml.Append("\"");
				}
				if (classMap.ImportsNamespaces.Count > 0)
				{
					xml.Append(" imports=\""); // do not localize
					foreach (string str in classMap.ImportsNamespaces)
					{
						xml.Append(str + ", ");
					}
					xml.Length -= 2;
					xml.Append("\"");
				}
			}
			xml.Append(">\r\n"); // do not localize
			xml.Append(SerializeMetaData(classMap.MetaData, "    "));
			foreach (IPropertyMap propertyMap in classMap.PropertyMaps)
			{
				xml.Append(SerializePropertyMap(propertyMap));
			}
			foreach (ICodeMap codeMap in classMap.CodeMaps)
			{
				if (codeMap.Code.Length > 0)
				{
					xml.Append(SerializeCodeMap(codeMap));
				}
			}
			foreach (IEnumValueMap enumValueMap in classMap.EnumValueMaps)
			{
				xml.Append(SerializeEnumValueMap(enumValueMap));
			}
			xml.Append("  </class>\r\n"); // do not localize
			return xml.ToString();
		}

		protected virtual string SerializeCodeMap(ICodeMap codeMap)
		{
			StringBuilder xml = new StringBuilder();
			xml.Append("    <code language=\"" + codeMap.CodeLanguage.ToString() + "\"><![CDATA[" + codeMap.Code + "]]></code>\r\n"); // do not localize
			return xml.ToString();				
		}

		protected virtual string SerializeEnumValueMap(IEnumValueMap enumValueMap)
		{
			StringBuilder xml = new StringBuilder();
			xml.Append("    <enum-value name=\"" + enumValueMap.Name + "\"  index=\"" + enumValueMap.Index.ToString() + "\" />\r\n"); // do not localize
			return xml.ToString();				
		}


		protected virtual string SerializePropertyMap(IPropertyMap propertyMap)
		{
			StringBuilder xml = new StringBuilder();
			bool ok;
			xml.Append("    <property name=\"" + propertyMap.Name + "\""); // do not localize
			if (propertyMap.FieldName.Length > 0)
			{
				xml.Append(" field=\"" + propertyMap.FieldName + "\""); // do not localize
			}
			if (propertyMap.ValidateMethod.Length > 0)
			{
				xml.Append(" validate=\"" + propertyMap.ValidateMethod + "\""); // do not localize
			}
			if (propertyMap.IsIdentity)
			{
				xml.Append(" id=\"true\"");
				if (propertyMap.ClassMap.GetIdentityPropertyMaps().Count > 1)
				{
					xml.Append(" id-index=\"" + propertyMap.IdentityIndex + "\""); // do not localize
				}
				if (propertyMap.IdentityGenerator.Length > 0)
				{
					xml.Append(" id-generator=\"" + propertyMap.IdentityGenerator + "\""); // do not localize
				}

			}
			if (propertyMap.IsKey)
			{
				xml.Append(" key=\"true\"");
				if (propertyMap.ClassMap.GetKeyPropertyMaps().Count > 1)
				{
					xml.Append(" key-index=\"" + propertyMap.KeyIndex + "\""); // do not localize
				}
			}

			if (propertyMap.IsNullable)
			{
				xml.Append(" nullable=\"true\""); // do not localize
			}
			if (propertyMap.IsAssignedBySource)
			{
				xml.Append(" source-assigned=\"true\""); // do not localize
			}
			if (propertyMap.MaxLength > -1)
			{
				xml.Append(" max-length=\"" + propertyMap.MaxLength.ToString() + "\""); // do not localize
			}
			if (propertyMap.MinLength > -1)
			{
				xml.Append(" min-length=\"" + propertyMap.MinLength.ToString() + "\""); // do not localize
			}
			if (propertyMap.MaxValue.Length > 0)
			{
				xml.Append(" max-value=\"" + propertyMap.MaxValue + "\""); // do not localize
			}
			if (propertyMap.MinValue.Length > 0)
			{
				xml.Append(" min-value=\"" + propertyMap.MinValue + "\""); // do not localize
			}

			if (propertyMap.SourceProperty.Length > 0)
			{
				xml.Append(" source-property=\"" + propertyMap.SourceProperty + "\""); // do not localize
			}
			if (propertyMap.Source.Length > 0)
				if (propertyMap.Source.Length > 0)
				{
					xml.Append(" source=\"" + propertyMap.Source + "\""); // do not localize
				}
			if (propertyMap.DocSource.Length > 0)
			{
				xml.Append(" doc-source=\"" + propertyMap.DocSource + "\""); // do not localize
			}
			if (propertyMap.Table.Length > 0)
			{
				xml.Append(" table=\"" + propertyMap.Table + "\""); // do not localize
			}
			if (propertyMap.DocAttribute.Length > 0)
			{
				xml.Append(" doc-attribute=\"" + propertyMap.DocAttribute + "\""); // do not localize
			}
			if (propertyMap.DocElement.Length > 0)
			{
				xml.Append(" doc-element=\"" + propertyMap.DocElement + "\""); // do not localize
			}
			if (propertyMap.DocPropertyMapMode == DocPropertyMapMode.Inline)
			{
				xml.Append(" doc-mode=\"Inline\"");
			}
			else if (propertyMap.DocPropertyMapMode == DocPropertyMapMode.ByReference)
			{
				xml.Append(" doc-mode=\"ByReference\"");
			}
            //else if (propertyMap.DocPropertyMapMode == DocPropertyMapMode.PerProperty)
            //{
            //    xml.Append(" doc-mode=\"PerProperty\"");
            //}
            //else if (propertyMap.DocPropertyMapMode == DocPropertyMapMode.PerValue )
            //{
            //    xml.Append(" doc-mode=\"PerValue\"");
            //}
            //else if (propertyMap.DocPropertyMapMode == DocPropertyMapMode.None)
            //{
            //    xml.Append(" doc-mode=\"None\"");
            //}
			if (propertyMap.Column.Length > 0)
			{
				xml.Append(" columns=\"" + propertyMap.Column + ", "); // do not localize
				foreach (string str in propertyMap.AdditionalColumns)
				{
					xml.Append(str + ", ");
				}
				xml.Length -= 2;
				xml.Append("\"");
			}
			if (propertyMap.IdColumn.Length > 0)
			{
				xml.Append(" id-columns=\"" + propertyMap.IdColumn + ", "); // do not localize
				foreach (string str in propertyMap.AdditionalIdColumns)
				{
					xml.Append(str + ", ");
				}
				xml.Length -= 2;
				xml.Append("\"");
			}
			if (propertyMap.IsGenerated)
			{
				xml.Append(" generated=\"true\""); // do not localize
			}
			if (propertyMap.IsCollection)
			{
				xml.Append(" list=\"true\""); // do not localize
				if (propertyMap.ItemType.Length > 0)
				{
					xml.Append(" item-type=\"" + propertyMap.ItemType + "\""); // do not localize
				}
				if (propertyMap.OrderBy.Length > 0)
				{
					xml.Append(" order-by=\"" + propertyMap.OrderBy + "\""); // do not localize
				}
			}
			if (propertyMap.IsReadOnly)
			{
				xml.Append(" read-only=\"true\"");
			}
			if (propertyMap.IsSlave)
			{
				xml.Append(" slave=\"true\"");
			}
			if (propertyMap.LazyLoad)
			{
				xml.Append(" lazy=\"true\"");
			}
			if (propertyMap.ReferenceType != ReferenceType.None)
			{
				if (propertyMap.ReferenceType == ReferenceType.OneToMany)
				{
					xml.Append(" ref=\"OneToMany\"");
				}
				else if (propertyMap.ReferenceType == ReferenceType.OneToOne)
				{
					xml.Append(" ref=\"OneToOne\"");
				}
				else if (propertyMap.ReferenceType == ReferenceType.ManyToOne)
				{
					xml.Append(" ref=\"ManyToOne\"");
				}
				else if (propertyMap.ReferenceType == ReferenceType.ManyToMany)
				{
					xml.Append(" ref=\"ManyToMany\"");
				}
				if (propertyMap.Inverse.Length > 0)
				{
					xml.Append(" inverse=\"" + propertyMap.Inverse + "\""); // do not localize
					if (propertyMap.InheritInverseMappings)
					{
						xml.Append(" inherits-inverse=\"true\"");
					}
					if (propertyMap.NoInverseManagement)
					{
						xml.Append(" manage-inverse=\"false\"");
					}
				}
				if (propertyMap.CascadingCreate)
				{
					xml.Append(" cascade-create=\"true\"");
				}
				if (propertyMap.CascadingDelete)
				{
					xml.Append(" cascade-delete=\"true\"");
				}
				if (propertyMap.ReferenceQualifier != ReferenceQualifier.Default)
				{
					xml.Append(" qualifier=\"" + propertyMap.ReferenceQualifier.ToString() + "\"");					
				}
			}
			if (propertyMap.NullSubstitute.Length > 0)
			{
				xml.Append(" null-subst=\"" + propertyMap.NullSubstitute + "\""); // do not localize
			}
			if (propertyMap.DeleteOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.Disabled)
			{
				xml.Append(" optimistic-delete=\"Disabled\"");
			}
			else if (propertyMap.DeleteOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.IncludeWhenDirty)
			{
				xml.Append(" optimistic-delete=\"IncludeWhenDirty\"");
			}
			else if (propertyMap.DeleteOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.IncludeWhenLoaded)
			{
				xml.Append(" optimistic-delete=\"IncludeWhenLoaded\"");
			}
			if (propertyMap.UpdateOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.Disabled)
			{
				xml.Append(" optimistic-update=\"Disabled\"");
			}
			else if (propertyMap.UpdateOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.IncludeWhenDirty)
			{
				xml.Append(" optimistic-update=\"IncludeWhenDirty\"");
			}
			else if (propertyMap.UpdateOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.IncludeWhenLoaded)
			{
				xml.Append(" optimistic-update=\"IncludeWhenLoaded\"");
			}
			if (propertyMap.OnCreateBehavior == PropertySpecialBehaviorType.Increase)
			{
				xml.Append(" on-create=\"Increase\"");
			}
			else if (propertyMap.OnCreateBehavior == PropertySpecialBehaviorType.SetDateTime)
			{
				xml.Append(" on-create=\"SetDateTime\"");
			}
			if (propertyMap.OnPersistBehavior == PropertySpecialBehaviorType.Increase)
			{
				xml.Append(" on-persist=\"Increase\"");
			}
			else if (propertyMap.OnPersistBehavior == PropertySpecialBehaviorType.SetDateTime)
			{
				xml.Append(" on-persist=\"SetDateTime\"");
			}

			if (!(propertyMap.MergeBehavior == MergeBehaviorType.DefaultBehavior))
			{
				xml.Append(" merge=\"" + propertyMap.RefreshBehavior.ToString() + "\""); // do not localize
			}
			
			if (!(propertyMap.RefreshBehavior == RefreshBehaviorType.DefaultBehavior))
			{
				xml.Append(" refresh=\"" + propertyMap.RefreshBehavior.ToString() + "\""); // do not localize
			}
			if (!(propertyMap.ValidationMode == ValidationMode.Default))
			{
				xml.Append(" validation=\"" + propertyMap.ValidationMode.ToString() + "\""); // do not localize
			}
			if (!(propertyMap.ListCountLoadBehavior == LoadBehavior.Default))
			{
				xml.Append(" count=\"" + propertyMap.ListCountLoadBehavior.ToString() + "\""); // do not localize
			}

			if (!(propertyMap.TimeToLive < 0))
			{
				xml.Append(" ttl=\"" + propertyMap.TimeToLive.ToString() + "\""); // do not localize
			}
			if (!(propertyMap.TimeToLiveBehavior == TimeToLiveBehavior.Default))
			{
				xml.Append(" ttl-behavior=\"" + propertyMap.TimeToLiveBehavior.ToString() + "\""); // do not localize
			}
			if (propertyMap.CommitRegions.Length > 0)
			{
				xml.Append(" commit-regions=\"" + propertyMap.CommitRegions + "\""); // do not localize
			}


			if (!(BareBones))
			{
				if (propertyMap.DataType.Length > 0)
				{
					ok = true;
					if ((propertyMap.IsCollection && propertyMap.DataType.ToLower(CultureInfo.InvariantCulture) == "system.collections.ilist"))
					{
						ok = false;
					}
					if ((propertyMap.IsCollection && propertyMap.DataType.ToLower(CultureInfo.InvariantCulture) == "system.collections.arraylist"))
					{
						ok = false;
					}
					if (propertyMap.DataType.ToLower(CultureInfo.InvariantCulture).IndexOf("interceptablelist") > 0)
					{
						ok = false;
					}
					if (propertyMap.DataType.ToLower(CultureInfo.InvariantCulture).IndexOf("managedlist") > 0)
					{
						ok = false;
					}
					if (ok)
					{
						xml.Append(" type=\"" + propertyMap.DataType + "\""); // do not localize
					}
				}
				if (propertyMap.DefaultValue.Length > 0)
				{
					ok = true;
					if (propertyMap.IsCollection)
					{
						ok = false;
					}
					//					if (!((propertyMap.IsCollection && propertyMap.DefaultValue.ToLower(CultureInfo.InvariantCulture) == "new system.collections.arraylist()"))) // do not localize
					//					{
					//						ok = false;
					//					}
					//					if (propertyMap.DefaultValue.ToLower(CultureInfo.InvariantCulture).IndexOf("interceptablelist") > 0)
					//					{
					//						ok = false;
					//					}
					//					if (propertyMap.DefaultValue.ToLower(CultureInfo.InvariantCulture).IndexOf("managedlist") > 0)
					//					{
					//						ok = false;
					//					}
					if (ok)
					{
						xml.Append(" default=\"" + propertyMap.DefaultValue + "\""); // do not localize
					}
				}
				if (propertyMap.Accessibility == AccessibilityType.InternalAccess)
				{
					xml.Append(" access=\"InternalAccess\"");
				}
				else if (propertyMap.Accessibility == AccessibilityType.PrivateAccess)
				{
					xml.Append(" access=\"PrivateAccess\"");
				}
				else if (propertyMap.Accessibility == AccessibilityType.ProtectedAccess)
				{
					xml.Append(" access=\"ProtectedAccess\"");
				}
				else if (propertyMap.Accessibility == AccessibilityType.ProtectedInternalAccess)
				{
					xml.Append(" access=\"ProtectedInternalAccess\"");
				}
				if (propertyMap.FieldAccessibility == AccessibilityType.InternalAccess)
				{
					xml.Append(" field-access=\"InternalAccess\"");
				}
				else if (propertyMap.FieldAccessibility == AccessibilityType.ProtectedAccess)
				{
					xml.Append(" field-access=\"ProtectedAccess\"");
				}
				else if (propertyMap.FieldAccessibility == AccessibilityType.ProtectedInternalAccess)
				{
					xml.Append(" field-access=\"ProtectedInternalAccess\"");
				}
				else if (propertyMap.FieldAccessibility == AccessibilityType.PublicAccess)
				{
					xml.Append(" field-access=\"PublicAccess\"");
				}
				if (propertyMap.PropertyModifier == PropertyModifier.Abstract)
				{
					xml.Append(" modifier=\"Abstract\"");
				}
				else if (propertyMap.PropertyModifier == PropertyModifier.Override)
				{
					xml.Append(" modifier=\"Override\"");
				}
				else if (propertyMap.PropertyModifier == PropertyModifier.None)
				{
					xml.Append(" modifier=\"None\"");
				}
				else if (propertyMap.PropertyModifier == PropertyModifier.Virtual)
				{
					xml.Append(" modifier=\"Virtual\"");
				}

			
			}
			if (propertyMap.MetaData.Count > 0)
			{
				xml.Append(">\r\n");
				xml.Append(SerializeMetaData(propertyMap.MetaData, "      "));
				xml.Append("    </property>\r\n"); // do not localize
			}
			else
			{
				xml.Append(" />\r\n"); // do not localize
			}
			return xml.ToString();
		}

		protected virtual string SerializeSourceMap(ISourceMap sourceMap)
		{
			StringBuilder xml = new StringBuilder();
			xml.Append("  <source name=\"" + sourceMap.Name + "\""); // do not localize
			if (sourceMap.PersistenceType != PersistenceType.Default)
			{
				xml.Append(" persistence-type=\"" + sourceMap.PersistenceType.ToString() + "\""); // do not localize				
			}
			if (sourceMap.Compute == true)
			{
				xml.Append(" compute=\"true\""); // do not localize
			}
			xml.Append(" type=\"" + sourceMap.SourceType.ToString() + "\""); // do not localize
			xml.Append(" provider=\"" + sourceMap.ProviderType.ToString() + "\""); // do not localize
			//KS: We like it with no schema name for Access
			//if (sourceMap.Schema.Length > 0)
			{
				xml.Append(" schema=\"" + sourceMap.Schema + "\""); // do not localize
			}
			if (sourceMap.Catalog.Length > 0)
			{
				xml.Append(" catalog=\"" + sourceMap.Catalog + "\""); // do not localize
			}
			if (sourceMap.ProviderAssemblyPath.Length > 0)
			{
				xml.Append(" provider-path=\"" + sourceMap.ProviderAssemblyPath + "\""); // do not localize
			}
			if (sourceMap.ProviderConnectionTypeName.Length > 0)
			{
				xml.Append(" provider-conn=\"" + sourceMap.ProviderConnectionTypeName + "\""); // do not localize
			}
			if (sourceMap.DocPath.Length > 0)
			{
				xml.Append(" doc-path=\"" + sourceMap.DocPath + "\""); // do not localize
			}
			if (sourceMap.DocRoot.Length > 0)
			{
				xml.Append(" doc-root=\"" + sourceMap.DocRoot + "\""); // do not localize
			}
			if (sourceMap.DocEncoding.Length > 0)
			{
				xml.Append(" doc-encoding=\"" + sourceMap.DocEncoding + "\""); // do not localize
			}
			if (sourceMap.Url.Length > 0)
			{
				xml.Append(" url=\"" + sourceMap.Url + "\""); // do not localize
			}
			if (sourceMap.DomainKey.Length > 0)
			{
				xml.Append(" domain-key=\"" + sourceMap.DomainKey + "\""); // do not localize
			}
            if (sourceMap.LockTable.Length > 0)
            {
                xml.Append(" lock-table=\"" + sourceMap.LockTable + "\""); // do not localize
            }


			xml.Append(">\r\n");
			xml.Append("    <connection-string>" + sourceMap.ConnectionString + "</connection-string>\r\n"); // do not localize
			xml.Append(SerializeMetaData(sourceMap.MetaData, "    "));
			foreach (ITableMap tableMap in sourceMap.TableMaps)
			{
				xml.Append(SerializeTableMap(tableMap));
			}
			xml.Append("  </source>\r\n"); // do not localize
			return xml.ToString();
		}

		protected virtual string SerializeTableMap(ITableMap tableMap)
		{
			StringBuilder xml = new StringBuilder();
			xml.Append("    <table name=\"" + tableMap.Name + "\""); // do not localize
			if (tableMap.IsView)
			{
				xml.Append(" view=\"true\"");
			}
            if (tableMap.LockIndex > -1)
            {
                xml.Append(" lock-index=\"" + tableMap.LockIndex.ToString() + "\"");
            }
            xml.Append(">\r\n");
			xml.Append(SerializeMetaData(tableMap.MetaData, "      "));
			foreach (IColumnMap columnMap in tableMap.ColumnMaps)
			{
				xml.Append(SerializeColumnMap(columnMap));
			}
			xml.Append("    </table>\r\n"); // do not localize
			return xml.ToString();
		}

		protected virtual string SerializeColumnMap(IColumnMap columnMap)
		{
			StringBuilder xml = new StringBuilder();
			xml.Append("      <column name=\"" + columnMap.Name + "\""); // do not localize
			if (columnMap.IsPrimaryKey)
			{
				xml.Append(" primary=\"true\"");
			}
			xml.Append(" type=\"" + columnMap.DataType.ToString() + "\""); // do not localize
			xml.Append(" prec=\"" + columnMap.Precision + "\""); // do not localize
			if (columnMap.AllowNulls)
			{
				xml.Append(" allow-null=\"true\"");
			}
			xml.Append(" length=\"" + columnMap.Length + "\""); // do not localize
			xml.Append(" scale=\"" + columnMap.Scale + "\""); // do not localize
			if (columnMap.IsFixedLength)
			{
				xml.Append(" fixed-length=\"true\"");
			}
			if (columnMap.IsForeignKey)
			{
				xml.Append(" foreign=\"true\"");
				if (columnMap.PrimaryKeyTable.Length > 0)
				{
					xml.Append(" primary-table=\"" + columnMap.PrimaryKeyTable + "\""); // do not localize
				}
				if (columnMap.PrimaryKeyColumn.Length > 0)
				{
					xml.Append(" primary-column=\"" + columnMap.PrimaryKeyColumn + "\""); // do not localize
				}
				if (columnMap.ForeignKeyName.Length > 0)
				{
					xml.Append(" foreign-key=\"" + columnMap.ForeignKeyName + "\""); // do not localize
				}
			}
			if (columnMap.Sequence.Length > 0)
			{
				xml.Append(" sequence=\"" + columnMap.Sequence + "\""); // do not localize
			}
			if (columnMap.IsAutoIncrease)
			{
				xml.Append(" auto-inc=\"true\"");
				xml.Append(" seed=\"" + columnMap.Seed + "\""); // do not localize
				xml.Append(" inc=\"" + columnMap.Increment + "\""); // do not localize
			}
			if (columnMap.DefaultValue.Length > 0)
			{
				xml.Append(" default=\"" + columnMap.DefaultValue + "\""); // do not localize
			}
			if (columnMap.Format.Length > 0)
			{
				xml.Append(" format=\"" + columnMap.Format + "\""); // do not localize
			}
			if (columnMap.SpecificDataType.Length > 0)
			{
				xml.Append(" specific-type=\"" + columnMap.SpecificDataType + "\""); // do not localize
			}
			if (columnMap.MetaData.Count > 0)
			{
				xml.Append(">\r\n");
				xml.Append(SerializeMetaData(columnMap.MetaData, "        "));
				xml.Append("    </column>\r\n"); // do not localize
			}
			else
			{
				xml.Append(" />\r\n"); // do not localize
			}
			return xml.ToString();
		}

		protected virtual string SerializeMetaData(ArrayList metaDataValues, string ident)
		{
			StringBuilder xml = new StringBuilder();
			foreach (IMetaDataValue metaDataValue in metaDataValues)
			{
				xml.Append(ident + "<meta-data key=\"" + metaDataValue.Key + "\" value=\"" + metaDataValue.Value + "\" />\r\n"); // do not localize
			}
			return xml.ToString();
		}

		protected virtual IDomainMap DeserializeDomainMap(XmlNode xmlDom)
		{
			IDomainMap domainMap = new DomainMap();
			XmlNodeList xmlClasses;
			XmlNodeList xmlSources;
			string str;
			string[] arr;
			if (!(xmlDom.Attributes["name"] == null))
			{
				domainMap.Name = xmlDom.Attributes["name"].Value;
			}
			if (!(xmlDom.Attributes["assembly"] == null))
			{
				domainMap.AssemblyName = xmlDom.Attributes["assembly"].Value;
			}
			if (!(xmlDom.Attributes["language"] == null))
			{
				domainMap.CodeLanguage = (CodeLanguage) Enum.Parse(typeof (CodeLanguage), xmlDom.Attributes["language"].Value);
			}
			if (!(xmlDom.Attributes["validation"] == null))
			{
				domainMap.ValidationMode = (ValidationMode) Enum.Parse(typeof (ValidationMode), xmlDom.Attributes["validation"].Value);
			}
			if (!(xmlDom.Attributes["root"] == null))
			{
				domainMap.RootNamespace = xmlDom.Attributes["root"].Value;
			}
			if (!(xmlDom.Attributes["source"] == null))
			{
				domainMap.Source = xmlDom.Attributes["source"].Value;
			}
			if (!(xmlDom.Attributes["doc-source"] == null))
			{
				domainMap.DocSource = xmlDom.Attributes["doc-source"].Value;
			}
			if (!(xmlDom.Attributes["read-only"] == null))
			{
				domainMap.IsReadOnly = ParseBool(xmlDom.Attributes["read-only"].Value);
			}
			if (!(xmlDom.Attributes["field-prefix"] == null))
			{
				domainMap.FieldPrefix = xmlDom.Attributes["field-prefix"].Value;
			}
			if (!(xmlDom.Attributes["field-strategy"] == null))
			{
				domainMap.FieldNameStrategy = (FieldNameStrategyType) Enum.Parse(typeof (FieldNameStrategyType), xmlDom.Attributes["field-strategy"].Value);
			}
			if (!(xmlDom.Attributes["base"] == null))
			{
				domainMap.InheritsTransientClass = xmlDom.Attributes["base"].Value;
			}
			if (!(xmlDom.Attributes["implements"] == null))
			{
				str = xmlDom.Attributes["implements"].Value;
				if (str.Length > 0)
				{
					arr = str.Split(',');
					foreach (string iStr in arr)
					{
						str = iStr.Trim();
						if (str.Length > 0)
						{
							domainMap.ImplementsInterfaces.Add(str);
						}
					}
				}
			}
			if (!(xmlDom.Attributes["imports"] == null))
			{
				str = xmlDom.Attributes["imports"].Value;
				if (str.Length > 0)
				{
					arr = str.Split(',');
					foreach (string iStr in arr)
					{
						str = iStr.Trim();
						if (str.Length > 0)
						{
							domainMap.ImportsNamespaces.Add(str);
						}
					}
				}
			}
			if (!(xmlDom.Attributes["ttl"] == null))
			{
				domainMap.TimeToLive = Int32.Parse(xmlDom.Attributes["ttl"].Value);
			}
			if (!(xmlDom.Attributes["ttl-behavior"] == null))
			{
				domainMap.TimeToLiveBehavior = (TimeToLiveBehavior) Enum.Parse(typeof (TimeToLiveBehavior), xmlDom.Attributes["ttl-behavior"].Value);
			}
			if (!(xmlDom.Attributes["load"] == null))
			{
				domainMap.LoadBehavior = (LoadBehavior) Enum.Parse(typeof (LoadBehavior), xmlDom.Attributes["load"].Value);
			}
			if (!(xmlDom.Attributes["merge"] == null))
			{
				domainMap.MergeBehavior = (MergeBehaviorType) Enum.Parse(typeof (MergeBehaviorType), xmlDom.Attributes["merge"].Value);
			}
			if (!(xmlDom.Attributes["refresh"] == null))
			{
				domainMap.RefreshBehavior = (RefreshBehaviorType) Enum.Parse(typeof (RefreshBehaviorType), xmlDom.Attributes["refresh"].Value);
			}
			if (!(xmlDom.Attributes["count"] == null))
			{
				domainMap.ListCountLoadBehavior = (LoadBehavior) Enum.Parse(typeof (LoadBehavior), xmlDom.Attributes["count"].Value);
			}
			if (!(xmlDom.Attributes["optimistic-delete"] == null))
			{
				domainMap.DeleteOptimisticConcurrencyBehavior = (OptimisticConcurrencyBehaviorType) Enum.Parse(typeof (OptimisticConcurrencyBehaviorType), xmlDom.Attributes["optimistic-delete"].Value);
			}
			if (!(xmlDom.Attributes["optimistic-update"] == null))
			{
				domainMap.UpdateOptimisticConcurrencyBehavior = (OptimisticConcurrencyBehaviorType) Enum.Parse(typeof (OptimisticConcurrencyBehaviorType), xmlDom.Attributes["optimistic-update"].Value);
			}
			if (!(xmlDom.Attributes["serializer"] == null))
			{
				if (xmlDom.Attributes["serializer"].Value.ToLower(CultureInfo.InvariantCulture) == "dotnet" || xmlDom.Attributes["serializer"].Value.ToLower(CultureInfo.InvariantCulture) == "dotnetserializer")
				{
					domainMap.MapSerializer = MapSerializer.DotNetSerializer;
				}
				else if (xmlDom.Attributes["serializer"].Value.ToLower(CultureInfo.InvariantCulture) == "custom" || xmlDom.Attributes["serializer"].Value.ToLower(CultureInfo.InvariantCulture) == "customserializer")
				{
					domainMap.MapSerializer = MapSerializer.CustomSerializer;
				}
				else
				{
					domainMap.MapSerializer = MapSerializer.DefaultSerializer;
				}
			}
			else
			{
				domainMap.MapSerializer = MapSerializer.DefaultSerializer;
			}
            if (!(xmlDom.Attributes["deadlock-strategy"] == null))
            {
                domainMap.DeadlockStrategy = (DeadlockStrategy)Enum.Parse(typeof(DeadlockStrategy), xmlDom.Attributes["deadlock-strategy"].Value);
            }
			if (!(xmlDom.Attributes["target-languages"] == null))
			{
				str = xmlDom.Attributes["target-languages"].Value;
				if (str.Length > 0)
				{
					arr = str.Split(',');
					foreach (string iStr in arr)
					{
						str = iStr.Trim();
						if (str.Length > 0)
						{
							if (str.ToLower(CultureInfo.InvariantCulture) == "cs" || str.ToLower(CultureInfo.InvariantCulture) == "c-sharp" || str.ToLower(CultureInfo.InvariantCulture) == "csharp" || str.ToLower(CultureInfo.InvariantCulture) == "c#")
							{
								domainMap.VerifyCSharpReservedWords = true;
							}
							else if (str.ToLower(CultureInfo.InvariantCulture) == "vb" || str.ToLower(CultureInfo.InvariantCulture) == "vb-net" || str.ToLower(CultureInfo.InvariantCulture) == "vb.net")
							{
								domainMap.VerifyVbReservedWords = true;
							}
							else if (str.ToLower(CultureInfo.InvariantCulture) == "delphi" || str.ToLower(CultureInfo.InvariantCulture) == "delphi.net")
							{
								domainMap.VerifyDelphiReservedWords = true;
							}
						}
					}
				}
			}
			ArrayList metaData = domainMap.MetaData;
			DeserializeMetaData(xmlDom, ref metaData);
			xmlClasses = xmlDom.SelectNodes("class");
			foreach (XmlNode xmlClass in xmlClasses)
			{
				DeserializeClassMap(domainMap, xmlClass);
			}
			xmlSources = xmlDom.SelectNodes("source");
			foreach (XmlNode xmlSource in xmlSources)
			{
				DeserializeSourceMap(domainMap, xmlSource);
			}
			XmlNodeList xmlCodeMaps = xmlDom.SelectNodes("code");
			foreach (XmlNode xmlCodeMap in xmlCodeMaps)
			{
				DeserializeCodeMap(domainMap, xmlCodeMap);
			}
			return domainMap;
		}

		protected virtual void DeserializeClassMap(IDomainMap domainMap, XmlNode xmlClass)
		{
			IClassMap classMap = new ClassMap();
			XmlNodeList xmlProps;
			string str;
			string[] arr;
			classMap.DomainMap = domainMap;
			if (!(xmlClass.Attributes["name"] == null))
			{
				classMap.Name = xmlClass.Attributes["name"].Value;
			}
			if (!(xmlClass.Attributes["type"] == null))
			{
				classMap.ClassType = (ClassType) Enum.Parse(typeof (ClassType), xmlClass.Attributes["type"].Value);
			}
			if (!(xmlClass.Attributes["assembly"] == null))
			{
				classMap.AssemblyName = xmlClass.Attributes["assembly"].Value;
			}
			if (!(xmlClass.Attributes["load-span"] == null))
			{
				classMap.LoadSpan = xmlClass.Attributes["load-span"].Value;
			}
			if (!(xmlClass.Attributes["validate"] == null))
			{
				classMap.ValidateMethod = xmlClass.Attributes["validate"].Value;
			}
			if (!(xmlClass.Attributes["source-class"] == null))
			{
				classMap.SourceClass = xmlClass.Attributes["source-class"].Value;
			}
			if (!(xmlClass.Attributes["source"] == null))
			{
				classMap.Source = xmlClass.Attributes["source"].Value;
			}
			if (!(xmlClass.Attributes["doc-source"] == null))
			{
				classMap.DocSource = xmlClass.Attributes["doc-source"].Value;
			}
			if (!(xmlClass.Attributes["table"] == null))
			{
				classMap.Table = xmlClass.Attributes["table"].Value;
			}
			if (!(xmlClass.Attributes["doc-element"] == null))
			{
				classMap.DocElement = xmlClass.Attributes["doc-element"].Value;
			}
			if (!(xmlClass.Attributes["doc-root"] == null))
			{
				classMap.DocRoot = xmlClass.Attributes["doc-root"].Value;
			}
			if (!(xmlClass.Attributes["doc-mode"] == null))
			{
				classMap.DocClassMapMode = (DocClassMapMode) Enum.Parse(typeof (DocClassMapMode), xmlClass.Attributes["doc-mode"].Value);
			}
			if (!(xmlClass.Attributes["type-column"] == null))
			{
				classMap.TypeColumn = xmlClass.Attributes["type-column"].Value;
			}
			if (!(xmlClass.Attributes["type-value"] == null))
			{
				classMap.TypeValue = xmlClass.Attributes["type-value"].Value;
			}
			if (!(xmlClass.Attributes["doc-parent"] == null))
			{
				classMap.DocParentProperty = xmlClass.Attributes["doc-parent"].Value;
			}
			if (!(xmlClass.Attributes["read-only"] == null))
			{
				classMap.IsReadOnly = ParseBool(xmlClass.Attributes["read-only"].Value);
			}
			if (!(xmlClass.Attributes["abstract"] == null))
			{
				classMap.IsAbstract = ParseBool(xmlClass.Attributes["abstract"].Value);
			}
			if (!(xmlClass.Attributes["inherits"] == null))
			{
				classMap.InheritsClass = xmlClass.Attributes["inherits"].Value;
			}
			if (!(xmlClass.Attributes["id-separator"] == null))
			{
				classMap.IdentitySeparator = xmlClass.Attributes["id-separator"].Value;
			}
			if (!(xmlClass.Attributes["key-separator"] == null))
			{
				classMap.KeySeparator = xmlClass.Attributes["key-separator"].Value;
			}
			if (!(xmlClass.Attributes["inheritance"] == null))
			{
				classMap.InheritanceType = (InheritanceType) Enum.Parse(typeof (InheritanceType), xmlClass.Attributes["inheritance"].Value);
			}
			if (!(xmlClass.Attributes["base"] == null))
			{
				classMap.InheritsTransientClass = xmlClass.Attributes["base"].Value;
			}
			if (!(xmlClass.Attributes["ttl"] == null))
			{
				classMap.TimeToLive = Int32.Parse(xmlClass.Attributes["ttl"].Value);
			}
			if (!(xmlClass.Attributes["ttl-behavior"] == null))
			{
				classMap.TimeToLiveBehavior = (TimeToLiveBehavior) Enum.Parse(typeof (TimeToLiveBehavior), xmlClass.Attributes["ttl-behavior"].Value);
			}
			if (!(xmlClass.Attributes["load"] == null))
			{
				classMap.LoadBehavior = (LoadBehavior) Enum.Parse(typeof (LoadBehavior), xmlClass.Attributes["load"].Value);
			}
			if (!(xmlClass.Attributes["commit-regions"] == null))
			{
				classMap.CommitRegions = xmlClass.Attributes["commit-regions"].Value;
			}

			if (!(xmlClass.Attributes["implements"] == null))
			{
				str = xmlClass.Attributes["implements"].Value;
				if (str.Length > 0)
				{
					arr = str.Split(',');
					foreach (string iStr in arr)
					{
						str = iStr.Trim();
						if (str.Length > 0)
						{
							classMap.ImplementsInterfaces.Add(str);
						}
					}
				}
			}
			if (!(xmlClass.Attributes["imports"] == null))
			{
				str = xmlClass.Attributes["imports"].Value;
				if (str.Length > 0)
				{
					arr = str.Split(',');
					foreach (string iStr in arr)
					{
						str = iStr.Trim();
						if (str.Length > 0)
						{
							classMap.ImportsNamespaces.Add(str);
						}
					}
				}
			}
			if (!(xmlClass.Attributes["merge"] == null))
			{
				classMap.MergeBehavior = (MergeBehaviorType) Enum.Parse(typeof (MergeBehaviorType), xmlClass.Attributes["merge"].Value);
			}
			if (!(xmlClass.Attributes["refresh"] == null))
			{
				classMap.RefreshBehavior = (RefreshBehaviorType) Enum.Parse(typeof (RefreshBehaviorType), xmlClass.Attributes["refresh"].Value);
			}
			if (!(xmlClass.Attributes["validation"] == null))
			{
				classMap.ValidationMode = (ValidationMode) Enum.Parse(typeof (ValidationMode), xmlClass.Attributes["validation"].Value);
			}
			if (!(xmlClass.Attributes["count"] == null))
			{
				classMap.ListCountLoadBehavior = (LoadBehavior) Enum.Parse(typeof (LoadBehavior), xmlClass.Attributes["count"].Value);
			}

			if (!(xmlClass.Attributes["optimistic-delete"] == null))
			{
				classMap.DeleteOptimisticConcurrencyBehavior = (OptimisticConcurrencyBehaviorType) Enum.Parse(typeof (OptimisticConcurrencyBehaviorType), xmlClass.Attributes["optimistic-delete"].Value);
			}
			if (!(xmlClass.Attributes["optimistic-update"] == null))
			{
				classMap.UpdateOptimisticConcurrencyBehavior = (OptimisticConcurrencyBehaviorType) Enum.Parse(typeof (OptimisticConcurrencyBehaviorType), xmlClass.Attributes["optimistic-update"].Value);
			}
			ArrayList metaData = classMap.MetaData;
			DeserializeMetaData(xmlClass, ref metaData);
			xmlProps = xmlClass.SelectNodes("property");
			foreach (XmlNode xmlProp in xmlProps)
			{
				DeserializePropertyMap(classMap, xmlProp);
			}
			XmlNodeList xmlCodeMaps = xmlClass.SelectNodes("code");
			foreach (XmlNode xmlCodeMap in xmlCodeMaps)
			{
				DeserializeCodeMap(classMap, xmlCodeMap);
			}
			XmlNodeList xmlEnumValueMaps = xmlClass.SelectNodes("enum-value");
			foreach (XmlNode xmlEnumValueMap in xmlEnumValueMaps)
			{
				DeserializeEnumValueMap(classMap, xmlEnumValueMap);
			}

		}

		protected virtual void DeserializeEnumValueMap(IClassMap classMap, XmlNode xmlEnumValueMap)
		{
			IEnumValueMap enumValueMap = new EnumValueMap();
			enumValueMap.ClassMap = classMap;
			if (!(xmlEnumValueMap.Attributes["name"] == null))
			{
				enumValueMap.Name = xmlEnumValueMap.Attributes["name"].Value;
			}
			if (!(xmlEnumValueMap.Attributes["index"] == null))
			{
				enumValueMap.Index = System.Convert.ToInt32(xmlEnumValueMap.Attributes["index"].Value);
			}
		}

		protected virtual void DeserializeCodeMap(IClassMap classMap, XmlNode xmlCodeMap)
		{
			ICodeMap codeMap = new CodeMap();
			//codeMap.ClassMap = classMap;
			classMap.CodeMaps.Add(codeMap);
			if (!(xmlCodeMap.Attributes["language"] == null))
			{
				codeMap.CodeLanguage = (CodeLanguage) Enum.Parse(typeof (CodeLanguage), xmlCodeMap.Attributes["language"].Value);
			}
			codeMap.Code = xmlCodeMap.InnerText ;
		}

		protected virtual void DeserializeCodeMap(IDomainMap domainMap, XmlNode xmlCodeMap)
		{
			ICodeMap codeMap = new CodeMap();
			//codeMap.ClassMap = classMap;
			domainMap.CodeMaps.Add(codeMap);
			if (!(xmlCodeMap.Attributes["language"] == null))
			{
				codeMap.CodeLanguage = (CodeLanguage) Enum.Parse(typeof (CodeLanguage), xmlCodeMap.Attributes["language"].Value);
			}
			codeMap.Code = xmlCodeMap.InnerText ;
		}

		protected virtual void DeserializePropertyMap(IClassMap classMap, XmlNode xmlProp)
		{
			IPropertyMap propertyMap = new PropertyMap();
			string str;
			string[] arr;
			bool first;
			propertyMap.ClassMap = classMap;
			if (!(xmlProp.Attributes["name"] == null))
			{
				propertyMap.Name = xmlProp.Attributes["name"].Value;
			}
			if (!(xmlProp.Attributes["validate"] == null))
			{
				propertyMap.ValidateMethod = xmlProp.Attributes["validate"].Value;
			}
			if (!(xmlProp.Attributes["validation"] == null))
			{
				propertyMap.ValidationMode = (ValidationMode) Enum.Parse(typeof (ValidationMode), xmlProp.Attributes["validation"].Value);
			}
			if (!(xmlProp.Attributes["source-property"] == null))
			{
				propertyMap.SourceProperty = xmlProp.Attributes["source-property"].Value;
			}
			if (!(xmlProp.Attributes["source"] == null))
			{
				propertyMap.Source = xmlProp.Attributes["source"].Value;
			}
			if (!(xmlProp.Attributes["doc-source"] == null))
			{
				propertyMap.DocSource = xmlProp.Attributes["doc-source"].Value;
			}
			if (!(xmlProp.Attributes["nullable"] == null))
			{
				propertyMap.IsNullable = ParseBool(xmlProp.Attributes["nullable"].Value);
			}
			if (!(xmlProp.Attributes["source-assigned"] == null))
			{
				propertyMap.IsAssignedBySource = ParseBool(xmlProp.Attributes["source-assigned"].Value);
			}
			if (!(xmlProp.Attributes["max-length"] == null))
			{
				propertyMap.MaxLength = Int32.Parse(xmlProp.Attributes["max-length"].Value);
			}
			if (!(xmlProp.Attributes["min-length"] == null))
			{
				propertyMap.MinLength = Int32.Parse(xmlProp.Attributes["min-length"].Value);
			}
			if (!(xmlProp.Attributes["max-value"] == null))
			{
				propertyMap.MaxValue = xmlProp.Attributes["max-value"].Value;
			}
			if (!(xmlProp.Attributes["min-value"] == null))
			{
				propertyMap.MinValue = xmlProp.Attributes["min-value"].Value;
			}
			if (!(xmlProp.Attributes["table"] == null))
			{
				propertyMap.Table = xmlProp.Attributes["table"].Value;
			}
			if (!(xmlProp.Attributes["doc-attribute"] == null))
			{
				propertyMap.DocAttribute = xmlProp.Attributes["doc-attribute"].Value;
			}
			if (!(xmlProp.Attributes["doc-element"] == null))
			{
				propertyMap.DocElement = xmlProp.Attributes["doc-element"].Value;
			}
			if (!(xmlProp.Attributes["doc-mode"] == null))
			{
				propertyMap.DocPropertyMapMode = (DocPropertyMapMode) Enum.Parse(typeof (DocPropertyMapMode), xmlProp.Attributes["doc-mode"].Value);
			}
			if (!(xmlProp.Attributes["columns"] == null))
			{
				first = true;
				str = xmlProp.Attributes["columns"].Value;
				if (str.Length > 0)
				{
					arr = str.Split(',');
					foreach (string iStr in arr)
					{
						str = iStr.Trim();
						if (str.Length > 0)
						{
							if (first)
							{
								first = false;
								propertyMap.Column = str;
							}
							else
							{
								propertyMap.AdditionalColumns.Add(str);
							}
						}
					}
				}
			}
			if (!(xmlProp.Attributes["id-columns"] == null))
			{
				first = true;
				str = xmlProp.Attributes["id-columns"].Value;
				if (str.Length > 0)
				{
					arr = str.Split(',');
					foreach (string iStr in arr)
					{
						str = iStr.Trim();
						if (str.Length > 0)
						{
							if (first)
							{
								first = false;
								propertyMap.IdColumn = str;
							}
							else
							{
								propertyMap.AdditionalIdColumns.Add(str);
							}
						}
					}
				}
			}
			if (!(xmlProp.Attributes["type"] == null))
			{
				propertyMap.DataType = xmlProp.Attributes["type"].Value;
			}
			if (!(xmlProp.Attributes["field"] == null))
			{
				propertyMap.FieldName = xmlProp.Attributes["field"].Value;
			}
			if (!(xmlProp.Attributes["generated"] == null))
			{
				propertyMap.IsGenerated = ParseBool(xmlProp.Attributes["generated"].Value);
			}
			if (!(xmlProp.Attributes["list"] == null))
			{
				propertyMap.IsCollection = ParseBool(xmlProp.Attributes["list"].Value);
			}
			if (!(xmlProp.Attributes["item-type"] == null))
			{
				propertyMap.ItemType = xmlProp.Attributes["item-type"].Value;
			}
			if (!(xmlProp.Attributes["order-by"] == null))
			{
				propertyMap.OrderBy = xmlProp.Attributes["order-by"].Value;
			}
			if (!(xmlProp.Attributes["modifier"] == null))
			{
				propertyMap.PropertyModifier = (PropertyModifier) Enum.Parse(typeof (PropertyModifier), xmlProp.Attributes["modifier"].Value);
			}
			if (!(xmlProp.Attributes["id"] == null))
			{
				propertyMap.IsIdentity = ParseBool(xmlProp.Attributes["id"].Value);
			}
			if (!(xmlProp.Attributes["id-index"] == null))
			{
				propertyMap.IdentityIndex = System.Convert.ToInt32(xmlProp.Attributes["id-index"].Value);
			}
			if (!(xmlProp.Attributes["key"] == null))
			{
				propertyMap.IsKey = ParseBool(xmlProp.Attributes["key"].Value);
			}
			if (!(xmlProp.Attributes["key-index"] == null))
			{
				propertyMap.KeyIndex = System.Convert.ToInt32(xmlProp.Attributes["key-index"].Value);
			}
			if (!(xmlProp.Attributes["id-generator"] == null))
			{
				propertyMap.IdentityGenerator = xmlProp.Attributes["id-generator"].Value;
			}
			if (!(xmlProp.Attributes["read-only"] == null))
			{
				propertyMap.IsReadOnly = ParseBool(xmlProp.Attributes["read-only"].Value);
			}
			if (!(xmlProp.Attributes["slave"] == null))
			{
				propertyMap.IsSlave = ParseBool(xmlProp.Attributes["slave"].Value);
			}
			if (!(xmlProp.Attributes["lazy"] == null))
			{
				propertyMap.LazyLoad = ParseBool(xmlProp.Attributes["lazy"].Value);
			}
			if (!(xmlProp.Attributes["manage-inverse"] == null))
			{
				propertyMap.NoInverseManagement = !(ParseBool(xmlProp.Attributes["manage-inverse"].Value));
			}
			if (!(xmlProp.Attributes["inherits-inverse"] == null))
			{
				propertyMap.InheritInverseMappings = ParseBool(xmlProp.Attributes["inherits-inverse"].Value);
			}
			if (!(xmlProp.Attributes["cascade-create"] == null))
			{
				propertyMap.CascadingCreate = ParseBool(xmlProp.Attributes["cascade-create"].Value);
			}
			if (!(xmlProp.Attributes["cascade-delete"] == null))
			{
				propertyMap.CascadingDelete = ParseBool(xmlProp.Attributes["cascade-delete"].Value);
			}
			if (!(xmlProp.Attributes["inverse"] == null))
			{
				propertyMap.Inverse = xmlProp.Attributes["inverse"].Value;
			}
			if (!(xmlProp.Attributes["access"] == null))
			{
				propertyMap.Accessibility = (AccessibilityType) Enum.Parse(typeof (AccessibilityType), xmlProp.Attributes["access"].Value);
			}
			if (!(xmlProp.Attributes["field-access"] == null))
			{
				propertyMap.FieldAccessibility = (AccessibilityType) Enum.Parse(typeof (AccessibilityType), xmlProp.Attributes["field-access"].Value);
			}
			if (!(xmlProp.Attributes["default"] == null))
			{
				propertyMap.DefaultValue = xmlProp.Attributes["default"].Value;
			}
			if (!(xmlProp.Attributes["null-subst"] == null))
			{
				propertyMap.NullSubstitute = xmlProp.Attributes["null-subst"].Value;
			}
			if (!(xmlProp.Attributes["ref"] == null))
			{
				propertyMap.ReferenceType = (ReferenceType) Enum.Parse(typeof (ReferenceType), xmlProp.Attributes["ref"].Value);
			}
			if (!(xmlProp.Attributes["qualifier"] == null))
			{
				propertyMap.ReferenceQualifier = (ReferenceQualifier) Enum.Parse(typeof (ReferenceQualifier), xmlProp.Attributes["qualifier"].Value);
			}
			if (!(xmlProp.Attributes["optimistic-delete"] == null))
			{
				propertyMap.DeleteOptimisticConcurrencyBehavior = (OptimisticConcurrencyBehaviorType) Enum.Parse(typeof (OptimisticConcurrencyBehaviorType), xmlProp.Attributes["optimistic-delete"].Value);
			}
			if (!(xmlProp.Attributes["optimistic-update"] == null))
			{
				propertyMap.UpdateOptimisticConcurrencyBehavior = (OptimisticConcurrencyBehaviorType) Enum.Parse(typeof (OptimisticConcurrencyBehaviorType), xmlProp.Attributes["optimistic-update"].Value);
			}
			if (!(xmlProp.Attributes["on-create"] == null))
			{
				propertyMap.OnCreateBehavior = (PropertySpecialBehaviorType) Enum.Parse(typeof (PropertySpecialBehaviorType), xmlProp.Attributes["on-create"].Value);
			}
			if (!(xmlProp.Attributes["on-persist"] == null))
			{
				propertyMap.OnPersistBehavior = (PropertySpecialBehaviorType) Enum.Parse(typeof (PropertySpecialBehaviorType), xmlProp.Attributes["on-persist"].Value);
			}
			if (!(xmlProp.Attributes["merge"] == null))
			{
				propertyMap.MergeBehavior = (MergeBehaviorType) Enum.Parse(typeof (MergeBehaviorType), xmlProp.Attributes["merge"].Value);
			}
			if (!(xmlProp.Attributes["refresh"] == null))
			{
				propertyMap.RefreshBehavior = (RefreshBehaviorType) Enum.Parse(typeof (RefreshBehaviorType), xmlProp.Attributes["refresh"].Value);
			}
			if (!(xmlProp.Attributes["count"] == null))
			{
				propertyMap.ListCountLoadBehavior = (LoadBehavior) Enum.Parse(typeof (LoadBehavior), xmlProp.Attributes["count"].Value);
			}
			if (!(xmlProp.Attributes["ttl"] == null))
			{
				propertyMap.TimeToLive = Int32.Parse(xmlProp.Attributes["ttl"].Value);
			}
			if (!(xmlProp.Attributes["ttl-behavior"] == null))
			{
				propertyMap.TimeToLiveBehavior = (TimeToLiveBehavior) Enum.Parse(typeof (TimeToLiveBehavior), xmlProp.Attributes["ttl-behavior"].Value);
			}
			if (!(xmlProp.Attributes["commit-regions"] == null))
			{
				propertyMap.CommitRegions = xmlProp.Attributes["commit-regions"].Value;
			}

			ArrayList metaData = propertyMap.MetaData;
			DeserializeMetaData(xmlProp, ref metaData);
		}

		protected virtual void DeserializeSourceMap(IDomainMap domainMap, XmlNode xmlSource)
		{
			ISourceMap sourceMap = new SourceMap();
			XmlNode xmlConnStr;
			XmlNodeList xmlTables;
			sourceMap.DomainMap = domainMap;
			if (!(xmlSource.Attributes["persistence-type"] == null))
			{
				sourceMap.PersistenceType = (PersistenceType) Enum.Parse(typeof (PersistenceType), xmlSource.Attributes["persistence-type"].Value);
			}
			if (!(xmlSource.Attributes["compute"] == null))
			{
				sourceMap.Compute = ParseBool(xmlSource.Attributes["compute"].Value);
			}
			if (!(xmlSource.Attributes["name"] == null))
			{
				sourceMap.Name = xmlSource.Attributes["name"].Value;
			}
			if (!(xmlSource.Attributes["schema"] == null))
			{
				sourceMap.Schema = xmlSource.Attributes["schema"].Value;
			}
			if (!(xmlSource.Attributes["catalog"] == null))
			{
				sourceMap.Catalog = xmlSource.Attributes["catalog"].Value;
			}
			if (!(xmlSource.Attributes["provider"] == null))
			{
				sourceMap.ProviderType = (ProviderType) Enum.Parse(typeof (ProviderType), xmlSource.Attributes["provider"].Value);
			}
			if (!(xmlSource.Attributes["type"] == null))
			{
				sourceMap.SourceType = (SourceType) Enum.Parse(typeof (SourceType), xmlSource.Attributes["type"].Value);
			}
			if (!(xmlSource.Attributes["provider-path"] == null))
			{
				sourceMap.ProviderAssemblyPath = xmlSource.Attributes["provider-path"].Value;
			}
			if (!(xmlSource.Attributes["provider-conn"] == null))
			{
				sourceMap.ProviderConnectionTypeName = xmlSource.Attributes["provider-conn"].Value;
			}
			if (!(xmlSource.Attributes["doc-path"] == null))
			{
				sourceMap.DocPath = xmlSource.Attributes["doc-path"].Value;
			}
			if (!(xmlSource.Attributes["doc-root"] == null))
			{
				sourceMap.DocRoot = xmlSource.Attributes["doc-root"].Value;
			}
			if (!(xmlSource.Attributes["doc-encoding"] == null))
			{
				sourceMap.DocEncoding = xmlSource.Attributes["doc-encoding"].Value;
			}
			if (!(xmlSource.Attributes["url"] == null))
			{
				sourceMap.Url = xmlSource.Attributes["url"].Value;
			}
			if (!(xmlSource.Attributes["domain-key"] == null))
			{
				sourceMap.DomainKey = xmlSource.Attributes["domain-key"].Value;
			}
            if (!(xmlSource.Attributes["lock-table"] == null))
            {
                sourceMap.LockTable = xmlSource.Attributes["lock-table"].Value;
            }
            ArrayList metaData = sourceMap.MetaData;
			DeserializeMetaData(xmlSource, ref metaData);
			xmlConnStr = xmlSource.SelectSingleNode("connection-string");
			if (xmlConnStr != null)
			{
				sourceMap.ConnectionString = xmlConnStr.InnerText;
			}
			xmlTables = xmlSource.SelectNodes("table");
			foreach (XmlNode xmlTable in xmlTables)
			{
				DeserializeTableMap(sourceMap, xmlTable);
			}
		}

		protected virtual void DeserializeTableMap(ISourceMap sourceMap, XmlNode xmlTable)
		{
			ITableMap tableMap = new TableMap();
			XmlNodeList xmlCols;
			tableMap.SourceMap = sourceMap;
			if (!(xmlTable.Attributes["name"] == null))
			{
				tableMap.Name = xmlTable.Attributes["name"].Value;
			}
			if (!(xmlTable.Attributes["view"] == null))
			{
				tableMap.IsView = ParseBool(xmlTable.Attributes["view"].Value);
			}
            if (!(xmlTable.Attributes["lock-index"] == null))
            {
                tableMap.LockIndex = System.Convert.ToInt32(xmlTable.Attributes["lock-index"].Value);
            }
            ArrayList metaData = tableMap.MetaData;
			DeserializeMetaData(xmlTable, ref metaData);
			xmlCols = xmlTable.SelectNodes("column");
			foreach (XmlNode xmlCol in xmlCols)
			{
				DeserializeColumnMap(tableMap, xmlCol);
			}
		}

		protected virtual void DeserializeColumnMap(ITableMap tableMap, XmlNode xmlCol)
		{
			IColumnMap columnMap = new ColumnMap();
			columnMap.TableMap = tableMap;
			if (!(xmlCol.Attributes["name"] == null))
			{
				columnMap.Name = xmlCol.Attributes["name"].Value;
			}
			if (!(xmlCol.Attributes["type"] == null))
			{
				columnMap.DataType = (DbType) Enum.Parse(typeof (DbType), xmlCol.Attributes["type"].Value);
			}
			if (!(xmlCol.Attributes["format"] == null))
			{
				columnMap.Format = xmlCol.Attributes["format"].Value;
			}
			if (!(xmlCol.Attributes["default"] == null))
			{
				columnMap.DefaultValue = xmlCol.Attributes["default"].Value;
			}
			if (!(xmlCol.Attributes["foreign-key"] == null))
			{
				columnMap.ForeignKeyName = xmlCol.Attributes["foreign-key"].Value;
			}
			if (!(xmlCol.Attributes["primary-table"] == null))
			{
				columnMap.PrimaryKeyTable = xmlCol.Attributes["primary-table"].Value;
			}
			if (!(xmlCol.Attributes["primary-column"] == null))
			{
				columnMap.PrimaryKeyColumn = xmlCol.Attributes["primary-column"].Value;
			}
			if (!(xmlCol.Attributes["sequence"] == null))
			{
				columnMap.Sequence = xmlCol.Attributes["sequence"].Value;
			}
			if (!(xmlCol.Attributes["specific-type"] == null))
			{
				columnMap.SpecificDataType = xmlCol.Attributes["specific-type"].Value;
			}
			if (!(xmlCol.Attributes["allow-null"] == null))
			{
				columnMap.AllowNulls = ParseBool(xmlCol.Attributes["allow-null"].Value);
			}
			if (!(xmlCol.Attributes["auto-inc"] == null))
			{
				columnMap.IsAutoIncrease = ParseBool(xmlCol.Attributes["auto-inc"].Value);
			}
			if (!(xmlCol.Attributes["primary"] == null))
			{
				columnMap.IsPrimaryKey = ParseBool(xmlCol.Attributes["primary"].Value);
			}
			if (!(xmlCol.Attributes["foreign"] == null))
			{
				columnMap.IsForeignKey = ParseBool(xmlCol.Attributes["foreign"].Value);
			}
			if (!(xmlCol.Attributes["fixed"] == null))
			{
				columnMap.IsFixedLength = ParseBool(xmlCol.Attributes["fixed"].Value);
			}
			if (!(xmlCol.Attributes["seed"] == null))
			{
				columnMap.Seed = System.Convert.ToInt32(xmlCol.Attributes["seed"].Value);
			}
			if (!(xmlCol.Attributes["inc"] == null))
			{
				columnMap.Increment = System.Convert.ToInt32(xmlCol.Attributes["inc"].Value);
			}
			if (!(xmlCol.Attributes["length"] == null))
			{
				columnMap.Length = System.Convert.ToInt32(xmlCol.Attributes["length"].Value);
			}
			if (!(xmlCol.Attributes["prec"] == null))
			{
				columnMap.Precision = System.Convert.ToInt32(xmlCol.Attributes["prec"].Value);
			}
			if (!(xmlCol.Attributes["scale"] == null))
			{
				columnMap.Scale = System.Convert.ToInt32(xmlCol.Attributes["scale"].Value);
			}
			ArrayList metaData = columnMap.MetaData;
			DeserializeMetaData(xmlCol, ref metaData);
		}

		protected virtual void DeserializeMetaData(XmlNode xmlOwner, ref ArrayList metaDataValues)
		{
			IMetaDataValue metaDataValue;
			XmlNodeList xmlMetaDataValues;
			xmlMetaDataValues = xmlOwner.SelectNodes("meta-data");
			foreach (XmlNode xmlMetaDataValue in xmlMetaDataValues)
			{
				if (!(xmlMetaDataValue.Attributes["key"] == null))
				{
					if (!(xmlMetaDataValue.Attributes["value"] == null))
					{
						metaDataValue = new MetaDataValue();
						metaDataValue.Key = xmlMetaDataValue.Attributes["key"].Value;
						metaDataValue.Value = xmlMetaDataValue.Attributes["value"].Value;
						metaDataValues.Add(metaDataValue);
					}
				}
			}
		}

		protected virtual bool ParseBool(string str)
		{
			if (str.ToLower(CultureInfo.InvariantCulture) == "false" || str.ToLower(CultureInfo.InvariantCulture) == "0" || str.ToLower(CultureInfo.InvariantCulture) == "off" || str.ToLower(CultureInfo.InvariantCulture) == "no")
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		protected virtual string GetTrue()
		{
			if (!(BareBones))
			{
				return "=\"true\"";
			}
			return "";
		}
	}
}
