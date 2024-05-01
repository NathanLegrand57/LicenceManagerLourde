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
    public class ViewModelUtilisateur
    {

        public ObservableCollection<User> Users { get; set; }


        public User? SelectedUser { get; set; }

        public User? NewUser { get; set; }

        public ViewModelUtilisateur()
        {
            if (this.NewUser == null)
            {
                this.NewUser = new User();
            }


            using (LicencemanagerContext mg = new LicencemanagerContext())
            {
                Users = new ObservableCollection<User>(mg.Users.ToList());
            }
        }

        internal void UpdateUser()
        {
            if (this.SelectedUser is not null)
            {
                using (LicencemanagerContext context = new())
                {
                    // Vérifier si les champs sont vides ou non
                    if (string.IsNullOrWhiteSpace(this.SelectedUser.Libelle))
                    {
                        MessageBox.Show("Veuillez saisir le nom de l'utilisateur.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        return; // Arrêter l'exécution de la méthode si le nom de l'utilisateur n'est pas rempli
                    }
                    else if (string.IsNullOrWhiteSpace(this.SelectedUser.Email))
                    {
                        MessageBox.Show("Veuillez saisir l'email de l'tilisateur.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    context.Update(this.SelectedUser); // Mettre à jour les modifications du contexte en base de données
                    context.SaveChanges();
                }

            }
        }

        internal void RemoveUser()
        {
            if (this.SelectedUser.Libelle is null || this.SelectedUser.Email is null)
            {
                string text = "Impossible de supprimer une ligne vide";
                MessageBox.Show(text);
            }
            else
            {
                using (LicencemanagerContext context = new())
                {
                    context.Remove(this.SelectedUser);
                    context.SaveChanges();
                }
                this.Users?.Remove(this.SelectedUser); // Supprime l'utilisateur
            }
        }
    }
}
