using System;
using System.Reflection;
using System.Windows.Forms;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for ObjectTreeNode.
	/// </summary>
	public class ObjectTreeNode : TreeNode, IObjectGuiItem
	{
		public ObjectTreeNode(IContext context, object obj)
		{
			this.context = context;
			this.obj = obj;
			this.ClassMap = context.DomainMap.MustGetClassMap(obj.GetType() );
			this.Nodes.Add(new TreeNode() );
			SetText();
			this.ImageIndex = 0;
			this.SelectedImageIndex = 0;
		}

		public ObjectTreeNode(IContext context, object obj, object referencedByObj, IPropertyMap referencedByPropertyMap)
		{
			this.context = context;
			this.obj = obj;
			this.ClassMap = context.DomainMap.MustGetClassMap(obj.GetType() );
			this.referencedByObj = referencedByObj;
			this.referencedByClassMap = context.DomainMap.MustGetClassMap(ReferencedByObj.GetType() );
			this.referencedByPropertyMap = referencedByPropertyMap;
			this.Nodes.Add(new TreeNode() );
			SetText();
			this.ImageIndex = 0;
			this.SelectedImageIndex = 0;
		}

		private void SetText()
		{
			this.Text = MainForm.GetObjectAsString(obj, this.Context);
		}

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

		public virtual void OnExpand()
		{
			AddChildren();
		}

		public virtual void AddChildren()
		{
			this.Nodes.Clear() ;
			foreach (IPropertyMap propertyMap in this.classMap.GetAllPropertyMaps() )
			{
				TreeNode child = new PropertyTreeNode(this.context, this.obj,  propertyMap.Name);
				this.Nodes.Add(child);
//				if (propertyMap.ReferenceType != ReferenceType.None)
//				{
//				}				
			}
			foreach (MethodInfo methodInfo in obj.GetType().GetMethods())
			{
				bool show = ShowMethod(methodInfo);
				if (show)
				{
					TreeNode child = new MethodTreeNode(this.context, this.obj,  methodInfo);
					this.Nodes.Add(child);									
				}
			} 
		}

		private bool ShowMethod(MethodInfo methodInfo)
		{
			bool show = true;
			if (!(MainForm.ShowMixinMethods))
			{
				if (MainForm.IsMixinMethod(methodInfo.Name))
				{
					show = false;
				}
			}
			if (show)
			{
				if (!(MainForm.ShowGetAndSetMethods))
				{
					if (MainForm.IsGetOrSetMethod(methodInfo.Name))
					{
						show = false;
					}
				}					
			}
			if (show)
			{
				if (!(MainForm.ShowObjectMethods))
				{
					if (MainForm.IsObjectMethod(methodInfo.Name))
					{
						show = false;
					}
				}					
			}
			return show;
		}

		public virtual void Refresh()
		{
			SetText();
		}
	}
}
