using System.Windows.Forms;
using JJ.Framework.VectorGraphics.Gestures;

namespace JJ.Framework.WinForms.Helpers
{
	public static class WinFormsVectorGraphicsHelper
	{
		public static DoubleClickGesture CreateDoubleClickGesture()
		{
			var gesture = new DoubleClickGesture(SystemInformation.DoubleClickTime, SystemInformation.DoubleClickSize.Width);
			return gesture;
		}
	}
}
