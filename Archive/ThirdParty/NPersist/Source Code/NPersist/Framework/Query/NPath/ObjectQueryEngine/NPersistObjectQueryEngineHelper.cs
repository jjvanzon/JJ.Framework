using System;
using System.Collections;
using Puzzle.NPath.Framework;
using Puzzle.NPath.Framework.CodeDom;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Querying;

namespace Puzzle.NPersist.Framework.NPath
{
	
	public class NPersistObjectQueryEngineHelper : IObjectQueryEngineHelper
	{
		public NPersistObjectQueryEngineHelper (IContext context) => this.Context = context;

	    #region Public Property Context
		private IContext context;
		public IContext Context
		{
			get => this.context;
		    set => this.context = value;
		}
		#endregion

		public void ExpandWildcards(NPathSelectQuery query)
		{
			ArrayList newSelectFieldList = new ArrayList();
			foreach (NPathSelectField field in query.Select.SelectFields)
			{
				string fieldName = field.Alias;
				NPathIdentifier path = field.Expression as NPathIdentifier;
				if (path != null && path.IsWildcard)
				{
					string[] parts = path.Path.Split('.');
					NPathClassName className = (NPathClassName) query.From.Classes[0];
	
					IClassMap classMap = Context.DomainMap.MustGetClassMap(className.Name);
	
					int i = 0;
					foreach (string part in parts)
					{
						if (i == parts.Length - 1)
							break;
	
						IPropertyMap property = classMap.MustGetPropertyMap(part);
						classMap = Context.DomainMap.MustGetClassMap(property.DataType);
						i++;
					}
	
					ArrayList properties = classMap.GetAllPropertyMaps();
	
					foreach (PropertyMap property in properties)
					{
						if (property.ReferenceType != ReferenceType.None)
							continue;
	
						NPathSelectField newField = new NPathSelectField();
						newField.Alias = null;
						NPathIdentifier newPath = new NPathIdentifier();
						if (parts.Length > 1)
							newPath.Path = string.Join(".", parts, 0, parts.Length - 1) + ".";
	
						newPath.Path += property.Name;
						newField.Expression = newPath;
						newSelectFieldList.Add(newField);
					}
				}
				else
				{
					newSelectFieldList.Add(field);
				}
			}
			query.Select.SelectFields = newSelectFieldList;
		}

		public bool GetNullValueStatus(object target, string property) => Context.GetNullValueStatus(target,property);

	    public object EvalParameter(object item, NPathParameter parameter)
		{
			IQueryParameter iq = (IQueryParameter)parameter;
			return iq.Value;
		}
	}
}
