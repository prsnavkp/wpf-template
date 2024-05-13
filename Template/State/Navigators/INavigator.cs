using Template.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Template.WPF.State.Navigators
{
    public enum ViewType
    {
        Login,
        Home,
        Dictionary
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        event Action StateChanged;

        void RenavigateHome();

        void RenavigateLogin();

        public void RenavigateRegister();
    }
}