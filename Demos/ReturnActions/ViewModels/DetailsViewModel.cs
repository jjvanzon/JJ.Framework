using JJ.Demos.ReturnActions.ViewModels.Entities;
using JJ.Framework.Presentation;

namespace JJ.Demos.ReturnActions.ViewModels
{
	public sealed class DetailsViewModel
	{
		public EntityViewModel Entity { get; set; }

		/// <summary> nullable </summary>
		public ActionInfo ReturnAction { get; set; }
	}
}