﻿using LicenceManager.DBLib.Class;
using LicenceManager.Wpf.ViewModels;
using LicenceManager.Wpf.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LicenceManager.Wpf
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
            DataContext = new ViewModelUtilisateur();

        }

        private void Edit_Utilisateur_Click(object sender, RoutedEventArgs e)
        {
            if (listeUtilisateurs.SelectedItem != null)
            {

                // Initialiser la vue FormEditUtilisateurView en transmettant le ViewModelUtilisateur et le produit sélectionné
                FormEditUtilisateurView formEditUtilisateurView = new FormEditUtilisateurView(((ViewModelUtilisateur)this.DataContext));

                // Afficher la vue
                formEditUtilisateurView.ShowDialog();
            }
            else
            {
                // Afficher un message d'erreur si aucun produit n'est sélectionné
                MessageBox.Show("Veuillez sélectionner un produit à modifier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}