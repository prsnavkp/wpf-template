using Template.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.WPF.ViewModels.Factories
{
    public interface ITemplateViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}