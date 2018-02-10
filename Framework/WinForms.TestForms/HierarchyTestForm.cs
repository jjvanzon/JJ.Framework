using System.Windows.Forms;
using JJ.Framework.WinForms.TestForms.Helpers;

namespace JJ.Framework.WinForms.TestForms
{
	internal partial class HierarchyTestForm : Form
	{
		public HierarchyTestForm()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			Text = GetType().FullName;

			diagramControl1.Diagram = VectorGraphicsFactory.CreateTestVectorGraphicsModel();
		}
	}
}
