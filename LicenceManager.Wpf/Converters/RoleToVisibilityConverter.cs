using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using LicenceManager.DBLib.Class;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace LicenceManager.Wpf.Converters;

class RoleToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        User? user = null;
        bool isAdmin = false;
        var connectionString = ConfigurationManager.ConnectionStrings["LicenceManagerConnexion"].ConnectionString;
        var optionsBuilder = new DbContextOptionsBuilder<LicencemanagerContext>();
        optionsBuilder.UseMySQL(connectionString);

        using (LicencemanagerContext context = new LicencemanagerContext(optionsBuilder.Options))
        {
            if (value is not User)
                throw new Exception("Le type de l'objet n'est pas bon, il faut que ce soit un utilisateur");
            user = (User)value;
            Role adminRole = context.Roles.First(r => r.Name == "admin");

            // Vérifier si l'utilisateur est un administrateur
            isAdmin = context.AssignedRoles.Any(ar => ar.EntityId == user.Id && ar.RoleId == adminRole.Id);

            // Cacher la visibilité par défaut
            Visibility visibility = Visibility.Collapsed;

            if (isAdmin && value != null && value != DependencyProperty.UnsetValue)
            {
                visibility = Visibility.Visible; // Afficher l'élément
            }
            return visibility;
        }
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
