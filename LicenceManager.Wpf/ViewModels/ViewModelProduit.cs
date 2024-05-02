using LicenceManager.DBLib.Class;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LicenceManager.Wpf.ViewModels
{
    public class ViewModelProduit
    {

        public ObservableCollection<Produit> Produits { get; set; }


        public Produit? SelectedProduit { get; set; }

        public Produit? NewProduit { get; set; }

        public ViewModelProduit()
        {
            if (this.NewProduit == null)
            {
                this.NewProduit = new Produit();
            }


            using (LicencemanagerContext mg = new LicencemanagerContext())
            {
                Produits = new ObservableCollection<Produit>(mg.Produits.ToList());
            }
        }

        internal void AddProduit()
        {
            // Vérifier si les champs obligatoires sont remplis

            using (LicencemanagerContext context = new())
            {
                if (this.NewProduit == null)
                {
                    this.NewProduit = new Produit();
                }

                // Vérifier si les champs sont vides ou non
                if (string.IsNullOrWhiteSpace(this.NewProduit.Libelle))
                {
                    MessageBox.Show("Veuillez saisir le nom du produit.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Arrêter l'exécution de la méthode si le nom du produit n'est pas rempli
                }
                    else if (string.IsNullOrWhiteSpace(this.NewProduit.Description))
                    {
                        MessageBox.Show("Veuillez saisir la description du produit.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    context.Add(this.NewProduit); // Ajouter le produit au contexte
                    context.SaveChanges(); // Sauvegarder les modifications du contexte en base de données
                    this.Produits.Add(this.NewProduit); // Afficher le nouveau produit dans la liste des produits

                    // Réinitialiser les champs du formulaire
                    this.NewProduit = new Produit();
            }
        }

        internal void UpdateProduit()
        {
            if (this.SelectedProduit is not null)
            {
                using (LicencemanagerContext context = new())
                {
                    // Vérifier si les champs sont vides ou non
                    if (string.IsNullOrWhiteSpace(this.SelectedProduit.Libelle))
                    {
                        MessageBox.Show("Veuillez saisir le nom du produit.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        return; // Arrêter l'exécution de la méthode si le nom du produit n'est pas rempli
                    }
                    else if (string.IsNullOrWhiteSpace(this.SelectedProduit.Description))
                    {
                        MessageBox.Show("Veuillez saisir la description du produit.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    context.Update(this.SelectedProduit); // Mettre à jour les modifications du contexte en base de données
                    context.SaveChanges();
                }
            }
        }

        internal void RemoveProduit()
        {
            if (this.SelectedProduit.Libelle is null || this.SelectedProduit.Description is null)
            {
                string text = "Impossible de supprimer une ligne vide";
                MessageBox.Show(text);
            }
            else
            {
                using (LicencemanagerContext context = new())
                {
                    context.Remove(this.SelectedProduit);
                    context.SaveChanges();
                }
                this.Produits?.Remove(this.SelectedProduit);
            }
        }

        // Déconnecte l'utilisateur 
        public void Logout() => ((App)App.Current).Logout();
    }
}
