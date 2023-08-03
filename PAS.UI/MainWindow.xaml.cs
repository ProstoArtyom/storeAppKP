using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using PAS.UI.HelperClasses;
using PAS.UI.HelperClasses.Commands;
using PAS.UI.Pages.Profile;
using PAS.UI.ViewModels;
using PAS.UI.Windows;

namespace PAS.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : PASAppWindow
    {
        private AuthorizationWindow AuthWindow { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            MainPageViewModel.Instance = new MainPageViewModel();
            
            DataContext = WindowsNavigation.MainWindow = this;
            WindowsNavigation.AuthWindow = AuthWindow = new AuthorizationWindow();

            LoadMainWindow();
        }

        private void LoadMainWindow()
        {
            Hide();
            AuthWindow.Show();
        }
    }
}
