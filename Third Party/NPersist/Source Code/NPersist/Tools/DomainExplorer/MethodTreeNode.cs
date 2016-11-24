using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for MethodTreeNode.
	/// </summary>
	public class MethodTreeNode : ObjectTreeNode
	{
		public MethodTreeNode(IContext context, object obj, MethodInfo methodInfo) : base(context, obj)
		{
			this.methodInfo = methodInfo;
			SetText();
			this.ImageIndex = 6;
			this.SelectedImageIndex = 6;
			this.Nodes.Clear() ;
		}

		public void SetText()
		{
			string text = methodInfo.Name + "(";
			ParameterInfo[] paramInfos = methodInfo.GetParameters();
			foreach (ParameterInfo paramInfo in paramInfos )
			{
				text += paramInfo.ParameterType.ToString()  + " " + paramInfo.Name + ", ";
			}
			if (paramInfos.Length > 0)
			{
				text = text.Substring(0, text.Length - 2);
			}
			this.Text = text + ")";
		}

		#region Property  MethodInfo
		
		private MethodInfo methodInfo;
		
		public MethodInfo MethodInfo
		{
			get { return this.methodInfo; }
			set { this.methodInfo = value; }
		}
		
		#endregion

		public object InvokeMethod(MethodProperties methodProperties)
		{
			object[] parameters = new object[this.methodInfo.GetParameters().Length];
			int i = 0;
			foreach (object propInfo in methodProperties.GetProperties() )
			{
				MethodParameterTypeDescriptor param = propInfo as MethodParameterTypeDescriptor;
				if (param != null)
				{
					parameters[i] = param.Value ;
					i++;					
				}
			}
			return this.methodInfo.Invoke(this.Obj, parameters);
		}

		public override void OnExpand()
		{
			AddChildren();
		}

		public override void AddChildren()
		{
//			this.Nodes.Clear() ;
//
//			this.Context.ObjectManager.EnsurePropertyIsLoaded(this.Obj, this.PropertyMap.Name);
//	
//			if (this.PropertyMap.IsCollection)
//			{
//				IList list = (IList) this.Obj.GetType().GetProperty(this.PropertyMap.Name).GetValue(this.Obj, null);
//				foreach (object refObj in list)
//				{
//					TreeNode child = new ObjectTreeNode(this.Context, refObj, this.Obj, this.PropertyMap);
//					this.Nodes.Add(child);
//				}							
//			}
//			else
//			{
//				object refObj = this.Obj.GetType().GetProperty(this.PropertyMap.Name).GetValue(this.Obj, null);
//				if (refObj != null)
//				{
//					TreeNode child = new ObjectTreeNode(this.Context, refObj, this.Obj, this.PropertyMap);
//					this.Nodes.Add(child);
//				}							
//			}
		}

		public override void Refresh()
		{
//			if (this.IsExpanded)
//			{
//				if (this.PropertyMap.IsCollection)
//				{
//					if (this.Nodes.Count > 0)
//					{
//						if (!(this.Nodes[0] is ObjectTreeNode))
//							this.Nodes.Clear() ;
//					}
//					IList added = new ArrayList(); 
//					IList list = (IList) this.Obj.GetType().GetProperty(this.PropertyMap.Name).GetValue(this.Obj, null);
//					foreach (object refObj in list)
//					{
//						bool found = false;
//						foreach (ObjectTreeNode test in this.Nodes) 
//						{
//							if (test.Obj == refObj)
//							{
//								added.Add(test);
//								found = true;
//								break;
//							}	
//						}
//						if (found == false)
//						{
//							TreeNode child = new ObjectTreeNode(this.Context, refObj, this.Obj, this.PropertyMap);
//							this.Nodes.Add(child);						
//							added.Add(child);
//						}
//					}	
//					IList remove = new ArrayList();		
//					foreach (ObjectTreeNode removeNode in this.Nodes)
//					{
//						if (!added.Contains(removeNode))
//						{
//							remove.Add(removeNode);
//						}
//					}
//					foreach (ObjectTreeNode removeNode in remove)
//					{
//						this.Nodes.Remove(removeNode);
//					}
//
//				}
//				else
//				{
//					object refObj = this.Obj.GetType().GetProperty(this.PropertyMap.Name).GetValue(this.Obj, null);
//					if (refObj != null)
//					{
//						if (this.Nodes.Count > 0)
//						{
//							if (this.Nodes[0] is ObjectTreeNode)
//							{
//								ObjectTreeNode child = (ObjectTreeNode) this.Nodes[0];
//								if (child.Obj != refObj)
//								{
//									this.Nodes.Clear() ;
//								}							
//							}
//							else
//							{
//								this.Nodes.Clear() ;
//							}
//						}
//						if (this.Nodes.Count < 1)
//						{
//							TreeNode child = new ObjectTreeNode(this.Context, refObj, this.Obj, this.PropertyMap);
//							this.Nodes.Add(child);						
//						}
//					}
//					else
//					{
//						if (this.Nodes.Count > 0)
//						{
//							this.Nodes.Clear() ;
//						}					
//					}
//				}							
//			}
		}
	}
}
