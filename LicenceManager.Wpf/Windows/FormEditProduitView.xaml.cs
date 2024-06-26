﻿using LicenceManager.DBLib.Class;
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
    /// Logique d'interaction pour FormEditProduitView.xaml
    /// </summary>
    public partial class FormEditProduitView : Window
    {
        public FormEditProduitView(ViewModelProduit viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }

        // Bouton de confirmation du formulaire
        private void confirm_click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelProduit)this.DataContext).SelectedProduit != null)
            {
                ((ViewModelProduit)this.DataContext).UpdateProduit();

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
