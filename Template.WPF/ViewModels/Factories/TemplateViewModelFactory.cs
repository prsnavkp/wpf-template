using Template.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.WPF.ViewModels.Factories
{
    public class TemplateViewModelFactory : ITemplateViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<DictionaryViewModel> _createDictionaryViewModel;

        public TemplateViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel, CreateViewModel<DictionaryViewModel> createDictionaryViewModel,
            CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createDictionaryViewModel = createDictionaryViewModel;
            _createLoginViewModel = createLoginViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();

                case ViewType.Home:
                    return _createHomeViewModel();

                case ViewType.Dictionary:
                    return _createDictionaryViewModel();

                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}