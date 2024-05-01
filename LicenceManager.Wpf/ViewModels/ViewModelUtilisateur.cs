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
    }
}
