using System;
using System.Collections.Generic;
using System.Text;

namespace Template.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public HomeViewModel()
        {
            Title = "Home View";
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}