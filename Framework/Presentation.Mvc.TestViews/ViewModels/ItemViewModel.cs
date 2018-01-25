using System.Collections.Generic;

namespace JJ.Framework.Mvc.TestViews.ViewModels
{
	public class ItemViewModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public List<ItemViewModel> Children { get; set; }
	}
}