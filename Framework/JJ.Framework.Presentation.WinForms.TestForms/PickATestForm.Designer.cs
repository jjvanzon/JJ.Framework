namespace JJ.Framework.Presentation.WinForms.TestForms
{
    partial class PickATestForm
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
            this.diagramControl1 = new JJ.Framework.Presentation.WinForms.Controls.DiagramControl();
            this.buttonShowHierarchyTestForm = new System.Windows.Forms.Button();
            this.buttonShowVectorGraphicsWithFlatClone_TestForm = new System.Windows.Forms.Button();
            this.buttonShowVectorGraphicsWithoutCloning_TestForm = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonShowGestureTestForm = new System.Windows.Forms.Button();
            this.buttonShowHelloWorldTestForm = new System.Windows.Forms.Button();
            this.buttonShowCurveTest = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // diagramControl1
            // 
            this.diagramControl1.Diagram = null;
            this.diagramControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagramControl1.Location = new System.Drawing.Point(0, 0);
            this.diagramControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.diagramControl1.Name = "diagramControl1";
            this.diagramControl1.Size = new System.Drawing.Size(315, 319);
            this.diagramControl1.TabIndex = 0;
            // 
            // buttonShowHierarchyTestForm
            // 
            this.buttonShowHierarchyTestForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowHierarchyTestForm.Location = new System.Drawing.Point(19, 68);
            this.buttonShowHierarchyTestForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowHierarchyTestForm.Name = "buttonShowHierarchyTestForm";
            this.buttonShowHierarchyTestForm.Size = new System.Drawing.Size(277, 38);
            this.buttonShowHierarchyTestForm.TabIndex = 1;
            this.buttonShowHierarchyTestForm.Text = "Hierarchy Test";
            this.buttonShowHierarchyTestForm.UseVisualStyleBackColor = true;
            this.buttonShowHierarchyTestForm.Click += new System.EventHandler(this.buttonShowHierarchyTestForm_Click);
            // 
            // buttonShowVectorGraphicsWithFlatClone_TestForm
            // 
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Location = new System.Drawing.Point(19, 116);
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Name = "buttonShowVectorGraphicsWithFlatClone_TestForm";
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Size = new System.Drawing.Size(277, 38);
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.TabIndex = 3;
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Text = "VectorGraphics With Flat Clone Test";
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.UseVisualStyleBackColor = true;
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Click += new System.EventHandler(this.buttonShowVectorGraphicsWithFlatClone_TestForm_Click);
            // 
            // buttonShowVectorGraphicsWithoutCloning_TestForm
            // 
            this.buttonShowVectorGraphicsWithoutCloning_TestForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowVectorGraphicsWithoutCloning_TestForm.Location = new System.Drawing.Point(19, 164);
            this.buttonShowVectorGraphicsWithoutCloning_TestForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowVectorGraphicsWithoutCloning_TestForm.Name = "buttonShowVectorGraphicsWithoutCloning_TestForm";
            this.buttonShowVectorGraphicsWithoutCloning_TestForm.Size = new System.Drawing.Size(277, 38);
            this.buttonShowVectorGraphicsWithoutCloning_TestForm.TabIndex = 4;
            this.buttonShowVectorGraphicsWithoutCloning_TestForm.Text = "VectorGraphics Without Cloning Test";
            this.buttonShowVectorGraphicsWithoutCloning_TestForm.UseVisualStyleBackColor = true;
            this.buttonShowVectorGraphicsWithoutCloning_TestForm.Click += new System.EventHandler(this.buttonShowVectorGraphicsWithoutCloning_TestForm_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonShowCurveTest, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowGestureTestForm, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowVectorGraphicsWithoutCloning_TestForm, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowHierarchyTestForm, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowHelloWorldTestForm, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowVectorGraphicsWithFlatClone_TestForm, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(315, 319);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // buttonShowGestureTestForm
            // 
            this.buttonShowGestureTestForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowGestureTestForm.Location = new System.Drawing.Point(19, 212);
            this.buttonShowGestureTestForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowGestureTestForm.Name = "buttonShowGestureTestForm";
            this.buttonShowGestureTestForm.Size = new System.Drawing.Size(277, 38);
            this.buttonShowGestureTestForm.TabIndex = 5;
            this.buttonShowGestureTestForm.Text = "Gesture Test";
            this.buttonShowGestureTestForm.UseVisualStyleBackColor = true;
            this.buttonShowGestureTestForm.Click += new System.EventHandler(this.buttonShowGestureTestForm_Click);
            // 
            // buttonShowHelloWorldTestForm
            // 
            this.buttonShowHelloWorldTestForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowHelloWorldTestForm.Location = new System.Drawing.Point(19, 20);
            this.buttonShowHelloWorldTestForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowHelloWorldTestForm.Name = "buttonShowHelloWorldTestForm";
            this.buttonShowHelloWorldTestForm.Size = new System.Drawing.Size(277, 38);
            this.buttonShowHelloWorldTestForm.TabIndex = 2;
            this.buttonShowHelloWorldTestForm.Text = "Hello World Test";
            this.buttonShowHelloWorldTestForm.UseVisualStyleBackColor = true;
            this.buttonShowHelloWorldTestForm.Click += new System.EventHandler(this.buttonShowHelloWorldTestForm_Click);
            // 
            // buttonShowCurveTest
            // 
            this.buttonShowCurveTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowCurveTest.Location = new System.Drawing.Point(19, 260);
            this.buttonShowCurveTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowCurveTest.Name = "buttonShowCurveTest";
            this.buttonShowCurveTest.Size = new System.Drawing.Size(277, 39);
            this.buttonShowCurveTest.TabIndex = 6;
            this.buttonShowCurveTest.Text = "Curve Test";
            this.buttonShowCurveTest.UseVisualStyleBackColor = true;
            this.buttonShowCurveTest.Click += new System.EventHandler(this.buttonShowCurveTest_Click);
            // 
            // PickATestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 319);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.diagramControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PickATestForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.DiagramControl diagramControl1;
        private System.Windows.Forms.Button buttonShowHierarchyTestForm;
        private System.Windows.Forms.Button buttonShowVectorGraphicsWithFlatClone_TestForm;
        private System.Windows.Forms.Button buttonShowVectorGraphicsWithoutCloning_TestForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonShowHelloWorldTestForm;
        private System.Windows.Forms.Button buttonShowGestureTestForm;
        private System.Windows.Forms.Button buttonShowCurveTest;
    }
}

