using LicenceManager.DBLib.Class;
using LicenceManager.Wpf.Windows;
using System.Configuration;
using System.Data;
using System.Windows;
using BCrypt.Net;

namespace LicenceManager.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region Fields

        public User? LoggedUser { get; set; }

        #endregion

        public void Login(User user)
        {
            LoggedUser = user;
            MainWindow mainWindow = new();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }

        public void Logout()
        {
            LoggedUser = null;
            WindowLogin windowLogin = new();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = windowLogin;
            windowLogin.Show();
        }

    }
}
