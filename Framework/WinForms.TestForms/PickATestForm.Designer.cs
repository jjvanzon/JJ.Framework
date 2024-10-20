﻿using JJ.Framework.WinForms.Controls;

namespace JJ.Framework.WinForms.TestForms
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
            this.diagramControl1 = new JJ.Framework.WinForms.Controls.DiagramControl();
            this.buttonShowHierarchyTestForm = new System.Windows.Forms.Button();
            this.buttonShowVectorGraphicsWithFlatClone_TestForm = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonShowFlowPositionerRightAlignedTest = new System.Windows.Forms.Button();
            this.buttonShowFlowPositionerLeftAlignedTest = new System.Windows.Forms.Button();
            this.buttonShowPictureTest = new System.Windows.Forms.Button();
            this.buttonShowEllipseTest = new System.Windows.Forms.Button();
            this.buttonShowScaleTest = new System.Windows.Forms.Button();
            this.buttonShowFilePathControlTest = new System.Windows.Forms.Button();
            this.buttonShowGestureTestForm = new System.Windows.Forms.Button();
            this.buttonShowHelloWorldTestForm = new System.Windows.Forms.Button();
            this.buttonShowCurveTest = new System.Windows.Forms.Button();
            this.buttonShowSimpleProcessControlTest = new System.Windows.Forms.Button();
            this.buttonShowSimpleProcessFormTest = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // diagramControl1
            // 
            this.diagramControl1.Diagram = null;
            this.diagramControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagramControl1.Location = new System.Drawing.Point(0, 0);
            this.diagramControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.diagramControl1.Name = "diagramControl1";
            this.diagramControl1.Size = new System.Drawing.Size(561, 604);
            this.diagramControl1.TabIndex = 0;
            // 
            // buttonShowHierarchyTestForm
            // 
            this.buttonShowHierarchyTestForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowHierarchyTestForm.Location = new System.Drawing.Point(19, 372);
            this.buttonShowHierarchyTestForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowHierarchyTestForm.Name = "buttonShowHierarchyTestForm";
            this.buttonShowHierarchyTestForm.Size = new System.Drawing.Size(523, 34);
            this.buttonShowHierarchyTestForm.TabIndex = 1;
            this.buttonShowHierarchyTestForm.Text = "Hierarchy Test";
            this.buttonShowHierarchyTestForm.UseVisualStyleBackColor = true;
            this.buttonShowHierarchyTestForm.Click += new System.EventHandler(this.buttonShowHierarchyTestForm_Click);
            // 
            // buttonShowVectorGraphicsWithFlatClone_TestForm
            // 
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Location = new System.Drawing.Point(19, 20);
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Name = "buttonShowVectorGraphicsWithFlatClone_TestForm";
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Size = new System.Drawing.Size(523, 34);
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.TabIndex = 3;
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Text = "VectorGraphics With Flat Clone Test";
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.UseVisualStyleBackColor = true;
            this.buttonShowVectorGraphicsWithFlatClone_TestForm.Click += new System.EventHandler(this.buttonShowVectorGraphicsWithFlatClone_TestForm_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonShowSimpleProcessFormTest, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowSimpleProcessControlTest, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowPictureTest, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowVectorGraphicsWithFlatClone_TestForm, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowCurveTest, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowEllipseTest, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowFilePathControlTest, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowGestureTestForm, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowFlowPositionerLeftAlignedTest, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowFlowPositionerRightAlignedTest, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowHelloWorldTestForm, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowHierarchyTestForm, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowScaleTest, 0, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.69184F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.691819F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.691819F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.691819F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.691819F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.691819F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.693347F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.694339F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.694709F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692685F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.691915F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692607F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.689467F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(561, 604);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // buttonShowFlowPositionerRightAlignedTest
            // 
            this.buttonShowFlowPositionerRightAlignedTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowFlowPositionerRightAlignedTest.Location = new System.Drawing.Point(19, 240);
            this.buttonShowFlowPositionerRightAlignedTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowFlowPositionerRightAlignedTest.Name = "buttonShowFlowPositionerRightAlignedTest";
            this.buttonShowFlowPositionerRightAlignedTest.Size = new System.Drawing.Size(523, 34);
            this.buttonShowFlowPositionerRightAlignedTest.TabIndex = 12;
            this.buttonShowFlowPositionerRightAlignedTest.Text = "Flow Positioner Right Aligned Test";
            this.buttonShowFlowPositionerRightAlignedTest.UseVisualStyleBackColor = true;
            this.buttonShowFlowPositionerRightAlignedTest.Click += new System.EventHandler(this.buttonShowFlowPositionerRightAlignedTest_Click);
            // 
            // buttonShowFlowPositionerLeftAlignedTest
            // 
            this.buttonShowFlowPositionerLeftAlignedTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowFlowPositionerLeftAlignedTest.Location = new System.Drawing.Point(19, 196);
            this.buttonShowFlowPositionerLeftAlignedTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowFlowPositionerLeftAlignedTest.Name = "buttonShowFlowPositionerLeftAlignedTest";
            this.buttonShowFlowPositionerLeftAlignedTest.Size = new System.Drawing.Size(523, 34);
            this.buttonShowFlowPositionerLeftAlignedTest.TabIndex = 11;
            this.buttonShowFlowPositionerLeftAlignedTest.Text = "Flow Positioner Left Aligned Test";
            this.buttonShowFlowPositionerLeftAlignedTest.UseVisualStyleBackColor = true;
            this.buttonShowFlowPositionerLeftAlignedTest.Click += new System.EventHandler(this.buttonShowFlowPositionerLeftAlignedTest_Click);
            // 
            // buttonShowPictureTest
            // 
            this.buttonShowPictureTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowPictureTest.Location = new System.Drawing.Point(19, 416);
            this.buttonShowPictureTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowPictureTest.Name = "buttonShowPictureTest";
            this.buttonShowPictureTest.Size = new System.Drawing.Size(523, 34);
            this.buttonShowPictureTest.TabIndex = 10;
            this.buttonShowPictureTest.Text = "Picture Test";
            this.buttonShowPictureTest.UseVisualStyleBackColor = true;
            this.buttonShowPictureTest.Click += new System.EventHandler(this.buttonShowPictureTest_Click);
            // 
            // buttonShowEllipseTest
            // 
            this.buttonShowEllipseTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowEllipseTest.Location = new System.Drawing.Point(19, 108);
            this.buttonShowEllipseTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowEllipseTest.Name = "buttonShowEllipseTest";
            this.buttonShowEllipseTest.Size = new System.Drawing.Size(523, 34);
            this.buttonShowEllipseTest.TabIndex = 9;
            this.buttonShowEllipseTest.Text = "Ellipse Test";
            this.buttonShowEllipseTest.UseVisualStyleBackColor = true;
            this.buttonShowEllipseTest.Click += new System.EventHandler(this.buttonShowEllipseTest_Click);
            // 
            // buttonShowScaleTest
            // 
            this.buttonShowScaleTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowScaleTest.Location = new System.Drawing.Point(19, 460);
            this.buttonShowScaleTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowScaleTest.Name = "buttonShowScaleTest";
            this.buttonShowScaleTest.Size = new System.Drawing.Size(523, 34);
            this.buttonShowScaleTest.TabIndex = 8;
            this.buttonShowScaleTest.Text = "Scale Test";
            this.buttonShowScaleTest.UseVisualStyleBackColor = true;
            this.buttonShowScaleTest.Click += new System.EventHandler(this.buttonShowScaleTest_Click);
            // 
            // buttonShowFilePathControlTest
            // 
            this.buttonShowFilePathControlTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowFilePathControlTest.Location = new System.Drawing.Point(19, 152);
            this.buttonShowFilePathControlTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowFilePathControlTest.Name = "buttonShowFilePathControlTest";
            this.buttonShowFilePathControlTest.Size = new System.Drawing.Size(523, 34);
            this.buttonShowFilePathControlTest.TabIndex = 7;
            this.buttonShowFilePathControlTest.Text = "File Path Control Test";
            this.buttonShowFilePathControlTest.UseVisualStyleBackColor = true;
            this.buttonShowFilePathControlTest.Click += new System.EventHandler(this.buttonShowFilePathControlTest_Click);
            // 
            // buttonShowGestureTestForm
            // 
            this.buttonShowGestureTestForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowGestureTestForm.Location = new System.Drawing.Point(19, 284);
            this.buttonShowGestureTestForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowGestureTestForm.Name = "buttonShowGestureTestForm";
            this.buttonShowGestureTestForm.Size = new System.Drawing.Size(523, 34);
            this.buttonShowGestureTestForm.TabIndex = 5;
            this.buttonShowGestureTestForm.Text = "Gesture Test";
            this.buttonShowGestureTestForm.UseVisualStyleBackColor = true;
            this.buttonShowGestureTestForm.Click += new System.EventHandler(this.buttonShowGestureTestForm_Click);
            // 
            // buttonShowHelloWorldTestForm
            // 
            this.buttonShowHelloWorldTestForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowHelloWorldTestForm.Location = new System.Drawing.Point(19, 328);
            this.buttonShowHelloWorldTestForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowHelloWorldTestForm.Name = "buttonShowHelloWorldTestForm";
            this.buttonShowHelloWorldTestForm.Size = new System.Drawing.Size(523, 34);
            this.buttonShowHelloWorldTestForm.TabIndex = 2;
            this.buttonShowHelloWorldTestForm.Text = "Hello World Test";
            this.buttonShowHelloWorldTestForm.UseVisualStyleBackColor = true;
            this.buttonShowHelloWorldTestForm.Click += new System.EventHandler(this.buttonShowHelloWorldTestForm_Click);
            // 
            // buttonShowCurveTest
            // 
            this.buttonShowCurveTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowCurveTest.Location = new System.Drawing.Point(19, 64);
            this.buttonShowCurveTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowCurveTest.Name = "buttonShowCurveTest";
            this.buttonShowCurveTest.Size = new System.Drawing.Size(523, 34);
            this.buttonShowCurveTest.TabIndex = 6;
            this.buttonShowCurveTest.Text = "Curve Test";
            this.buttonShowCurveTest.UseVisualStyleBackColor = true;
            this.buttonShowCurveTest.Click += new System.EventHandler(this.buttonShowCurveTest_Click);
            // 
            // buttonShowSimpleProcessControlTest
            // 
            this.buttonShowSimpleProcessControlTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowSimpleProcessControlTest.Location = new System.Drawing.Point(19, 504);
            this.buttonShowSimpleProcessControlTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowSimpleProcessControlTest.Name = "buttonShowSimpleProcessControlTest";
            this.buttonShowSimpleProcessControlTest.Size = new System.Drawing.Size(523, 34);
            this.buttonShowSimpleProcessControlTest.TabIndex = 13;
            this.buttonShowSimpleProcessControlTest.Text = "Simple Process Control Test";
            this.buttonShowSimpleProcessControlTest.UseVisualStyleBackColor = true;
            this.buttonShowSimpleProcessControlTest.Click += new System.EventHandler(this.buttonShowSimpleProcessControlTest_Click);
            // 
            // buttonShowSimpleProcessFormTest
            // 
            this.buttonShowSimpleProcessFormTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowSimpleProcessFormTest.Location = new System.Drawing.Point(19, 548);
            this.buttonShowSimpleProcessFormTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowSimpleProcessFormTest.Name = "buttonShowSimpleProcessFormTest";
            this.buttonShowSimpleProcessFormTest.Size = new System.Drawing.Size(523, 36);
            this.buttonShowSimpleProcessFormTest.TabIndex = 14;
            this.buttonShowSimpleProcessFormTest.Text = "Simple Process Form Test";
            this.buttonShowSimpleProcessFormTest.UseVisualStyleBackColor = true;
            this.buttonShowSimpleProcessFormTest.Click += new System.EventHandler(this.buttonShowSimpleProcessFormTest_Click);
            // 
            // PickATestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 604);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.diagramControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PickATestForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DiagramControl diagramControl1;
        private System.Windows.Forms.Button buttonShowHierarchyTestForm;
        private System.Windows.Forms.Button buttonShowVectorGraphicsWithFlatClone_TestForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonShowHelloWorldTestForm;
        private System.Windows.Forms.Button buttonShowGestureTestForm;
        private System.Windows.Forms.Button buttonShowFilePathControlTest;
        private System.Windows.Forms.Button buttonShowScaleTest;
        private System.Windows.Forms.Button buttonShowEllipseTest;
        private System.Windows.Forms.Button buttonShowPictureTest;
        private System.Windows.Forms.Button buttonShowFlowPositionerLeftAlignedTest;
        private System.Windows.Forms.Button buttonShowFlowPositionerRightAlignedTest;
        private System.Windows.Forms.Button buttonShowSimpleProcessFormTest;
        private System.Windows.Forms.Button buttonShowSimpleProcessControlTest;
        private System.Windows.Forms.Button buttonShowCurveTest;
    }
}

