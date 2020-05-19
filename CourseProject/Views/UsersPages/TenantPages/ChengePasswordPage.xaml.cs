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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseProject.ViewModels;

namespace CourseProject.Views.UsersPages.TenantPages
{
    /// <summary>
    /// Логика взаимодействия для ChengePasswordPage.xaml
    /// </summary>
    public partial class ChengePasswordPage : Page
    {
        private string _login;

        public ChengePasswordPage(string login)
        {
            _login = login;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheangePasswordViewModel.CheckOldPassword(_login, OldPaswordPB.Password) && NewPaswordPB1.Password == NewPaswordPB2.Password)
            {
                CheangePasswordViewModel.Change(_login, NewPaswordPB1.Password);
                MessageBox.Show("Password is changed!");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Error, try again!");
                OldPaswordPB.Password = string.Empty;
                NewPaswordPB1.Password = string.Empty;
                NewPaswordPB2.Password = string.Empty;
            }
        }
    }
}
