using LicenceManager.DBLib.Class;
using LicenceManager.Wpf.ViewModels;
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
using System.Windows.Shapes;

namespace LicenceManager.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour DetailsUtilisateurView.xaml
    /// </summary>
    public partial class DetailsUtilisateurView : Window
    {
        public DetailsUtilisateurView(ViewModelUtilisateur viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }

        private void return_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
