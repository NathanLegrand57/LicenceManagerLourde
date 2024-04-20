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
            InitializeComponent();
            DataContext = new ViewModelProduit();

        }
        private void Create_Produit_Click(object sender, RoutedEventArgs e)
        {
            FormCreateProduitView formCreateProduitsView = new FormCreateProduitView((ViewModelProduit)this.DataContext);

            formCreateProduitsView.ShowDialog();

        }

        private void Edit_Produit_Click(object sender, RoutedEventArgs e)
        {
            FormEditProduitView formModif = new FormEditProduitView(((ViewModelProduit)this.DataContext));

            formModif.ShowDialog();
        }

        //private void Show_Details_Produit(object sender, RoutedEventArgs e)
        //{
        //    ViewDetails detailsview = new ViewDetails();

        //    detailsview.ShowDialog();

        //    //detailsview.MyProperty;
        //}


        //private void Delete_Produit_Click(object sender, RoutedEventArgs e)
        //{
        //    ((ViewModelProduit)this.DataContext).RemoveProduits();
        //}
    }
}