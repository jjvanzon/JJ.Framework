using System;
using System.Windows.Forms;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for ObjectListViewItem.
	/// </summary>
	public class ObjectListViewItem : ListViewItem, IObjectGuiItem
	{

		public ObjectListViewItem(IContext context, object obj, Type type) : this(context, obj, type, false)
		{
		}

		public ObjectListViewItem(IContext context, object obj, Type type, bool isClipBoardItem)
		{
			this.context = context;
			this.obj = obj;
			this.type = type;
			this.isClipBoardItem = isClipBoardItem;
			this.classMap = context.DomainMap.MustGetClassMap(obj.GetType() );
			this.typeClassMap = context.DomainMap.MustGetClassMap(type );
			SetText();
			this.ImageIndex = 0;
			this.StateImageIndex = 0;
			Refresh(true);
		}

		private void SetText()
		{			
			this.Text = MainForm.GetObjectAsString(obj, this.Context);			
		}

		#region Property  Type
		
		private Type type;
		
		public Type Type
		{
			get { return this.type; }
			set { this.type = value; }
		}
		
		#endregion

		#region Property  Context
		
		private IContext context;
		
		public IContext Context
		{
			get { return this.context; }
			set { this.context = value; }
		}
		
		#endregion

		#region Property  Obj
		
		private object obj;
		
		public object Obj
		{
			get { return this.obj; }
			set { this.obj = value; }
		}
		
		#endregion

		#region Property  ClassMap
		
		private IClassMap classMap;
		
		public IClassMap ClassMap
		{
			get { return this.classMap; }
			set { this.classMap = value; }
		}
		
		#endregion

		#region Property  TypeClassMap
		
		private IClassMap typeClassMap;
		
		public IClassMap TypeClassMap
		{
			get { return this.typeClassMap; }
			set { this.typeClassMap = value; }
		}
		
		#endregion

		#region Property  PropertyMap
		
		private IPropertyMap propertyMap = null;
		
		public IPropertyMap PropertyMap
		{
			get { return this.propertyMap; }
			set { this.propertyMap = value; }
		}
		
		#endregion
		
		#region Property  ReferencedByObj
		
		private object referencedByObj = null;
		
		public object ReferencedByObj
		{
			get { return this.referencedByObj; }
			set { this.referencedByObj = value; }
		}
		
		#endregion

		#region Property  ReferencedByClassMap
		
		private IClassMap referencedByClassMap= null;
		
		public IClassMap ReferencedByClassMap
		{
			get { return this.referencedByClassMap; }
			set { this.referencedByClassMap = value; }
		}
		
		#endregion

		#region Property  ReferencedByPropertyMap
		
		private IPropertyMap referencedByPropertyMap= null;
		
		public IPropertyMap ReferencedByPropertyMap
		{
			get { return this.referencedByPropertyMap; }
			set { this.referencedByPropertyMap = value; }
		}
		
		#endregion

		#region Property  IsClipBoardItem
		
		private bool isClipBoardItem = false;
		
		public bool IsClipBoardItem
		{
			get { return this.isClipBoardItem; }
			set { this.isClipBoardItem = value; }
		}
		
		#endregion

		public static void SetupColumns(IContext context, Type type, ListView listView)
		{
			IClassMap classMap = context.DomainMap.MustGetClassMap(type);
			listView.Columns.Add("Identity", 150, HorizontalAlignment.Left );
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					if (propertyMap.IsCollection == false)
					{
						listView.Columns.Add(propertyMap.Name, 150, HorizontalAlignment.Left );
					}					
				}
			}			
		}

		public void Refresh()
		{
			Refresh(false);
		}

		public void Refresh(bool setup)
		{
			SetText();
			if (isClipBoardItem)
				return;
			int i = 1;
			IObjectManager om = this.context.ObjectManager;
			foreach (IPropertyMap propertyMap in TypeClassMap.GetAllPropertyMaps())
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					if (propertyMap.IsCollection == false)
					{
						if (this.context.GetNullValueStatus(this.obj, propertyMap.Name))
						{
							if (setup)
								this.SubItems.Add("<Null>");
							else
								this.SubItems[i].Text = "<Null>";
						}
						else
						{
							string text = "<Null>";
							object value = om.GetPropertyValue(this.obj, propertyMap.Name);
							if (value != null)
								text = value.ToString() ;

							if (setup)
								this.SubItems.Add(text);								
							else
								this.SubItems[i].Text = text;
						}
						i++;
					}					
				}
			}			
		}
	
	}
}
