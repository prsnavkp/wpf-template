using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Template.ModelingAPI.Result;
using Template.ModelingAPI.Services;
using Template.WPF.Commands;

namespace Template.WPF.ViewModels
{
    public class DictionaryViewModel : ViewModelBase
    {
        private string _searchText;
        private readonly IDictionaryDataService _dictionaryDataService;

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }

        private WordDefinition _wordDefinition;

        public WordDefinition WordDefinition
        {
            get { return _wordDefinition; }
            set
            {
                _wordDefinition = value;
                OnPropertyChanged(nameof(WordDefinition));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public MessageViewModel StatusMessageViewModel { get; }

        public string StatusMessage
        {
            set => StatusMessageViewModel.Message = value;
        }

        public AsyncCommandWithoutParameter GetDefinitionCommand { get; private set; }

        public DictionaryViewModel(IDictionaryDataService dictionaryDataService)
        {
            ErrorMessageViewModel = new MessageViewModel();
            StatusMessageViewModel = new MessageViewModel();

            _dictionaryDataService = dictionaryDataService;

            GetDefinitionCommand = new AsyncCommandWithoutParameter(GetWordDefinitionAsync);
        }

        private async Task GetWordDefinitionAsync()
        {
            StatusMessage = string.Empty;
            ErrorMessage = string.Empty;

            try
            {
                WordDefinition = await _dictionaryDataService.GetMeaning(SearchText);

                StatusMessage = "Completed";
            }
            catch (Exception ex)
            {
                ErrorMessage = "Error";
            }
        }
    }
}