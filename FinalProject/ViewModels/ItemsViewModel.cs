using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using FinalProject.Models;
using FinalProject.Views;

namespace FinalProject.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Character> Characters { get; set; }
        public Command LoadCharactersCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Characters = new ObservableCollection<Character>();
            LoadCharactersCommand = new Command(async () => await ExecuteLoadCharactersCommand());

            MessagingCenter.Subscribe<NewItemPage, Character>(this, "AddCharacter", async (obj, character) =>
            {
                //await DataStore.AddCharacterAsync(character);
                var newItem = character as Character;

                Characters.Add(newItem);

                await App.Database.AddCharacterAsync(newItem);
            });
        }

        async Task ExecuteLoadCharactersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Characters.Clear();
                var characters = await App.Database.GetCharactersAsync();
                foreach (var character in characters)
                {
                    Characters.Add(character);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}