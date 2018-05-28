using System.Collections.Generic;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels.Entities;

namespace JJ.Demos.ReturnActions.NoViewMapping.ViewModels
{
	public sealed class ListViewModel
	{
		public IList<EntityViewModel> List { get; set; }
	}
}