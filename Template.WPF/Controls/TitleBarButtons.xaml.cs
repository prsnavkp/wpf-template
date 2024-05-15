using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Template.WPF.Commands;

namespace Template.WPF.Controls
{
    /// <summary>
    /// Interaction logic for TitleBarButtons.xaml
    /// </summary>
    public partial class TitleBarButtons : UserControl
    {
        public ICommand MinimizeCommand { get; private set; }
        public ICommand MaximizeRestoreCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }

        public TitleBarButtons()
        {
            InitializeComponent();
            MinimizeCommand = new RelayCommand(OnMinimize);
            MaximizeRestoreCommand = new RelayCommand(OnMaximizeRestore);
            CloseCommand = new RelayCommand(OnClose);
            DataContext = this;
        }

        private void OnClose()
        {
            Window.GetWindow(this).Close();
        }

        private void OnMinimize()
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void OnMaximizeRestore()
        {
            var window = Window.GetWindow(this);
            window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }
    }
}