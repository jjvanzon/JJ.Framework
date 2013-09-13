using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using System.Collections;
using Puzzle.NAspect.Framework.ConfigurationElements;
using Puzzle.NAspect.Visualization.Nodes;
using Puzzle.NAspect.Visualization.PropertyHolders;
using Puzzle.NAspect.Visualization.Presentation;
using Puzzle.NAspect.Visualization.Items;
using System.IO;
using System.Xml;

namespace Puzzle.NAspect.Visualization
{
    public partial class VisualizeProjectForm : Form
    {
        public VisualizeProjectForm()
        {
            InitializeComponent();
        }

        #region Private fields

        private string projectFileName = "";
        private string configFileName = "";

        private PresentationModel model = null;

        private AspectMatcher aspectMatcher = new AspectMatcher();
        private PointcutMatcher pointcutMatcher = new PointcutMatcher();

        private IList assemblies = new ArrayList();

        private object selected = null;
        private object listViewMaster = null;

        #endregion

        #region Refresh

        private void RefreshAll()
        {
            ClearApplicationCache();
            RefreshTreeViews();
            RefreshListView();
            RefreshXml();
        }

        private void ClearApplicationCache()
        {
            if (model == null)
                return;

            foreach (PresentationAspect aspect in model.Aspects)
            {
                aspect.AppliedOnTypes.Clear();
                foreach (PresentationPointcut pointcut in aspect.Pointcuts)
                {
                    pointcut.AppliedOnMethods.Clear();
                }
            }
        }

        private void RefreshTreeViews()
        {
            if (assemblyTreeView.Nodes.Count < 1)
            {
                TreeViewManager.SetupProjectTreeView(assemblyTreeView, assemblies, model, aspectMatcher, pointcutMatcher);
            }
            else
                TreeViewManager.RefreshTreeView(assemblyTreeView);

            if (configTreeView.Nodes.Count < 1)
            {
                if (model != null)
                    TreeViewManager.SetupAspectTreeView(configTreeView, assemblies, model, aspectMatcher, pointcutMatcher);
            }
            else
                TreeViewManager.RefreshTreeView(configTreeView);

        }

        private void RefreshListView()
        {
            if (listViewMaster == null)
                return;

            if (listViewMaster is PresentationAspect)
                ShowAspectTypes((PresentationAspect)listViewMaster);
            if (listViewMaster is PresentationPointcut)
                ShowPointcutMethods((PresentationPointcut)listViewMaster);
            if (listViewMaster is PresentationInterceptor)
                ShowInterceptorMethods((PresentationInterceptor)listViewMaster);
        }

        private void RefreshXml()
        {
            if (model == null)
                return;

            xmlTextBox.Text = Serialization.SerializeConfiguration(model);
        }

        #endregion

        #region Selecting

        private void SelectObject(object obj)
        {
            PresentationAspect aspect = obj as PresentationAspect;
            if (aspect != null)
            {
                propertyGrid.SelectedObject = new AspectProperties(aspect);
                ShowAspectTypes(aspect);
            }

            PresentationAspectTarget aspectTarget = obj as PresentationAspectTarget;
            if (aspectTarget != null)
                propertyGrid.SelectedObject = new AspectTargetProperties(aspectTarget);

            PresentationMixin mixin = obj as PresentationMixin;
            if (mixin != null)
                propertyGrid.SelectedObject = new MixinProperties(mixin);

            PresentationPointcut pointcut = obj as PresentationPointcut;
            if (pointcut != null)
            {
                propertyGrid.SelectedObject = new PointcutProperties(pointcut);
                ShowPointcutMethods(pointcut);
            }
            PresentationPointcutTarget pointcutTarget = obj as PresentationPointcutTarget;
            if (pointcutTarget != null)
                propertyGrid.SelectedObject = new PointcutTargetProperties(pointcutTarget);

            PresentationInterceptor interceptor = obj as PresentationInterceptor;
            if (interceptor != null)
            {
                propertyGrid.SelectedObject = new InterceptorProperties(interceptor);
                ShowInterceptorMethods(interceptor); 
            }

            Type type = obj as Type;
            if (type != null)
                propertyGrid.SelectedObject = new TypeProperties(type);

        }

        #endregion

        #region Actions

        #region I/O

        #region Assembly

        private void AddAssembly()
        {
            openFileDialog1.Filter = "Assembly files|*.dll|Executable files|*.exe";
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (openFileDialog1.FileName != "")
                {
                    try
                    {
                        Assembly asm = Assembly.LoadFile(openFileDialog1.FileName);
                        foreach (Assembly exists in assemblies)
                        {
                            if (exists.FullName == asm.FullName)
                            {
                                MessageBox.Show("The assembly is already included in the project!");
                                return;
                            }
                        }
                        assemblies.Add(asm);
                        RefreshAll();
                    } 
                    catch (Exception ex) 
                    {
                        HandleException(ex);
                    }                   
                }
            }
        }

        #endregion

        #region Configuration

        private void OpenConfiguration()
        {
            openFileDialog1.Filter = "Configuration files|*.config|Xml files|*.xml|All files|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (openFileDialog1.FileName != "")
                {
                    try
                    {
                        ClearControls();

                        IEngine engine = EngineFactory.FromFile(openFileDialog1.FileName, true);
                        model = PresentationModelManager.CreatePresentationModel(engine);

                        configFileName = openFileDialog1.FileName;
                        
                        RefreshAll();
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                }
            }
        }

        private void SaveConfig()
        {
            SaveConfig(false);
        }

        private void SaveConfig(bool saveAs)
        {
        }

        private void SaveAll()
        {
            SaveProject();
            SaveConfig();
        }

        #endregion

        #region Project

        private void OpenProject()
        {
            openFileDialog1.Filter = "Xml files|*.xml|All files|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (openFileDialog1.FileName != "")
                {
                    try
                    {
                        CloseProject();

                        FileInfo file = new FileInfo(openFileDialog1.FileName);
                        string xml = "";
                        using (StreamReader sr = file.OpenText())
                        {
                            xml = sr.ReadToEnd();
                        }

                        if (xml != "")
                        {
                            Serialization.DeserializeProject(xml, assemblies, ref configFileName);

                            if (configFileName != "")
                            {
                                IEngine engine = EngineFactory.FromFile(configFileName, true);
                                model = PresentationModelManager.CreatePresentationModel(engine);
                            }

                            RefreshAll();
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                }
            }
        }

        private void CloseProject()
        {
            ClearControls();
            assemblies.Clear();
            projectFileName = "";
            configFileName = "";
            model = null;
            selected = null;
            listViewMaster = null;
        }

        private void SaveProject()
        {
            SaveProject(false);
        }

        private void SaveProject(bool saveAs)
        {
            string fileName = projectFileName;
            if (fileName == "")
                saveAs = true;

            if (fileName == "")
                fileName = "New project.xml";

            if (saveAs)
            {
                saveFileDialog1.FileName = fileName;

                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                fileName = saveFileDialog1.FileName;
            }

            if (fileName == "")
                return;

            string xml = Serialization.SerializeProject(assemblies, configFileName);

            FileInfo file = new FileInfo(fileName);
            using (StreamWriter sw = file.CreateText())
            {
                sw.Write(xml);
            }
        }

        #endregion

        #endregion

        #region Clearing

        private void ClearControls()
        {
            assemblyTreeView.Nodes.Clear();
            configTreeView.Nodes.Clear();
            applicationListView.Clear();
            propertyGrid.SelectedObject = null;
            xmlTextBox.Text = "";
        }

        #endregion

        #region Removal

        private void RemoveAssembly(Assembly asm)
        {
            assemblies.Remove(asm);
            RefreshAll();
        }

        private void RemoveAspect(PresentationAspect aspect)
        {
            model.Aspects.Remove(aspect);
            RefreshAll();
        }

        private void RemoveAspectTarget(PresentationAspectTarget aspectTarget)
        {
            aspectTarget.Aspect.Targets.Remove(aspectTarget);
            RefreshAll();
        }

        private void RemovePointcut(PresentationPointcut pointcut)
        {
            pointcut.Aspect.Pointcuts.Remove(pointcut);
            RefreshAll();
        }

        private void RemoveMixin(PresentationMixin mixin)
        {
            mixin.Aspect.Mixins.Remove(mixin);
            RefreshAll();
        }

        private void RemovePointcutTarget(PresentationPointcutTarget pointcutTarget)
        {
            pointcutTarget.Pointcut.Targets.Remove(pointcutTarget);
            RefreshAll();
        }

        private void RemoveInterceptor(PresentationInterceptor interceptor)
        {
            interceptor.Pointcut.Interceptors.Remove(interceptor);
            RefreshAll();
        }

        #endregion

        #region Addition

        private void AddAspectTarget(PresentationAspect aspect)
        {
            PresentationAspectTarget aspectTarget = new PresentationAspectTarget(aspect);
            aspectTarget.Signature = "[New Aspect Target]";
            aspectTarget.TargetType = AspectTargetType.Signature;
            aspect.Targets.Add(aspectTarget);
            RefreshAll();
        }

        private void AddPointcut(PresentationAspect aspect)
        {
            PresentationPointcut pointcut = new PresentationPointcut(aspect);
            pointcut.Name = "New Pointcut";
            aspect.Pointcuts.Add(pointcut);
            RefreshAll();
        }

        private void AddMixin(PresentationAspect aspect)
        {
            PresentationMixin mixin = new PresentationMixin(aspect);
            mixin.TypeName = "[New Mixin]";
            aspect.Mixins.Add(mixin);
            RefreshAll();
        }

        private void AddPointcutTarget(PresentationPointcut pointcut)
        {
            PresentationPointcutTarget pointcutTarget = new PresentationPointcutTarget(pointcut);
            pointcutTarget.Signature = "[New Pointcut Target]";
            pointcutTarget.TargetType = PointcutTargetType.Signature;
            pointcut.Targets.Add(pointcutTarget);
            RefreshAll();
        }

        private void AddInterceptor(PresentationPointcut pointcut)
        {
            PresentationInterceptor interceptor = new PresentationInterceptor(pointcut);
            interceptor.TypeName = "[New Interceptor]";
            pointcut.Interceptors.Add(interceptor);
            RefreshAll();
        }

        #endregion

        #endregion

        #region ListView

        private void ShowAspectTypes(PresentationAspect aspect)
        {
            listViewMaster = aspect;

            applicationListView.BeginUpdate();
            applicationListView.Clear();

            applicationListView.Columns.Add("Name", 250);
            applicationListView.Columns.Add("Assembly", 250);

            foreach (Type type in aspect.AppliedOnTypes)
            {
                TypeItem item = new TypeItem(type);
                applicationListView.Items.Add(item);
            }

            applicationListView.EndUpdate();
        }

        private void ShowPointcutMethods(PresentationPointcut pointcut)
        {
            listViewMaster = pointcut;

            ShowAppliedMethods(pointcut.AppliedOnMethods);
        }

        private void ShowInterceptorMethods(PresentationInterceptor interceptor)
        {
            listViewMaster = interceptor;

            ShowAppliedMethods(interceptor.AppliedOnMethods);
        }

        private void ShowAppliedMethods(IList methods)
        {
            applicationListView.BeginUpdate();
            applicationListView.Clear();

            applicationListView.Columns.Add("Name", 250);
            applicationListView.Columns.Add("Type", 250);
            applicationListView.Columns.Add("Assembly", 250);

            foreach (MethodBase method in methods)
            {
                MethodItem item = new MethodItem(method);
                applicationListView.Items.Add(item);
            }

            applicationListView.EndUpdate();
        }

        #endregion

        #region EventHandlers

        #region PropertyGrid

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            RefreshAll();
        }

        #endregion

        #region TreeViews

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectObject(((NodeBase) e.Node).Object);
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectObject(((NodeBase)e.Node).Object);
        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            TreeViewMouseUp(assemblyTreeView, e);
        }

        private void treeView2_MouseUp(object sender, MouseEventArgs e)
        {
            TreeViewMouseUp(configTreeView, e);
        }

        private void configTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeViewItemDrag(e, sender);
        }

        private void configTreeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeViewDragDrop((TreeView)sender, e);
        }

        private void configTreeView_DragEnter(object sender, DragEventArgs e)
        {
            TreeViewDragEnter(e);
        }

        private void configTreeView_DragLeave(object sender, EventArgs e)
        {
            TurnOffTreeDragHilite();
        }

        private void configTreeView_DragOver(object sender, DragEventArgs e)
        {
            TreeViewDragOver((TreeView)sender, e);
        }

        private void assemblyTreeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeViewDragDrop((TreeView)sender, e);
        }

        private void assemblyTreeView_DragEnter(object sender, DragEventArgs e)
        {
            TreeViewDragEnter(e);
        }

        private void assemblyTreeView_DragLeave(object sender, EventArgs e)
        {
            TurnOffTreeDragHilite();
        }

        private void assemblyTreeView_DragOver(object sender, DragEventArgs e)
        {
            TreeViewDragOver((TreeView)sender, e);
        }

        private void assemblyTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeViewItemDrag(e, sender);
        }


        #endregion

        #region MenuStrip

        private void addAssemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAssembly();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void openConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenConfiguration();
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject(true);
        }

        private void saveConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void saveConfigAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveConfig(true);
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void saveAllToolStripButton_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #region Context Menus


        private void removeAssemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembly asm = selected as Assembly;
            if (asm != null)
                RemoveAssembly(asm);
        }

        private void removeAspectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresentationAspect aspect = selected as PresentationAspect;
            if (aspect != null)
                RemoveAspect(aspect);
        }

        private void removeAspectTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresentationAspectTarget aspectTarget = selected as PresentationAspectTarget;
            if (aspectTarget != null)
                RemoveAspectTarget(aspectTarget);
        }

        private void removeMixinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresentationMixin mixin = selected as PresentationMixin;
            if (mixin != null)
                RemoveMixin(mixin);
        }

        private void removePointcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresentationPointcut pointcut = selected as PresentationPointcut;
            if (pointcut != null)
                RemovePointcut(pointcut);
        }

        private void removePointcutTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresentationPointcutTarget pointcutTarget = selected as PresentationPointcutTarget;
            if (pointcutTarget != null)
                RemovePointcutTarget(pointcutTarget);
        }

        private void removeInterceptorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresentationInterceptor interceptor = selected as PresentationInterceptor;
            if (interceptor != null)
                RemoveInterceptor(interceptor);
        }

        private void addTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresentationAspect aspect = selected as PresentationAspect;
            if (aspect != null)
                AddAspectTarget(aspect);
        }

        private void addPointcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresentationAspect aspect = selected as PresentationAspect;
            if (aspect != null)
                AddPointcut(aspect);        
        }

        private void addMixinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresentationAspect aspect = selected as PresentationAspect;
            if (aspect != null)
                AddMixin(aspect);
        }

        private void addPointcutTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresentationPointcut pointcut = selected as PresentationPointcut;
            if (pointcut != null)
                AddPointcutTarget(pointcut);
        }

        private void addInterceptorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresentationPointcut pointcut = selected as PresentationPointcut;
            if (pointcut != null)
                AddInterceptor(pointcut);
        }

        #endregion

        #endregion

        #region Event Helpers

        #region TreeView

        #region Mouse

        private void TreeViewMouseUp(TreeView treeView, MouseEventArgs e)
        {
            TreeNode onNode = treeView.GetNodeAt(new Point(e.X, e.Y));

            if (onNode != null)
            {
                if (treeView.SelectedNode != onNode)
                    treeView.SelectedNode = onNode;

                if (e.Button == MouseButtons.Right)
                {
                    NodeBase nodeBase = onNode as NodeBase;
                    selected = nodeBase.Object;

                    if (onNode is AspectNode)
                        aspectContextMenuStrip.Show(treeView, new Point(e.X, e.Y));

                    if (onNode is AspectTargetNode)
                        aspectTargetContextMenuStrip.Show(treeView, new Point(e.X, e.Y));

                    if (onNode is MixinNode)
                        mixinContextMenuStrip.Show(treeView, new Point(e.X, e.Y));

                    if (onNode is PointcutNode)
                        pointcutContextMenuStrip.Show(treeView, new Point(e.X, e.Y));

                    if (onNode is PointcutTargetNode)
                        pointcutTargetContextMenuStrip.Show(treeView, new Point(e.X, e.Y));

                    if (onNode is InterceptorNode)
                        interceptorContextMenuStrip.Show(treeView, new Point(e.X, e.Y));

                    if (onNode is AssemblyNode)
                        assemblyContextMenuStrip.Show(treeView, new Point(e.X, e.Y));

                }
            }
            else
            {
                selected = null;
            }

        }

        #endregion

        #region DragDrop

        private void TreeViewDragDrop(TreeView treeView, DragEventArgs e)
        {
            Point pt = treeView.PointToClient(new Point(e.X, e.Y));

            int x = pt.X;
            int y = pt.Y;
            string data = "";

            NodeBase overNode = (NodeBase)treeView.GetNodeAt(new Point(x, y));

            if (e.Data.GetDataPresent(typeof(string)))
            {
                data = (string)e.Data.GetData(typeof(string));
            }

            if (data == null)
                data = "";

            if (data.Length > 0)
            {
                string header;
                XmlNode payload = ParseDragData(data, out header);
                if (header == "aspect")
                {
                    PresentationAspect dropAspect = GetDropAspect(payload);
                    if (overNode != null)
                    {
                        if (overNode is TypeNode)
                        {
                            if (dropAspect != null)
                            {
                                dropAspect.AddTypeTarget(((TypeNode)overNode).Type);
                                RefreshAll();
                            }
                        }
                    }
                }
                if (header == "pointcut")
                {
                    PresentationPointcut dropPointcut = GetDropPointcut(payload);
                    if (overNode != null)
                    {
                        if (overNode is TypeNode)
                        {
                            if (dropPointcut != null)
                            {
                                dropPointcut.AddTypeTarget(((TypeNode)overNode).Type);
                                RefreshAll();
                            }
                        }
                        if (overNode is MethodNode)
                        {
                            if (dropPointcut != null)
                            {
                                MethodNode methodNode = overNode as MethodNode;
                                if (methodNode.CanBeProxied())
                                {
                                    dropPointcut.AddMethodTarget(methodNode.MethodBase, methodNode.Type);
                                    RefreshAll();
                                }
                            }
                        }
                    }
                }
                if (header == "interceptor")
                {
                    PresentationInterceptor dropInterceptor = GetDropInterceptor(payload);
                    if (overNode != null)
                    {
                        if (overNode is TypeNode)
                        {
                            if (dropInterceptor != null)
                            {
                                dropInterceptor.AddTypeTarget(((TypeNode)overNode).Type);
                                RefreshAll();
                            }
                        }
                        if (overNode is MethodNode)
                        {
                            if (dropInterceptor != null)
                            {
                                MethodNode methodNode = overNode as MethodNode;
                                if (methodNode.CanBeProxied())
                                {
                                    dropInterceptor.AddMethodTarget(methodNode.MethodBase, methodNode.Type);
                                    RefreshAll();
                                }
                            }
                        }
                    }
                }
            }

            TurnOffTreeDragHilite();
        }

        private void TreeViewItemDrag(ItemDragEventArgs e, object sender)
        {
            NodeBase node = (NodeBase)e.Item;
            object obj = node.Object;
            string dragMsg = GetObjectXml(obj);
            if (dragMsg != "")
                ((Control)sender).DoDragDrop(dragMsg, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void TreeViewDragEnter(DragEventArgs e)
        {
            string data = "";

            if (e.Data.GetDataPresent(typeof(string)))
            {
                data = (string)e.Data.GetData(typeof(string));
            }

            if (data == null)
                data = "";

            if (data.Length > 0)
            {
                string header;
                XmlNode payload = ParseDragData(data, out header);
                if (header == "aspect")
                {
                    e.Effect = DragDropEffects.Copy;
                }
                if (header == "pointcut")
                {
                    e.Effect = DragDropEffects.Copy;
                }
                if (header == "interceptor")
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private bool insideTreeViewDragOver = false;

        private void TreeViewDragOver(TreeView treeView, DragEventArgs e)
        {
            if (insideTreeViewDragOver)
                return;

            insideTreeViewDragOver = true;

            try
            {
                Point pt = treeView.PointToClient(new Point(e.X, e.Y));

                int x = pt.X;
                int y = pt.Y;
                string data = "";
                bool doHilite = false;

                NodeBase overNode = (NodeBase)treeView.GetNodeAt(new Point(x, y));

                if (e.Data.GetDataPresent(typeof(string)))
                {
                    data = (string)e.Data.GetData(typeof(string));
                }

                if (data == null)
                    data = "";

                if (data.Length > 0)
                {
                    string header;
                    XmlNode payload = ParseDragData(data, out header);
                    if (header == "aspect")
                    {
                        if (overNode != null)
                        {
                            if (overNode is TypeNode)
                            {
                                doHilite = true;
                            }
                        }
                    }
                    if (header == "pointcut" || header == "interceptor")
                    {
                        if (overNode != null)
                        {
                            if (overNode is TypeNode)
                            {
                                doHilite = true;
                            }
                            if (overNode is MethodNode)
                            {
                                if (((MethodNode) overNode).CanBeProxied())
                                    doHilite = true;
                            }
                        }
                    }
                }

                if (doHilite)
                {
                    e.Effect = DragDropEffects.Copy;
                    TurnOnTreeDragHilite(overNode);
                }
                else
                    TurnOffTreeDragHilite();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                insideTreeViewDragOver = false;
            }
        }

        private NodeBase m_TreeDragHilited = null;

        private void TurnOnTreeDragHilite(NodeBase node)
        {
            if (node != m_TreeDragHilited)
                TurnOffTreeDragHilite();

            m_TreeDragHilited = node;

            m_TreeDragHilited.BackColor = Color.DarkBlue;
            m_TreeDragHilited.ForeColor = Color.White;
        }

        private void TurnOffTreeDragHilite()
        {
            if (m_TreeDragHilited != null)
            {
                m_TreeDragHilited.BackColor = Color.White;
                m_TreeDragHilited.ForeColor = Color.Black;
                m_TreeDragHilited = null;
            }
        }


        private static string GetObjectXml(object obj)
        {
            PresentationAspect aspect = obj as PresentationAspect;
            if (aspect != null)
            {
                return "xml:<aspect><name>" + aspect.Name + "</name></aspect>";
            }
            PresentationPointcut pointcut = obj as PresentationPointcut;
            if (pointcut != null)
            {
                return String.Format("xml:<pointcut><aspect>{0}</aspect><pointcut>{1}</pointcut></pointcut>", 
                    pointcut.Aspect.Name,
                    pointcut.Name);
            }
            PresentationInterceptor interceptor = obj as PresentationInterceptor;
            if (interceptor != null)
            {
                return String.Format("xml:<interceptor><aspect>{0}</aspect><pointcut>{1}</pointcut><type-name>{2}</type-name></interceptor>",
                    interceptor.Pointcut.Aspect.Name,
                    interceptor.Pointcut.Name,
                    interceptor.TypeName);
            }
            return "";
        }

        private XmlNode ParseDragData(string data, out string header)
        {
            header = data;
            XmlNode payload = null;
            if (data.StartsWith("xml:"))
            {
                data = data.Substring(4);
                data = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + data;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(data);

                payload = xmlDoc.SelectSingleNode("aspect");
                if (payload != null)
                {
                    header = "aspect";
                    return payload;
                }

                payload = xmlDoc.SelectSingleNode("pointcut");
                if (payload != null)
                {
                    header = "pointcut";
                    return payload;
                }

                payload = xmlDoc.SelectSingleNode("interceptor");
                if (payload != null)
                {
                    header = "interceptor";
                    return payload;
                }

            }
            return payload;
        }

        private PresentationAspect GetDropAspect(XmlNode payload)
        {
            XmlNode nameNode = payload.SelectSingleNode("name");
            return model.GetAspect(nameNode.InnerText);
        }

        private PresentationPointcut GetDropPointcut(XmlNode payload)
        {
            XmlNode aspectNode = payload.SelectSingleNode("aspect");
            XmlNode pointcutNode = payload.SelectSingleNode("pointcut");
            PresentationAspect aspect = model.GetAspect(aspectNode.InnerText);
            if (aspect != null)
            {
                return aspect.GetPointcut(pointcutNode.InnerText);
            }
            return null;
        }

        private PresentationInterceptor GetDropInterceptor(XmlNode payload)
        {
            XmlNode aspectNode = payload.SelectSingleNode("aspect");
            XmlNode pointcutNode = payload.SelectSingleNode("pointcut");
            XmlNode typeNameNode = payload.SelectSingleNode("type-name");
            PresentationAspect aspect = model.GetAspect(aspectNode.InnerText);
            if (aspect != null)
            {
                PresentationPointcut pointcut = aspect.GetPointcutWithNameAndInterceptor(pointcutNode.InnerText, typeNameNode.InnerText);
                if (pointcut != null)
                {
                    PresentationInterceptor interceptor = pointcut.GetInterceptor(typeNameNode.InnerText);
                    return interceptor;
                }
            }
            return null;
        }

        #endregion

        #endregion

        #endregion

        #region Exception Handling

        private void HandleException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        #endregion

        private void VisualizeProjectForm_Load(object sender, EventArgs e)
        {
            //TreeViewPainter.AttachTreeView(assemblyTreeView,2);
            //TreeViewPainter.AttachTreeView(configTreeView,1);
        }
    }
}
