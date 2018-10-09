using System;
using System.Collections;
using System.Windows.Forms;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for PropertyTreeNode.
	/// </summary>
	public class PropertyTreeNode : ObjectTreeNode
	{
		public PropertyTreeNode(IContext context, object obj, string propertyName) : base(context, obj)
		{
			this.PropertyMap = this.ClassMap.MustGetPropertyMap(propertyName);
			this.Text = propertyName;
			this.ImageIndex = 1;
			this.SelectedImageIndex = 1;
			if (this.PropertyMap.ReferenceType == ReferenceType.None)
				this.Nodes.Clear() ;
		}
		
		public override void OnExpand()
		{
			AddChildren();
		}

		public override void AddChildren()
		{
			this.Nodes.Clear() ;

			if (this.PropertyMap.ReferenceType != ReferenceType.None)
			{
				this.Context.ObjectManager.EnsurePropertyIsLoaded(this.Obj, this.PropertyMap.Name);
	
				if (this.PropertyMap.IsCollection)
				{
					IList list = (IList) this.Obj.GetType().GetProperty(this.PropertyMap.Name).GetValue(this.Obj, null);
					foreach (object refObj in list)
					{
						TreeNode child = new ObjectTreeNode(this.Context, refObj, this.Obj, this.PropertyMap);
						this.Nodes.Add(child);
					}							
				}
				else
				{
					object refObj = this.Obj.GetType().GetProperty(this.PropertyMap.Name).GetValue(this.Obj, null);
					if (refObj != null)
					{
						TreeNode child = new ObjectTreeNode(this.Context, refObj, this.Obj, this.PropertyMap);
						this.Nodes.Add(child);
					}							
				}				
			}
		}

		public override void Refresh()
		{
			if (this.IsExpanded)
			{
				if (this.PropertyMap.ReferenceType != ReferenceType.None)
				{
					if (this.PropertyMap.IsCollection)
					{
						if (this.Nodes.Count > 0)
						{
							if (!(this.Nodes[0] is ObjectTreeNode))
								this.Nodes.Clear() ;
						}
						IList added = new ArrayList(); 
						IList list = (IList) this.Obj.GetType().GetProperty(this.PropertyMap.Name).GetValue(this.Obj, null);
						foreach (object refObj in list)
						{
							bool found = false;
							foreach (ObjectTreeNode test in this.Nodes) 
							{
								if (test.Obj == refObj)
								{
									added.Add(test);
									found = true;
									break;
								}	
							}
							if (found == false)
							{
								TreeNode child = new ObjectTreeNode(this.Context, refObj, this.Obj, this.PropertyMap);
								this.Nodes.Add(child);						
								added.Add(child);
							}
						}	
						IList remove = new ArrayList();		
						foreach (ObjectTreeNode removeNode in this.Nodes)
						{
							if (!added.Contains(removeNode))
							{
								remove.Add(removeNode);
							}
						}
						foreach (ObjectTreeNode removeNode in remove)
						{
							this.Nodes.Remove(removeNode);
						}

					}
					else
					{
						object refObj = this.Obj.GetType().GetProperty(this.PropertyMap.Name).GetValue(this.Obj, null);
						if (refObj != null)
						{
							if (this.Nodes.Count > 0)
							{
								if (this.Nodes[0] is ObjectTreeNode)
								{
									ObjectTreeNode child = (ObjectTreeNode) this.Nodes[0];
									if (child.Obj != refObj)
									{
										this.Nodes.Clear() ;
									}							
								}
								else
								{
									this.Nodes.Clear() ;
								}
							}
							if (this.Nodes.Count < 1)
							{
								TreeNode child = new ObjectTreeNode(this.Context, refObj, this.Obj, this.PropertyMap);
								this.Nodes.Add(child);						
							}
						}
						else
						{
							if (this.Nodes.Count > 0)
							{
								this.Nodes.Clear() ;
							}					
						}
					}							
				}
			}
		}
	}
}
