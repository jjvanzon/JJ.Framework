using System.Windows.Forms;
using JJ.Framework.WinForms.TestForms.Helpers;

namespace JJ.Framework.WinForms.TestForms.VectorGraphicsWithFlatClone
{
	internal partial class VectorGraphicsWithFlatClone_TestForm : Form
	{
		public VectorGraphicsWithFlatClone_TestForm()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			Text = GetType().FullName;

			diagramControl1.RootVectorGraphicsRectangle = VectorGraphicsFactory.CreateTestVectorGraphicsModel().Background;
		}
	}
}
