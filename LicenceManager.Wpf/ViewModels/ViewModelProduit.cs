using LicenceManager.DBLib.Class;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            using (LicencemanagerContext context = new())
            {
                if (this.NewProduit == null)
                {
                    this.NewProduit = new Produit();
                }

                context.Add(this.NewProduit);//J'ajoute le produit au contexte
                context.SaveChanges(); // Je sauvegarde les modification du contexte en base de données
                this.Produits.Add(this.NewProduit); // Si j'ai une liste pour la vue, je l'y ajoute pour qu'elle s'
            }
        }

        internal void UpdateProduit()
        {
            if (this.SelectedProduit is not null)
            {
                using (LicencemanagerContext context = new())
                {
                    context.Update(this.SelectedProduit);
                    context.SaveChanges();
                }

            }
        }
        //internal void RemoveProduit()
        //{
        //    if (this.SelectedProduit.Libelle is null || this.SelectedProduit.Type is null) // Ne fonctionne pas avec les clés étrangères
        //    {
        //        string text = "Impossible de supprimer une ligne vide";
        //        MessageBox.Show(text);
        //    }
        //    else
        //    {
        //        using (LicencemanagerContext context = new())
        //        {
        //            context.Remove(this.SelectedProduit);
        //            context.SaveChanges();
        //        }
        //        this.Produits?.Remove(this.SelectedProduit);
        //    }
        //}
    }
}
