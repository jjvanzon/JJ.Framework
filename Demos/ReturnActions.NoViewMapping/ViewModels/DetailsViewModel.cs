using JJ.Demos.ReturnActions.NoViewMapping.ViewModels.Entities;

namespace JJ.Demos.ReturnActions.NoViewMapping.ViewModels
{
	public sealed class DetailsViewModel
	{
		public EntityViewModel Entity { get; set; }

		/// <summary> nullable </summary>
		public string ReturnAction { get; set; }
	}
}