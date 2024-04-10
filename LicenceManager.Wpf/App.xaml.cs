using System.Configuration;
using System.Data;
using System.Windows;

namespace LicenceManager.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region Fields

        private bool _IsLoggedIn;


        #endregion

        #region Properties

        public bool IsLoggedIn { get => _IsLoggedIn; set => _IsLoggedIn = value; }

        #endregion

    }
}