using JJ.Demos.ReturnActions.Framework.Presentation;
using JJ.Demos.ReturnActions.ViewModels;

namespace JJ.Demos.ReturnActions.WithViewMapping.ViewModels
{
	public sealed class EditViewModel
	{
		public EntityViewModel Entity { get; set; }

		/// <summary> nullable </summary>
		public ActionInfo ReturnAction { get; set; }
	}
}