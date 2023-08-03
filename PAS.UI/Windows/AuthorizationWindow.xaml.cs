using System.Windows;
using System.Windows.Controls;
using PAS.UI.Pages.Authorization;

namespace PAS.UI.Windows;

public partial class AuthorizationWindow : PASAppWindow
{
    private RoleSelectionPage RoleSelectionPage { get; } = new();

    public AuthorizationWindow()
    {
        InitializeComponent();

        DataContext = this;

        authFrame.Navigate(RoleSelectionPage);
    }
    
    
}