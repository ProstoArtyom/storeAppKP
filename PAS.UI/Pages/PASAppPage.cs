using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Controls;
using PAS.Storage.Repositories;

namespace PAS.UI.Pages;

public class PASAppPage : Page
{
    protected IPASAppRepository DataStore { get; } = new PASAppRepository();
}