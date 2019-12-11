using System;

using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Character Item { get; set; }
        public ItemDetailViewModel(Character item = null)
        {
        }
    }
}
