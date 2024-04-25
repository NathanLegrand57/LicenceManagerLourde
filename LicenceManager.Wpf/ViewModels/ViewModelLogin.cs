using LicenceManager.Core;
using LicenceManager.DBLib.Class;
//using Microsoft.AspNet.Identity;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            using (LicencemanagerContext context = new())
                user = context.Users.FirstOrDefault(userTemp => userTemp.Libelle.Equals(Libelle));

            if (user != null)
            {
                // Vérifier le mot de passe haché avec BCrypt
                if (BCrypt.Net.BCrypt.Verify(Password, user.Password))
                {
                    ((App)App.Current).Login(user);
                }
                else
                {
                    // Mot de passe incorrect
                    MessageBox.Show("Mot de passe incorrect", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Nom d'utilisateur introuvable
                MessageBox.Show("Nom d'utilisateur introuvable", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
