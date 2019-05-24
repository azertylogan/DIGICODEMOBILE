using System;

using DIGICODE.Models;

namespace DIGICODE.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.nom;
            Item = item;
        }
    }
}
