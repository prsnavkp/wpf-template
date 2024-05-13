using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Template.WPF.Commands;
using Template.WPF.ViewModels;
using Template.WPF.ViewModels.Factories;

namespace Template.WPF.State.Navigators
{
    public class Navigator : INavigator
    {
        private ViewModelBase _currentViewModel;
        private CreateViewModel<HomeViewModel> _createHomeViewModel;
        private CreateViewModel<LoginViewModel> _createLoginViewModel;
        private CreateViewModel<RegisterViewModel> _createRegisterViewModel;

        public Navigator(CreateViewModel<HomeViewModel> createViewModel, CreateViewModel<LoginViewModel> createLoginViewModel,
            CreateViewModel<RegisterViewModel> createRegisterViewModel)
        {
            _createHomeViewModel = createViewModel;
            _createLoginViewModel = createLoginViewModel;
            _createRegisterViewModel = createRegisterViewModel;
        }

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel?.Dispose();

                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;

        public void RenavigateHome()
        {
            CurrentViewModel = _createHomeViewModel();
        }

        public void RenavigateLogin()
        {
            CurrentViewModel = _createLoginViewModel();
        }

        public void RenavigateRegister()
        {
            CurrentViewModel = _createRegisterViewModel();
        }
    }
}