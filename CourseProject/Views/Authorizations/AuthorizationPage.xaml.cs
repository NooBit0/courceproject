using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseProject.Models.Users;
using CourseProject.ViewModels;
using CourseProject.Views.Authorization;
using CourseProject.Views.UsersPages;
using CourseProject.Views.UsersPages.AdministratorPages;

namespace CourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        public AdministratorViewModel ViewModel { get; set; }

        private void LoginTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (LoginTextBox.Text == "Login" || LoginTextBox.Text == string.Empty)
            {
                LoginTextBox.Text = string.Empty;
            }
        }

        private void LoginTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
           if (LoginTextBox.Text == "Login" || LoginTextBox.Text == string.Empty)
            {
                LoginTextBox.Text = "Login";
            }
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            User user = ViewModels.AuthorizationViewModel.CheckAuthorization(LoginTextBox.Text, PaswordPB.Password);
            switch (user?.GetType().Name)
            {
                case "Administrator":
                    NavigationService.Navigate(new AdministratorPage(user.Login));
                    break;
                case "Accountant":
                    NavigationService.Navigate(new AccountantPage(user.Login));
                    break;
                case "Owner":
                    NavigationService.Navigate(new OwnerPages(user.Login));
                    break;
                case "Tenant":
                    NavigationService.Navigate(new TenantPage(user.Login));
                    break;
                default:
                    LoginTextBox.Text = "Login";
                    PaswordPB.Password = string.Empty;
                    MessageBox.Show("Authorisation Error");
                    break;
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
