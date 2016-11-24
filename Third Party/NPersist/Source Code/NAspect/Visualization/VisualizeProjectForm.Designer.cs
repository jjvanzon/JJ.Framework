namespace Puzzle.NAspect.Visualization
{
    partial class VisualizeProjectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizeProjectForm));
            this.assemblyTreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.configTreeView = new System.Windows.Forms.TreeView();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.aspectTargetContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeAspectTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aspectContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPointcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMixinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAspectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationListView = new System.Windows.Forms.ListView();
            this.pointcutContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addPointcutTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addInterceptorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePointcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mixinContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeMixinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointcutTargetContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removePointcutTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interceptorContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeInterceptorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.assemblyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeAssemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addAssemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.xmlTextBox = new System.Windows.Forms.TextBox();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.aspectTargetContextMenuStrip.SuspendLayout();
            this.aspectContextMenuStrip.SuspendLayout();
            this.pointcutContextMenuStrip.SuspendLayout();
            this.mixinContextMenuStrip.SuspendLayout();
            this.pointcutTargetContextMenuStrip.SuspendLayout();
            this.interceptorContextMenuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.assemblyContextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // assemblyTreeView
            // 
            this.assemblyTreeView.AllowDrop = true;
            this.assemblyTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assemblyTreeView.ImageIndex = 0;
            this.assemblyTreeView.ImageList = this.imageList1;
            this.assemblyTreeView.Location = new System.Drawing.Point(0, 0);
            this.assemblyTreeView.Name = "assemblyTreeView";
            this.assemblyTreeView.SelectedImageIndex = 0;
            this.assemblyTreeView.Size = new System.Drawing.Size(200, 519);
            this.assemblyTreeView.TabIndex = 2;
            this.assemblyTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.assemblyTreeView_DragDrop);
            this.assemblyTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.assemblyTreeView_DragOver);
            this.assemblyTreeView.DragLeave += new System.EventHandler(this.assemblyTreeView_DragLeave);
            this.assemblyTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.assemblyTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            this.assemblyTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.assemblyTreeView_DragEnter);
            this.assemblyTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.assemblyTreeView_ItemDrag);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "assembly.gif");
            this.imageList1.Images.SetKeyName(1, "class.gif");
            this.imageList1.Images.SetKeyName(2, "method2.gif");
            this.imageList1.Images.SetKeyName(3, "property.gif");
            this.imageList1.Images.SetKeyName(4, "aspect2.gif");
            this.imageList1.Images.SetKeyName(5, "mixin2.gif");
            this.imageList1.Images.SetKeyName(6, "pointcut2.gif");
            this.imageList1.Images.SetKeyName(7, "interceptor.gif");
            this.imageList1.Images.SetKeyName(8, "target2.gif");
            this.imageList1.Images.SetKeyName(9, "aspect_on_class.gif");
            this.imageList1.Images.SetKeyName(10, "intercepted_method.gif");
            this.imageList1.Images.SetKeyName(11, "aspects.gif");
            this.imageList1.Images.SetKeyName(12, "assemblies.gif");
            this.imageList1.Images.SetKeyName(13, "method2_grey.gif");
            // 
            // configTreeView
            // 
            this.configTreeView.AllowDrop = true;
            this.configTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configTreeView.ImageIndex = 0;
            this.configTreeView.ImageList = this.imageList1;
            this.configTreeView.Location = new System.Drawing.Point(0, 0);
            this.configTreeView.Name = "configTreeView";
            this.configTreeView.SelectedImageIndex = 0;
            this.configTreeView.Size = new System.Drawing.Size(182, 245);
            this.configTreeView.TabIndex = 5;
            this.configTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.configTreeView_DragDrop);
            this.configTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.configTreeView_DragOver);
            this.configTreeView.DragLeave += new System.EventHandler(this.configTreeView_DragLeave);
            this.configTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            this.configTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView2_MouseUp);
            this.configTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.configTreeView_DragEnter);
            this.configTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.configTreeView_ItemDrag);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(182, 271);
            this.propertyGrid.TabIndex = 7;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // aspectTargetContextMenuStrip
            // 
            this.aspectTargetContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeAspectTargetToolStripMenuItem});
            this.aspectTargetContextMenuStrip.Name = "aspectTargetContextMenuStrip";
            this.aspectTargetContextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // removeAspectTargetToolStripMenuItem
            // 
            this.removeAspectTargetToolStripMenuItem.Name = "removeAspectTargetToolStripMenuItem";
            this.removeAspectTargetToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.removeAspectTargetToolStripMenuItem.Text = "Remove";
            this.removeAspectTargetToolStripMenuItem.Click += new System.EventHandler(this.removeAspectTargetToolStripMenuItem_Click);
            // 
            // aspectContextMenuStrip
            // 
            this.aspectContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeAspectToolStripMenuItem});
            this.aspectContextMenuStrip.Name = "aspectContextMenuStrip";
            this.aspectContextMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTargetToolStripMenuItem,
            this.addPointcutToolStripMenuItem,
            this.addMixinToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // addTargetToolStripMenuItem
            // 
            this.addTargetToolStripMenuItem.Name = "addTargetToolStripMenuItem";
            this.addTargetToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.addTargetToolStripMenuItem.Text = "Target";
            this.addTargetToolStripMenuItem.Click += new System.EventHandler(this.addTargetToolStripMenuItem_Click);
            // 
            // addPointcutToolStripMenuItem
            // 
            this.addPointcutToolStripMenuItem.Name = "addPointcutToolStripMenuItem";
            this.addPointcutToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.addPointcutToolStripMenuItem.Text = "Pointcut";
            this.addPointcutToolStripMenuItem.Click += new System.EventHandler(this.addPointcutToolStripMenuItem_Click);
            // 
            // addMixinToolStripMenuItem
            // 
            this.addMixinToolStripMenuItem.Name = "addMixinToolStripMenuItem";
            this.addMixinToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.addMixinToolStripMenuItem.Text = "Mixin";
            this.addMixinToolStripMenuItem.Click += new System.EventHandler(this.addMixinToolStripMenuItem_Click);
            // 
            // removeAspectToolStripMenuItem
            // 
            this.removeAspectToolStripMenuItem.Name = "removeAspectToolStripMenuItem";
            this.removeAspectToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.removeAspectToolStripMenuItem.Text = "Remove";
            this.removeAspectToolStripMenuItem.Click += new System.EventHandler(this.removeAspectToolStripMenuItem_Click);
            // 
            // applicationListView
            // 
            this.applicationListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.applicationListView.Location = new System.Drawing.Point(0, 0);
            this.applicationListView.Name = "applicationListView";
            this.applicationListView.Size = new System.Drawing.Size(434, 519);
            this.applicationListView.SmallImageList = this.imageList1;
            this.applicationListView.TabIndex = 8;
            this.applicationListView.UseCompatibleStateImageBehavior = false;
            this.applicationListView.View = System.Windows.Forms.View.Details;
            // 
            // pointcutContextMenuStrip
            // 
            this.pointcutContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.removePointcutToolStripMenuItem});
            this.pointcutContextMenuStrip.Name = "pointcutContextMenuStrip";
            this.pointcutContextMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPointcutTargetToolStripMenuItem,
            this.addInterceptorToolStripMenuItem});
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.addToolStripMenuItem1.Text = "Add";
            // 
            // addPointcutTargetToolStripMenuItem
            // 
            this.addPointcutTargetToolStripMenuItem.Name = "addPointcutTargetToolStripMenuItem";
            this.addPointcutTargetToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.addPointcutTargetToolStripMenuItem.Text = "Target";
            this.addPointcutTargetToolStripMenuItem.Click += new System.EventHandler(this.addPointcutTargetToolStripMenuItem_Click);
            // 
            // addInterceptorToolStripMenuItem
            // 
            this.addInterceptorToolStripMenuItem.Name = "addInterceptorToolStripMenuItem";
            this.addInterceptorToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.addInterceptorToolStripMenuItem.Text = "Interceptor";
            this.addInterceptorToolStripMenuItem.Click += new System.EventHandler(this.addInterceptorToolStripMenuItem_Click);
            // 
            // removePointcutToolStripMenuItem
            // 
            this.removePointcutToolStripMenuItem.Name = "removePointcutToolStripMenuItem";
            this.removePointcutToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.removePointcutToolStripMenuItem.Text = "Remove";
            this.removePointcutToolStripMenuItem.Click += new System.EventHandler(this.removePointcutToolStripMenuItem_Click);
            // 
            // mixinContextMenuStrip
            // 
            this.mixinContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeMixinToolStripMenuItem});
            this.mixinContextMenuStrip.Name = "mixinContextMenuStrip";
            this.mixinContextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // removeMixinToolStripMenuItem
            // 
            this.removeMixinToolStripMenuItem.Name = "removeMixinToolStripMenuItem";
            this.removeMixinToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.removeMixinToolStripMenuItem.Text = "Remove";
            this.removeMixinToolStripMenuItem.Click += new System.EventHandler(this.removeMixinToolStripMenuItem_Click);
            // 
            // pointcutTargetContextMenuStrip
            // 
            this.pointcutTargetContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removePointcutTargetToolStripMenuItem});
            this.pointcutTargetContextMenuStrip.Name = "pointcutTargetContextMenuStrip";
            this.pointcutTargetContextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // removePointcutTargetToolStripMenuItem
            // 
            this.removePointcutTargetToolStripMenuItem.Name = "removePointcutTargetToolStripMenuItem";
            this.removePointcutTargetToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.removePointcutTargetToolStripMenuItem.Text = "Remove";
            this.removePointcutTargetToolStripMenuItem.Click += new System.EventHandler(this.removePointcutTargetToolStripMenuItem_Click);
            // 
            // interceptorContextMenuStrip
            // 
            this.interceptorContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeInterceptorToolStripMenuItem});
            this.interceptorContextMenuStrip.Name = "interceptorContextMenuStrip";
            this.interceptorContextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // removeInterceptorToolStripMenuItem
            // 
            this.removeInterceptorToolStripMenuItem.Name = "removeInterceptorToolStripMenuItem";
            this.removeInterceptorToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.removeInterceptorToolStripMenuItem.Text = "Remove";
            this.removeInterceptorToolStripMenuItem.Click += new System.EventHandler(this.removeInterceptorToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.saveAllToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(822, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "toolStripButton1";
            this.openToolStripButton.ToolTipText = "Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "toolStripButton2";
            this.saveToolStripButton.ToolTipText = "Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // saveAllToolStripButton
            // 
            this.saveAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAllToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveAllToolStripButton.Image")));
            this.saveAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAllToolStripButton.Name = "saveAllToolStripButton";
            this.saveAllToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveAllToolStripButton.Text = "toolStripButton1";
            this.saveAllToolStripButton.ToolTipText = "Save All";
            this.saveAllToolStripButton.Click += new System.EventHandler(this.saveAllToolStripButton_Click);
            // 
            // assemblyContextMenuStrip
            // 
            this.assemblyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeAssemblyToolStripMenuItem});
            this.assemblyContextMenuStrip.Name = "assemblyContextMenuStrip";
            this.assemblyContextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // removeAssemblyToolStripMenuItem
            // 
            this.removeAssemblyToolStripMenuItem.Name = "removeAssemblyToolStripMenuItem";
            this.removeAssemblyToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.removeAssemblyToolStripMenuItem.Text = "Remove";
            this.removeAssemblyToolStripMenuItem.Click += new System.EventHandler(this.removeAssemblyToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(822, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.addAssemblyToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeProjectToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveProjectToolStripMenuItem,
            this.saveProjectAsToolStripMenuItem,
            this.saveConfigToolStripMenuItem,
            this.saveConfigAsToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem,
            this.openConfigurationToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openProjectToolStripMenuItem.Text = "Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // openConfigurationToolStripMenuItem
            // 
            this.openConfigurationToolStripMenuItem.Name = "openConfigurationToolStripMenuItem";
            this.openConfigurationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openConfigurationToolStripMenuItem.Text = "Configuration";
            this.openConfigurationToolStripMenuItem.Click += new System.EventHandler(this.openConfigurationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // addAssemblyToolStripMenuItem
            // 
            this.addAssemblyToolStripMenuItem.Name = "addAssemblyToolStripMenuItem";
            this.addAssemblyToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.addAssemblyToolStripMenuItem.Text = "Add Assembly";
            this.addAssemblyToolStripMenuItem.Click += new System.EventHandler(this.addAssemblyToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(201, 6);
            // 
            // closeProjectToolStripMenuItem
            // 
            this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
            this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.closeProjectToolStripMenuItem.Text = "Close Project";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(201, 6);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // saveProjectAsToolStripMenuItem
            // 
            this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
            this.saveProjectAsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.saveProjectAsToolStripMenuItem.Text = "Save Project As...";
            this.saveProjectAsToolStripMenuItem.Click += new System.EventHandler(this.saveProjectAsToolStripMenuItem_Click);
            // 
            // saveConfigToolStripMenuItem
            // 
            this.saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            this.saveConfigToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.saveConfigToolStripMenuItem.Text = "Save Configuration";
            this.saveConfigToolStripMenuItem.Click += new System.EventHandler(this.saveConfigToolStripMenuItem_Click);
            // 
            // saveConfigAsToolStripMenuItem
            // 
            this.saveConfigAsToolStripMenuItem.Name = "saveConfigAsToolStripMenuItem";
            this.saveConfigAsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.saveConfigAsToolStripMenuItem.Text = "Save Configuration As...";
            this.saveConfigAsToolStripMenuItem.Click += new System.EventHandler(this.saveConfigAsToolStripMenuItem_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.saveAllToolStripMenuItem.Text = "Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(201, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.assemblyTreeView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 519);
            this.panel1.TabIndex = 16;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 49);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 519);
            this.splitter1.TabIndex = 17;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.applicationListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(203, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(434, 519);
            this.panel2.TabIndex = 18;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(637, 49);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 519);
            this.splitter2.TabIndex = 19;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.splitter3);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(640, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 519);
            this.panel3.TabIndex = 20;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.propertyGrid);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 248);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(182, 271);
            this.panel5.TabIndex = 2;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 245);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(182, 3);
            this.splitter3.TabIndex = 1;
            this.splitter3.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.configTreeView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(182, 245);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.xmlTextBox);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(203, 468);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(434, 100);
            this.panel6.TabIndex = 21;
            // 
            // xmlTextBox
            // 
            this.xmlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlTextBox.Location = new System.Drawing.Point(0, 0);
            this.xmlTextBox.Multiline = true;
            this.xmlTextBox.Name = "xmlTextBox";
            this.xmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.xmlTextBox.Size = new System.Drawing.Size(434, 100);
            this.xmlTextBox.TabIndex = 0;
            this.xmlTextBox.WordWrap = false;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(203, 465);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(434, 3);
            this.splitter4.TabIndex = 22;
            this.splitter4.TabStop = false;
            // 
            // VisualizeProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 568);
            this.Controls.Add(this.splitter4);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VisualizeProjectForm";
            this.Text = "Puzzle Aspect Workbench";
            this.Load += new System.EventHandler(this.VisualizeProjectForm_Load);
            this.aspectTargetContextMenuStrip.ResumeLayout(false);
            this.aspectContextMenuStrip.ResumeLayout(false);
            this.pointcutContextMenuStrip.ResumeLayout(false);
            this.mixinContextMenuStrip.ResumeLayout(false);
            this.pointcutTargetContextMenuStrip.ResumeLayout(false);
            this.interceptorContextMenuStrip.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.assemblyContextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView assemblyTreeView;
        private System.Windows.Forms.TreeView configTreeView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ContextMenuStrip aspectTargetContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeAspectTargetToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip aspectContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPointcutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMixinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAspectToolStripMenuItem;
        private System.Windows.Forms.ListView applicationListView;
        private System.Windows.Forms.ContextMenuStrip pointcutContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removePointcutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mixinContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeMixinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addPointcutTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addInterceptorToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip pointcutTargetContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removePointcutTargetToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip interceptorContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeInterceptorToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ContextMenuStrip assemblyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeAssemblyToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addAssemblyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConfigurationToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox xmlTextBox;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.ToolStripButton saveAllToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem saveConfigToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}