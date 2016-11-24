using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework;
using Puzzle.NCore.Framework.Compression;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Mapping.Transformation;
using Puzzle.NPersist.Framework.NPath;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework.Remoting.Formatting;
using Puzzle.NPersist.Framework.Remoting.WebService.Client;
using Puzzle.NPersist.Tools.DomainExplorer.Merging;
using Puzzle.NPersist.Tools.QueryAnalyzer;
using Puzzle.Syntaxbox.DefaultSyntaxFiles;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PropertyGrid objectPropertyGrid;
		private System.Windows.Forms.TreeView objectTreeView;
		private System.Windows.Forms.ListView objectsListView;
		private System.Windows.Forms.ListView clipBoardListView;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Panel panelLeftTop;
		private System.Windows.Forms.Splitter splitterLeft;
		private System.Windows.Forms.Panel panelLeftBottom;
		private System.Windows.Forms.Splitter splitterLeftBottom;
		private System.Windows.Forms.Splitter splitterMain;
		private System.Windows.Forms.Panel panelRight;
		private System.Windows.Forms.Splitter splitterRight;
		private System.Windows.Forms.ContextMenu objectContextMenu;
		private System.Windows.Forms.MenuItem exploreObjectMenuItem;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem deleteObjectMenuItem;
		private System.Windows.Forms.MenuItem removeObjectMenuItem;
		private System.Windows.Forms.ContextMenu propertyContextMenu;
		private System.Windows.Forms.MenuItem clearPropertyMenuItem;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MenuItem fileOpenMenuItem;
		private System.Windows.Forms.ToolBarButton openToolBarButton;
		private System.Windows.Forms.ToolBarButton runToolBarButton;
		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.TabControl bottomTabControl;
		private System.Windows.Forms.TabPage clipBoardTabPage;
		private System.Windows.Forms.TabPage logTabPage;
		private System.Windows.Forms.ToolBarButton separatorToolBarButton1;
		private System.Windows.Forms.ToolBarButton saveToolBarButton;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.MenuItem fileSaveMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Panel panelTree;
		private System.Windows.Forms.Splitter splitterTree;
		private System.Windows.Forms.TreeView classTreeView;
		private System.Windows.Forms.ContextMenu classContextMenu;
		private System.Windows.Forms.MenuItem fetchAllObjectsMenuItem;
		private System.Windows.Forms.MenuItem createObjectMenuItem;
		private System.Windows.Forms.MenuItem fetchTopObjectsMenuItem;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.ContextMenu methodContextMenu;
		private System.Windows.Forms.MenuItem callMethodMenuItem;
		private System.Windows.Forms.MenuItem queryFilterMenuItem;
		private System.Windows.Forms.MenuItem queryResultMenuItem;
		private System.Windows.Forms.MenuItem queryMenuItem;
		private System.Windows.Forms.MenuItem queryDataSourceMenuItem;
		private System.Windows.Forms.TabPage errorsTabPage;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ListView errorsListView;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem fieldLevelOptimisticConcurrencyMenuItem;
		private System.Windows.Forms.MenuItem rowLevelOptimisticConcurrencyMenuItem;
		private System.Windows.Forms.MenuItem noOptimisticConcurrencyMenuItem;
		private System.Windows.Forms.ContextMenu schemaPropertyContextMenu;
		private System.Windows.Forms.MenuItem setKeyMenuItem;
		private System.Windows.Forms.MenuItem addToKeyMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ListView compilerErrorListView;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem validateBeforeCommitmenuItem;
		private System.Windows.Forms.ToolBarButton validateToolBarButton;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem refreshObjectMenuItem;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem refreshPropertyMenuItem;
		private System.Windows.Forms.MenuItem refreshObjectUnmodifiedMenuItem;
		private System.Windows.Forms.MenuItem refreshObjectAllMenuItem;
		private System.Windows.Forms.MenuItem compareObjectMenuItem;
		private System.Windows.Forms.TabPage unitOfWorkTabPage;
		private System.Windows.Forms.TabPage upForCreationTabPage;
		private System.Windows.Forms.TabPage dirtyTabPage;
		private System.Windows.Forms.TabPage upForDeletionTabPage;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem clearClipboardMenuItem;
		private System.Windows.Forms.TabControl unitOfWorkTabControl;
		private System.Windows.Forms.ListView upForDeletionListView;
		private System.Windows.Forms.ListView dirtyListView;
		private System.Windows.Forms.ListView upForCreationListView;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.MenuItem comparePropertyMenuItem;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.TabControl tabControlText;
		private System.Windows.Forms.TabPage tabPageNPath;
		private System.Windows.Forms.TabPage codeTabPage;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem revertPropertyMenuItem;
		private System.Windows.Forms.MenuItem compareOriginalPropertyMenuItem;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem revertObjectMenuItem;
		private System.Windows.Forms.TabControl logTabControl;
		private System.Windows.Forms.TabPage sqlLogTabPage;
		private System.Windows.Forms.TabPage webServiceLogTabPage;
		private System.Windows.Forms.ListView exceptionsListView;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper npathTextBox;
		private Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper codeTextBox;
		private Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper sqlLogTextBox;
		private Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper webServiceLogTextBox;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();


			SyntaxBoxConfigurator config = new SyntaxBoxConfigurator(sqlLogTextBox.SyntaxBoxControl) ;
			config.SetupSqlServer2KSql() ;

			config = new SyntaxBoxConfigurator(webServiceLogTextBox.SyntaxBoxControl) ;
			config.SetupText() ;
		}

		public MainForm(IDomainMap domainMap) : this()
		{
			Start(domainMap);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			if (Context != null)
				Context.Dispose() ;
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.objectPropertyGrid = new System.Windows.Forms.PropertyGrid();
			this.objectTreeView = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.objectsListView = new System.Windows.Forms.ListView();
			this.clipBoardListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.fileOpenMenuItem = new System.Windows.Forms.MenuItem();
			this.fileSaveMenuItem = new System.Windows.Forms.MenuItem();
			this.queryMenuItem = new System.Windows.Forms.MenuItem();
			this.queryDataSourceMenuItem = new System.Windows.Forms.MenuItem();
			this.queryFilterMenuItem = new System.Windows.Forms.MenuItem();
			this.queryResultMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.fieldLevelOptimisticConcurrencyMenuItem = new System.Windows.Forms.MenuItem();
			this.rowLevelOptimisticConcurrencyMenuItem = new System.Windows.Forms.MenuItem();
			this.noOptimisticConcurrencyMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.validateBeforeCommitmenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.clearClipboardMenuItem = new System.Windows.Forms.MenuItem();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.openToolBarButton = new System.Windows.Forms.ToolBarButton();
			this.saveToolBarButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.validateToolBarButton = new System.Windows.Forms.ToolBarButton();
			this.separatorToolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.runToolBarButton = new System.Windows.Forms.ToolBarButton();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.panelLeftBottom = new System.Windows.Forms.Panel();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.bottomTabControl = new System.Windows.Forms.TabControl();
			this.clipBoardTabPage = new System.Windows.Forms.TabPage();
			this.errorsTabPage = new System.Windows.Forms.TabPage();
			this.errorsListView = new System.Windows.Forms.ListView();
			this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.exceptionsListView = new System.Windows.Forms.ListView();
			this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.compilerErrorListView = new System.Windows.Forms.ListView();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.unitOfWorkTabPage = new System.Windows.Forms.TabPage();
			this.unitOfWorkTabControl = new System.Windows.Forms.TabControl();
			this.upForCreationTabPage = new System.Windows.Forms.TabPage();
			this.upForCreationListView = new System.Windows.Forms.ListView();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.dirtyTabPage = new System.Windows.Forms.TabPage();
			this.dirtyListView = new System.Windows.Forms.ListView();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.upForDeletionTabPage = new System.Windows.Forms.TabPage();
			this.upForDeletionListView = new System.Windows.Forms.ListView();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.logTabPage = new System.Windows.Forms.TabPage();
			this.logTabControl = new System.Windows.Forms.TabControl();
			this.sqlLogTabPage = new System.Windows.Forms.TabPage();
			this.sqlLogTextBox = new Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper();
			this.webServiceLogTabPage = new System.Windows.Forms.TabPage();
			this.webServiceLogTextBox = new Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper();
			this.splitterLeftBottom = new System.Windows.Forms.Splitter();
			this.splitterLeft = new System.Windows.Forms.Splitter();
			this.panelLeftTop = new System.Windows.Forms.Panel();
			this.tabControlText = new System.Windows.Forms.TabControl();
			this.tabPageNPath = new System.Windows.Forms.TabPage();
			this.npathTextBox = new Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper();
			this.codeTabPage = new System.Windows.Forms.TabPage();
			this.codeTextBox = new Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper();
			this.splitterMain = new System.Windows.Forms.Splitter();
			this.panelRight = new System.Windows.Forms.Panel();
			this.splitterRight = new System.Windows.Forms.Splitter();
			this.objectContextMenu = new System.Windows.Forms.ContextMenu();
			this.exploreObjectMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.removeObjectMenuItem = new System.Windows.Forms.MenuItem();
			this.deleteObjectMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.refreshObjectMenuItem = new System.Windows.Forms.MenuItem();
			this.refreshObjectUnmodifiedMenuItem = new System.Windows.Forms.MenuItem();
			this.refreshObjectAllMenuItem = new System.Windows.Forms.MenuItem();
			this.compareObjectMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.revertObjectMenuItem = new System.Windows.Forms.MenuItem();
			this.propertyContextMenu = new System.Windows.Forms.ContextMenu();
			this.clearPropertyMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.refreshPropertyMenuItem = new System.Windows.Forms.MenuItem();
			this.comparePropertyMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.revertPropertyMenuItem = new System.Windows.Forms.MenuItem();
			this.compareOriginalPropertyMenuItem = new System.Windows.Forms.MenuItem();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panelTree = new System.Windows.Forms.Panel();
			this.classTreeView = new System.Windows.Forms.TreeView();
			this.splitterTree = new System.Windows.Forms.Splitter();
			this.classContextMenu = new System.Windows.Forms.ContextMenu();
			this.fetchAllObjectsMenuItem = new System.Windows.Forms.MenuItem();
			this.fetchTopObjectsMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.createObjectMenuItem = new System.Windows.Forms.MenuItem();
			this.methodContextMenu = new System.Windows.Forms.ContextMenu();
			this.callMethodMenuItem = new System.Windows.Forms.MenuItem();
			this.schemaPropertyContextMenu = new System.Windows.Forms.ContextMenu();
			this.setKeyMenuItem = new System.Windows.Forms.MenuItem();
			this.addToKeyMenuItem = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.panelLeft.SuspendLayout();
			this.panelLeftBottom.SuspendLayout();
			this.panelBottom.SuspendLayout();
			this.bottomTabControl.SuspendLayout();
			this.clipBoardTabPage.SuspendLayout();
			this.errorsTabPage.SuspendLayout();
			this.unitOfWorkTabPage.SuspendLayout();
			this.unitOfWorkTabControl.SuspendLayout();
			this.upForCreationTabPage.SuspendLayout();
			this.dirtyTabPage.SuspendLayout();
			this.upForDeletionTabPage.SuspendLayout();
			this.logTabPage.SuspendLayout();
			this.logTabControl.SuspendLayout();
			this.sqlLogTabPage.SuspendLayout();
			this.webServiceLogTabPage.SuspendLayout();
			this.panelLeftTop.SuspendLayout();
			this.tabControlText.SuspendLayout();
			this.tabPageNPath.SuspendLayout();
			this.codeTabPage.SuspendLayout();
			this.panelRight.SuspendLayout();
			this.panelTree.SuspendLayout();
			this.SuspendLayout();
			// 
			// objectPropertyGrid
			// 
			this.objectPropertyGrid.CommandsVisibleIfAvailable = true;
			this.objectPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.objectPropertyGrid.LargeButtons = false;
			this.objectPropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.objectPropertyGrid.Location = new System.Drawing.Point(0, 131);
			this.objectPropertyGrid.Name = "objectPropertyGrid";
			this.objectPropertyGrid.Size = new System.Drawing.Size(237, 396);
			this.objectPropertyGrid.TabIndex = 0;
			this.objectPropertyGrid.Text = "propertyGrid1";
			this.toolTip1.SetToolTip(this.objectPropertyGrid, "Object Properties");
			this.objectPropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.objectPropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			this.objectPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.objectPropertyGrid_PropertyValueChanged);
			// 
			// objectTreeView
			// 
			this.objectTreeView.AllowDrop = true;
			this.objectTreeView.Dock = System.Windows.Forms.DockStyle.Top;
			this.objectTreeView.ImageList = this.imageList1;
			this.objectTreeView.Location = new System.Drawing.Point(0, 0);
			this.objectTreeView.Name = "objectTreeView";
			this.objectTreeView.Size = new System.Drawing.Size(237, 128);
			this.objectTreeView.TabIndex = 1;
			this.toolTip1.SetToolTip(this.objectTreeView, "Object Explorer");
			this.objectTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.objectTreeView_MouseUp);
			this.objectTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.objectTreeView_DragOver);
			this.objectTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.objectTreeView_AfterSelect);
			this.objectTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.objectTreeView_BeforeExpand);
			this.objectTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.objectTreeView_DragEnter);
			this.objectTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.objectTreeView_ItemDrag);
			this.objectTreeView.DragLeave += new System.EventHandler(this.objectTreeView_DragLeave);
			this.objectTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.objectTreeView_DragDrop);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// objectsListView
			// 
			this.objectsListView.AllowDrop = true;
			this.objectsListView.Dock = System.Windows.Forms.DockStyle.Top;
			this.objectsListView.FullRowSelect = true;
			this.objectsListView.Location = new System.Drawing.Point(0, 0);
			this.objectsListView.Name = "objectsListView";
			this.objectsListView.Size = new System.Drawing.Size(429, 304);
			this.objectsListView.SmallImageList = this.imageList1;
			this.objectsListView.TabIndex = 2;
			this.toolTip1.SetToolTip(this.objectsListView, "Object result list");
			this.objectsListView.View = System.Windows.Forms.View.Details;
			this.objectsListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.objectsListView_MouseDown);
			this.objectsListView.Click += new System.EventHandler(this.objectsListView_Click);
			this.objectsListView.DoubleClick += new System.EventHandler(this.objectsListView_DoubleClick);
			this.objectsListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.objectsListView_MouseUp);
			this.objectsListView.DragOver += new System.Windows.Forms.DragEventHandler(this.objectsListView_DragOver);
			this.objectsListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.objectsListView_DragDrop);
			this.objectsListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.objectsListView_DragEnter);
			this.objectsListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.objectsListView_ItemDrag);
			this.objectsListView.DragLeave += new System.EventHandler(this.objectsListView_DragLeave);
			// 
			// clipBoardListView
			// 
			this.clipBoardListView.AllowDrop = true;
			this.clipBoardListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								this.columnHeader1});
			this.clipBoardListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clipBoardListView.Location = new System.Drawing.Point(0, 0);
			this.clipBoardListView.Name = "clipBoardListView";
			this.clipBoardListView.Size = new System.Drawing.Size(421, 91);
			this.clipBoardListView.SmallImageList = this.imageList1;
			this.clipBoardListView.TabIndex = 5;
			this.clipBoardListView.View = System.Windows.Forms.View.List;
			this.clipBoardListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clipBoardListView_MouseDown);
			this.clipBoardListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.clipBoardListView_MouseUp);
			this.clipBoardListView.DragOver += new System.Windows.Forms.DragEventHandler(this.clipBoardListView_DragOver);
			this.clipBoardListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.clipBoardListView_DragDrop);
			this.clipBoardListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.clipBoardListView_DragEnter);
			this.clipBoardListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.clipBoardListView_ItemDrag);
			this.clipBoardListView.DragLeave += new System.EventHandler(this.clipBoardListView_DragLeave);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Identity";
			this.columnHeader1.Width = 250;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.queryMenuItem,
																					  this.menuItem3,
																					  this.menuItem10});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.fileOpenMenuItem,
																					  this.fileSaveMenuItem});
			this.menuItem1.Text = "File";
			// 
			// fileOpenMenuItem
			// 
			this.fileOpenMenuItem.Index = 0;
			this.fileOpenMenuItem.Text = "Open";
			this.fileOpenMenuItem.Click += new System.EventHandler(this.openDomainMenuItem_Click);
			// 
			// fileSaveMenuItem
			// 
			this.fileSaveMenuItem.Index = 1;
			this.fileSaveMenuItem.Text = "Save";
			this.fileSaveMenuItem.Click += new System.EventHandler(this.fileSaveMenuItem_Click);
			// 
			// queryMenuItem
			// 
			this.queryMenuItem.Index = 1;
			this.queryMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.queryDataSourceMenuItem,
																						  this.queryFilterMenuItem,
																						  this.queryResultMenuItem});
			this.queryMenuItem.Text = "Query";
			// 
			// queryDataSourceMenuItem
			// 
			this.queryDataSourceMenuItem.Checked = true;
			this.queryDataSourceMenuItem.Index = 0;
			this.queryDataSourceMenuItem.RadioCheck = true;
			this.queryDataSourceMenuItem.Text = "Query Data Source";
			this.queryDataSourceMenuItem.Click += new System.EventHandler(this.queryDataSourceMenuItem_Click);
			// 
			// queryFilterMenuItem
			// 
			this.queryFilterMenuItem.Index = 1;
			this.queryFilterMenuItem.RadioCheck = true;
			this.queryFilterMenuItem.Text = "Filter Cached Objects";
			this.queryFilterMenuItem.Click += new System.EventHandler(this.queryFilterMenuItem_Click);
			// 
			// queryResultMenuItem
			// 
			this.queryResultMenuItem.Index = 2;
			this.queryResultMenuItem.RadioCheck = true;
			this.queryResultMenuItem.Text = "Filter Result";
			this.queryResultMenuItem.Click += new System.EventHandler(this.queryResultMenuItem_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem6});
			this.menuItem3.Text = "Commit";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.fieldLevelOptimisticConcurrencyMenuItem,
																					  this.rowLevelOptimisticConcurrencyMenuItem,
																					  this.noOptimisticConcurrencyMenuItem});
			this.menuItem5.Text = "Concurrency";
			// 
			// fieldLevelOptimisticConcurrencyMenuItem
			// 
			this.fieldLevelOptimisticConcurrencyMenuItem.Checked = true;
			this.fieldLevelOptimisticConcurrencyMenuItem.Index = 0;
			this.fieldLevelOptimisticConcurrencyMenuItem.RadioCheck = true;
			this.fieldLevelOptimisticConcurrencyMenuItem.Text = "Field Level Optimistic Concurrency";
			this.fieldLevelOptimisticConcurrencyMenuItem.Click += new System.EventHandler(this.fieldLevelOptimisticConcurrencyMenuItem_Click);
			// 
			// rowLevelOptimisticConcurrencyMenuItem
			// 
			this.rowLevelOptimisticConcurrencyMenuItem.Index = 1;
			this.rowLevelOptimisticConcurrencyMenuItem.RadioCheck = true;
			this.rowLevelOptimisticConcurrencyMenuItem.Text = "Row Level Optimistic Concurrency";
			this.rowLevelOptimisticConcurrencyMenuItem.Click += new System.EventHandler(this.rowLevelOptimisticConcurrencyMenuItem_Click);
			// 
			// noOptimisticConcurrencyMenuItem
			// 
			this.noOptimisticConcurrencyMenuItem.Index = 2;
			this.noOptimisticConcurrencyMenuItem.RadioCheck = true;
			this.noOptimisticConcurrencyMenuItem.Text = "No Optimistic Concurrency";
			this.noOptimisticConcurrencyMenuItem.Click += new System.EventHandler(this.noOptimisticConcurrencyMenuItem_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.validateBeforeCommitmenuItem});
			this.menuItem6.Text = "Validation";
			// 
			// validateBeforeCommitmenuItem
			// 
			this.validateBeforeCommitmenuItem.Checked = true;
			this.validateBeforeCommitmenuItem.Index = 0;
			this.validateBeforeCommitmenuItem.Text = "Validate Before Commit";
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 3;
			this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.clearClipboardMenuItem});
			this.menuItem10.Text = "Clipboard";
			// 
			// clearClipboardMenuItem
			// 
			this.clearClipboardMenuItem.Index = 0;
			this.clearClipboardMenuItem.Text = "Clear";
			this.clearClipboardMenuItem.Click += new System.EventHandler(this.clearClipboardMenuItem_Click);
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.openToolBarButton,
																						this.saveToolBarButton,
																						this.toolBarButton1,
																						this.validateToolBarButton,
																						this.separatorToolBarButton1,
																						this.runToolBarButton});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(856, 28);
			this.toolBar1.TabIndex = 6;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// openToolBarButton
			// 
			this.openToolBarButton.ImageIndex = 2;
			this.openToolBarButton.Tag = "Open";
			this.openToolBarButton.ToolTipText = "Open a domain configuration";
			// 
			// saveToolBarButton
			// 
			this.saveToolBarButton.ImageIndex = 4;
			this.saveToolBarButton.Tag = "Save";
			this.saveToolBarButton.ToolTipText = "Save all changes";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// validateToolBarButton
			// 
			this.validateToolBarButton.ImageIndex = 7;
			this.validateToolBarButton.Tag = "Validate";
			this.validateToolBarButton.ToolTipText = "Validate changes";
			// 
			// separatorToolBarButton1
			// 
			this.separatorToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// runToolBarButton
			// 
			this.runToolBarButton.ImageIndex = 3;
			this.runToolBarButton.Tag = "Run";
			this.runToolBarButton.ToolTipText = "Run npath query";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 555);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1,
																						  this.statusBarPanel2});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(856, 22);
			this.statusBar1.TabIndex = 7;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Text = "Ready";
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel2.Width = 740;
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.panelLeftBottom);
			this.panelLeft.Controls.Add(this.splitterLeft);
			this.panelLeft.Controls.Add(this.panelLeftTop);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(187, 28);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(429, 527);
			this.panelLeft.TabIndex = 11;
			// 
			// panelLeftBottom
			// 
			this.panelLeftBottom.Controls.Add(this.panelBottom);
			this.panelLeftBottom.Controls.Add(this.splitterLeftBottom);
			this.panelLeftBottom.Controls.Add(this.objectsListView);
			this.panelLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelLeftBottom.Location = new System.Drawing.Point(0, 103);
			this.panelLeftBottom.Name = "panelLeftBottom";
			this.panelLeftBottom.Size = new System.Drawing.Size(429, 424);
			this.panelLeftBottom.TabIndex = 2;
			// 
			// panelBottom
			// 
			this.panelBottom.Controls.Add(this.bottomTabControl);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBottom.Location = new System.Drawing.Point(0, 307);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(429, 117);
			this.panelBottom.TabIndex = 6;
			// 
			// bottomTabControl
			// 
			this.bottomTabControl.Controls.Add(this.clipBoardTabPage);
			this.bottomTabControl.Controls.Add(this.errorsTabPage);
			this.bottomTabControl.Controls.Add(this.unitOfWorkTabPage);
			this.bottomTabControl.Controls.Add(this.logTabPage);
			this.bottomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bottomTabControl.Location = new System.Drawing.Point(0, 0);
			this.bottomTabControl.Name = "bottomTabControl";
			this.bottomTabControl.SelectedIndex = 0;
			this.bottomTabControl.Size = new System.Drawing.Size(429, 117);
			this.bottomTabControl.TabIndex = 0;
			// 
			// clipBoardTabPage
			// 
			this.clipBoardTabPage.Controls.Add(this.clipBoardListView);
			this.clipBoardTabPage.Location = new System.Drawing.Point(4, 22);
			this.clipBoardTabPage.Name = "clipBoardTabPage";
			this.clipBoardTabPage.Size = new System.Drawing.Size(421, 91);
			this.clipBoardTabPage.TabIndex = 0;
			this.clipBoardTabPage.Text = "Clip board";
			// 
			// errorsTabPage
			// 
			this.errorsTabPage.Controls.Add(this.errorsListView);
			this.errorsTabPage.Controls.Add(this.exceptionsListView);
			this.errorsTabPage.Controls.Add(this.compilerErrorListView);
			this.errorsTabPage.Location = new System.Drawing.Point(4, 22);
			this.errorsTabPage.Name = "errorsTabPage";
			this.errorsTabPage.Size = new System.Drawing.Size(421, 91);
			this.errorsTabPage.TabIndex = 2;
			this.errorsTabPage.Text = "Errors";
			// 
			// errorsListView
			// 
			this.errorsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnHeader18,
																							 this.columnHeader2,
																							 this.columnHeader3,
																							 this.columnHeader4,
																							 this.columnHeader5,
																							 this.columnHeader6});
			this.errorsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.errorsListView.Location = new System.Drawing.Point(0, 0);
			this.errorsListView.Name = "errorsListView";
			this.errorsListView.Size = new System.Drawing.Size(421, 91);
			this.errorsListView.SmallImageList = this.imageList1;
			this.errorsListView.TabIndex = 0;
			this.errorsListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader18
			// 
			this.columnHeader18.Text = "Object";
			this.columnHeader18.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Property";
			this.columnHeader2.Width = 120;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Exception";
			this.columnHeader3.Width = 250;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Limit";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Actual";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Value";
			// 
			// exceptionsListView
			// 
			this.exceptionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.columnHeader16,
																								 this.columnHeader17,
																								 this.columnHeader15,
																								 this.columnHeader14});
			this.exceptionsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exceptionsListView.Location = new System.Drawing.Point(0, 0);
			this.exceptionsListView.Name = "exceptionsListView";
			this.exceptionsListView.Size = new System.Drawing.Size(421, 91);
			this.exceptionsListView.SmallImageList = this.imageList1;
			this.exceptionsListView.TabIndex = 2;
			this.exceptionsListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "Object";
			this.columnHeader16.Width = 120;
			// 
			// columnHeader17
			// 
			this.columnHeader17.Text = "Property";
			this.columnHeader17.Width = 120;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "Message";
			this.columnHeader15.Width = 250;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Type";
			this.columnHeader14.Width = 120;
			// 
			// compilerErrorListView
			// 
			this.compilerErrorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									this.columnHeader7,
																									this.columnHeader8,
																									this.columnHeader9,
																									this.columnHeader10});
			this.compilerErrorListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.compilerErrorListView.Location = new System.Drawing.Point(0, 0);
			this.compilerErrorListView.Name = "compilerErrorListView";
			this.compilerErrorListView.Size = new System.Drawing.Size(421, 91);
			this.compilerErrorListView.SmallImageList = this.imageList1;
			this.compilerErrorListView.TabIndex = 1;
			this.compilerErrorListView.View = System.Windows.Forms.View.Details;
			this.compilerErrorListView.Visible = false;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Error";
			this.columnHeader7.Width = 250;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Line";
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Column";
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Warning";
			// 
			// unitOfWorkTabPage
			// 
			this.unitOfWorkTabPage.Controls.Add(this.unitOfWorkTabControl);
			this.unitOfWorkTabPage.Location = new System.Drawing.Point(4, 22);
			this.unitOfWorkTabPage.Name = "unitOfWorkTabPage";
			this.unitOfWorkTabPage.Size = new System.Drawing.Size(421, 91);
			this.unitOfWorkTabPage.TabIndex = 3;
			this.unitOfWorkTabPage.Text = "Unit of Work";
			// 
			// unitOfWorkTabControl
			// 
			this.unitOfWorkTabControl.Controls.Add(this.upForCreationTabPage);
			this.unitOfWorkTabControl.Controls.Add(this.dirtyTabPage);
			this.unitOfWorkTabControl.Controls.Add(this.upForDeletionTabPage);
			this.unitOfWorkTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.unitOfWorkTabControl.Location = new System.Drawing.Point(0, 0);
			this.unitOfWorkTabControl.Name = "unitOfWorkTabControl";
			this.unitOfWorkTabControl.SelectedIndex = 0;
			this.unitOfWorkTabControl.Size = new System.Drawing.Size(421, 91);
			this.unitOfWorkTabControl.TabIndex = 0;
			// 
			// upForCreationTabPage
			// 
			this.upForCreationTabPage.Controls.Add(this.upForCreationListView);
			this.upForCreationTabPage.Location = new System.Drawing.Point(4, 22);
			this.upForCreationTabPage.Name = "upForCreationTabPage";
			this.upForCreationTabPage.Size = new System.Drawing.Size(413, 150);
			this.upForCreationTabPage.TabIndex = 0;
			this.upForCreationTabPage.Text = "New";
			// 
			// upForCreationListView
			// 
			this.upForCreationListView.AllowDrop = true;
			this.upForCreationListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									this.columnHeader13});
			this.upForCreationListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.upForCreationListView.Location = new System.Drawing.Point(0, 0);
			this.upForCreationListView.Name = "upForCreationListView";
			this.upForCreationListView.Size = new System.Drawing.Size(413, 150);
			this.upForCreationListView.SmallImageList = this.imageList1;
			this.upForCreationListView.TabIndex = 7;
			this.upForCreationListView.View = System.Windows.Forms.View.List;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Identity";
			this.columnHeader13.Width = 250;
			// 
			// dirtyTabPage
			// 
			this.dirtyTabPage.Controls.Add(this.dirtyListView);
			this.dirtyTabPage.Location = new System.Drawing.Point(4, 22);
			this.dirtyTabPage.Name = "dirtyTabPage";
			this.dirtyTabPage.Size = new System.Drawing.Size(413, 150);
			this.dirtyTabPage.TabIndex = 1;
			this.dirtyTabPage.Text = "Modified";
			// 
			// dirtyListView
			// 
			this.dirtyListView.AllowDrop = true;
			this.dirtyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.columnHeader12});
			this.dirtyListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dirtyListView.Location = new System.Drawing.Point(0, 0);
			this.dirtyListView.Name = "dirtyListView";
			this.dirtyListView.Size = new System.Drawing.Size(413, 150);
			this.dirtyListView.SmallImageList = this.imageList1;
			this.dirtyListView.TabIndex = 6;
			this.dirtyListView.View = System.Windows.Forms.View.List;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Identity";
			this.columnHeader12.Width = 250;
			// 
			// upForDeletionTabPage
			// 
			this.upForDeletionTabPage.Controls.Add(this.upForDeletionListView);
			this.upForDeletionTabPage.Location = new System.Drawing.Point(4, 22);
			this.upForDeletionTabPage.Name = "upForDeletionTabPage";
			this.upForDeletionTabPage.Size = new System.Drawing.Size(413, 150);
			this.upForDeletionTabPage.TabIndex = 2;
			this.upForDeletionTabPage.Text = "Deleted";
			// 
			// upForDeletionListView
			// 
			this.upForDeletionListView.AllowDrop = true;
			this.upForDeletionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									this.columnHeader11});
			this.upForDeletionListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.upForDeletionListView.Location = new System.Drawing.Point(0, 0);
			this.upForDeletionListView.Name = "upForDeletionListView";
			this.upForDeletionListView.Size = new System.Drawing.Size(413, 150);
			this.upForDeletionListView.SmallImageList = this.imageList1;
			this.upForDeletionListView.TabIndex = 6;
			this.upForDeletionListView.View = System.Windows.Forms.View.List;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Identity";
			this.columnHeader11.Width = 250;
			// 
			// logTabPage
			// 
			this.logTabPage.Controls.Add(this.logTabControl);
			this.logTabPage.Location = new System.Drawing.Point(4, 22);
			this.logTabPage.Name = "logTabPage";
			this.logTabPage.Size = new System.Drawing.Size(421, 91);
			this.logTabPage.TabIndex = 1;
			this.logTabPage.Text = "Log";
			// 
			// logTabControl
			// 
			this.logTabControl.Controls.Add(this.sqlLogTabPage);
			this.logTabControl.Controls.Add(this.webServiceLogTabPage);
			this.logTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logTabControl.Location = new System.Drawing.Point(0, 0);
			this.logTabControl.Name = "logTabControl";
			this.logTabControl.SelectedIndex = 0;
			this.logTabControl.Size = new System.Drawing.Size(421, 91);
			this.logTabControl.TabIndex = 0;
			// 
			// sqlLogTabPage
			// 
			this.sqlLogTabPage.Controls.Add(this.sqlLogTextBox);
			this.sqlLogTabPage.Location = new System.Drawing.Point(4, 22);
			this.sqlLogTabPage.Name = "sqlLogTabPage";
			this.sqlLogTabPage.Size = new System.Drawing.Size(413, 65);
			this.sqlLogTabPage.TabIndex = 0;
			this.sqlLogTabPage.Text = "Sql";
			// 
			// sqlLogTextBox
			// 
			this.sqlLogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sqlLogTextBox.Location = new System.Drawing.Point(0, 0);
			this.sqlLogTextBox.Name = "sqlLogTextBox";
			this.sqlLogTextBox.ReadOnly = false;
			this.sqlLogTextBox.SelectedText = "";
			this.sqlLogTextBox.Size = new System.Drawing.Size(413, 65);
			this.sqlLogTextBox.TabIndex = 0;
			// 
			// webServiceLogTabPage
			// 
			this.webServiceLogTabPage.Controls.Add(this.webServiceLogTextBox);
			this.webServiceLogTabPage.Location = new System.Drawing.Point(4, 22);
			this.webServiceLogTabPage.Name = "webServiceLogTabPage";
			this.webServiceLogTabPage.Size = new System.Drawing.Size(413, 65);
			this.webServiceLogTabPage.TabIndex = 1;
			this.webServiceLogTabPage.Text = "Web";
			// 
			// webServiceLogTextBox
			// 
			this.webServiceLogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webServiceLogTextBox.Location = new System.Drawing.Point(0, 0);
			this.webServiceLogTextBox.Name = "webServiceLogTextBox";
			this.webServiceLogTextBox.ReadOnly = false;
			this.webServiceLogTextBox.SelectedText = "";
			this.webServiceLogTextBox.Size = new System.Drawing.Size(413, 65);
			this.webServiceLogTextBox.TabIndex = 0;
			// 
			// splitterLeftBottom
			// 
			this.splitterLeftBottom.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitterLeftBottom.Location = new System.Drawing.Point(0, 304);
			this.splitterLeftBottom.Name = "splitterLeftBottom";
			this.splitterLeftBottom.Size = new System.Drawing.Size(429, 3);
			this.splitterLeftBottom.TabIndex = 3;
			this.splitterLeftBottom.TabStop = false;
			// 
			// splitterLeft
			// 
			this.splitterLeft.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitterLeft.Location = new System.Drawing.Point(0, 100);
			this.splitterLeft.Name = "splitterLeft";
			this.splitterLeft.Size = new System.Drawing.Size(429, 3);
			this.splitterLeft.TabIndex = 1;
			this.splitterLeft.TabStop = false;
			// 
			// panelLeftTop
			// 
			this.panelLeftTop.Controls.Add(this.tabControlText);
			this.panelLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelLeftTop.Location = new System.Drawing.Point(0, 0);
			this.panelLeftTop.Name = "panelLeftTop";
			this.panelLeftTop.Size = new System.Drawing.Size(429, 100);
			this.panelLeftTop.TabIndex = 0;
			// 
			// tabControlText
			// 
			this.tabControlText.Controls.Add(this.tabPageNPath);
			this.tabControlText.Controls.Add(this.codeTabPage);
			this.tabControlText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlText.Location = new System.Drawing.Point(0, 0);
			this.tabControlText.Name = "tabControlText";
			this.tabControlText.SelectedIndex = 0;
			this.tabControlText.Size = new System.Drawing.Size(429, 100);
			this.tabControlText.TabIndex = 1;
			// 
			// tabPageNPath
			// 
			this.tabPageNPath.Controls.Add(this.npathTextBox);
			this.tabPageNPath.Location = new System.Drawing.Point(4, 22);
			this.tabPageNPath.Name = "tabPageNPath";
			this.tabPageNPath.Size = new System.Drawing.Size(421, 74);
			this.tabPageNPath.TabIndex = 0;
			this.tabPageNPath.Text = "NPath";
			// 
			// npathTextBox
			// 
			this.npathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.npathTextBox.Location = new System.Drawing.Point(0, 0);
			this.npathTextBox.Name = "npathTextBox";
			this.npathTextBox.ReadOnly = false;
			this.npathTextBox.SelectedText = "";
			this.npathTextBox.Size = new System.Drawing.Size(421, 74);
			this.npathTextBox.TabIndex = 0;
			this.npathTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.npathTextBox_DragEnter);
			this.npathTextBox.DragLeave += new System.EventHandler(this.npathTextBox_DragLeave);
			this.npathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.npathTextBox_DragDrop);
			this.npathTextBox.DragOver += new System.Windows.Forms.DragEventHandler(this.npathTextBox_DragOver);
			// 
			// codeTabPage
			// 
			this.codeTabPage.Controls.Add(this.codeTextBox);
			this.codeTabPage.Location = new System.Drawing.Point(4, 22);
			this.codeTabPage.Name = "codeTabPage";
			this.codeTabPage.Size = new System.Drawing.Size(421, 74);
			this.codeTabPage.TabIndex = 1;
			this.codeTabPage.Text = "Code";
			// 
			// codeTextBox
			// 
			this.codeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.codeTextBox.Location = new System.Drawing.Point(0, 0);
			this.codeTextBox.Name = "codeTextBox";
			this.codeTextBox.ReadOnly = false;
			this.codeTextBox.SelectedText = "";
			this.codeTextBox.Size = new System.Drawing.Size(421, 74);
			this.codeTextBox.TabIndex = 0;
			// 
			// splitterMain
			// 
			this.splitterMain.Location = new System.Drawing.Point(616, 28);
			this.splitterMain.Name = "splitterMain";
			this.splitterMain.Size = new System.Drawing.Size(3, 527);
			this.splitterMain.TabIndex = 12;
			this.splitterMain.TabStop = false;
			// 
			// panelRight
			// 
			this.panelRight.Controls.Add(this.objectPropertyGrid);
			this.panelRight.Controls.Add(this.splitterRight);
			this.panelRight.Controls.Add(this.objectTreeView);
			this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRight.Location = new System.Drawing.Point(619, 28);
			this.panelRight.Name = "panelRight";
			this.panelRight.Size = new System.Drawing.Size(237, 527);
			this.panelRight.TabIndex = 13;
			// 
			// splitterRight
			// 
			this.splitterRight.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitterRight.Location = new System.Drawing.Point(0, 128);
			this.splitterRight.Name = "splitterRight";
			this.splitterRight.Size = new System.Drawing.Size(237, 3);
			this.splitterRight.TabIndex = 2;
			this.splitterRight.TabStop = false;
			// 
			// objectContextMenu
			// 
			this.objectContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							  this.exploreObjectMenuItem,
																							  this.menuItem2,
																							  this.removeObjectMenuItem,
																							  this.deleteObjectMenuItem,
																							  this.menuItem7,
																							  this.menuItem13,
																							  this.menuItem14});
			// 
			// exploreObjectMenuItem
			// 
			this.exploreObjectMenuItem.Index = 0;
			this.exploreObjectMenuItem.Text = "Explore";
			this.exploreObjectMenuItem.Click += new System.EventHandler(this.exploreObjectMenuItem_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// removeObjectMenuItem
			// 
			this.removeObjectMenuItem.Index = 2;
			this.removeObjectMenuItem.Text = "Remove";
			this.removeObjectMenuItem.Click += new System.EventHandler(this.removeObjectMenuItem_Click);
			// 
			// deleteObjectMenuItem
			// 
			this.deleteObjectMenuItem.Index = 3;
			this.deleteObjectMenuItem.Text = "Delete";
			this.deleteObjectMenuItem.Click += new System.EventHandler(this.deleteObjectMenuItem_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 4;
			this.menuItem7.Text = "-";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 5;
			this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.refreshObjectMenuItem,
																					   this.compareObjectMenuItem});
			this.menuItem13.Text = "Source";
			// 
			// refreshObjectMenuItem
			// 
			this.refreshObjectMenuItem.Index = 0;
			this.refreshObjectMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								  this.refreshObjectUnmodifiedMenuItem,
																								  this.refreshObjectAllMenuItem});
			this.refreshObjectMenuItem.Text = "Refresh From Source";
			this.refreshObjectMenuItem.Click += new System.EventHandler(this.refreshObjectMenuItem_Click);
			// 
			// refreshObjectUnmodifiedMenuItem
			// 
			this.refreshObjectUnmodifiedMenuItem.Index = 0;
			this.refreshObjectUnmodifiedMenuItem.Text = "Refresh Unmodifed Properties";
			this.refreshObjectUnmodifiedMenuItem.Click += new System.EventHandler(this.refreshObjectUnmodifiedMenuItem_Click);
			// 
			// refreshObjectAllMenuItem
			// 
			this.refreshObjectAllMenuItem.Index = 1;
			this.refreshObjectAllMenuItem.Text = "Refresh All Properties";
			this.refreshObjectAllMenuItem.Click += new System.EventHandler(this.refreshObjectAllMenuItem_Click);
			// 
			// compareObjectMenuItem
			// 
			this.compareObjectMenuItem.Index = 1;
			this.compareObjectMenuItem.Text = "Check For Conflicts";
			this.compareObjectMenuItem.Click += new System.EventHandler(this.compareObjectMenuItem_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 6;
			this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.revertObjectMenuItem});
			this.menuItem14.Text = "Originals";
			// 
			// revertObjectMenuItem
			// 
			this.revertObjectMenuItem.Index = 0;
			this.revertObjectMenuItem.Text = "Revert To Originals";
			// 
			// propertyContextMenu
			// 
			this.propertyContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								this.clearPropertyMenuItem,
																								this.menuItem8,
																								this.menuItem9,
																								this.menuItem11,
																								this.menuItem12});
			// 
			// clearPropertyMenuItem
			// 
			this.clearPropertyMenuItem.Index = 0;
			this.clearPropertyMenuItem.Text = "Clear";
			this.clearPropertyMenuItem.Click += new System.EventHandler(this.clearPropertyMenuItem_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 1;
			this.menuItem8.Text = "-";
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 2;
			this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.refreshPropertyMenuItem,
																					  this.comparePropertyMenuItem});
			this.menuItem9.Text = "Source";
			// 
			// refreshPropertyMenuItem
			// 
			this.refreshPropertyMenuItem.Index = 0;
			this.refreshPropertyMenuItem.Text = "Refresh From Source";
			// 
			// comparePropertyMenuItem
			// 
			this.comparePropertyMenuItem.Index = 1;
			this.comparePropertyMenuItem.Text = "Check For Conflict";
			this.comparePropertyMenuItem.Click += new System.EventHandler(this.comparePropertyMenuItem_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 3;
			this.menuItem11.Text = "-";
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 4;
			this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.revertPropertyMenuItem,
																					   this.compareOriginalPropertyMenuItem});
			this.menuItem12.Text = "Original";
			// 
			// revertPropertyMenuItem
			// 
			this.revertPropertyMenuItem.Index = 0;
			this.revertPropertyMenuItem.Text = "Revert To Original";
			// 
			// compareOriginalPropertyMenuItem
			// 
			this.compareOriginalPropertyMenuItem.Index = 1;
			this.compareOriginalPropertyMenuItem.Text = "Compare With Original";
			// 
			// panelTree
			// 
			this.panelTree.Controls.Add(this.classTreeView);
			this.panelTree.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelTree.Location = new System.Drawing.Point(0, 28);
			this.panelTree.Name = "panelTree";
			this.panelTree.Size = new System.Drawing.Size(184, 527);
			this.panelTree.TabIndex = 14;
			// 
			// classTreeView
			// 
			this.classTreeView.AllowDrop = true;
			this.classTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.classTreeView.ImageList = this.imageList1;
			this.classTreeView.Location = new System.Drawing.Point(0, 0);
			this.classTreeView.Name = "classTreeView";
			this.classTreeView.Size = new System.Drawing.Size(184, 527);
			this.classTreeView.TabIndex = 0;
			this.classTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.classTreeView_MouseUp);
			this.classTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.classTreeView_DragOver);
			this.classTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.classTreeView_DragEnter);
			this.classTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.classTreeView_ItemDrag);
			this.classTreeView.DragLeave += new System.EventHandler(this.classTreeView_DragLeave);
			this.classTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.classTreeView_DragDrop);
			// 
			// splitterTree
			// 
			this.splitterTree.Location = new System.Drawing.Point(184, 28);
			this.splitterTree.Name = "splitterTree";
			this.splitterTree.Size = new System.Drawing.Size(3, 527);
			this.splitterTree.TabIndex = 15;
			this.splitterTree.TabStop = false;
			// 
			// classContextMenu
			// 
			this.classContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.fetchAllObjectsMenuItem,
																							 this.fetchTopObjectsMenuItem,
																							 this.menuItem4,
																							 this.createObjectMenuItem});
			// 
			// fetchAllObjectsMenuItem
			// 
			this.fetchAllObjectsMenuItem.Index = 0;
			this.fetchAllObjectsMenuItem.Text = "Fetch All Objects";
			this.fetchAllObjectsMenuItem.Click += new System.EventHandler(this.fetchAllObjectsMenuItem_Click);
			// 
			// fetchTopObjectsMenuItem
			// 
			this.fetchTopObjectsMenuItem.Index = 1;
			this.fetchTopObjectsMenuItem.Text = "Fetch Top...";
			this.fetchTopObjectsMenuItem.Click += new System.EventHandler(this.fetchTopObjectsMenuItem_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// createObjectMenuItem
			// 
			this.createObjectMenuItem.Index = 3;
			this.createObjectMenuItem.Text = "Create New Object";
			this.createObjectMenuItem.Click += new System.EventHandler(this.createObjectMenuItem_Click);
			// 
			// methodContextMenu
			// 
			this.methodContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							  this.callMethodMenuItem});
			// 
			// callMethodMenuItem
			// 
			this.callMethodMenuItem.Index = 0;
			this.callMethodMenuItem.Text = "Call Method";
			this.callMethodMenuItem.Click += new System.EventHandler(this.callMethodMenuItem_Click);
			// 
			// schemaPropertyContextMenu
			// 
			this.schemaPropertyContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									  this.setKeyMenuItem,
																									  this.addToKeyMenuItem});
			// 
			// setKeyMenuItem
			// 
			this.setKeyMenuItem.Index = 0;
			this.setKeyMenuItem.Text = "Set As Key Property";
			this.setKeyMenuItem.Click += new System.EventHandler(this.setKeyMenuItem_Click);
			// 
			// addToKeyMenuItem
			// 
			this.addToKeyMenuItem.Index = 1;
			this.addToKeyMenuItem.Text = "Add To Key Properties";
			this.addToKeyMenuItem.Click += new System.EventHandler(this.addToKeyMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(856, 577);
			this.Controls.Add(this.panelRight);
			this.Controls.Add(this.splitterMain);
			this.Controls.Add(this.panelLeft);
			this.Controls.Add(this.splitterTree);
			this.Controls.Add(this.panelTree);
			this.Controls.Add(this.toolBar1);
			this.Controls.Add(this.statusBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Puzzle Domain Explorer";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.panelLeft.ResumeLayout(false);
			this.panelLeftBottom.ResumeLayout(false);
			this.panelBottom.ResumeLayout(false);
			this.bottomTabControl.ResumeLayout(false);
			this.clipBoardTabPage.ResumeLayout(false);
			this.errorsTabPage.ResumeLayout(false);
			this.unitOfWorkTabPage.ResumeLayout(false);
			this.unitOfWorkTabControl.ResumeLayout(false);
			this.upForCreationTabPage.ResumeLayout(false);
			this.dirtyTabPage.ResumeLayout(false);
			this.upForDeletionTabPage.ResumeLayout(false);
			this.logTabPage.ResumeLayout(false);
			this.logTabControl.ResumeLayout(false);
			this.sqlLogTabPage.ResumeLayout(false);
			this.webServiceLogTabPage.ResumeLayout(false);
			this.panelLeftTop.ResumeLayout(false);
			this.tabControlText.ResumeLayout(false);
			this.tabPageNPath.ResumeLayout(false);
			this.codeTabPage.ResumeLayout(false);
			this.panelRight.ResumeLayout(false);
			this.panelTree.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();
			Application.Run(new MainForm());
		}

		#region Static Members

		public static string domainConfigListPath = Application.LocalUserAppDataPath + @"\..\DomainConfigs.xml";
		public static DomainConfigList domainConfigList;

		public static bool UseObjectToString = false;

		public static bool ShowObjectMethods = true;
		public static bool ShowMixinMethods = false;
		public static bool ShowGetAndSetMethods = false;


		#endregion

		#region Private Members

		private IContext Context = null;
		private IList Exceptions = new ArrayList(); 
		private int ImageListCount = 0;

		private DomainConfig domainConfig = new DomainConfig() ; 

		private string mapPath = "";
		private string connectionString = "";
		private Assembly domain = null;

		private IList contextMenuObjects = new ArrayList() ;

		#endregion

		#region Start

		private void Start(IDomainMap domainMap)
		{
			LoadDomainMap(domainMap);
		}

		#endregion

		#region Context


		private void Connect()
		{
			bool hasSource = false;
			Context = GetContext(ref hasSource);	
			SetQuerySource(hasSource);
		}

		private void Connect(IDomainMap domainMap)
		{
			bool hasSource = false;
			Context = GetContext(domainMap, ref hasSource);	
			SetQuerySource(hasSource);
		}

		public virtual IContext GetContext(ref bool hasSource)
		{
			return GetContext(null, ref hasSource);
		}

		public virtual IContext GetContext(IDomainMap domainMap, ref bool hasSource)
		{
			IContext context = null;

			if (domainMap != null)
			{
				context = new Context(domainMap);				
				if (!GenerateAssembly(context))
				{
					return null;
				}
			}
			else
			{
				if (this.domainConfig.MapPath.Length > 0)
				{
					context = new Context(this.domainConfig.MapPath);				

					if (this.domainConfig.UseCustomDataSource)
					{
						if (this.domainConfig.PersistenceType == PersistenceType.ObjectRelational)
						{
							context.DomainMap.UnFixate() ;
							ISourceMap sourceMap = context.GetSourceMap();
							sourceMap.ConnectionString = this.domainConfig.ConnectionString;
							sourceMap.SourceType = this.domainConfig.SourceType;
							sourceMap.ProviderType = this.domainConfig.ProviderType;
							context.DomainMap.Fixate() ;
							hasSource = true;
						}
						else if (this.domainConfig.PersistenceType == PersistenceType.ObjectService)
						{
							IPersistenceEngine remotingEngine = new WebServiceRemotingEngine(new XmlFormatter(), this.domainConfig.Url, this.domainConfig.DomainKey, new DefaultWebServiceCompressor(), true);
							context.PersistenceEngine = remotingEngine;							
							hasSource = true;
						}
						else if (this.domainConfig.PersistenceType == PersistenceType.ObjectDocument)
						{
							
							hasSource = true;
						}						
					}															
				}
				else if (this.domainConfig.Url.Length > 0)
				{
					context = new Context(this.domainConfig.Url, this.domainConfig.DomainKey);					
					hasSource = true;
				}
				else if (this.domainConfig.ConnectionString.Length > 0)
				{
					//Wrap db on the fly
					WrapDatabase();
					hasSource = true;
				}
				else
				{
					return null;
				}

				if (this.domainConfig.AssemblyPath.Length > 0)
				{
					domain = System.Reflection.Assembly.LoadFrom(this.domainConfig.AssemblyPath);				
				}
				else
				{
					GenerateAssembly(context);
				}	
			}

			context.ValidateBeforeCommit = false;

			if (domain != null)
			{
				context.AssemblyManager.RegisterAssembly(domain);
				
				context.ExecutingSql += new ExecutingSqlEventHandler(this.HandleExecutingSql) ;
				context.CallingWebService += new CallingWebServiceEventHandler(this.HandleCallingWebService) ;				
			}

			SyntaxBoxConfigurator config = new SyntaxBoxConfigurator(npathTextBox.SyntaxBoxControl) ;
			config.SetupNPath() ;

			return context;
		}

		private void WrapDatabase()
		{
			
		}

		private bool GenerateAssembly(IContext context)
		{
			try
			{
				IDomainMap domainMap = context.DomainMap;
				ModelToCodeTransformer modelToCodeTransformer = new ModelToCodeTransformer() ;
				CodeDomProvider provider = null;
				SyntaxBoxConfigurator config = new SyntaxBoxConfigurator(codeTextBox.SyntaxBoxControl) ;
				if (domainMap.CodeLanguage == CodeLanguage.CSharp)
				{
					provider = new CSharpCodeProvider();
					config.SetupCSharp() ;					
				}
				else if (domainMap.CodeLanguage == CodeLanguage.VB)
				{
					provider = new VBCodeProvider();
					config.SetupVBNet() ;					
				}
				else
					throw new IAmOpenSourcePleaseImplementMeException() ;

				string code = modelToCodeTransformer.ToCode(domainMap, provider);
				codeTextBox.Text = code;

				CompilerResults cr = modelToCodeTransformer.ToCompilerResults(domainMap, provider);
				if (cr.Errors.Count > 0)
				{
					DisplayCompilerErrors(cr);
					MessageBox.Show("Domain model could not be compiled! The exceptions given by the compiler can be seen in the Errors list. ");
					domain = null;
				}
				else
				{
					domain = cr.CompiledAssembly;					
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Domain model could not be compiled! The compiler gave the following exception: " + ex.ToString() );
				domain = null;
			}
			if (domain == null)
				return false;

			return true;
		}

		private void DisplayCompilerErrors(CompilerResults cr)
		{
			panelTree.Visible = false;
			panelRight.Visible = false; 
			objectsListView.Visible = false;

			unitOfWorkTabPage.Parent.Controls.Remove(unitOfWorkTabPage);
			logTabPage.Parent.Controls.Remove(logTabPage);
			clipBoardTabPage.Parent.Controls.Remove(clipBoardTabPage);
			tabPageNPath.Parent.Controls.Remove(tabPageNPath);
			
			splitterMain.Enabled = false;
			splitterMain.Visible = false;

			bottomTabControl.SelectedTab = errorsTabPage;
			errorsListView.Visible = false;
			exceptionsListView.Visible = false ;
			compilerErrorListView.Visible = true;
			compilerErrorListView.Items.Clear() ;

			panelLeft.Dock = DockStyle.Fill ;

			foreach (CompilerError ce in cr.Errors)
			{
				CompilerExceptionListViewItem listViewItem = new CompilerExceptionListViewItem(ce, ImageListCount) ;
				compilerErrorListView.Items.Add(listViewItem);
			}			
		}


		#endregion

		#region Static Methods

		public static void LoadDomainConfigList()
		{
			domainConfigList = DomainConfigList.Load(domainConfigListPath);		
		}

		public static bool IsObjectMethod(string methodName)
		{
			if (methodName == "GetHashCode")
				return true;
			if (methodName == "Equals")
				return true;
			if (methodName == "ToString")
				return true;
			if (methodName == "GetType")
				return true;

			return false;
		}

		public static bool IsMixinMethod(string methodName)
		{
			if (methodName == "HandleCall")
				return true;
			if (methodName == "get_Data")
				return true;
			if (methodName == "HasOriginalValues")
				return true;
			if (methodName == "GetOriginalPropertyValue")
				return true;
			if (methodName == "SetOriginalPropertyValue")
				return true;
			if (methodName == "RemoveOriginalValues")
				return true;
			if (methodName == "GetNullValueStatus")
				return true;
			if (methodName == "SetNullValueStatus")
				return true;
			if (methodName == "GetObjectClone")
				return true;
			if (methodName == "SetObjectClone")
				return true;
			if (methodName == "GetUpdatedStatus")
				return true;
			if (methodName == "SetUpdatedStatus")
				return true;
			if (methodName == "ClearUpdatedStatuses")
				return true;
			if (methodName == "GetInterceptor")
				return true;
			if (methodName == "SetInterceptor")
				return true;
			if (methodName == "GetObjectStatus")
				return true;
			if (methodName == "SetObjectStatus")
				return true;

			return false;
		}

		public static bool IsGetOrSetMethod(string methodName)
		{
			if (methodName.StartsWith("get_"))
				return true;
			if (methodName.StartsWith("set_"))
				return true;
			return false;
		}

		public static string GetObjectAsString(object obj, IContext context)
		{
			if (UseObjectToString)
				return obj.ToString() + " (" + context.DomainMap.MustGetClassMap(obj.GetType()).Name + ")" ;
			else
				return context.DomainMap.MustGetClassMap(obj.GetType()).Name + "." + context.ObjectManager.GetObjectKeyOrIdentity(obj);
		}

		#endregion

		#region Private Methods


		private IList GetExceptions(object obj)
		{
			IList exceptions = new ArrayList(); 
			foreach (Exception ex in Exceptions)
			{
				NPersistValidationException validationException = ex as NPersistValidationException ;
				if (validationException != null)
				{
					if (validationException.Obj == obj)
					{
						exceptions.Add(validationException);
					}
				}
			}
			return exceptions;
		}

		private IList GetExceptions(object obj, string propertyName)
		{
			IList exceptions = new ArrayList(); 
			foreach (Exception ex in Exceptions)
			{
				NPersistValidationException validationException = ex as NPersistValidationException ;
				if (validationException != null)
				{
					if (validationException.Obj == obj)
					{
						if (validationException.PropertyName == propertyName)
						{
							exceptions.Add(validationException);
						}
					}
				}
			}
			return exceptions;			
		}



		private void LoadDomain()
		{
			DomainConfigListForm frm = new DomainConfigListForm() ;
			if (frm.ShowDialog(this) == DialogResult.OK)
			{
				LoadDomainConfig(frm.SelectedDomainConfig);				
			}
		}
		
		private void LoadDomainMap(IDomainMap domainMap)
		{
			ClearAll();
			Connect(domainMap);
			if (domain != null)
			{
				FillClassesTree();
				RefreshAll();
			}

		}

		private void SetQuerySource(bool hasSource)
		{
			if (this.Context != null)
			{
				ISourceMap sourceMap = this.Context.GetSourceMap(); 
				if (sourceMap != null)
				{
					if (hasSource == false)
					{
						if (sourceMap.ConnectionString.Length > 0)
						{
							hasSource = true;
						}
						else if (sourceMap.Url.Length > 0)
						{
							hasSource = true;
						}
						if (sourceMap.DocPath.Length > 0)
						{
							hasSource = true;
						}						
					}
					if (hasSource)
					{
						queryDataSourceMenuItem.Checked = true;		
						queryFilterMenuItem.Checked = false;
						queryResultMenuItem.Checked = false;						
					}
					else
					{
						queryDataSourceMenuItem.Checked = false;		
						queryFilterMenuItem.Checked = true;
						queryResultMenuItem.Checked = false;						
					}
		
				}				
			}
		}

		private void LoadDomainConfig(DomainConfig config)
		{
			ClearAll();
			if (config == null)
				return;

			this.domainConfig = config;

			Connect();
			FillClassesTree();
			RefreshAll();
		}

		private void SaveDomain()
		{
			if (validateBeforeCommitmenuItem.Checked)
				ValidateModel();
			if (Exceptions.Count < 1 || validateBeforeCommitmenuItem.Checked == false)
			{
				try
				{
					Context.Commit(-1) ;									
				}
				catch (CompositeException compEx)
				{
					ListAllSystemExceptions(compEx.InnerExceptions);
					MessageBox.Show("Exceptions were encountered while committing changes! Please inspect the list of errors for more information!");
				}
				catch (Exception ex)
				{
					IList exceptions = new ArrayList();
					exceptions.Add(ex);
					ListAllSystemExceptions(exceptions);
					MessageBox.Show("An exception was encountered while committing changes! Please inspect the list of errors for more information!");
				}
				RefreshAll();
			}
		}

		private void GetClass(string className, string top)
		{
			string npath = "Select ";

			if (top.Length > 0)
				npath += "Top " + top ;

			npath += "* From " + className ;

			RunQuery(npath);
		}


		private void CreateObject()
		{
			string className = GetSelectedClassName();
			IClassMap classMap = Context.DomainMap.MustGetClassMap(className);

			Type type = Context.AssemblyManager.MustGetTypeFromClassMap(classMap);

			object obj = Context.CreateObject(type);				

			AddObjectToListView(obj, type, clipBoardListView);
			InsertObjectIntoListView(obj, type, objectsListView);
			
			OpenObject(obj); 

			RefreshAll();
		}

		private void GetAllObjectsOfClass()
		{
			GetClass(GetSelectedClassName(), "");
		}

		private void GetTopObjectsOfClass()
		{
			InputBox input = new InputBox("Fetch Objects", "Maximum number of objects to fetch", "1000");
			if (input.ShowDialog() == DialogResult.Cancel)
				return;

			try
			{
				int top = Int32.Parse(input.InputText);

				GetClass(GetSelectedClassName(), input.InputText);
			}
			catch
			{
				MessageBox.Show("You must enter a numeric value!");	
			}
		}

		private string GetSelectedClassName()
		{
			return ((TreeNode)contextMenuObjects[0]).Text ;
		}
		

		private void ClearAll()
		{
			objectTreeView.Nodes.Clear();
			objectsListView.Clear();
			clipBoardListView.Items.Clear();
			objectPropertyGrid.SelectedObject = null;
		}

		private void RefreshAll()
		{
			RefreshAll(null);
		}

		private void RefreshAll(object onlyForObject)
		{
			RefreshToolBar();
			RefreshTreeView();	
			RefreshListViews(onlyForObject);
			RefreshPropertyGrid();
		}

		private void RefreshToolBar()
		{
			if (Context == null)
			{
				saveToolBarButton.Enabled = false;
				runToolBarButton.Enabled = false;
				return;				
			}
			saveToolBarButton.Enabled = Context.IsDirty ;
			//runToolBarButton.Enabled = npathTextBox.Text.Length > 0;
			runToolBarButton.Enabled = true;
		}

		private void OpenObject(object obj)
		{
			objectTreeView.Nodes.Clear() ;
			TreeNode treeNode = new ObjectTreeNode(Context, obj) ;
			objectTreeView.Nodes.Add(treeNode);
			treeNode.Expand() ;
			SelectObject(obj);
		}

		private void DeleteObject(object obj)
		{
			if (MessageBox.Show("Do you really want to delete the object " + GetObjectAsString(obj, this.Context) + "?", "Delete Object", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				Context.DeleteObject(obj);
				RefreshAll();
			}
		}

		private void RefreshObject(object obj)
		{
			RefreshObject(obj, RefreshBehaviorType.OverwriteLoaded);
		}

		private void RefreshObject(object obj, RefreshBehaviorType refreshBehavior)
		{
			Context.RefreshObject(obj, refreshBehavior);
			RefreshAll();
		}

		private void RefreshProperty(object obj, string propertyName)
		{
			RefreshProperty(obj, propertyName, RefreshBehaviorType.OverwriteDirty);
		}

		private void RefreshProperty(object obj, string propertyName, RefreshBehaviorType refreshBehavior)
		{
			Context.RefreshProperty(obj, propertyName, refreshBehavior);
			RefreshAll();
		}


		private void CompareProperty(object obj, string propertyName)
		{
			try
			{
				Context.RefreshProperty(obj, propertyName, RefreshBehaviorType.ThrowConcurrencyException);				

				MessageBox.Show("No conflicts!");
			}
			catch (RefreshException ex)
			{
				MergeTextValues mergeForm = new MergeTextValues(this.Context,  obj, propertyName, ex.CachedValue, ex.FreshValue, this.Context.ObjectManager.GetPropertyValue(obj, propertyName)) ;
				mergeForm.ShowDialog();
			}
			RefreshAll();
		}


		private void SelectMethod(MethodTreeNode methodTreeNode)
		{
			if (objectPropertyGrid.SelectedObject != null)
			{
				MethodProperties selectedMethodProperties = objectPropertyGrid.SelectedObject as MethodProperties;
				if (selectedMethodProperties != null)
				{
					if (selectedMethodProperties.Obj == methodTreeNode.Obj)
					{
						if (selectedMethodProperties.Signature == methodTreeNode.Text)
						{
							return;
						}
					}
				}
			}
			MethodProperties properties = new MethodProperties(Context, methodTreeNode.Obj,  methodTreeNode.MethodInfo) ;
			objectPropertyGrid.SelectedObject = properties;
		}

		private void SelectObject(object obj)
		{
			ObjectProperties properties = new ObjectProperties(Context, obj) ;
			objectPropertyGrid.SelectedObject = properties;
		}

		private void ClearProperty(object obj, IPropertyMap propertyMap)
		{
			if (propertyMap.IsCollection)
			{
				IList list = (IList) Context.ObjectManager.GetPropertyValue(obj,  propertyMap.Name);
				list.Clear() ;
				Context.ObjectManager.SetPropertyValue(obj,  propertyMap.Name, list);
			}
			else
			{
				obj.GetType().GetProperty(propertyMap.Name).SetValue(obj, null, null);
			}
			RefreshAll();
		}

		private void RemoveFromProperty(object obj, IPropertyMap propertyMap, object refObj)
		{
			if (propertyMap.IsCollection)
			{
				IList list = (IList) Context.ObjectManager.GetPropertyValue(obj,  propertyMap.Name);
				list.Remove(refObj) ;
				Context.ObjectManager.SetPropertyValue(obj,  propertyMap.Name, list);
			}
			else
			{
				obj.GetType().GetProperty(propertyMap.Name).SetValue(obj, null, null);
			}
			RefreshAll();
		}

		private void RunQuery()
		{
			RunQuery("");
		}

		private void RunQuery(string query)
		{
			if (query == "")
				query = GetQuery();
			if (query == "")
			{
				MessageBox.Show("You must enter a query first!");
				return;				
			}

			Cursor cacheCursor = this.Cursor ;
			
//			try
//			{
				this.Cursor = Cursors.WaitCursor ;
				Application.DoEvents() ;

				IList filter = null;
				if (queryResultMenuItem.Checked)
				{
					filter = GetListViewObjects();
				}

				objectsListView.Clear() ;
				objectsListView.Columns.Clear() ;
				objectsListView.Items.Clear() ;

				NPathQuery npath = new NPathQuery(query) ;
				IClassMap classMap = Context.NPathEngine.GetRootClassMap(query, Context.DomainMap);
				Type type = Context.AssemblyManager.MustGetTypeFromClassMap(classMap);

				npath.Context = Context;
				npath.PrimaryType = type;

				NPathQueryType npathQueryType = Context.NPathEngine.GetNPathQueryType(query);

				if (npathQueryType == NPathQueryType.SelectObjects)
				{					
					IList result = null;						
					if (queryDataSourceMenuItem.Checked)
					{
						result = Context.GetObjects(npath, type);						
					}
					else if (queryFilterMenuItem.Checked)
					{
						result = Context.FilterObjects(npath);						
					}
					else 
					{
						result = Context.FilterObjects(filter, npath);						
					}

					ObjectListViewItem.SetupColumns(Context, type, objectsListView);

					objectsListView.BeginUpdate() ;
					foreach (object obj in result)
					{
						ListViewItem listViewItem = new ObjectListViewItem(Context, obj, type) ;
						objectsListView.Items.Add(listViewItem );							
					}
					objectsListView.EndUpdate() ;
				}

				if (npathQueryType == NPathQueryType.SelectScalar)
				{
					MessageBox.Show("Only queries that returned objects are allowed in the Object Explorer! For scalar queries, please use the Query Analyzer instead.");
				}

				if (npathQueryType == NPathQueryType.SelectTable )
				{
					MessageBox.Show("Only queries that returned objects are allowed in the Object Explorer! For tabular queries, please use the Query Analyzer instead.");
				}
//			}
//			catch (CompositeException compEx)
//			{
//				ListAllSystemExceptions(compEx.InnerExceptions);
//				MessageBox.Show("Exceptions were encountered while executing the query! Please inspect the list of errors for more information!");
//			}
//			catch (Exception ex)
//			{
//				IList exceptions = new ArrayList();
//				exceptions.Add(ex);
//				ListAllSystemExceptions(exceptions);
//				MessageBox.Show("An exception was encountered while executing the query! Please inspect the list of errors for more information!");
//			}

			this.Cursor = cacheCursor ;

		}



		#endregion

		#region ListView

		private IList GetListViewObjects()
		{
			IList result = new ArrayList(); 
			foreach (ObjectListViewItem listViewItem in objectsListView.Items )
			{
				result.Add(listViewItem.Obj);
			}	
			return result;
		}

		private void RefreshListViews(object onlyForObject)
		{
			RefreshListView(objectsListView, onlyForObject);
			RefreshListView(clipBoardListView, onlyForObject);
			RefreshUnitOfWorkListViews(onlyForObject);

		}

		private void RefreshUnitOfWorkListViews(object onlyForObject)
		{
			if (this.Context != null)
			{
				upForCreationListView.BeginUpdate() ;
				upForCreationListView.Items.Clear() ;
				foreach (object obj in this.Context.UnitOfWork.GetCreatedObjects() )
					AddObjectToListView(obj, obj.GetType(), upForCreationListView);				
				upForCreationListView.EndUpdate() ;

				dirtyListView.BeginUpdate() ;
				dirtyListView.Items.Clear() ;
				foreach (object obj in this.Context.UnitOfWork.GetDirtyObjects() )
					AddObjectToListView(obj, obj.GetType(), dirtyListView);				
				dirtyListView.EndUpdate() ;
		
				upForDeletionListView.BeginUpdate() ;
				upForDeletionListView.Items.Clear() ;
				foreach (object obj in this.Context.UnitOfWork.GetDeletedObjects() )
					AddObjectToListView(obj, obj.GetType(), upForDeletionListView);				
				upForDeletionListView.EndUpdate() ;				
			}
		}


		private void RefreshListView(ListView listView, object onlyForObject)
		{
			listView.BeginUpdate() ;
			bool doRefresh = false;
			foreach (ObjectListViewItem listViewItem in listView.Items)
			{
				doRefresh = false;
				if (onlyForObject == null)
					doRefresh = true;
				else
				{
				if (listViewItem.Obj == onlyForObject )
				{
					doRefresh = true;
				}
					
				}
				if (doRefresh)
				{
					listViewItem.Refresh() ;					
				}
			}			
			listView.EndUpdate() ;
		}
		

		
		private string GetQuery()
		{
			string query = npathTextBox.SelectedText ;
			if (query == "") { query = npathTextBox.Text; }
			return query;
		}

		private void ListViewMouseDown(ListView listView, System.Windows.Forms.MouseEventArgs e)
		{
		}

		private void ListViewMouseUp(ListView listView, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				contextMenuObjects.Clear() ;
				foreach (ObjectListViewItem listViewItem in listView.SelectedItems)
				{
					contextMenuObjects.Add(listViewItem);
				}
				ShowContextMenu(listView, e.X, e.Y);				
			}
			if (e.Button == MouseButtons.Left)
			{
				foreach (ObjectListViewItem listViewItem in listView.SelectedItems)
				{
					SelectObject(listViewItem.Obj);
					break;
				}				
			}
		}


		private void ListViewItemDrag(ItemDragEventArgs e, object sender)
		{
			IObjectGuiItem objectGuiItem = (IObjectGuiItem) e.Item;
			object obj = objectGuiItem.Obj;
			string className = objectGuiItem.ClassMap.GetName();
			string dragMsg = GetObjectXml(obj, className, this.Context);
			((Control) sender).DoDragDrop(dragMsg, DragDropEffects.Copy | DragDropEffects.Move);
		}

		private static string GetObjectXml(object obj, string className, IContext context)
		{
			string id = context.ObjectManager.GetObjectIdentity(obj);
			return "xml:<object><class>" + className  + "</class><id>" + id + "</id></object>";
		}


		private void ListViewDragEnter(ListView listView, DragEventArgs e)
		{
			string data = "";
	
			if (e.Data.GetDataPresent(typeof(string)))
			{
				data = (string) e.Data.GetData(typeof(string));
			}
	
			if (data == null)
				data = "";
	
			if (data.Length > 0)
			{
				string header ;
				XmlNode payload = ParseDragData(data, out header);
				if (header == "object")
				{
					if (listView == clipBoardListView)
					{
						e.Effect = DragDropEffects.Copy ; 						
					}
				}
				else if (header == "class")
				{
					if (listView == objectsListView)
					{
						e.Effect = DragDropEffects.Copy ; 						
					}					
				}
			}
		}

				
		private void ListViewDragDrop(ListView listView, DragEventArgs e)
		{
			string data = "";
	
			if (e.Data.GetDataPresent(typeof(string)))
			{
				data = (string) e.Data.GetData(typeof(string));
			}
	
			if (data == null)
				data = "";
	
			if (data.Length > 0)
			{
				string header;
				XmlNode payload = ParseDragData(data, out header);
				if (header == "object")
				{
					if (listView == clipBoardListView)
					{
						object dropObject = GetDropObject(payload);

						AddObjectToListView(dropObject, dropObject.GetType(), listView);
					}
				}
				else if (header == "class")
				{
					if (listView == objectsListView)
					{
						GetClass(payload.InnerText, "");
					}					
				}
			}
		}

		private void AddObjectToListView(object dropObject, Type type, ListView listView)
		{
			ListViewItem listViewItem = new ObjectListViewItem(Context, dropObject, type, true) ;
			listView.Items.Add(listViewItem );
		}

		private void InsertObjectIntoListView(object dropObject, Type type, ListView listView)
		{
			listView.Clear() ;
			ObjectListViewItem.SetupColumns(Context, dropObject.GetType(), listView );
			
			ListViewItem listViewItem = new ObjectListViewItem(Context, dropObject, type) ;
			listView.Items.Add(listViewItem );
		}

		private void objectsListView_DoubleClick(object sender, System.EventArgs e)
		{
			foreach (ObjectListViewItem listViewItem in objectsListView.SelectedItems)
			{
				OpenObject(listViewItem.Obj);
				break;
			}
			
		}

				
		private void objectsListView_Click(object sender, System.EventArgs e)
		{
		}

		private void objectsListView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ListViewMouseDown((ListView) sender, e);		
		}

		private void objectsListView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ListViewMouseUp((ListView) sender, e);
		}


		private void objectsListView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			ListViewDragDrop((ListView) sender, e);
		}

		private void objectsListView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			ListViewDragEnter((ListView) sender, e);
		}

		private void objectsListView_DragLeave(object sender, System.EventArgs e)
		{
		
		}

		private void objectsListView_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
		
		}

		private void objectsListView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			ListViewItemDrag(e, sender);
		}



		private void clipBoardListView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ListViewMouseDown((ListView) sender, e);				
		}

		private void clipBoardListView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ListViewMouseUp((ListView) sender, e);					
		}

		private void clipBoardListView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			ListViewDragDrop((ListView) sender, e);		
		}

		private void clipBoardListView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			ListViewDragEnter((ListView) sender, e);
		}


		private void clipBoardListView_DragLeave(object sender, System.EventArgs e)
		{
		
		}

		private void clipBoardListView_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
		
		}

		private void clipBoardListView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			ListViewItemDrag(e, sender);
		}


		#endregion

		#region TreeView

		#region Classes TreeView

		private void FillClassesTree()
		{
			TreeNode classNode;
			TreeNode propNode;
			classTreeView.Nodes.Clear();
			foreach (IClassMap classMap in Context.DomainMap.GetPersistentClassMaps())
			{
				classNode = new TreeNode(classMap.Name, 0, 0) ;
				classTreeView.Nodes.Add(classNode);	
				foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
				{
					propNode = new TreeNode(propertyMap.Name, 1, 1) ;
					classNode.Nodes.Add(propNode);	
				}
			}
		}

		#endregion


		private void RefreshTreeView()
		{
			RefreshTreeView(objectTreeView);
		}

		private void RefreshTreeView(TreeView treeView)
		{
			treeView.BeginUpdate() ;
			foreach (ObjectTreeNode treeNode in treeView.Nodes)
			{
				RefreshTreeNode(treeNode);
			}
			treeView.EndUpdate() ;
		}

		private void RefreshTreeNode(ObjectTreeNode treeNode)
		{
			if (treeNode.IsExpanded)
			{
				foreach (ObjectTreeNode child in treeNode.Nodes)
				{
					RefreshTreeNode(child);
				}				
			}
			treeNode.Refresh();
		}

		private void TreeViewMouseUp(TreeView treeView, System.Windows.Forms.MouseEventArgs e)
		{
			
	        TreeNode onNode = treeView.GetNodeAt(new Point(e.X, e.Y));

			if (onNode != null)
			{
				if (treeView.SelectedNode != onNode)
				{
	                treeView.SelectedNode = onNode;					
				}				
			}

			if (e.Button == MouseButtons.Right)
			{
				contextMenuObjects.Clear() ;
				if (treeView.SelectedNode != null)
				{
					contextMenuObjects.Add(treeView.SelectedNode);
					ShowContextMenu(treeView, e.X, e.Y);									
				}
			}
		}

		private void TreeViewAfterSelect(TreeView treeView, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (treeView.SelectedNode != null)
			{
				if (treeView.SelectedNode is MethodTreeNode)
				{
					MethodTreeNode methodTreeNode = treeView.SelectedNode as MethodTreeNode;
					SelectMethod(methodTreeNode);					
				}
				else
				{					
					SelectObject(((IObjectGuiItem) treeView.SelectedNode).Obj);
				}
			}		
		}

		private bool insideTreeViewDragOver = false;

		private void TreeViewDragOver(TreeView treeView, System.Windows.Forms.DragEventArgs e)
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

				ObjectTreeNode overNode = (ObjectTreeNode) treeView.GetNodeAt(new Point(x, y));

				if (e.Data.GetDataPresent(typeof(string)))
				{
					data = (string) e.Data.GetData(typeof(string));
				}

				if (data == null)
					data = "";

				if (data.Length > 0)
				{
					string header;
					XmlNode payload = ParseDragData(data, out header);
					if (header == "object")
					{
						if (overNode != null)
						{
							if (overNode.PropertyMap != null)
							{
								object dropObject = GetDropObject(payload);
								IClassMap dropClassMap = Context.DomainMap.MustGetClassMap(dropObject.GetType() );
								if (dropClassMap.IsSubClassOrThisClass(overNode.PropertyMap.GetReferencedClassMap()))
								{
									doHilite = true ; 							
								}
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

		private void TreeViewDragDrop(TreeView treeView, System.Windows.Forms.DragEventArgs e)
		{
			Point pt = treeView.PointToClient(new Point(e.X, e.Y));

			int x = pt.X;
			int y = pt.Y;
			string data = "";
			
			ObjectTreeNode overNode = (ObjectTreeNode) treeView.GetNodeAt(new Point(x, y));

			if (e.Data.GetDataPresent(typeof(string)))
			{
				data = (string) e.Data.GetData(typeof(string));
			}

			if (data == null)
				data = "";

			if (data.Length > 0)
			{
				string header ;
				XmlNode payload = ParseDragData(data, out header);
				if (header == "object")
				{
					object dropObject = GetDropObject(payload);
					if (overNode != null)
					{
						if (overNode.PropertyMap != null)
						{
							if (dropObject != null)
							{
								IClassMap dropClassMap = Context.DomainMap.MustGetClassMap(dropObject.GetType() );
								if (dropClassMap.IsSubClassOrThisClass(overNode.PropertyMap.GetReferencedClassMap()))
								{
									if (overNode.PropertyMap.IsCollection)
									{
										IList list = (IList) Context.ObjectManager.GetPropertyValue(overNode.Obj,  overNode.PropertyMap.Name);
										list.Add(dropObject);
										Context.ObjectManager.SetPropertyValue(overNode.Obj,  overNode.PropertyMap.Name, list);
									}
									else
									{
										overNode.Obj.GetType().GetProperty(overNode.PropertyMap.Name).SetValue(overNode.Obj, dropObject, null);
									}
									RefreshAll();
								}								
							}
						}
					}
					else
					{
						if (dropObject != null)
						{
							OpenObject(dropObject);	
						}						
					}
				}
			}

			TurnOffTreeDragHilite();
		}	

		
		private void TreeViewItemDrag(ItemDragEventArgs e, object sender)
		{
			IObjectGuiItem objectGuiItem = (IObjectGuiItem) e.Item;
			object obj = objectGuiItem.Obj;
			string className = objectGuiItem.ClassMap.GetName();
			string dragMsg = GetObjectXml(obj, className, this.Context);
			((Control) sender).DoDragDrop(dragMsg, DragDropEffects.Copy | DragDropEffects.Move);
		}

		private object GetDropObject(XmlNode payload)
		{
			XmlNode classNode = payload.SelectSingleNode("class");
			XmlNode idNode = payload.SelectSingleNode("id");

			IClassMap classMap = Context.DomainMap.MustGetClassMap(classNode.InnerText);
			Type type = Context.AssemblyManager.MustGetTypeFromClassMap(classMap);

			return Context.GetObjectById(idNode.InnerText, type);
		}
		
		private void TreeViewDragEnter(DragEventArgs e)
		{
			string data = "";
	
			if (e.Data.GetDataPresent(typeof(string)))
			{
				data = (string) e.Data.GetData(typeof(string));
			}
	
			if (data == null)
				data = "";
	
			if (data.Length > 0)
			{
				string header ;
				XmlNode payload = ParseDragData(data, out header);
				if (header == "object")
				{
					e.Effect = DragDropEffects.Copy ; 
				}
			}
		}

		private ObjectTreeNode m_TreeDragHilited = null;

		private void TurnOnTreeDragHilite(ObjectTreeNode node)
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

				payload = xmlDoc.SelectSingleNode("object");

				if (payload != null)
				{
					header = "object";
					return payload;					
				}

				payload = xmlDoc.SelectSingleNode("class");

				if (payload != null)
				{
					header = "class";
					return payload;					
				}

				payload = xmlDoc.SelectSingleNode("property");

				if (payload != null)
				{
					header = "property";
					return payload;					
				}

			}
			return payload;
		}



		private void objectTreeView_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			((ObjectTreeNode) e.Node).OnExpand();
		}
		
		private void objectTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TreeViewAfterSelect((TreeView) sender, e);		
		}

		private void objectTreeView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			TreeViewMouseUp((TreeView) sender, e);		
		}


		private void objectTreeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			TreeViewDragDrop((TreeView) sender, e);
		}

		private void objectTreeView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			TreeViewDragEnter(e);
		}


		private void objectTreeView_DragLeave(object sender, System.EventArgs e)
		{
			TurnOffTreeDragHilite();
		}

		private void objectTreeView_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			TreeViewDragOver((TreeView) sender, e);
		}

		private void objectTreeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			TreeViewItemDrag(e, sender);
		}


		private void classTreeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
		
		}

		private void classTreeView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
		
		}

		private void classTreeView_DragLeave(object sender, System.EventArgs e)
		{
		
		}

		private void classTreeView_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
		
		}

		private void classTreeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			TreeNode node = (TreeNode) e.Item; 
			if (node != null)
			{
				if (node.ImageIndex == 0)
				{
					classTreeView.DoDragDrop("xml:<class>" + node.Text + "</class>", DragDropEffects.Copy | DragDropEffects.Move);									
				}
				else if (node.ImageIndex == 1)
				{
					classTreeView.DoDragDrop("xml:<property>" + node.Text + "</property>", DragDropEffects.Copy | DragDropEffects.Move);									
				}
			}		
		}

		
		private void classTreeView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			TreeViewMouseUp((TreeView) sender, e);		
		}


		#endregion

		#region PropertyGrid

		private void RefreshPropertyGrid()
		{
			objectPropertyGrid.SelectedObject = objectPropertyGrid.SelectedObject;
		}

		
		private void objectPropertyGrid_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			RefreshAll(((ObjectProperties) objectPropertyGrid.SelectedObject).Obj);
		}

		#endregion

		#region ContextMenu

		private void ShowContextMenu(Control ctrl, int x, int y)
		{
			if (contextMenuObjects.Count == 1)
			{
				if (contextMenuObjects[0] is MethodTreeNode)
					ShowMethodContextMenu(ctrl, x, y);
				if (contextMenuObjects[0] is IObjectGuiItem)
					ShowContextMenu((IObjectGuiItem) contextMenuObjects[0], ctrl, x, y);
				else if (contextMenuObjects[0] is TreeNode)
					ShowClassesTreeContextMenu((TreeNode) contextMenuObjects[0], ctrl, x, y);
			}
		}

		private void ShowMethodContextMenu(Control ctrl, int x, int y)
		{
			methodContextMenu.Show(ctrl, new Point(x, y));
		}


		private void ShowContextMenu(IObjectGuiItem objectGuiItem, Control ctrl, int x, int y)
		{
			if (objectGuiItem.PropertyMap != null)
			{
				ShowPropertyContextMenu(ctrl, x, y) ;
			}
			else if (objectGuiItem.ReferencedByObj != null)
			{
				ShowReferenceContextMenu(ctrl, x, y) ;
			}
			else if (objectGuiItem.Obj != null)
			{
				ShowObjectContextMenu(ctrl, x, y) ;
			}
		}

		private void ShowClassesTreeContextMenu(TreeNode treeNode, Control ctrl, int x, int y)
		{
			if (treeNode.ImageIndex == 0)
			{
				ShowClassContextMenu(ctrl, x, y) ;
			}
			else if (treeNode.ImageIndex == 1)
			{
				ShowSchemaPropertyContextMenu(ctrl, x, y) ;
			}
		}

		private void ShowObjectContextMenu(Control ctrl, int x, int y)
		{
			removeObjectMenuItem.Visible = false;
			objectContextMenu.Show(ctrl, new Point(x, y));
		}

		private void ShowReferenceContextMenu(Control ctrl, int x, int y)
		{
			removeObjectMenuItem.Visible = true;
			objectContextMenu.Show(ctrl, new Point(x, y));
		}

		private void ShowPropertyContextMenu(Control ctrl, int x, int y)
		{
			propertyContextMenu.Show(ctrl, new Point(x, y));
		}

		private void ShowClassContextMenu(Control ctrl, int x, int y)
		{
			classContextMenu.Show(ctrl, new Point(x, y));
		}

		private void ShowSchemaPropertyContextMenu(Control ctrl, int x, int y)
		{
			schemaPropertyContextMenu.Show(ctrl, new Point(x, y));
		}

		#region Event Handlers

		
		private void exploreObjectMenuItem_Click(object sender, System.EventArgs e)
		{
			foreach (IObjectGuiItem objectGuiItem in contextMenuObjects)
			{
				OpenObject(objectGuiItem.Obj);
				break;				
			}
		}

		private void removeObjectMenuItem_Click(object sender, System.EventArgs e)
		{
			foreach (IObjectGuiItem objectGuiItem in contextMenuObjects)
			{
				RemoveFromProperty(objectGuiItem.ReferencedByObj, objectGuiItem.ReferencedByPropertyMap, objectGuiItem.Obj);
				break;				
			}				
		}

		private void deleteObjectMenuItem_Click(object sender, System.EventArgs e)
		{
			foreach (IObjectGuiItem objectGuiItem in contextMenuObjects)
			{
				DeleteObject(objectGuiItem.Obj);
				break;				
			}		
		}


		private void refreshObjectMenuItem_Click(object sender, System.EventArgs e)
		{
	
		}

		private void clearPropertyMenuItem_Click(object sender, System.EventArgs e)
		{
			foreach (IObjectGuiItem objectGuiItem in contextMenuObjects)
			{
				ClearProperty(objectGuiItem.Obj, objectGuiItem.PropertyMap);
				break;				
			}		
		}

		#endregion

		#endregion


		private void MainForm_Load(object sender, System.EventArgs e)
		{
			AddErrorIcons();
			LoadDomainConfigList();
			RefreshAll();
		}

		private void openDomainMenuItem_Click(object sender, System.EventArgs e)
		{
			LoadDomain();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.Tag.ToString())
			{
				case "Open": 
					LoadDomain();
					break;
				case "Save": 
					SaveDomain();
					break;
				case "Validate": 
					ValidateModel();
					break;
				case "Run": 
					RunQuery();
					break;
			}
		}


		private void HandleExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			sqlLogTextBox.Text = "Executing Sql: " + e.Sql + "\r\n" + sqlLogTextBox.Text;
			Application.DoEvents() ;
		}

		private void HandleCallingWebService(object sender, WebServiceCancelEventArgs e)
		{
			webServiceLogTextBox.Text = "Calling Web Service: " + e.Method + " (" + e.Url + ") \r\n" + webServiceLogTextBox.Text;
			Application.DoEvents() ;
		}

		private void fileSaveMenuItem_Click(object sender, System.EventArgs e)
		{
		
		}

		private void objectClassMenuItem_Click(object sender, System.EventArgs e)
		{
		
		}

		private void objectNPathMenuItem_Click(object sender, System.EventArgs e)
		{
		
		}

		private void objectCreateMenuItem_Click(object sender, System.EventArgs e)
		{
		
		}

		#region QueryBox

		private void npathTextBox_TextChanged(object sender, System.EventArgs e)
		{
			//runToolBarButton.Enabled = npathTextBox.Text.Length > 0;
			runToolBarButton.Enabled = true;
		}

		
		private void npathTextBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string data = (string) e.Data.GetData(typeof(string));
			string header;
			XmlNode payload = ParseDragData(data, out header);
			if (header == "class" || header == "property")
				npathTextBox.SelectedText = payload.InnerText ; 
		}

		private void npathTextBox_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string data = (string) e.Data.GetData(typeof(string));
			string header;
			XmlNode payload = ParseDragData(data, out header);
			if (header == "class" || header == "property")
				e.Effect = DragDropEffects.Copy;
		
		}

		private void npathTextBox_DragLeave(object sender, System.EventArgs e)
		{
		
		}

		private void npathTextBox_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;		
		}

		#endregion

		private void SetKeyProperty(TreeNode propertyTreeNode)
		{
			string propertyName = propertyTreeNode.Text;
			string className = propertyTreeNode.Parent.Text;		
			SetKeyProperty(propertyName, className);
		}

		private void SetKeyProperty(string propertyName, string className)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(className);
			IPropertyMap propertyMap = classMap.MustGetPropertyMap(propertyName);
			SetKeyProperty(propertyMap);				
		}

		private void SetKeyProperty(IPropertyMap propertyMap)
		{
			this.Context.DomainMap.UnFixate();
			foreach (IPropertyMap keyPropertyMap in propertyMap.ClassMap.GetAllPropertyMaps() )
			{
				keyPropertyMap.IsKey = false;
				keyPropertyMap.KeyIndex = 0;
			}

			propertyMap.IsKey = true;
			propertyMap.KeyIndex = 0;

			this.Context.DomainMap.Fixate();
			RefreshAll();
		}

		private void AddKeyProperty(TreeNode propertyTreeNode)
		{
			string propertyName = propertyTreeNode.Text;
			string className = propertyTreeNode.Parent.Text;		
			AddKeyProperty(propertyName, className);
		}

		private void AddKeyProperty(string propertyName, string className)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(className);
			IPropertyMap propertyMap = classMap.MustGetPropertyMap(propertyName);
			AddKeyProperty(propertyMap);
				
		}

		private void AddKeyProperty(IPropertyMap propertyMap)
		{
			this.Context.DomainMap.UnFixate();
			propertyMap.KeyIndex = propertyMap.ClassMap.GetKeyPropertyMaps().Count ;
			propertyMap.IsKey = true;

			this.Context.DomainMap.Fixate();
			RefreshAll();
		}


		private void fetchAllObjectsMenuItem_Click(object sender, System.EventArgs e)
		{
			GetAllObjectsOfClass();
		}

		private void fetchTopObjectsMenuItem_Click(object sender, System.EventArgs e)
		{
			GetTopObjectsOfClass();		
		}

		private void createObjectMenuItem_Click(object sender, System.EventArgs e)
		{
			CreateObject();
		}


		private void CallMethod(MethodTreeNode methodTreeNode)
		{
			try
			{
				object result = methodTreeNode.InvokeMethod((MethodProperties) objectPropertyGrid.SelectedObject);
				if (result != null)
				{
					MessageBox.Show(result.ToString() ); 							
				}				
				else
				{
					MessageBox.Show("Method completed and returned null.");					
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Method threw the following exception: " + ex.ToString() );				
			}
		}

		private void callMethodMenuItem_Click(object sender, System.EventArgs e)
		{
			CallMethod((MethodTreeNode) contextMenuObjects[0]);	
		}

		private void queryDataSourceMenuItem_Click(object sender, System.EventArgs e)
		{
			queryDataSourceMenuItem.Checked = true;		
			queryFilterMenuItem.Checked = false;
			queryResultMenuItem.Checked = false;
		
		}

		private void queryFilterMenuItem_Click(object sender, System.EventArgs e)
		{
			queryDataSourceMenuItem.Checked = false;		
			queryFilterMenuItem.Checked = true;
			queryResultMenuItem.Checked = false;
		
		}

		private void queryResultMenuItem_Click(object sender, System.EventArgs e)
		{
			queryDataSourceMenuItem.Checked = false;		
			queryFilterMenuItem.Checked = false;
			queryResultMenuItem.Checked = true;
		
		}

		private void AddErrorIcons()
		{
			IList newImages = new ArrayList();
			Image errorImg = imageList1.Images[imageList1.Images.Count - 1];

			foreach (Image img in imageList1.Images)
			{
				AddErrorIconToImage(img, newImages, errorImg);
			}

			foreach (Image img in newImages)
			{
				imageList1.Images.Add(img);				
			}

			ImageListCount = imageList1.Images.Count ;
		}


		private void AddErrorIconToImage(Image img, IList newImages, Image errorImg)
		{
			Bitmap bmp = new Bitmap(16, 16);
			Graphics g = Graphics.FromImage(bmp);

			g.DrawImage(img, 0, 0, 16, 16);
			g.DrawImage(errorImg, 0, 0, 16, 16);
			g.Dispose();

			newImages.Add(bmp);			
		}


		private void ValidateModel()
		{
			Exceptions.Clear() ;
			Context.ValidateUnitOfWork(Exceptions);
			ListAllExceptions();
		}

		private void ListAllExceptions()
		{
			errorsListView.Visible = true ;
			compilerErrorListView.Visible = false ;
			exceptionsListView.Visible = false ;
			errorsListView.Items.Clear() ;
			if (Exceptions.Count > 0)
			{
				bottomTabControl.SelectedTab = errorsTabPage;
				foreach (Exception ex in Exceptions)
				{
					NPersistValidationException validationException = ex as NPersistValidationException;
					if (validationException != null)
					{
						ExceptionListViewItem listViewItem = new ExceptionListViewItem(Context, validationException, ImageListCount) ;
						errorsListView.Items.Add(listViewItem);
					}
				}				
			}
		}


		private void ListAllSystemExceptions(IList exceptions)
		{
			errorsListView.Visible = false;
			compilerErrorListView.Visible = false ;
			exceptionsListView.Visible = true ;
			exceptionsListView.Items.Clear() ;
			if (exceptions.Count > 0)
			{
				bottomTabControl.SelectedTab = errorsTabPage;
				foreach (Exception ex in exceptions)
				{
					SystemExceptionListViewItem listViewItem = new SystemExceptionListViewItem(Context, ex, ImageListCount) ;
					exceptionsListView.Items.Add(listViewItem);
				}				
			}
		}
		private void fieldLevelOptimisticConcurrencyMenuItem_Click(object sender, System.EventArgs e)
		{
		
		}

		private void rowLevelOptimisticConcurrencyMenuItem_Click(object sender, System.EventArgs e)
		{
		
		}

		private void noOptimisticConcurrencyMenuItem_Click(object sender, System.EventArgs e)
		{
		
		}

		private void setKeyMenuItem_Click(object sender, System.EventArgs e)
		{
			SetKeyProperty((TreeNode) contextMenuObjects[0]);
		}

		private void addToKeyMenuItem_Click(object sender, System.EventArgs e)
		{
			AddKeyProperty((TreeNode) contextMenuObjects[0]);		
		}

		private void compareObjectMenuItem_Click(object sender, System.EventArgs e)
		{
		
		}

		private void clearClipboardMenuItem_Click(object sender, System.EventArgs e)
		{
			clipBoardListView.Items.Clear() ;
		}

		private void refreshObjectUnmodifiedMenuItem_Click(object sender, System.EventArgs e)
		{
			foreach (IObjectGuiItem objectGuiItem in contextMenuObjects)
			{
				RefreshObject(objectGuiItem.Obj);
				break;				
			}			
		}

		private void refreshObjectAllMenuItem_Click(object sender, System.EventArgs e)
		{
			foreach (IObjectGuiItem objectGuiItem in contextMenuObjects)
			{
				RefreshObject(objectGuiItem.Obj, RefreshBehaviorType.OverwriteDirty);
				break;				
			}					
		}

		private void comparePropertyMenuItem_Click(object sender, System.EventArgs e)
		{
			foreach (IObjectGuiItem objectGuiItem in contextMenuObjects)
			{
				CompareProperty(objectGuiItem.Obj, objectGuiItem.PropertyMap.Name);
				break;				
			}					
		}


		#region SyntaxBox


		#endregion		 

	}
}
