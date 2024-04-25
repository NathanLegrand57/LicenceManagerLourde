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
    /// Logique d'interaction pour FormCreateProduitView.xaml
    /// </summary>
    public partial class FormCreateProduitView : Window
    {
        public FormCreateProduitView(ViewModelProduit context)
        {
            InitializeComponent();
            this.DataContext = context;
        }

        private void confirm_click(object sender, RoutedEventArgs e)
        {
            ((ViewModelProduit)this.DataContext).AddProduit();
            this.Close();
        }

        private void cancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
