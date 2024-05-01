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
    /// Logique d'interaction pour FormEditUtilisateurView.xaml
    /// </summary>
    public partial class FormEditUtilisateurView : Window
    {
        public FormEditUtilisateurView(ViewModelUtilisateur viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }

        // Bouton de confirmation du formulaire
        private void confirm_click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelUtilisateur)this.DataContext).SelectedUser != null)
            {
                ((ViewModelUtilisateur)this.DataContext).UpdateUser();

                this.Close();

            }
        }

        // Bouton d'annulation du formulaire
        private void cancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
