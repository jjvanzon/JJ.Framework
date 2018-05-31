using System.Collections.Generic;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels.Entities;

namespace JJ.Demos.ReturnActions.WithViewMapping.ViewModels
{
	public sealed class ListViewModel
	{
		public IList<EntityViewModel> List { get; set; }
	}
}