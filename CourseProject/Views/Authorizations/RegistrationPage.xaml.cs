using System;
using System.Collections.Generic;
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
using CourseProject.ViewModels;

namespace CourseProject.Views.Authorization
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void FullNameTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (FullNameTextBox.Text == "Full name" || FullNameTextBox.Text == string.Empty)
            {
                FullNameTextBox.Text = string.Empty;
            }
        }

        private void FullNameTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (FullNameTextBox.Text == "Full name" || FullNameTextBox.Text == string.Empty)
            {
                FullNameTextBox.Text = "Full name";
            }
        }

        private void LoginTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (LoginTextBox.Text == "Login" || LoginTextBox.Text == string.Empty)
            {
                LoginTextBox.Text = "Login";
            }
            else
            {
                if (AuthorizationViewModel.CheckLogin(LoginTextBox.Text))
                {
                    CheckLoginTextBox.Text = "Login is free";
                    CheckLoginTextBox.Foreground = new SolidColorBrush(Colors.Green);
                } else
                {
                    CheckLoginTextBox.Text = "Login is busy";
                    CheckLoginTextBox.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void LoginTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (LoginTextBox.Text == "Login" || LoginTextBox.Text == string.Empty)
            {
                LoginTextBox.Text = string.Empty;
            }

            CheckLoginTextBox.Text = string.Empty;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SignIpButton_Click(object sender, RoutedEventArgs e)
        {
            if (PaswordPB1.Password == PaswordPB2.Password && PaswordPB1.Password.Length > 4 && CheckLoginTextBox.Text == "Login is free" && FullNameTextBox.Text != "Full name")
            {
                AuthorizationViewModel.RegistrationUser(FullNameTextBox.Text, LoginTextBox.Text, PaswordPB1.Password);
                MessageBox.Show("User is registered!");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Incorrect password! Password must be the same and have more than 4 chars.");
                PaswordPB1.Password = string.Empty;
                PaswordPB2.Password = string.Empty;
            }
        }
    }
}
