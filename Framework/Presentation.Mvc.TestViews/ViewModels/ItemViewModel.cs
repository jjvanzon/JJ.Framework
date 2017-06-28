using System.Collections.Generic;

namespace JJ.OneOff.BeginCollectionItemTest.ViewModels
{
    public class ItemViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ItemViewModel> Children { get; set; }
    }
}