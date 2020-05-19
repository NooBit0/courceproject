using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using CourseProject.Models;
using CourseProject.ViewModels;

namespace CourseProject.Views.UsersPages.AdministratorPages
{
    /// <summary>
    /// Логика взаимодействия для ListUserPage.xaml
    /// </summary>
    public partial class ListUsersPage : Page
    {

        private AdministratorViewModel _viewModels;

        public ListUsersPage()
        {
            InitializeComponent();
            _viewModels = new AdministratorViewModel();
        }

        private void SaveBdButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModels.UsersDbSave();
        }

        private void UserAccountantsButton_Click(object sender, RoutedEventArgs e)
        {
            StatusTextBlock.Text = "Accountants";
            FullNameColumn.Visibility = Visibility.Visible;
            LoginColumn.Visibility = Visibility.Visible;
            PasswordColumn.Visibility = Visibility.Visible;
            TenantIdColumn.Visibility = Visibility.Hidden;
            RentalPremisesIdColumn.Visibility = Visibility.Hidden;
            UsersDataGreed.ItemsSource = _viewModels.GetAccountants().ToBindingList();
        }

        private void UserAdministranorsButton_Click(object sender, RoutedEventArgs e)
        {
            StatusTextBlock.Text = "Adminstrators";
            FullNameColumn.Visibility = Visibility.Visible;
            LoginColumn.Visibility = Visibility.Visible;
            PasswordColumn.Visibility = Visibility.Visible;

            RentalNumberColumn.Visibility = Visibility.Hidden;
            AdressColumn.Visibility = Visibility.Hidden;
            TenantIdColumn.Visibility = Visibility.Hidden;
            RentalPremisesIdColumn.Visibility = Visibility.Hidden;
            UsersDataGreed.ItemsSource = _viewModels.GetAdministrators().ToBindingList();
        }

        private void UserOwnersButton_Click(object sender, RoutedEventArgs e)
        {
            StatusTextBlock.Text = "Owners";
            FullNameColumn.Visibility = Visibility.Visible;
            LoginColumn.Visibility = Visibility.Visible;
            PasswordColumn.Visibility = Visibility.Visible;

            RentalNumberColumn.Visibility = Visibility.Hidden;
            AdressColumn.Visibility = Visibility.Hidden;
            TenantIdColumn.Visibility = Visibility.Hidden;
            RentalPremisesIdColumn.Visibility = Visibility.Hidden;
            UsersDataGreed.ItemsSource = _viewModels.GetOwners().ToBindingList();
        }

        private void UserTenantsButton_Click(object sender, RoutedEventArgs e)
        {
            StatusTextBlock.Text = "Tenants";
            FullNameColumn.Visibility = Visibility.Visible;
            LoginColumn.Visibility = Visibility.Visible;
            PasswordColumn.Visibility = Visibility.Visible;

            RentalNumberColumn.Visibility = Visibility.Hidden;
            AdressColumn.Visibility = Visibility.Hidden;
            TenantIdColumn.Visibility = Visibility.Hidden;
            RentalPremisesIdColumn.Visibility = Visibility.Hidden;
            UsersDataGreed.ItemsSource = _viewModels.GetTenants().ToBindingList();
        }
    }
}
