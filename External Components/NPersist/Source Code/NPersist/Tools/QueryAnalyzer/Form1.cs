using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NCore.Framework;
using Puzzle.NPersist.Framework.NPath;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper;

namespace Puzzle.NPersist.Tools.QueryAnalyzer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Panel panelTree;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panelRowList;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panelQuery;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Panel panelObjectList;
		private System.Windows.Forms.TreeView treeSchema;
		private System.Windows.Forms.DataGrid gridRows;
		private System.Windows.Forms.ToolBarButton buttonRun;
		private System.Windows.Forms.ToolBarButton buttonLoad;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.DataGrid gridObjects;
		private System.Windows.Forms.Splitter splitter4;
		private Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper textQuery;
		private Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper textSql;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuEdit;
		private System.Windows.Forms.MenuItem menuTools;
		private System.Windows.Forms.MenuItem menuToolsOptions;
		private System.Windows.Forms.MenuItem menuQuery;
		private System.Windows.Forms.MenuItem menuQueryExecute;
		private System.Windows.Forms.MenuItem menuQueryParse;
		private System.Windows.Forms.ToolBarButton buttonParse;
		private System.Windows.Forms.MenuItem menuFileOpen;
		private System.Windows.Forms.MenuItem menuFileExit;
		private System.Windows.Forms.MenuItem menuItem3;
		private Puzzle.SourceCode.SyntaxDocument syntaxDocument1;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			LoadSyntaxFiles();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.buttonLoad = new System.Windows.Forms.ToolBarButton();
			this.buttonParse = new System.Windows.Forms.ToolBarButton();
			this.buttonRun = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.panelTree = new System.Windows.Forms.Panel();
			this.treeSchema = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panelRowList = new System.Windows.Forms.Panel();
			this.gridRows = new System.Windows.Forms.DataGrid();
			this.splitter4 = new System.Windows.Forms.Splitter();
			this.textSql = new Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panelQuery = new System.Windows.Forms.Panel();
			this.textQuery = new Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper();
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.panelObjectList = new System.Windows.Forms.Panel();
			this.gridObjects = new System.Windows.Forms.DataGrid();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuFileOpen = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuFileExit = new System.Windows.Forms.MenuItem();
			this.menuEdit = new System.Windows.Forms.MenuItem();
			this.menuQuery = new System.Windows.Forms.MenuItem();
			this.menuQueryParse = new System.Windows.Forms.MenuItem();
			this.menuQueryExecute = new System.Windows.Forms.MenuItem();
			this.menuTools = new System.Windows.Forms.MenuItem();
			this.menuToolsOptions = new System.Windows.Forms.MenuItem();
			this.syntaxDocument1 = new Puzzle.SourceCode.SyntaxDocument(this.components);
			this.panelTree.SuspendLayout();
			this.panelRowList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridRows)).BeginInit();
			this.panelQuery.SuspendLayout();
			this.panelObjectList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridObjects)).BeginInit();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.buttonLoad,
																						this.buttonParse,
																						this.buttonRun});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(733, 28);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// buttonLoad
			// 
			this.buttonLoad.ImageIndex = 4;
			this.buttonLoad.Tag = "Load";
			this.buttonLoad.ToolTipText = "Load Domain";
			// 
			// buttonParse
			// 
			this.buttonParse.ImageIndex = 8;
			this.buttonParse.Tag = "Parse";
			this.buttonParse.ToolTipText = "Parse Query";
			// 
			// buttonRun
			// 
			this.buttonRun.ImageIndex = 6;
			this.buttonRun.Tag = "Run";
			this.buttonRun.ToolTipText = "Execute Query";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 473);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(733, 19);
			this.statusBar1.TabIndex = 1;
			this.statusBar1.Text = "statusBar1";
			// 
			// panelTree
			// 
			this.panelTree.Controls.Add(this.treeSchema);
			this.panelTree.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelTree.Location = new System.Drawing.Point(0, 28);
			this.panelTree.Name = "panelTree";
			this.panelTree.Size = new System.Drawing.Size(167, 445);
			this.panelTree.TabIndex = 2;
			// 
			// treeSchema
			// 
			this.treeSchema.AllowDrop = true;
			this.treeSchema.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeSchema.ImageList = this.imageList1;
			this.treeSchema.Location = new System.Drawing.Point(0, 0);
			this.treeSchema.Name = "treeSchema";
			this.treeSchema.Size = new System.Drawing.Size(167, 445);
			this.treeSchema.TabIndex = 0;
			this.treeSchema.DragOver += new System.Windows.Forms.DragEventHandler(this.treeSchema_DragOver);
			this.treeSchema.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeSchema_DragEnter);
			this.treeSchema.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeSchema_ItemDrag);
			this.treeSchema.DragLeave += new System.EventHandler(this.treeSchema_DragLeave);
			this.treeSchema.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeSchema_DragDrop);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(167, 28);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(2, 445);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// panelRowList
			// 
			this.panelRowList.Controls.Add(this.gridRows);
			this.panelRowList.Controls.Add(this.splitter4);
			this.panelRowList.Controls.Add(this.textSql);
			this.panelRowList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelRowList.Location = new System.Drawing.Point(169, 321);
			this.panelRowList.Name = "panelRowList";
			this.panelRowList.Size = new System.Drawing.Size(564, 152);
			this.panelRowList.TabIndex = 4;
			// 
			// gridRows
			// 
			this.gridRows.CaptionText = "Relational Result Set";
			this.gridRows.DataMember = "";
			this.gridRows.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridRows.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridRows.Location = new System.Drawing.Point(0, 72);
			this.gridRows.Name = "gridRows";
			this.gridRows.Size = new System.Drawing.Size(564, 80);
			this.gridRows.TabIndex = 0;
			// 
			// splitter4
			// 
			this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter4.Location = new System.Drawing.Point(0, 69);
			this.splitter4.Name = "splitter4";
			this.splitter4.Size = new System.Drawing.Size(564, 3);
			this.splitter4.TabIndex = 2;
			this.splitter4.TabStop = false;
			// 
			// textSql
			// 
			this.textSql.Dock = System.Windows.Forms.DockStyle.Top;
			this.textSql.Location = new System.Drawing.Point(0, 0);
			this.textSql.Name = "textSql";
			this.textSql.ReadOnly = false;
			this.textSql.SelectedText = "";
			this.textSql.Size = new System.Drawing.Size(564, 69);
			this.textSql.TabIndex = 3;
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(169, 318);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(564, 3);
			this.splitter2.TabIndex = 5;
			this.splitter2.TabStop = false;
			// 
			// panelQuery
			// 
			this.panelQuery.Controls.Add(this.textQuery);
			this.panelQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelQuery.Location = new System.Drawing.Point(169, 28);
			this.panelQuery.Name = "panelQuery";
			this.panelQuery.Size = new System.Drawing.Size(564, 87);
			this.panelQuery.TabIndex = 6;
			// 
			// textQuery
			// 
			this.textQuery.AllowDrop = true;
			this.textQuery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textQuery.Location = new System.Drawing.Point(0, 0);
			this.textQuery.Name = "textQuery";
			this.textQuery.ReadOnly = false;
			this.textQuery.SelectedText = "";
			this.textQuery.Size = new System.Drawing.Size(564, 87);
			this.textQuery.TabIndex = 2;
			this.textQuery.DragEnter += new System.Windows.Forms.DragEventHandler(this.textQuery_DragEnter);
			this.textQuery.DragLeave += new System.EventHandler(this.textQuery_DragLeave);
			this.textQuery.DragDrop += new System.Windows.Forms.DragEventHandler(this.textQuery_DragDrop);
			this.textQuery.DragOver += new System.Windows.Forms.DragEventHandler(this.textQuery_DragOver);
			// 
			// splitter3
			// 
			this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter3.Location = new System.Drawing.Point(169, 115);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(564, 3);
			this.splitter3.TabIndex = 7;
			this.splitter3.TabStop = false;
			// 
			// panelObjectList
			// 
			this.panelObjectList.Controls.Add(this.gridObjects);
			this.panelObjectList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelObjectList.Location = new System.Drawing.Point(169, 118);
			this.panelObjectList.Name = "panelObjectList";
			this.panelObjectList.Size = new System.Drawing.Size(564, 200);
			this.panelObjectList.TabIndex = 8;
			// 
			// gridObjects
			// 
			this.gridObjects.CaptionText = "Object Result Set";
			this.gridObjects.DataMember = "";
			this.gridObjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridObjects.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridObjects.Location = new System.Drawing.Point(0, 0);
			this.gridObjects.Name = "gridObjects";
			this.gridObjects.Size = new System.Drawing.Size(564, 200);
			this.gridObjects.TabIndex = 0;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuFile,
																					  this.menuEdit,
																					  this.menuQuery,
																					  this.menuTools});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFileOpen,
																					 this.menuItem3,
																					 this.menuFileExit});
			this.menuFile.Text = "File";
			// 
			// menuFileOpen
			// 
			this.menuFileOpen.Index = 0;
			this.menuFileOpen.Text = "Open";
			this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "-";
			// 
			// menuFileExit
			// 
			this.menuFileExit.Index = 2;
			this.menuFileExit.Text = "Exit";
			this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
			// 
			// menuEdit
			// 
			this.menuEdit.Index = 1;
			this.menuEdit.Text = "Edit";
			this.menuEdit.Visible = false;
			// 
			// menuQuery
			// 
			this.menuQuery.Index = 2;
			this.menuQuery.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuQueryParse,
																					  this.menuQueryExecute});
			this.menuQuery.Text = "Query";
			// 
			// menuQueryParse
			// 
			this.menuQueryParse.Index = 0;
			this.menuQueryParse.Shortcut = System.Windows.Forms.Shortcut.CtrlF5;
			this.menuQueryParse.Text = "Parse";
			this.menuQueryParse.Click += new System.EventHandler(this.menuQueryParse_Click);
			// 
			// menuQueryExecute
			// 
			this.menuQueryExecute.Index = 1;
			this.menuQueryExecute.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.menuQueryExecute.Text = "Execute";
			this.menuQueryExecute.Click += new System.EventHandler(this.menuQueryExecute_Click);
			// 
			// menuTools
			// 
			this.menuTools.Index = 3;
			this.menuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuToolsOptions});
			this.menuTools.Text = "Tools";
			this.menuTools.Visible = false;
			// 
			// menuToolsOptions
			// 
			this.menuToolsOptions.Index = 0;
			this.menuToolsOptions.Text = "Options";
			this.menuToolsOptions.Click += new System.EventHandler(this.menuToolsOptions_Click);
			// 
			// syntaxDocument1
			// 
			this.syntaxDocument1.Lines = new string[] {
														  ""};
			this.syntaxDocument1.MaxUndoBufferSize = 1000;
			this.syntaxDocument1.Modified = false;
			this.syntaxDocument1.UndoStep = 0;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(733, 492);
			this.Controls.Add(this.panelObjectList);
			this.Controls.Add(this.splitter3);
			this.Controls.Add(this.panelQuery);
			this.Controls.Add(this.splitter2);
			this.Controls.Add(this.panelRowList);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panelTree);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.toolBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "NPersist Query Analyzer";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panelTree.ResumeLayout(false);
			this.panelRowList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridRows)).EndInit();
			this.panelQuery.ResumeLayout(false);
			this.panelObjectList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridObjects)).EndInit();
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
			Application.Run(new Form1());
		}

		public static string domainConfigListPath = Application.StartupPath + @"\DomainConfigs.xml";
		public static DomainConfigList domainConfigList;

		private DomainConfig domainConfig = new DomainConfig() ; 

		private string mapPath = "";
		private string connectionString = "";
		private Assembly domain = null;

		
		private void LoadDomainConfigList()
		{
			domainConfigList = DomainConfigList.Load(domainConfigListPath);		
		}
		
		
		private void LoadDomainConfig(DomainConfig config)
		{
			mapPath = config.MapPath;
			connectionString = config.ConnectionString;
			domain = System.Reflection.Assembly.LoadFrom(config.AssemblyPath);
			FillTreeSchema();
		}

		private void LoadSyntaxFiles()
		{
			textQuery.SetupNPath();			
			textSql.SetupSqlServerSql();
		}

		private void LoadDomain()
		{
			DomainConfigForm frm = new DomainConfigForm() ;
			frm.SetConfig(domainConfig);
			if (frm.ShowDialog(this) == DialogResult.OK)
			{
				LoadDomainConfig(domainConfig);				
			}
		}

		private IContext GetContext()
		{
			IContext context = new Context(mapPath);
			
			if (connectionString != "")
			{
				context.SetConnectionString(connectionString);
			}

			context.AssemblyManager.RegisterAssembly(domain);
			return context;
		}

		private void RunQuery()
		{
			RunQuery(false);
		}

		private void ParseQuery()
		{
			RunQuery(true);
		}

		private void RunQuery(bool eval)
		{
			string query = GetQuery();
			if (query == "")
			{
				MessageBox.Show("You must enter a query first!");
				return;				
			}
			try
			{
			NPathQuery npath = new NPathQuery(query) ;
				IContext context = GetContext();
				IClassMap classMap = context.NPathEngine.GetRootClassMap(query, context.DomainMap);
				Type type = context.AssemblyManager.MustGetTypeFromClassMap(classMap);

				if (type == null)
					throw new Exception("Could not find type for classMap " + classMap.Name);

				npath.Context = context;
				npath.PrimaryType = type;

				NPathQueryType npathQueryType = context.NPathEngine.GetNPathQueryType(query);
				
				string sql = npath.ToSql();
				textSql.Text = sql;					

				if (!(eval))
				{

					if (npathQueryType == NPathQueryType.SelectObjects)
					{
						 
						DataTable sqlResult = context.SqlExecutor.ExecuteDataTable(sql, context.GetDataSource( classMap.GetSourceMap()), npath.Parameters);
						gridRows.DataSource = sqlResult;
					
						IList result = context.GetObjectsByQuery(npath);
						DataTable table = GetDataTable(result, context);
						gridObjects.DataSource = table;					

					}

					if (npathQueryType == NPathQueryType.SelectScalar)
					{

						DataTable sqlResult = context.SqlExecutor.ExecuteDataTable(sql, context.GetDataSource( classMap.GetSourceMap()));
						gridRows.DataSource = sqlResult;
					
						object result = context.ExecuteScalar(npath);
						DataTable table = GetScalarDataTable(result);
						gridObjects.DataSource = table;					

					}

					if (npathQueryType == NPathQueryType.SelectTable )
					{

						DataTable sqlResult = context.SqlExecutor.ExecuteDataTable(sql, context.GetDataSource( classMap.GetSourceMap()));
						gridRows.DataSource = sqlResult;
					
						DataTable result = context.GetDataTable(npath);
						gridObjects.DataSource = result;	

					}

				}
				context.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);				
			}
		}

		private string GetQuery()
		{
			ITextBox textBox = textQuery;
			string query = textBox.SelectedText ;
			if (query == "") { query = textBox.Text; }
			return query;
		}

		private DataTable GetScalarDataTable(object result)
		{
			DataTable table = new DataTable() ;
			table.Columns.Add("Result", result.GetType());
			DataRow dr = table.NewRow();
			dr["Result"] = result;
			table.Rows.Add(dr);
			return table;
		}


		private DataTable GetDataTable(IList objects, IContext context)
		{
			DataTable table = new DataTable() ;
			IClassMap classMap = null;
			foreach (object obj in objects)
			{
				classMap = context.DomainMap.MustGetClassMap(obj.GetType());
				SetupTableColumns(obj, table, classMap, context);
				//break;
			}			
			foreach (object obj in objects)
			{
				AddObjectToTable(obj, table, classMap, context);
			}			
			return table;
		}

		private void SetupTableColumns(object obj, DataTable table, IClassMap classMap, IContext context)
		{
			SetupTableColumns(obj, table, classMap, context, "");
		}

		private void SetupTableColumns(object obj, DataTable table, IClassMap classMap, IContext context, string prefix)
		{
			object refObj;
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				if (context.GetPropertyStatus(obj, propertyMap.Name) == PropertyStatus.NotLoaded)
				{
				}
				else
				{
					if (!(propertyMap.IsCollection))
					{					
						if (propertyMap.ReferenceType != ReferenceType.None)
						{
						}
						else
						{
							if (!(table.Columns.Contains(prefix + propertyMap.Name)))
							{
								table.Columns.Add(prefix + propertyMap.Name, obj.GetType().GetProperty(propertyMap.Name).PropertyType );								
							}
						}
					}
				}
			}
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				if (context.GetPropertyStatus(obj, propertyMap.Name) == PropertyStatus.NotLoaded)
				{
				}
				else
				{
					if (!(propertyMap.IsCollection))
					{					
						if (propertyMap.ReferenceType != ReferenceType.None)
						{
							refObj = context.ObjectManager.GetPropertyValue(obj, propertyMap.Name);
							if (refObj == null)
							{
								
							}
							else
							{
								SetupTableColumns(refObj, 
									table, propertyMap.GetReferencedClassMap(), 
									context, 
									prefix + propertyMap.Name + ".");								
							}
						}
						else
						{
						}
					}
				}
			}

		}

		private void AddObjectToTable(object obj, DataTable table, IClassMap classMap, IContext context)
		{
			DataRow dr = table.NewRow() ;
			string prefix = "";
			AddObjectToTable(obj, table, classMap, context, prefix, dr);
		}

		private void AddObjectToTable(object obj, DataTable table, IClassMap classMap, IContext context, string prefix, DataRow dr)
		{
			object refObj;
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				if (!(propertyMap.IsCollection))
				{
					if (context.GetPropertyStatus(obj, propertyMap.Name) != PropertyStatus.NotLoaded)
					{
						if (propertyMap.ReferenceType != ReferenceType.None)
						{
						}
						else
						{
							if (table.Columns.Contains(prefix + propertyMap.Name))
							{
								if (obj.GetType().GetProperty(propertyMap.Name).GetValue(obj, null) == null)
								{
									dr[prefix + propertyMap.Name] = System.DBNull.Value;							
								}
								else
								{
									dr[prefix + propertyMap.Name] = obj.GetType().GetProperty(propertyMap.Name).GetValue(obj, null);
								}							
								
							}
						}
					}					
				}
			}
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				if (!(propertyMap.IsCollection))
				{
					if (context.GetPropertyStatus(obj, propertyMap.Name) != PropertyStatus.NotLoaded)
					{
						if (propertyMap.ReferenceType != ReferenceType.None)
						{
							refObj = obj.GetType().GetProperty(propertyMap.Name).GetValue(obj, null);
							if (refObj == null)
							{
								if (table.Columns.Contains(prefix + propertyMap.Name))
								{
									dr[prefix + propertyMap.Name] = System.DBNull.Value;																
								}
							}
							else
							{
								AddObjectToTable(refObj,
									table, 
									context.DomainMap.MustGetClassMap(refObj.GetType()), 
									context, 
									prefix + propertyMap.Name + ".",
									dr);
							}							
						}
						else
						{
						}
					}					
				}
			}

			if (prefix == "")
			{			
				table.Rows.Add(dr);	
			}
		}
		
		private void FillTreeSchema()
		{
			TreeNode classNode;
			TreeNode propNode;
			treeSchema.Nodes.Clear();
			IContext context = GetContext();
			foreach (IClassMap classMap in context.DomainMap.GetPersistentClassMaps())
			{
				classNode = new TreeNode(classMap.Name, 0, 1) ;
				treeSchema.Nodes.Add(classNode);	
				foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
				{
					propNode = new TreeNode(propertyMap.Name, 2, 3) ;
					classNode.Nodes.Add(propNode);	
				}
			}
			context.Dispose();
		}


		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (((string)e.Button.Tag) == "Load")
			{
				LoadDomain();
			}
			else if (((string)e.Button.Tag) == "Parse")
			{
				ParseQuery();
			}
			else if (((string)e.Button.Tag) == "Run")
			{
				RunQuery();
			}
		}

		private void menuToolsOptions_Click(object sender, System.EventArgs e)
		{

		}

		private void menuQueryExecute_Click(object sender, System.EventArgs e)
		{
			RunQuery();
		}

		private void treeSchema_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
		
		}

		private void treeSchema_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
		
		}

		private void treeSchema_DragLeave(object sender, System.EventArgs e)
		{
		
		}

		private void treeSchema_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			
		}

		private void treeSchema_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			TreeNode node = (TreeNode) e.Item; 
			if (node != null)
			{
				treeSchema.DoDragDrop(node.Text, DragDropEffects.Copy | DragDropEffects.Move);				
			}
		}

		private void textQuery_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			textQuery.Text = (string) e.Data.GetData(typeof(string));
		}

		private void textQuery_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		
		}

		private void textQuery_DragLeave(object sender, System.EventArgs e)
		{
		
		}

		private void textQuery_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		
		}

		private void menuQueryParse_Click(object sender, System.EventArgs e)
		{
			ParseQuery();
		}

		private void menuFileOpen_Click(object sender, System.EventArgs e)
		{
			LoadDomain(); 
		}

		private void menuFileExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			LoadDomainConfigList();
		}



	}
}
