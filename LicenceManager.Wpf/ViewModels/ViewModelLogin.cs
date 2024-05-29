using LicenceManager.Core;
using LicenceManager.DBLib.Class;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Windows;

namespace LicenceManager.Wpf.ViewModels
{
    internal class ViewModelLogin : ObservableObject
    {
        #region Fields

        /// <summary>
        /// Nom d'utilisateur
        /// </summary>
        public string? Libelle { get; set; }

        /// <summary>
        /// Mot de passe
        /// </summary>
        public string? Password { get; set; }

        #endregion

        public void Login()
        {
            User? user = null;
            bool isEmploye = false;
            bool isAdmin = false;

            var connectionString = ConfigurationManager.ConnectionStrings["LicenceManagerConnexion"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<LicencemanagerContext>();
            optionsBuilder.UseMySQL(connectionString);

            using (LicencemanagerContext context = new LicencemanagerContext(optionsBuilder.Options))
            {
                user = context.Users.FirstOrDefault(userTemp => userTemp.Libelle.Equals(Libelle));
                Role employeRole = context.Roles.First(r => r.Name == "employe");
                Role adminRole = context.Roles.First(r => r.Name == "admin");

                if (user != null)
                {
                    // Vérifier si l'utilisateur est un employé ou un administrateur
                    isEmploye = context.AssignedRoles.Any(ar => ar.EntityId == user.Id && ar.RoleId == employeRole.Id);
                    isAdmin = context.AssignedRoles.Any(ar => ar.EntityId == user.Id && ar.RoleId == adminRole.Id);
                    if (isEmploye || isAdmin )
                    {
                        // Vérifier le mot de passe haché avec BCrypt
                        if (BCrypt.Net.BCrypt.Verify(Password, user.Password))
                        {
                            ((App)App.Current).Login(user);
                        }
                        else
                        {
                            // Mot de passe incorrect
                            MessageBox.Show("Mot de passe incorrect", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        // L'utilisateur n'a pas les autorisations nécessaires
                        MessageBox.Show("Vous n'avez pas les autorisations nécessaires pour accéder à cette application", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    // Nom d'utilisateur introuvable
                    MessageBox.Show("Nom d'utilisateur introuvable", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
