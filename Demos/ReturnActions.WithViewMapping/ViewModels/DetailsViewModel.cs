using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation;

namespace JJ.Demos.ReturnActions.WithViewMapping.ViewModels
{
	public sealed class DetailsViewModel
	{
		public EntityViewModel Entity { get; set; }

		/// <summary> nullable </summary>
		public ActionInfo ReturnAction { get; set; }
	}
}