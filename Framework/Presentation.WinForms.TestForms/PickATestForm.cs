using JJ.Framework.Presentation.WinForms.TestForms.VectorGraphicsWithFlatClone;
using System;
using System.Windows.Forms;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
	internal partial class PickATestForm : Form
	{
		public PickATestForm()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			Text = this.GetType().FullName;
		}

		private void buttonShowHierarchyTestForm_Click(object sender, EventArgs e)
		{
			new HierarchyTestForm().Show();
		}

		private void buttonShowHelloWorldTestForm_Click(object sender, EventArgs e)
		{
			new HelloWorldTestForm().Show();
		}

		private void buttonShowVectorGraphicsWithFlatClone_TestForm_Click(object sender, EventArgs e)
		{
			new VectorGraphicsWithFlatClone_TestForm().Show();
		}

		private void buttonShowGestureTestForm_Click(object sender, EventArgs e)
		{
			new GesturesTestForm().Show();
		}

		private void buttonShowCurveTest_Click(object sender, EventArgs e)
		{
			new CurveTestForm().Show();
		}

		private void buttonShowFilePathControlTest_Click(object sender, EventArgs e)
		{
			new FilePathControlTestForm().Show();
		}

		private void buttonShowScaleTest_Click(object sender, EventArgs e)
		{
			new ScaleTestForm().Show();
		}
	}
}
