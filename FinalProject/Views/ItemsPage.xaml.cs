using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FinalProject.Models;
using FinalProject.Views;
using FinalProject.ViewModels;
using Xamarin.Essentials;

namespace FinalProject.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var character = args.SelectedItem as Character;
            if (character == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(character)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        async void btnBrowse_ClickAsync(object sender, SelectedItemChangedEventArgs e)
        {
            var character = e.SelectedItem as Character;

            await Browser.OpenAsync("https://www.google.com/search?q=" + character.name, BrowserLaunchMode.SystemPreferred);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Characters.Count == 0)
                viewModel.LoadCharactersCommand.Execute(null);
        }
    }
}