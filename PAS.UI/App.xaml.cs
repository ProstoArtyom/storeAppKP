using System;
using System.Windows;
using PAS.Storage;

namespace PAS.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void AppStartup(object sender, StartupEventArgs e)
        {
            var _contentRootPath = AppDomain.CurrentDomain.BaseDirectory;
            var dbConnectionString = PAS.UI.Properties.Settings.Default["ConnectionString"].ToString();
            dbConnectionString = dbConnectionString.Replace("%CONTENTROOTPATH%", _contentRootPath);
            StorageParameters.ConnectionString = dbConnectionString;
        }
    }
}
