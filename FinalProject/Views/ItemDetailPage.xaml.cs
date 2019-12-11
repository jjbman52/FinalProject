using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var character = new Character
            {
                name = "Item 1",
                homeworld = "This is an item description.",
                height = "This is an item description.",
                birth_year = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(character);
            BindingContext = viewModel;
        }
    }
}