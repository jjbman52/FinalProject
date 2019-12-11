using System;
using System.Collections.Generic;
using FinalProject.Models;
using FinalProject.Services;
using FinalProject.ViewModels;
using Xamarin.Forms;
using System.ComponentModel;

namespace FinalProject.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Character Character { get; set; }

        NewItemViewModel Vm => BindingContext as NewItemViewModel;

        public NewItemPage()
        {
            InitializeComponent();

            var dataService = new StarWarsDataService();

            BindingContext = new NewItemViewModel(dataService);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Vm.Init();
        }

        async void CharactersListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var character = e.SelectedItem as Character;
            Character = new Character
            {
                name = character.name,
                homeworld = character.homeworld,
                height = character.height,
                birth_year = character.birth_year,
            };
            MessagingCenter.Send(this, "AddCharacter", Character);
            await Navigation.PopModalAsync();
        }
    }
}