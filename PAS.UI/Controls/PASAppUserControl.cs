using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using PAS.Storage.Repositories;

namespace PAS.UI.Controls;

public class PASAppUserControl : UserControl
{
    protected IPASAppRepository DataStore { get; } = new PASAppRepository();
}