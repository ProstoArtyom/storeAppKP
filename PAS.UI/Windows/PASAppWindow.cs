using System.ComponentModel;
using System.Windows;
using PAS.Storage.Repositories;

namespace PAS.UI.Windows;

public class PASAppWindow : Window
{
    protected IPASAppRepository DataStore { get; } = new PASAppRepository();
    
    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);
        Application.Current.Shutdown();
    }
}