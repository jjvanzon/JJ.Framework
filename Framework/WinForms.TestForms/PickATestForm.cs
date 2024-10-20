﻿using System;
using System.Windows.Forms;
using JJ.Framework.WinForms.TestForms.VectorGraphicsWithFlatClone;

namespace JJ.Framework.WinForms.TestForms
{
    internal partial class PickATestForm : Form
    {
        public PickATestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize() => Text = GetType().FullName;
        private void buttonShowVectorGraphicsWithFlatClone_TestForm_Click(object sender, EventArgs e) => new VectorGraphicsWithFlatClone_TestForm().Show();
        private void buttonShowCurveTest_Click(object sender, EventArgs e) => new CurveTestForm().Show();
        private void buttonShowEllipseTest_Click(object sender, EventArgs e) => new EllipseTestForm().Show();
        private void buttonShowFilePathControlTest_Click(object sender, EventArgs e) => new FilePathControlTestForm().Show();
        private void buttonShowFlowPositionerLeftAlignedTest_Click(object sender, EventArgs e) => new FlowPositionerLeftAlignedTestForm().Show();
        private void buttonShowFlowPositionerRightAlignedTest_Click(object sender, EventArgs e) => new FlowPositionerRightAlignedTestForm().Show();
        private void buttonShowGestureTestForm_Click(object sender, EventArgs e) => new GesturesTestForm().Show();
        private void buttonShowHelloWorldTestForm_Click(object sender, EventArgs e) => new HelloWorldTestForm().Show();
        private void buttonShowHierarchyTestForm_Click(object sender, EventArgs e) => new HierarchyTestForm().Show();
        private void buttonShowPictureTest_Click(object sender, EventArgs e) => new PictureTestForm().Show();
        private void buttonShowScaleTest_Click(object sender, EventArgs e) => new ScaleTestForm().Show();
        private void buttonShowSimpleProcessControlTest_Click(object sender, EventArgs e) => new SimpleProcessControlTestForm().Show();
        private void buttonShowSimpleProcessFormTest_Click(object sender, EventArgs e) => new SimpleProcessTestForm().Show();
    }
}
