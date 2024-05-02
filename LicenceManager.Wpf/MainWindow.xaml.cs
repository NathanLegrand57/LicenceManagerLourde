using LicenceManager.DBLib.Class;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new ViewModelProduit();
            InitializeComponent();

        }
        private void Create_Produit_Click(object sender, RoutedEventArgs e)
        {
            // Initialiser la vue FormCreateProduitView en transmettant le ViewModelProduit
            FormCreateProduitView formCreateProduitView = new FormCreateProduitView((ViewModelProduit)this.DataContext);

            // Afficher la vue

            formCreateProduitView.ShowDialog();

        }

        private void Edit_Produit_Click(object sender, RoutedEventArgs e)
        {
            if (listeProduits.SelectedItem != null)
            {

                // Initialiser la vue FormEditProduitView en transmettant le ViewModelProduit et le produit sélectionné
                FormEditProduitView formEditProduitView = new FormEditProduitView(((ViewModelProduit)this.DataContext));

                // Afficher la vue
                formEditProduitView.ShowDialog();
            }
            else
            {
                // Afficher un message d'erreur si aucun produit n'est sélectionné
                MessageBox.Show("Veuillez sélectionner un produit à modifier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Show_Details_Produit(object sender, RoutedEventArgs e)
        {
            if (listeProduits.SelectedItem != null)
            {

                // Initialiser la vue DetailsProduitView en transmettant le ViewModelProduit et le produit sélectionné
                DetailsProduitView detailsProduitView = new DetailsProduitView(((ViewModelProduit)this.DataContext));

                // Afficher la vue
                detailsProduitView.ShowDialog();
            }
            else
            {
                // Afficher un message d'erreur si aucun produit n'est sélectionné
                MessageBox.Show("Veuillez sélectionner un produit.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void Delete_Produit_Click(object sender, RoutedEventArgs e)
        {
            if (listeProduits.SelectedItem != null)
            {
                // Supprimer le produit sélectionné
                ((ViewModelProduit)this.DataContext).RemoveProduit();
            }
            else
            {
                // Afficher un message d'erreur si aucun produit n'est sélectionné
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        // Appelle la fonction logout dans ViewModelProduit
        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        => ((ViewModelProduit)this.DataContext).Logout();
    }
}