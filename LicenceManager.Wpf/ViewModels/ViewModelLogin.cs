using LicenceManager.Core;
using LicenceManager.DBLib.Class;
using Microsoft.AspNet.Identity;

namespace LicenceManager.Wpf.ViewModels
{
    internal class ViewModelLogin : ObservableObject
    {
        #region Fields

        /// <summary>
        /// User
        /// </summary>
        private string? _Libelle;

        /// <summary>
        /// Mot de passe
        /// </summary>
        private String? _Password;

        /// <summary>
        /// Message
        /// </summary>
        private string? _Message;

        /// <summary>
        /// Indique si l'user est connecté ou non.
        /// </summary>
        private bool? _IsLoggedIn;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou défini <see cref="_Libelle"/>
        /// </summary>
        public string? Libelle { get => _Libelle; set => _Libelle = value; }

        /// <summary>
        /// Obtient ou défini <see cref="_Password"/>
        /// </summary>
        public string? Password { get => _Password; set => _Password = value; }

        /// <summary>
        /// Obtient ou défini <see cref="_Message"/>
        /// Vu qu'on veut actualisé la vue lors du changement, on utilise <see cref="ObservableObject.SetProperty{T}(string, ref T, T, bool)"/>
        /// </summary>
        public string? Message { get => _Message; set => SetProperty(nameof(Message), ref _Message, value); }

        /// <summary>
        /// Obtient ou défini <see cref="_IsLoggedIn"/>
        /// </summary>
        public bool? IsLoggedIn { get => _IsLoggedIn; private set => SetProperty(nameof(IsLoggedIn), ref _IsLoggedIn, value); }

        #endregion


        #region Constructors

        /// <summary>
        ///  Constructeur
        /// </summary>
        public ViewModelLogin()
        {
            IsLoggedIn = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Méthode de d'authentification d'un user
        /// </summary>
        internal void Authenticate()
        {
            // Outil de hashage
            PasswordHasher hasher = new PasswordHasher();

            PasswordVerificationResult result = PasswordVerificationResult.Failed;

            // L'user récupéré
            User? user = null;
            // On recherche l'user par son identifiant
            using (LicencemanagerContext context = new())
                user = context.Users.FirstOrDefault(userTemp => userTemp.Libelle.Equals(Libelle));

            // Si il n'existe pas, on renvoie une erreur
            if (user == null)
                Message = "Impossible de trouver l'user";
            else if (Password == null)
                result = PasswordVerificationResult.Failed;
            else
                result = hasher.VerifyHashedPassword(user.Password, Password);

            switch (result)
            {
                case PasswordVerificationResult.Failed:
                    Message = "Mot de passe incorrect";
                    break;
                case PasswordVerificationResult.Success:
                    // On défini le logging à true. La vue observe cette propriété et va se cacher si IsLogging = true.
                    IsLoggedIn = true;
                    break;
                default:
                    break;
            }
        }

        #endregion


    }
}
