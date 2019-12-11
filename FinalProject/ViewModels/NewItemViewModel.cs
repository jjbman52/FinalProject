using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FinalProject.Models;
using FinalProject.Services;
using Xamarin.Forms;

namespace FinalProject.ViewModels
{
    public class NewItemViewModel : BaseViewModel
        {
            readonly IStarWarsDataService _dataService;

            ObservableCollection<Character> _characters;
            public ObservableCollection<Character> Characters
            {
                get { return _characters; }
                set
                {
                    _characters = value;
                    OnPropertyChanged();
                }
            }

        ICommand _loadCharactersCommand;
        public ICommand LoadCharactersCommand
        {
            get
            {
                return _loadCharactersCommand ?? (_loadCharactersCommand = new Command(async () => await LoadCharacters()));
            }
        }

        public NewItemViewModel(IStarWarsDataService dataService)
            {
                _dataService = dataService;

                Characters = new ObservableCollection<Character>();
            }

            public void Init()
            {
            LoadCharactersCommand.Execute(null);
        }

        async Task LoadCharacters()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Characters.Clear();

                var characters = await _dataService.GetCharacters();

                foreach (var c in characters)
                    Characters.Add(c);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}